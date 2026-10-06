using EFCoreRelationsHw.Data;
using EFCoreRelationsHw.Menu;
using EFCoreRelationsHw.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreRelationsHw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<MoviesContext>(options =>
                options.UseSqlServer("Server=localhost;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True;"));

            services.AddScoped<UserService>();
            services.AddScoped<MovieService>();
            services.AddScoped<MainMenu>();

            var provider = services.BuildServiceProvider();

            var menu = provider.GetRequiredService<MainMenu>();
            menu.Show();
        }
    }
}
