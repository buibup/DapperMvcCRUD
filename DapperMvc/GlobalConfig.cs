using DapperMvc.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using static DapperMvc.Enums;

namespace DapperMvc
{
    public class GlobalConfig
    {
        public static IDataConnection Connection { get; set; }

        public static void InitializeConnections(DataBaseType db)
        {
            if(db == DataBaseType.MySql)
            {
                var mySql = new MySqlConnector();
                Connection = mySql;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}