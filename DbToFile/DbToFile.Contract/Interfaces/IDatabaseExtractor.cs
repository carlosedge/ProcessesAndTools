using DbToFile.Contract.Models;
using System.Collections.Generic;

namespace DbToFile.Contract.Interfaces
{
    /// <summary>
    /// Represents an extraction service for database information stored in tables.
    /// </summary>
    public interface IDatabaseExtractor
    {
        /// <summary>
        /// Extracts a list of tables into a list of <see cref="DbTableContent" />
        /// </summary>
        /// <param name="tableGroup">Extraction strategy to apply </param>
        /// <returns>Ennumerable of <see cref="DbTableContent".</returns>
        IEnumerable<DbTableContent> ExtractTable(TableGroup tableGroup);
    }
}
