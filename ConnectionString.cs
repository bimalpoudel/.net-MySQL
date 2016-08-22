using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTest
{
    class ConnectionString
    {
        private string HOSTNAME = "localhost";
        private string DATABASE = "DATABASE";
        private string USERNAME = "USERNAME";
        private string PASSWORD = "PASSWORD";

        public ConnectionString()
        {
            // odbc
            // dsn
            // native
        }

        public override string ToString()
        {
            //"DRIVER={MySQL ODBC 5.3 Unicode Driver};SERVER=localhost;DATABASE=DATABASE;UID=admin;PASSWORD=PASSWORD;OPTION=3";
            //"DSN=mysql64;SERVER=localhost;DATABASE=DATABASE;UID=USERNAME;PASSWORD=PASSWORD;OPTION=3";
            string ConnectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", this.HOSTNAME, this.DATABASE, this.USERNAME, this.PASSWORD);
            return ConnectionString;
        }
    }
}
