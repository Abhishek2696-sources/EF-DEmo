using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.DAL.EmployeeDAL.Interface;
using MVCWebApplication.Dto;

namespace MVCWebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IEmployees _employees;
        public EmployeesController(IEmployee employee, IEmployees employees)
        {
            _employee = employee;
            _employees = employees;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
            var employee = _employees.GetAllEmployeeDetail();
            return View(employee);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDto employeeDto)
        {

            try
            {
                _employees.AddNewEmployee(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employee.GetByEmployee(id);

            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeDto employeeDto)
        {
            try
            {
                _employee.UpdateEmployee(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            var employeeId = _employee.DeleteEmployee(id);
            return View(employeeId);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            EmployeeDto employeeDto = new EmployeeDto();
            employeeDto.EmployeeId = id;
            try
            {
                _employees.DeleteEmployee(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
