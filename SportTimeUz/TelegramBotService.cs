using SportTime.BLL.Service;
using SportTime.DAL;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SportTimeUz.Server;

public class TelegramBotService
{
    private readonly TelegramBotClient _botClient;
    private readonly Dictionary<long, bool> _admins = new();
    private const string AdminPassword = "admin123"; // 🔑 Admin paroli

    private readonly MainContext _context;
    private readonly IStadiumService _stadiumService;
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;

    public TelegramBotService(MainContext context, IStadiumService stadiumService, IUserService userService, IAdminService adminService)
    {
        _botClient = new TelegramBotClient("8013798090:AAG6PywkTd1TFbV3ksVXjmUnql7YzctpCS4");
        LoadAdmins();

        var cts = new CancellationTokenSource();
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);
        Console.WriteLine("🤖 Bot ishga tushdi...");

        _context = context;
        _stadiumService = stadiumService;
        _userService = userService;
        _adminService = adminService;
    }

    [Obsolete]
    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;
        long chatId = message.Chat.Id;
        string text = message.Text ?? "";

        if (text == "/start")
        {
            await botClient.SendTextMessageAsync(chatId, "Assalomu alaykum! SportTime botiga xush kelibsiz!\n\n👤 Foydalanuvchi sifatida foydalanish uchun /user ni bosing.\n👑 Admin bo‘lish uchun /admin ni bosing.");
        }
        else if (text == "/admin")
        {
            await botClient.SendTextMessageAsync(chatId, "👑 Admin bo‘lish uchun parolni kiriting:");
        }
        else if (text == AdminPassword)
        {
            if (!_admins.ContainsKey(chatId))
            {
                _admins[chatId] = true;
                SaveAdmins();
                await botClient.SendTextMessageAsync(chatId, "✅ Siz admin bo‘ldingiz!\nAdmin panelga kirish uchun /menu ni bosing.");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId, "Siz allaqachon adminsiz! /menu ni bosing.");
            }
        }
        else if (text == "/menu" && _admins.ContainsKey(chatId) && _admins[chatId])
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton[] { "🏟 Stadion qo‘shish", "❌ Stadion o‘chirish" },
                new KeyboardButton[] { "🔄 Stadion yangilash", "📋 Zakazlar ro‘yxati" }
            })
            {
                ResizeKeyboard = true // Tugmalar ekranga mos tushadi
            };

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Quyidagi bo‘limlardan birini tanlang:",
                replyMarkup: replyKeyboard
            );
        }
        else if (text == "/user")
        {
            await botClient.SendTextMessageAsync(chatId, "👤 Foydalanuvchi sifatida foydalanishingiz mumkin.");
        }
        else if (_admins.ContainsKey(chatId) && _admins[chatId])
        {
            await botClient.SendTextMessageAsync(chatId, "👑 Admin paneliga xush kelibsiz! /menu ni bosing.");
        }
        else
        {
            await botClient.SendTextMessageAsync(chatId, "❌ Noto‘g‘ri buyruq yoki parol!");
        }
    }

    private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine($"❌ Xatolik: {exception.Message}");
        return Task.CompletedTask;
    }

    private void SaveAdmins()
    {
        File.WriteAllText("admins.json", JsonSerializer.Serialize(_admins));
    }

    private void LoadAdmins()
    {
        if (File.Exists("admins.json"))
        {
            _admins.Clear();
            var loadedAdmins = JsonSerializer.Deserialize<Dictionary<long, bool>>(File.ReadAllText("admins.json"));
            if (loadedAdmins != null)
            {
                foreach (var admin in loadedAdmins)
                {
                    _admins[admin.Key] = admin.Value;
                }
            }
        }
    }
}
