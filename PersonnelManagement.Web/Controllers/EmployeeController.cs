using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesDB.Abstract;
using EmployeesDB.Entities;

namespace PersonnelManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Список сотрудников
        /// </summary>
        public ViewResult EmployeesList(string lastName)
        {
            ViewBag.Positions = GetPositions();
            return View(_unitOfWork.EmployeeRepository.GetEmployees().Where(e => lastName == null || e.LastName.ToUpper().Contains(lastName.ToUpper())));
        }

        [HttpGet]
        public ViewResult NewEmployee()
        {
            ViewBag.Positions = GetPositions();
            return View("UpdateEmployee", new Employee());
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {

            Employee employee = _unitOfWork.EmployeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// Подтверждение удаления сотрудника
        /// </summary>
        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            _unitOfWork.EmployeeRepository.DeleteEmployee(id);
            _unitOfWork.Save();
            TempData["result"] = "Сотрудник № " + id + " был успешно удален.";
            return RedirectToAction("EmployeesList");
        }


        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            Employee employee = _unitOfWork.EmployeeRepository.GetEmployeeById(id);
            ViewBag.Positions = GetPositions();
            return View(employee);
        }

        /// <summary>
        /// Обновление информации по сотруднику
        /// </summary>
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    _unitOfWork.EmployeeRepository.CreateEmployee(employee);
                }
                else
                {
                    _unitOfWork.EmployeeRepository.UpdateEmployee(employee);
                }
                _unitOfWork.Save();
                TempData["result"] = "Сотрудник № " + employee.Id + " был успешно обновлен.";
                return RedirectToAction("EmployeesList");
            }
            ViewBag.Positions = GetPositions();
            return View();
        }

        //Получаем список должностей для передачи в представление
        private SelectList GetPositions()
        {
            return new SelectList(_unitOfWork.PositionRepository.GetPositions(), "Id", "Title");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork?.Dispose();
            base.Dispose(disposing);
        }
    }
}