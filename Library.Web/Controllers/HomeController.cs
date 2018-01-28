﻿using BusinesLogicLayer.Services;
using Library.Web.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;
        private PublicationHouseService _publicationHouseService;

        public HomeController()
        {
            _bookService = new BookService(Settings.GetConnectionString());
            _publicationHouseService = new PublicationHouseService(Settings.GetConnectionString());
        }
        public ActionResult Index()
        {
            return View(_bookService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            _bookService.Add(book);
            return RedirectToAction("Index");
        }
        public JsonResult GetAllPublish()
        {
            List<PublicationHouse> list = new List<PublicationHouse>();
            foreach(PublicationHouse item in _publicationHouseService.GetAll())
            {
                list.Add(new PublicationHouse {Id = item.Id, Name = item.Name});
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSelectedPublish(int id)
        {
            List<PublicationHouse> list = new List<PublicationHouse>();
            foreach(PublicationHouse item in _bookService.GetById(id).PublicationHouses)
            {
                list.Add(new PublicationHouse {Id = item.Id, Name = item.Name});
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            return View(_bookService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                _bookService.Edit(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}