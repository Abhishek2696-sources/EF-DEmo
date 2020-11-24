using MVCWebApplication.Dto;
using System.Collections.Generic;

namespace MVCWebApplication.DAL.EmployeeDAL.Interface
{
    public interface IEmployee
    {
        List<EmployeeDto> GetAllEmployeeDetail();
        void AddNewEmployee(EmployeeDto employeeDto);
        EmployeeDto UpdateEmployee(EmployeeDto employeeDto);
        EmployeeDto GetByEmployee(int employeeId);
        EmployeeDto DeleteEmployee(int employeeDto);
    }
}
