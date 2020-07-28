using DbToFile.Contract.Models;
using System.Collections.Generic;

namespace DbToFile.Contract.Interfaces
{
    public interface IDatabaseExtractor
    {
        List<DbTableContent> ExtractTable(TableGroup tableGroup);
    }
}
