using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            var allCodeGeneratorTypes = Enum.GetValues(typeof(CodeGeneratorTypes)).Cast<CodeGeneratorTypes>().Select(x => x.ToString());

            if (args == null || args.Length == 0)
            {
                System.Console.WriteLine("Please provide parameters. For help, pass --help");
                return;
            }
            if (args.First() == "--help")
            {
                System.Console.WriteLine(@$"
Help for dot-net-mvc-code-generator

The following parameters can be pass to the application:

    {ParamsConstants.Namespace}         Namespace of the code to generate
    {ParamsConstants.Server}            Server that hosts the database of which your code should be based
    {ParamsConstants.DataSource}        Dtabase of which your code should be based. 
                        Note that all tables must contain a column named `Id` with datatype `int`. 
                        It must not be a identity column
    {ParamsConstants.GeneratorTypes}    (optional) decides what should be generated. Provide one or more of the following values: 
                        {string.Join("\r\n\t\t\t", allCodeGeneratorTypes)} (default)
                                        
Example: .\CodeGenerator.Console.exe {ParamsConstants.Namespace} MyApplication {ParamsConstants.Server} .\sqlexpress {ParamsConstants.DataSource}  MyDatabase {ParamsConstants.GeneratorTypes} DataAccess Services Models 
");
                return;
            }

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection
                                    .AddLogging()
                                    .BuildServiceProvider();

            try
            {
                var controller = serviceProvider.GetService<IController>();
                controller.Run(args);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error running service: " + ex.Message);
                throw;
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
            serviceCollection.AddTransient<IDataAccess, DataAccess>();
        }
    }

}
