using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EmpProgram.DataAccess;

namespace EmpProgram.Business
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
       
        public DataTable ReadEmployee()
        {
            return EmployeeDB.ReadEmployee();
        }
        public bool SaveEmployee(Employee emp)
        {
           return EmployeeDB.SaveEmployees(emp);
        }

        public bool UpdateEmployee(Employee emp)
        {
            return EmployeeDB.UpdateEmployee(emp);
        }
        public bool DeleteEmployee(Employee emp)
        {
            return EmployeeDB.DeleteEmployee(emp);
        }
        public DataTable SearchEmployee(int id)
        {
            return EmployeeDB.SearchEmployees(id);
        }
    }
}
