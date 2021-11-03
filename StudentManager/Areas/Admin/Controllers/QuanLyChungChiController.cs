using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class QuanLyChungChiController : Controller
    {
        // GET: Admin/QuanLyChungChi
        public ActionResult Index()
        {
            ListChungchi listChungchi= new ListChungchi();
            List<Chungchi> obj = listChungchi.getChungChi();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Chungchi cc)
        {
            if (ModelState.IsValid)
            {
                ListChungchi listChungchi = new ListChungchi();
                listChungchi.addChungchi(cc);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int ID = 0)
        {
            ListChungchi listChungchi = new ListChungchi();
            List<Chungchi> obj = listChungchi.getChungChi(ID);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Chungchi cc)
        {
            ListChungchi listChungchi= new ListChungchi();
            listChungchi.updateChungchi(cc);
            return RedirectToAction("Index");
        }

        public void Delete(int ID = 0) {
            ListChungchi listChungchi = new ListChungchi();
            listChungchi.deleteChungchi(ID);
        }

    }
}