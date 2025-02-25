using SportTime.BLL.Service;
using SportTime.DAL;
using SportTime.Repository.Service;
using SportTimeUz;
using SportTimeUz.Server;
using SportTimeUz.Server.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Bot xizmatini ro‘yxatdan o‘tkazish
builder.Services.AddScoped<TelegramBotService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MainContext>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStadiumService, StadiumService>();
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();


builder.ConfigureDataBase();

var app = builder.Build();

// Telegram bot xizmatini ishga tushirish
using (var scope = app.Services.CreateScope())
{
    var botService = scope.ServiceProvider.GetRequiredService<TelegramBotService>();
    // botService.Start() yoki boshqa ishlarni qilishingiz mumkin
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();