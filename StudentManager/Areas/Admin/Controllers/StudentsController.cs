using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Admin/Student
        public ActionResult Index()
        {
            StudentList studentList = new StudentList();
            List<Student> obj = studentList.getStudent();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student sv)
        {
            if (ModelState.IsValid)
            {
                StudentList stuList = new StudentList();
                stuList.addStudent(sv);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int ID = 0)
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(ID);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Student sv)
        {
            StudentList stuList = new StudentList();
            stuList.updateStudent(sv);
            return RedirectToAction("Index");
        }
        /*
        public ActionResult Delete(int ID = 0)
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(ID);
            return View(obj.FirstOrDefault());
        }
        */
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            StudentList stuList = new StudentList();
            stuList.deleteStudent(ID);
            return RedirectToAction("Index");
        }
    }
}