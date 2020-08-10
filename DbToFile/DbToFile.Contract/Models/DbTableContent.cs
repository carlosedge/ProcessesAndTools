using System.Data;

namespace DbToFile.Contract.Models
{
    public class DbTableContent
    {
        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the table data in <see cref="DataTable"/> format.
        /// </summary>
        public DataTable Data { get; set; }
    }
}
