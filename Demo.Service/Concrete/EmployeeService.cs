using Demo.DataModel.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Concrete
{    
     public class EmployeeService
    {
        private readonly List<Employee> employees;
        private readonly List<Department> departments;
        public EmployeeService()
        {

            employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Age = 28, Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane", Age = 32, Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Jim", Age = 22, Department = "IT", Salary = 55000 },
            new Employee { Id = 4, Name = "Jake", Age = 45, Department = "HR", Salary = 70000 },
            new Employee { Id = 5, Name = "Jill", Age = 36, Department = "Finance", Salary = 75000 },
            new Employee { Id = 6, Name = "Jack", Age = 29, Department = "Finance", Salary = 67000 },
            new Employee { Id = 7, Name = "Jerry", Age = 50, Department = "IT", Salary = 80000 },
            new Employee { Id = 8, Name = "Joan", Age = 38, Department = "Marketing", Salary = 72000 },
    new Employee { Id = 9, Name = "James", Age = 27, Department = "Marketing", Salary = 48000 },
    new Employee { Id = 10, Name = "Jordan", Age = 33, Department = "Sales", Salary = 55000 },
    new Employee { Id = 11, Name = "Janet", Age = 41, Department = "Sales", Salary = 68000 },
    new Employee { Id = 12, Name = "Jake", Age = 29, Department = "Finance", Salary = 66000 },
    new Employee { Id = 13, Name = "Jasmine", Age = 37, Department = "HR", Salary = 72000 },
    new Employee { Id = 14, Name = "Jason", Age = 26, Department = "IT", Salary = 52000 },
    new Employee { Id = 15, Name = "Jimena", Age = 32, Department = "HR", Salary = 69000 },
    new Employee { Id = 16, Name = "Joel", Age = 40, Department = "Marketing", Salary = 74000 },
    new Employee { Id = 17, Name = "Jeff", Age = 48, Department = "Sales", Salary = 80000 }
        };

            departments = new List<Department>
        {
            new Department { Name = "HR", Location = "Building A" },
            new Department { Name = "IT", Location = "Building B" },
            new Department { Name = "Finance", Location = "Building C" }
        };


        }

        public IEnumerable<Employee> GetEmployeesOlderThan(int age)
        {
            return from emp in employees 
                   where emp.Age > age
                   select emp;
        }

        public IEnumerable<dynamic> GetEmployeeDepartments ()
        {
            var res = from e in employees
                      join d in departments
                      on e.Department equals d.Name
                      select new
                      {
                          e.Name,
                          e.Salary,
                          e.Department,
                          e.Age,
                          d.Location,
                      };

            return res;
        }

        public IEnumerable<IGrouping<string, Employee>> GetEmployeesGroupedByDepartment()
        {
            return from e in employees
                   group e by e.Department into depGroup
                   select depGroup;
        }


        public Employee HighestPaidEmployee()
        {
            var res = (from e in employees
                      orderby e.Salary descending
                      select e).FirstOrDefault();
            return res;
        }

        public Employee SecondHighestSalary ()
        {
            var res = (from e in employees
                       orderby e.Salary descending
                       select e).Skip(1).FirstOrDefault();

            return res;
        }

        public List<Employee> GetEmployeesWithSalaryGreaterThan(int salary)
        {

            var res = (from e in employees
                       where e.Salary > salary
                       orderby e.Age 
                       select e).ToList();
            return res;
        }

        public List<EmployeeDepartmentInfoVm> GetEmployeeAndDepartment ()
        {
            var res = (from e in employees
                      join d in departments
                      on e.Department equals d.Name
                      select new EmployeeDepartmentInfoVm
                      {
                        Name = e.Name,
                         Department =  e.Department,
                         Location = d.Location,
                      }).ToList();

            
            return res;
            
        }

        public List<GetAverageSalryByDepartmentVm> GetAverageSalryByDepartment()
        {
            var res = (from e in employees
                       group e by e.Department into departmentGroup
                       select new GetAverageSalryByDepartmentVm
                       {
                           Department = departmentGroup.Key,
                           Salary = departmentGroup.Average(e => e.Salary)

                       }
                       ).ToList();
            return res;
        }

        public List<EmployeeDepartmentInfoVm> EmployeeInCertainBuiling ()
        {
            var res = from e in employees
                      join d in departments
                      on e.Department equals d.Name
                      where d.Location == "Building A" || d.Location == "Building B"
                      select new EmployeeDepartmentInfoVm
                      {
                          Name = e.Name,
                          Department = e.Department,
                          Location = d.Location,
                      };

            return res.ToList();
        }

        public List<GetAverageSalryByDepartmentVm> TotalSalaryByDepartment ()
        {
            var res = from e in employees
                      group e by e.Department into departmentGroup
                      select new GetAverageSalryByDepartmentVm
                      {
                          Department = departmentGroup.Key,
                          Salary = departmentGroup.Sum(e => e.Salary)
                      };
            return res.ToList();
        }

        public List<HighEarnerDetailVm> GetHighEarnersWithDetails()
        {
            var res = (from e in employees
                       join d in departments
                       on e.Department equals d.Name
                       where e.Salary >  60000
                       orderby e.Age 
                       select new HighEarnerDetailVm
                       {
                           Id = e.Id,
                           Name = e.Name,
                           Age = e.Age,
                           DepartmentName = e.Department,
                           Salary = e.Salary,
                           Location = d.Location,
                       }).ToList();
            return res;
        }

        public List<Employee> GetEmployeeByDepartmetHighestSalary ()
        {
            var res = from e in employees
                      group e by e.Department into departmentGroup

                      select new GetAverageSalryByDepartmentVm
                      {
                          Department = departmentGroup.Key,
                          Salary = departmentGroup.Sum(x => x.Salary)
                      };

            var highestSalaryByDepartment = (from e in res
                                             orderby e.Salary descending
                                             select new Employee
                                             {
                                                 Department = e.Department,
                                                 Salary = e.Salary,
                                             }).FirstOrDefault();

            var emp = from e in employees
                      where e.Department == highestSalaryByDepartment.Department
                      select e;

            return emp.ToList();
        }




        public List<Employee> AvgAgeByDeptWithHighSalary()
        {
            var res = from e in employees
                      group e by e.Department into ageGroup
                      let aveSalary = ageGroup.Average(x => x.Salary)
                      where aveSalary > 60000
                      select new Employee
                      {
                          Department = ageGroup.Key,
                          Age = (int)ageGroup.Average(a => a.Age)
                          
                      };                                         

           return res.ToList();

                      
        }

        public List<Employee> GetSalaryByEmployeeDepartment()
        {
            var res = (from e in employees
                       where e.Name == "John" && e.Age == 28
                       select new Employee
                       {
                           Department = e.Department
                       }).FirstOrDefault();

            var employeesInJohnsDept = from e in employees
                                       where e.Department == res.Department
                                       orderby e.Salary descending
                                       select new Employee
                                       {
                                           Name = e.Name,
                                           Salary = e.Salary
                                       };


            return employeesInJohnsDept.ToList();
        }


        public List<Employee> TotalSalaryInBuilding()
        {
            var res = from e in employees
                      join d in departments on e.Department equals d.Name
                      where d.Location == "Building A" || d.Location == "Building C"
                      group e by e.Department into g
                      select new Employee
                      {
                          Department = g.Key,
                          Salary = g.Sum(s => s.Salary)
                      };

            var orderByDecending = from e in res
                                   orderby e.Salary descending
                                   select e;

            return orderByDecending.ToList();


        }


        public List<Employee> AverageAgeInFinance()
        {
            var averageAgeInFinance = (from e in employees
                                      where e.Department == "Finance" 
                                      select e.Age).Average();

            var res = from e in employees
                      where e.Department == "Finance" && e.Age < averageAgeInFinance
                      select new Employee
                      {
                          Name = e.Name,
                          Department = e.Department,
                          Salary = e.Salary,
                      };
            return res.ToList();
        }

        public List<Employee> OverallAverageSalary()
        {
            var overallAverageSalary = (from e in employees
                                        select e.Salary).Average();

            var res = (from e in employees
                      group e by e.Department into depGroup
                      where depGroup.Average(e => e.Salary) > overallAverageSalary
                       select new Employee
                      {
                          Department = depGroup.Key,
                      });
            return res.ToList();
        }

        public class HighEarnerDetailVm
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string DepartmentName { get; set; }
            public double Salary { get; set; }
            public string Location { get; set; }
        }


        public class EmployeeDepartmentInfoVm
        {
            public string Name { get; set; }
            public string Department { get; set; }

            public string Location { get; set; }
        }

        public class GetAverageSalryByDepartmentVm
        {
            public double Salary { get; set; }

            public string Department { get; set; }

        }
    }
}
