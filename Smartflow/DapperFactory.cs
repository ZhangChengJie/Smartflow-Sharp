﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Smartflow.Enums;

namespace Smartflow
{
    public class DapperFactory
    {
        public static IDbConnection CreateWorkflowConnection()
        {
            SmartflowConfigHandle config = ConfigurationManager.GetSection("smartflowConfig") as SmartflowConfigHandle;
            DatabaseCategory dbc;
            if (Enum.TryParse(config.DatabaseCategory, out dbc) || String.IsNullOrEmpty(config.ConnectionString))
            {
                return DapperFactory.CreateConnection(dbc, config.ConnectionString);
            }
            else
            {
                throw new Exception("请检查数据库连接配置");
            }
        }

        public static IDbConnection CreateConnection(DatabaseCategory dbc, string connectionString)
        {
            IDbConnection connection = null;
            switch (dbc)
            {
                case DatabaseCategory.SQLServer:
                    connection = DatabaseService.CreateInstance(new SqlConnection(connectionString));
                    break;
                case DatabaseCategory.Oracle:
                    connection = DatabaseService.CreateInstance(new SqlConnection(connectionString));
                    break;
                case DatabaseCategory.MySQL:
                    connection = DatabaseService.CreateInstance(new SqlConnection(connectionString));
                    break;
            }
            return connection;
        }
    }
}
