using DbToFile.Contract.Interfaces;
using FileLoader.Excel;
using System;

namespace DbToFileTool.BusinessLogic
{
    internal class FileWriterFactory : IFileWriterFactory
    {
        public IFileWriter Create(string fileType)
        {
            if (fileType == "excel")
            {
                return new ExcelWriter();
            }
            throw new InvalidOperationException($"File writer for {fileType} not available ");
        }
    }
}
