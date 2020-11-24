using FRAMEWORKDEMO.DAL.Generics;
using MVCWebApplication.DAL.EmbeddedReources;
using MVCWebApplication.DAL.EmployeeDAL.Interface;
using MVCWebApplication.DAL.Interface;
using MVCWebApplication.Dto;
using System.Collections.Generic;

namespace MVCWebApplication.DAL.EmployeeDAL
{
    public class EmployeeDB : BaseRepository<EmployeeDto>, IEmployees
    {
        public EmployeeDB(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public void AddNewEmployee(EmployeeDto employeeDto)
        {
            base.Save(employeeDto);
        }

        public void DeleteEmployee(EmployeeDto employeeDto)
        {
            base.Delete(employeeDto);
        }

        public List<EmployeeDto> GetAllEmployeeDetail()
        {
            return base.GetWithRawSqls<EmployeeDto>(EmbeddedResource.ReadEmbeddedReource(SqlResource.GetAllEmpoloyee));
        }

        public EmployeeDto GetByEmployee(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEmployee(EmployeeDto employeeDto)
        {
            base.Update(employeeDto);
        }
    }
}
