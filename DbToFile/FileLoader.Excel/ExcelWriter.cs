using DbToFile.Contract.Interfaces;
using DbToFile.Contract.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileLoader.Excel
{
    public class ExcelWriter : IFileWriter
    {
        private readonly XSSFWorkbook _workbook;
        public ExcelWriter()        
        {            
            _workbook = new XSSFWorkbook();
        }

        public void AppendToFile(List<DbTableContent> dataSetList, string fileNameAndPath)
        {
            FileStream _fs = new FileStream(fileNameAndPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

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
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            _workbook.Write(_fs);
            _workbook.Close();
        }
    }
}
