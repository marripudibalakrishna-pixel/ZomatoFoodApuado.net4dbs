using System;
using Microsoft.Data.SqlClient;

namespace ZomatoFoodApi_Entities.Interfaces
{

        public interface IConnectionFactory
        {
            public SqlConnection MidLandSqlConnectionString();
            public SqlConnection Northwind_DBSqlConnectionString();
            public SqlConnection HotelmanagementsqlConnectionString();

        }
    }


