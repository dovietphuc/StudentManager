using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class KhenThuongKyLuatController : Controller
    {
        // GET: Admin/QuanLyChungChi
        public ActionResult Index()
        {
            Listkhenthuongkyluat listkhenthuongkyluat = new Listkhenthuongkyluat();
            List<Khenthuongkyluat> obj = listkhenthuongkyluat.getKhenthuongkyluat();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Khenthuongkyluat ktkl)
        {
            if (ModelState.IsValid)
            {
                Listkhenthuongkyluat listkhenthuongkyluat = new Listkhenthuongkyluat();
                listkhenthuongkyluat.addKhenthuongkyluat(ktkl);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int ID = 0)
        {
            Listkhenthuongkyluat listkhenthuongkyluat = new Listkhenthuongkyluat();
            List<Khenthuongkyluat> obj = listkhenthuongkyluat.getKhenthuongkyluat(ID);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Khenthuongkyluat htkl)
        {
            Listkhenthuongkyluat listkhenthuongkyluat = new Listkhenthuongkyluat();
            listkhenthuongkyluat.updateKhenthuongkyluat(htkl);
            return RedirectToAction("Index");
        }
    }
}
