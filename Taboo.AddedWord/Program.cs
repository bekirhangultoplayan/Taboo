using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taboo.Entity.DataTransfer.Storage;

namespace Taboo.AddedWord
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //.AddJsonFile($"appsettings.{​​​​​​environmentName}​​​​​​.json", optional: true, reloadOnChange: true);

            var configuration = configurationBuilder.Build();
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                    
                   services.AddSingleton<Form1>();

                   Taboo.Business.ServiceConfiguration.DependencyConfiguration.ConfigureServices(services);
                   services.AddDbContext<DataTransferStorageDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

                   //services.AddSingleton<IHttpClientFactory, HttpClientFactory>();

               });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var form = services.GetRequiredService<Form1>();
                    Application.Run(form);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Occured " + e);
                }
            } 
           
        }
    }
}