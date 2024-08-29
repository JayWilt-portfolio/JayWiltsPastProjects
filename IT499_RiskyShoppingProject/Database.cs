using System;
using System.Data.SqlClient;

namespace IT499_RiskyShoppingProject
{
    public static class Database
    {
        private const string ConnectionString = "Data Source=K2107N0117911\\SQLEXPRESS;Initial Catalog=RiskyBusinessShop;User Id=RiskyCEO;Password=password1; Integrated Security=False;";


        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
