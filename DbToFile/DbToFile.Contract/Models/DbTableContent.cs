using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DbToFile.Contract.Models
{
    public class DbTableContent
    {
        public string TableName { get; set; }
        public DataTable Data { get; set; }

    }
}
