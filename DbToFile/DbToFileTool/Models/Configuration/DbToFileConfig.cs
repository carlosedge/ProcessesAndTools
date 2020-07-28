using System;
using System.Collections.Generic;
using System.Text;

namespace DbToFileTool.Models.Configuration
{
    public class DbToFileConfig
    {
        /// <summary>
        /// Gets or sets the connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the table groups
        /// </summary>
        public List<TableGroup> TableGroups { get; set; }

        /// <summary>
        /// Gets or sets the file output name
        /// </summary>
        public string FileOutputName { get; set; }

        /// <summary>
        /// Gets or sets the output format
        /// </summary>
        public string OutputFormat { get; set; }
    }
}
