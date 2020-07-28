using DbToFileTool.Models.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace DbToFileTool
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            DbToFileConfig fileConfig = new DbToFileConfig();
            config.GetSection("DbToFileConfig").Bind(fileConfig);

            Console.WriteLine("Database to File Tool");
        }
    }
}
