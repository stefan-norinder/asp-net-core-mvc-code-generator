using CodeGenerator.Lib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CodeGenerator.Console
{
    partial class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                                           .AddLogging();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection
                                    .AddLogging()
                                    .BuildServiceProvider();

            try
            {
                var controller = serviceProvider.GetService<IController>();
                //controller.Run();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error running service: " + ex.Message);
                throw ex;
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            System.Console.WriteLine("Initiating with ASPNETCORE_ENVIRONMENT " + environment);
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile($"appsettings.{environment}.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTransient<IController, Controller>();
        }
    }

}
