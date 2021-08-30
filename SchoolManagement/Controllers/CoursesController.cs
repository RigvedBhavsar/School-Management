using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private SchoolManagement_DBEntities db = new SchoolManagement_DBEntities();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


/*
 

******************How To Add MySql Database to the MVC PRoject******************
    1.Goto View -> Sql Server Object Creation -> Expand SQl Server ->
        MSSQLLocaDB -> Database -> 
    2. Create Database
    3. Create Tables
    4. Adding Entiy FrameWork Diagram to Our Project.
       Right Click Models -> Add  -> New Item -> Select ADO.Net Entity Data Model (Data Sub category)
        -> Provide Name(SchooManagementDBMOdel) -> Add -> Ef Designer -> New Connection -> MSSQl Server ->
             Provide Server Name -> Select Database Name -> Add.
    5. (Objects from Databse like to import ? )
            Seletct Tables that we want to add in Model Diagram -> Finish
       Diagram Will Appear.
       (Inside Models/SchoolManagementDBModel.edmx/ will see ClassFile of Tables)

******************How To Add Controller to the Medel(Databse Table)******************

    1.Right Click on COntroller And Add Controller 
    2. Selct MVC-5 Controller with views ,using Entity Framework
    3. Add
    Then Controller POP-UP will come from that 
        Optional  -> (check aysnc Controller action) 
    4.Selct Model Class (Basically Table on which you want to create controller)
        Every Table is Considerd as Class in C#
    5.Select Databse Context class (Databse Name)
    6.check Layout page and Selct Layout from /Views/Shared/_Layout.cshtml
 
 */

