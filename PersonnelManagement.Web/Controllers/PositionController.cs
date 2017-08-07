using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesDB.Abstract;
using EmployeesDB.Entities;

namespace PersonnelManagement.Web.Controllers
{
    public class PositionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Список должностей
        /// </summary>
        public ActionResult PositionList()
        {
            return View(_unitOfWork.PositionRepository.GetPositions());
        }

        [HttpGet]
        public ViewResult NewPosition()
        {
            return View("UpdatePosition", new Position());
        }

        /// <summary>
        /// Удаление должности
        /// </summary>
        [HttpGet]
        public ActionResult DeletePosition(int id)
        {

            Position position = _unitOfWork.PositionRepository.GetPositionById(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        /// <summary>
        /// Подтверждение удаления должности
        /// </summary>
        [HttpPost, ActionName("DeletePosition")]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = _unitOfWork.PositionRepository.GetPositionById(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            try
            {
                _unitOfWork.PositionRepository.DeletePosition(id);
                _unitOfWork.Save();
                TempData["result"] = "Должность № " + id + " была успешно удалена.";
            }
            catch
            {
                TempData["result"] = "Невозможно удалить запись. Возможно на неё имеются ссылки!";
            }
            return RedirectToAction("PositionList");
        }


        [HttpGet]
        public ActionResult UpdatePosition(int id)
        {
            Position position = _unitOfWork.PositionRepository.GetPositionById(id);
            return View(position);
        }

        //Обновление должности
        [HttpPost]
        public ActionResult UpdatePosition(Position position)
        {
            if (ModelState.IsValid)
            {
                if (position.Id == 0)
                {
                    _unitOfWork.PositionRepository.CreatePosition(position);
                }
                else
                {
                    _unitOfWork.PositionRepository.UpdatePosition(position);
                }
                _unitOfWork.Save();
                TempData["result"] = "Должность № " + position.Id + " была успешно обновлена.";
                return RedirectToAction("PositionList");
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork?.Dispose();
            base.Dispose(disposing);
        }
    }
}