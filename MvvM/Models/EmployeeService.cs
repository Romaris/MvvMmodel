using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvvM.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeesList;

        public EmployeeService()
        {
            ObjEmployeesList = new List<Employee>()
            {
                new Employee{ Id = 101, Name = "Rami", Age=28}
            }; 
        }

        public List<Employee> GetAll() 
        {
            return ObjEmployeesList;
        }

        public bool Add(Employee objNewEmployee)
        {
            //Age must be between 21 and 58
            if (objNewEmployee.Age < 21 && objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit for employee");
            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == objNewEmployee.Id)
                    throw new ArgumentException($" Id {objNewEmployee.Id} already exsits");
            }
            //Add employee and return true
            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objEmployeeToUpdate) {
            bool isUpdated = false;
            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == objEmployeeToUpdate.Id) 
                {
                    ObjEmployeesList[index].Name = objEmployeeToUpdate.Name;
                    ObjEmployeesList[index].Age = objEmployeeToUpdate.Age;
                    isUpdated = true;
                    break;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id) {
            bool isDeleted = false;
            for (int index = 0; index < ObjEmployeesList.Count; index++)
            {
                if (ObjEmployeesList[index].Id == id )
                {
                    ObjEmployeesList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;

        }

        public Employee Search(int id) 
        {
            return ObjEmployeesList.FirstOrDefault(e => e.Id == id);
        }

    }
}
