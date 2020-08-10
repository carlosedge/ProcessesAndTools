using DbToFile.Contract.Models;
using System.Collections.Generic;

namespace DbToFile.Contract.Interfaces
{
    /// <summary>
    /// Provides an service for write table contents into files.
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Appends to an existing file
        /// </summary>
        /// <param name="tableContent">List of tables</param>
        /// <param name="fileNameAndPath">File name and path</param>
        void AppendToFile(List<DbTableContent> tableContent, string fileNameAndPath);
    }
}
