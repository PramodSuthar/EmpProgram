using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EmpProgram.Business;

namespace EmpProgram.DataAccess
{
   public static class EmployeeDB
    {
        public static SqlConnection connDb = UtilityDB.ConnectDB();
        public static SqlCommand cmd = new SqlCommand();
        public static DataTable ReadEmployee()
        {
            if (connDb.State == ConnectionState.Closed)
            {
                connDb = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }
            cmd.Connection = connDb;
            cmd.CommandText = "select * from employees";
             SqlDataReader reader=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            // remove any resources managed from memory for clean up 
            cmd.Dispose();
            connDb.Close();
            return dt;

        }
        public  static bool SaveEmployees(Employee emp)
        {
            //var result = true;
            try
            {
                if(connDb.State == ConnectionState.Closed)
                {
                    connDb = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }
                
                cmd.Connection = connDb;
                cmd.CommandText = string.Format("insert into Employees (EmployeeId ,FirstName , LastName , JobTitle) values ({0}, '{1}','{2}','{3}') ", emp.EmployeeId, emp.FirstName, emp.LastName, emp.JobTitle);
                cmd.ExecuteNonQuery();
                //close connection 
                connDb.Close();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.Write(ex.Message);
                return false;
                // result = false;
                //throw;
            }
           
        }
        public static bool UpdateEmployee(Employee emp )
        {
            try
            {
                if (connDb.State == ConnectionState.Closed)
                {
                    connDb = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }
                cmd.Connection = connDb;
                cmd.CommandText = string.Format("update employees set firstName='{0}' ,lastName='{1}' , jobTitle='{2}' where EmployeeId={3} ", emp.FirstName, emp.LastName, emp.JobTitle, emp.EmployeeId);
                cmd.ExecuteNonQuery();
                connDb.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }            

        }

        public static bool DeleteEmployee(Employee emp)
        {
            try
            {
                if (connDb.State == ConnectionState.Closed)
                {
                    connDb = UtilityDB.ConnectDB();
                    cmd = new SqlCommand();
                }
                cmd.Connection = connDb;
                cmd.CommandText = "delete from employees where employeeId =" + emp.EmployeeId ;
                cmd.ExecuteNonQuery();
                connDb.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }

        }
         public static DataTable SearchEmployees(int id)
        {
            if(connDb.State == ConnectionState.Closed)
            {
                connDb = UtilityDB.ConnectDB();
                cmd = new SqlCommand();
            }
            cmd.Connection = connDb;
            cmd.CommandText = "select * from employees where employeeId=" + id;
            SqlDataReader reader= cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cmd.Dispose();
            connDb.Close();
            return dt;
        }

    }
}
