using Microsoft.EntityFrameworkCore;
using MVCWebApplication.DAL.Context;
using MVCWebApplication.DAL.EmbeddedReources;
using MVCWebApplication.DAL.EmployeeDAL.Interface;
using MVCWebApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MVCWebApplication.DAL.EmployeeDAL
{
    public class Employee : IEmployee
    {
        private readonly DataBaseContext _context;
        public Employee(DataBaseContext context)
        {
            _context = context;
        }
        public List<EmployeeDto> GetAllEmployeeDetail()
        {
            var employee = _context.Employee.FromSql(EmbeddedResource.ReadEmbeddedReource(SqlResource.GetAllEmpoloyee)).ToList();
            return employee;
        }
        public void AddNewEmployee(EmployeeDto employeeDto)
        {
            var transaction = _context.Database;
            try
            {
                transaction.BeginTransaction();

                _context.Employee.Add(employeeDto);

                _context.SaveChanges();

                transaction.CommitTransaction();
            }
            catch (Exception)
            {
                transaction.RollbackTransaction();
            }
        }

        public EmployeeDto UpdateEmployee(EmployeeDto employeeDto)
        {
            var updatedRecord = _context.Employee.FirstOrDefault(x => x.EmployeeId == employeeDto.EmployeeId);
            try
            {
                updatedRecord.EmployeeId = employeeDto.EmployeeId;
                updatedRecord.Name = employeeDto.Name;
                updatedRecord.Address = employeeDto.Address;
                updatedRecord.City = employeeDto.City;
                updatedRecord.Salary = employeeDto.Salary;
                _context.Update(updatedRecord);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return updatedRecord;
        }

        public EmployeeDto GetByEmployee(int employeeId)
        {
            var employee = _context.Employee.Single(x => x.EmployeeId == employeeId);
            return employee;
        }

        public EmployeeDto DeleteEmployee(int employeeId)
        {
            if (IsCheckEmployee(employeeId))
            {
                throw new HttpRequestException();
            }
            var employee = _context.Employee.Find(employeeId);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            return employee;
        }

        private bool IsCheckEmployee(int employeeId)
        {
            bool IsApplicable = true;
            var employeeIdId = _context.Employee.Where(x => x.EmployeeId == employeeId).SingleOrDefault();
            if (employeeIdId != null)
            {
                IsApplicable = false;   
            }

            return IsApplicable;
        }
    }
}
