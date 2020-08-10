using DbToFile.Contract.Interfaces;
using DbToFile.SqlServer;
using DbToFileTool.BusinessLogic;
using DbToFileTool.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbToFileTool
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            DbToFileConfig fileConfig = new DbToFileConfig();
            config.GetSection("DbToFileConfig").Bind(fileConfig);

            RegisterServices(fileConfig);
            LaunchProcessor(fileConfig);
        }

        private static void RegisterServices(DbToFileConfig fileConfig)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IDatabaseExtractor>(x => new SqlServerExtractor(fileConfig.ConnectionString));
            services.AddSingleton<IFileWriterFactory, FileWriterFactory>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void LaunchProcessor(DbToFileConfig fileConfig)
        {
            IDatabaseExtractor databaseExtractor = _serviceProvider.GetService<IDatabaseExtractor>();
            IFileWriter fileWriter = _serviceProvider.GetService<IFileWriterFactory>().Create(fileConfig.OutputFormat);
            var processor = new Processor(databaseExtractor, fileWriter);
            processor.Process(fileConfig.TableGroups, fileConfig.FileOutputName);
        }
    }
}
