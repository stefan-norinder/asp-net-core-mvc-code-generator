using CodeGenerator.Lib.DataAccess;
using CodeGenerator.Lib.Factories;
using CodeGenerator.Lib.Models;
using CodeGenerator.Lib.Services;
using CodeGenerator.Lib.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

    {ParamsConstants.Namespace}         Namespace of the code to generate.
    {ParamsConstants.Server}            Server that hosts the database of which your code should be based.
    {ParamsConstants.DataSource}        Database of which your code should be based. 
                        Note that all tables must contain a column named `Id` with datatype `int`. 
                        It must not be a identity column.

    {ParamsConstants.IdentifierType}            (optional) `Integer` (default) or `Guid`
    {ParamsConstants.Output}            (optional) Destination of the generated code. Default folder is ./src.
    {ParamsConstants.GeneratorTypes}    (optional) Decides what should be generated. Provide one or more of the following values: 
                        {string.Join("\r\n\t\t\t", allCodeGeneratorTypes)} (default)
                                        
Example: .\CodeGenerator.Console.exe {ParamsConstants.Namespace} MyApplication {ParamsConstants.Server} .\sqlexpress {ParamsConstants.DataSource}  MyDatabase {ParamsConstants.GeneratorTypes} DataAccess Services Models 
");
                return;
            }
            var identifierType = "Integer";
            if(args.Length > 10) identifierType = args[10];

            ConfigureServices(serviceCollection, identifierType);

            var serviceProvider = serviceCollection
                                    .AddLogging()
                                    .BuildServiceProvider();

            var controller = serviceProvider.GetService<IController>();
            controller.Run(args);
        }

        #region private

        private static void ConfigureServices(IServiceCollection serviceCollection, string identifierType)
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
            serviceCollection.AddSingleton(new IdentifierTypeService(identifierType));

            serviceCollection.AddLogging(configure => configure.AddConsole());
        }

        #endregion
    }

}
