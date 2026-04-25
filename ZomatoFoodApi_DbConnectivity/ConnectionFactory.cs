using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using ZomatoFoodApi_Entities.Interfaces;
using ZomatoFoodApi_Entities.Utils;



namespace ZomatoFoodApi_DbConnectivity
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        //inject the IConfiguration interface in the constructor of the connection factory class and assign it to the private readonly field of the IConfiguration interface type.
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection HotelmanagementsqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Hotelmanagement_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection MidLandSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Midland_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection Northwind_DBSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Northwind_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public SqlConnection RestaurantDBSqlConnectionString()
        {
            var connectionString = Convert.ToString(_configuration.GetSection(ConnectionStringNames.Restaurant_DBConnectionstringname).Value);
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }


}
