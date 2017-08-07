using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeesDB.Abstract;
using EmployeesDB.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonnelManagement.Web.Controllers;

namespace PersonnelManagement.Tests
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IUnitOfWork> _mock;
        [TestInitialize]
        public void Start()
        {
            _mock =  new Mock<IUnitOfWork>();
            _mock.Setup(m => m.EmployeeRepository.GetEmployees()).Returns(new List<Employee>()
            {
                new Employee() {LastName = "Иванов"},
                new Employee() {LastName = "Петров"},
                new Employee() {LastName = "Михайлов"},
                new Employee() {LastName = "Андреев"},
                new Employee() {LastName = "Сидоров"},
            });
            _mock.Setup(m => m.PositionRepository.GetPositions()).Returns(new List<Position>()
            {
                new Position() {Id = 1, Title = "Программист"},
                new Position() {Id = 2, Title = "Главный бухгалтер"}
            });
        }

        [TestMethod]
        public void Find_By_LastName()
        {
            EmployeeController controller = new EmployeeController(_mock.Object);
            IEnumerable<Employee> employees = (IEnumerable<Employee>)(controller.EmployeesList("Петров")).ViewData.Model;
            Assert.IsTrue(employees.Count() == 1);
        }


    }
}
