using DbToFile.Contract.Interfaces;
using DbToFile.Contract.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbToFileTool
{
    internal class Processor
    {
        private readonly IDatabaseExtractor _databaseExtractor;
        private readonly IFileWriter _fileWriter;

        public Processor(IDatabaseExtractor databaseExtractor, IFileWriter fileWriter)
        {
            _databaseExtractor = databaseExtractor ?? throw new ArgumentNullException(nameof(databaseExtractor));
            _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        }

        public void Process(List<TableGroup> tableGroups, string fileNameAndPath)
        {
            var tableData = new List<DbTableContent>();
            foreach (TableGroup tableGroup in tableGroups)
            {
                tableData.AddRange(_databaseExtractor.ExtractTable(tableGroup));
            }

            _fileWriter.AppendToFile(tableData, fileNameAndPath);
        }
    }
}
