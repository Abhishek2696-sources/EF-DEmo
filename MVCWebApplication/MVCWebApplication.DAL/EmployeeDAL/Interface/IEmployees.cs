using MVCWebApplication.Dto;
using System.Collections.Generic;

namespace MVCWebApplication.DAL.EmployeeDAL.Interface
{
    public interface IEmployees
    {
        void AddNewEmployee(EmployeeDto employeeDto);
        List<EmployeeDto> GetAllEmployeeDetail();
        void UpdateEmployee(EmployeeDto employeeDto);
        EmployeeDto GetByEmployee(int employeeId);
        void DeleteEmployee(EmployeeDto employeeDto);
    }
}
