using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmpProgram.DataAccess
{
   public static class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {
            //datasource = ?? it is server name 
            //database = ?? it is database name that we want to conect to that for example in 
            //our project I put table employees in the sample DB, so I want to connect to Sample DB
            //Integrated security it shows how I want to connect to Database 
            //by windows authentication if I put SSPI
            SqlConnection ConnDB = new SqlConnection("data source= . ; database=sample ; Integrated Security = SSPI");
           // SqlConnection con = new SqlConnection("data source= . ; database=sample ; user=sa; password=123");
            ConnDB.Open();
            return ConnDB;
        }
    }
}
