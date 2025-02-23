using Microsoft.EntityFrameworkCore;
using SportTime.DAL;

namespace SportTimeUz
{
    public static class DataBaseConfiguration
    {
        public static void ConfigureDataBase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DataBaseConnection");

            builder.Services.AddDbContext<MainContext>
                (b => b.UseSqlServer(connectionString));
        }
    }
}
