using Demo.DataModel.Data.Entities;
using Demo.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> GetEmployeesOlderThan (int age)
        {
            return _employeeService.GetEmployeesOlderThan(age);
        }
        [Route("GetEmployeeDepartments")]
        [HttpGet]
        public IEnumerable<dynamic> GetEmployeeDepartments ()
        {
            return _employeeService.GetEmployeeDepartments();
        }


        [Route("GetEmployeesGroupedByDepartment")]
        [HttpGet]
        public IEnumerable<dynamic> GetEmployeesGroupedByDepartment ()
        {
            return _employeeService.GetEmployeesGroupedByDepartment();
        }

        [Route("HighestPaidEmployee")]
        [HttpGet]
        public IActionResult HighestPaidEmployee()
        {
            var res =  _employeeService.HighestPaidEmployee();
            return Ok(res);
        }

        [Route("SecondHighestSalary")]
        [HttpGet]
        public IActionResult SecondHighestSalary()
        {
            var res = _employeeService.SecondHighestSalary();
            return Ok(res);
        }

        [Route("GetEmployeesWithSalaryGreaterThan")]
        [HttpGet]

        public IActionResult GetEmployeesWithSalaryGreaterThan(int salary)
        {
            var res = _employeeService.GetEmployeesWithSalaryGreaterThan(salary);
            return Ok(res);
        }

        [Route ("GetEmployeeAndDepartment")]
        [HttpGet]

        public IActionResult GetEmployeeAndDepartment()
        {
            var res = _employeeService.GetEmployeeAndDepartment();
            return Ok(res);
        }


        [Route("GetAverageSalryByDepartment")]
        [HttpGet]
        public IActionResult GetAverageSalryByDepartment ()
        {
            var res = _employeeService.GetAverageSalryByDepartment();
            return Ok(res);
        }

        [Route("EmployeeInCertainBuiling")]
        [HttpGet]
        public IActionResult EmployeeInCertainBuiling ()
        {
            var res = _employeeService.EmployeeInCertainBuiling();
            return Ok(res);
        }

        [Route("TotalSalaryByDepartment")]
        [HttpGet]

        public IActionResult TotalSalaryByDepartment ()
        {
            var res = _employeeService.TotalSalaryByDepartment();
            return Ok(res);
        }

        [Route("GetHighEarnersWithDetails")]
        [HttpGet]
        public IActionResult GetHighEarnersWithDetails()
        {
            var res = _employeeService.GetHighEarnersWithDetails();
            return Ok(res);
        }


        [Route("GetEmployeeByDepartmetHighestSalary")]
        [HttpGet]

        public IActionResult GetEmployeeByDepartmetHighestSalary ()
        {
            var res = _employeeService.GetEmployeeByDepartmetHighestSalary();
            return Ok(res);
        }

        [Route("AvgAgeByDeptWithHighSalary")]
        [HttpGet]

        public IActionResult AvgAgeByDeptWithHighSalary ()
        {
            var res = _employeeService.AvgAgeByDeptWithHighSalary();
            return Ok(res);
        }

        [Route("GetSalaryByEmployeeDepartment")]
        [HttpGet]

        public IActionResult GetSalaryByEmployeeDepartment ()
        {
            var res = _employeeService.GetSalaryByEmployeeDepartment();
            return Ok(res);
        }

        [Route("TotalSalaryInBuilding")]
        [HttpGet]

        public IActionResult TotalSalaryInBuilding()
        {
            var res = _employeeService.TotalSalaryInBuilding();
            return Ok(res);
        }

        [Route("AverageAgeInFinance")]
        [HttpGet]
        public IActionResult AvgAgeInBuilding()
        {
            var res = _employeeService.AverageAgeInFinance();
            return Ok(res);
        }

        [Route("OverallAverageSalary")]
        [HttpGet]
        public IActionResult OverallAverageSalary ()
        {
            var res = _employeeService.OverallAverageSalary();
            return Ok(res);
        }

        [Route("HightestSalrayInEacheDep")]
        [HttpGet]

        public IActionResult HightestSalrayInEacheDep()
        {
            var res = _employeeService.HightestSalrayInEacheDep();
            return Ok(res);
        }

        [Route("ITAndFinanceSalary")]
        [HttpGet]
        public IActionResult ITAndFinanceSalary ()
        {
            var res = _employeeService.ITAndFinanceSalary();
            return Ok(res);
        }

        [Route("EmployeeAverageSalaryInTheirDep")]
        [HttpGet]
        public IActionResult EmployeeAverageSalaryInTheirDep()
        {
            var res = _employeeService.EmployeeAverageSalaryInTheirDep();
            return Ok(res);
        }

        [Route("GetDepartmentWithMostEmployees")]
        [HttpGet]

        public IActionResult GetDepartmentWithMostEmployees()
        {
            var res = _employeeService.GetDepartmentWithMostEmployees();
            return Ok(res);
        }

        [Route("GetEmployeeCountByDepartment")]
        [HttpGet]
        public IActionResult GetEmployeeWithMostEmployees()
        {
            var res = _employeeService.GetEmployeeCountByDepartment();
            return Ok(res);
        }

        [Route("GetTopNSalaryInEveryDepartment")]
        [HttpGet]

        public IActionResult GetTopNSalaryInEveryDepartment(int N)
        {
            var res = _employeeService.GetTopNSalaryInEveryDepartment(N);
            return Ok(res);
        }


        [Route("GetDepartmentWithHighestAverageSalary")]
        [HttpGet]
        public IActionResult GetDepartmentWithHighestAverageSalary()
        {
            var res = _employeeService.GetDepartmentWithHighestAverageSalary();
            return Ok(res);
        }


        [Route("DoubleSalary")]

        [HttpGet]

        public IActionResult DoubleSalary() 
        { 
            var res = _employeeService.DoubleSalary();
            return Ok(res);
        }

        [Route("GetMostCommonSalaryInEachDepartment")]
        [HttpGet]
        public IActionResult GetMostCommonSalaryInEachDepartment()
        {
            var res = _employeeService.GetMostCommonSalaryInEachDepartment();
            return Ok(res);
        }
    }
}
