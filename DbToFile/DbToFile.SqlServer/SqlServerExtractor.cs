using DbToFile.Contract.Interfaces;
using DbToFile.Contract.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DbToFile.SqlServer
{
    public class SqlServerExtractor : IDatabaseExtractor
    {
        private readonly SqlConnection _connection;
        const string PkReplace = "%";

        public SqlServerExtractor(string connectionString)
        {            
            _connection = new SqlConnection(connectionString);
        }

        ~SqlServerExtractor()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }    
        }

        public List<DbTableContent> ExtractTable(TableGroup tableGroup)
        {
            List<DbTableContent> dataTableList = new List<DbTableContent>();

            foreach (string tableName in tableGroup.TableNames)
            {
                string query = BuildSqlQuery(tableName, tableGroup.PkName, tableGroup.TableColumns, tableGroup.Where);
                SqlCommand command = new SqlCommand(query, _connection);
                command.Connection.Open();
                SqlDataReader result = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(result);
                dataTableList.Add(new DbTableContent{TableName = tableName, Data = dt);
            }
            return dataTableList;
        }

        private string BuildSqlQuery(string tableName, string pkName, List<string> tableColumns, string where)
        {
            string pkNameFormated = pkName.Replace(PkReplace, tableName);
            string columns = string.Join(",", tableColumns.ToArray());

            return ($"SELECT {pkNameFormated},{columns} FROM {tableName} WHERE {where}");
        }
    }
}
