using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouLend.WebAPI.Data;

namespace YouLend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Find the service layer in scope
            using (var scope = host.Services.CreateScope())
            {
                //Get the WebApiContext in service
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WebAPIContext>();

                //Call LoanSeeder to create sample data
                LoanSeeder.Initialize(services);
            }

            //Continue to run
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
