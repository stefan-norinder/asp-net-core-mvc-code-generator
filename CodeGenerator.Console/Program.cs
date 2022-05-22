using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace CodeGenerator.Console
{
    partial class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                                           .AddLogging();

            if (args == null || args.Length == 0)
            {
                System.Console.WriteLine("Please provide parameters. For help, pass --help");
                return;
            }
            if (args.First() == "--help")
            {
                System.Console.WriteLine(
@$"
Help for dot-net-mvc-code-generator

The following parameters can be pass to the application:

    {ParamsConstants.Namespace}    namespace of the code to generate
    {ParamsConstants.Class}        entity name of the code to generate
    {ParamsConstants.Properies}    pair of strings representing properties to generate for enteties

Example: .\CodeGenerator.Console.exe --namespace MyApplication --class Person --properties Name string Age int
");
                return;
            }

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection
                                    .AddLogging()
                                    .BuildServiceProvider();

            try
            {
                var paramsModel = new ParamsModel(args);
                var controller = serviceProvider.GetService<IController>();
                controller.Run(CodeGeneratorTypes.Models,CodeGeneratorFetcherTypes.FromString, paramsModel.Namespace, paramsModel.ClassName, paramsModel.Properties);
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
                //.AddJsonFile($"appsettings.{environment}.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTransient<IController, Controller>();
            serviceCollection.AddTransient<ICodeGeneratorFactory, CodeGeneratorFactory>();
            serviceCollection.AddTransient<IOutputAdapter, FileWriterOutputAdapter>();
        }
    }

}
