using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var _db = services.GetRequiredService<AppStore>();
                    List<Client> check = _db.Clients.ToList();

                    if (check.Count() == 0)
                    {
                        var dbInitializer = services.GetRequiredService<IInitialClientService>();
                        dbInitializer.Initialize(_db).GetAwaiter().GetResult();//Buna Bax

                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogWarning("The Program Database is null");
                    }
                }
                catch (Exception problem)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(problem, "An error occurred while seeding the database");
                }
                //finally
                //{
                //    var logger = services.GetRequiredService<ILogger<Program>>();
                //    logger.LogError("An error occurred while seeding the database");
                //}

            }
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
