using System;
using System.Collections.Generic;
using System.Text;

namespace DbToFile.Contract.Models
{
    public class TableGroup
    {
        /// <summary>
        /// Gets or sets the table names included in the group
        /// </summary>
        public List<string> TableNames { get; set; }

        /// <summary>
        /// Gets or sets the primary key name
        /// </summary>
        public string PkName { get; set; }

        /// <summary>
        /// Gets or sets the table columns to retrieve
        /// </summary>
        public List<string> TableColumns { get; set; }

        /// <summary>
        /// Gets pr sets the optional where clause
        /// </summary>
        public string Where { get; set; }
    }
}
