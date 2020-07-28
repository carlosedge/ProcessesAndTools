using DbToFile.Contract.Interfaces;
using DbToFile.Contract.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileLoader.Excel
{
    public class ExcelLoader : IFileLoader
    {
        private readonly XSSFWorkbook _workbook;
        private readonly FileStream _fs;
        public ExcelLoader(string filePath)
        {
            _fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _workbook = new XSSFWorkbook();
        }

        public void AppendToFile(List<DbTableContent> dataSetList, string name)
        {
            foreach (DbTableContent dataContent in dataSetList)
            {
                try
                {
                    var sheet = _workbook.CreateSheet(dataContent.TableName);                    
                    
                    IRow row = sheet.CreateRow(0);
                    for (var j = 0; j < dataContent.Data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(dataContent.Data.Columns[j].ColumnName);
                    }
                    var count = 1;

                    for (var i = 0; i < dataContent.Data.Rows.Count; ++i)
                    {
                        row = sheet.CreateRow(count);
                        for (var j = 0; j < dataContent.Data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(dataContent.Data.Rows[i][j].ToString());
                        }
                        ++count;
                    }
                    _workbook.Write(_fs); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}
