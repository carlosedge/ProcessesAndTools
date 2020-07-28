using DbToFile.Contract.Models;
using System.Collections.Generic;

namespace DbToFile.Contract.Interfaces
{
    public interface IFileLoader
    {
        void AppendToFile(List<DbTableContent> tableContent, string name);
    }
}
