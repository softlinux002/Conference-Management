using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APTA.Models;
using APTA.Models.viewmodel;

namespace APTA.Controllers
{
    public class STUDENTsController : Controller
    {
        private APTAEntities db = new APTAEntities();
        private List<StudentsViewModel> _StudentList;
        public STUDENTsController()
        {
            _StudentList = new List<StudentsViewModel>()
            {
                new StudentsViewModel(){ STUDENT_ID=1,EVENT="Event1",LAST_NAME="Jhon",FIRST_NAME="Mike",PHONE="9999999999",EMAIL="Jhon@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false},
                new StudentsViewModel(){ STUDENT_ID=2,EVENT="Event2",LAST_NAME="Jhonson",FIRST_NAME="Roger",PHONE="8888888888",EMAIL="Jhonson@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false},
                new StudentsViewModel(){ STUDENT_ID=3,EVENT="Event3",LAST_NAME="Kim",FIRST_NAME="Adam",PHONE="7777777777",EMAIL="Kim@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false}
            };
        }
        // GET: STUDENTs
        public ActionResult Index()
        {
            //var sTUDENTS = db.STUDENTS.Include(s => s.EVENT); //when using data base
            return View(_StudentList);  //pass sTUDENTS to view for entity framework
        }

        // GET: STUDENTs/Details/5
        public ActionResult Details(int id) //when you have connected database you can use int?
        {
            ////this block of code is used when you have connected database
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    STUDENT sTUDENT = db.STUDENTS.Find(id);
            ////
            StudentsViewModel sTUDENT = _StudentList[id];
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // GET: STUDENTs/Create
        public ActionResult Create()
        {
            ViewBag.EVENT_ID = new SelectList(db.EVENTS.Where(e => e.IsDeleted == false), "EVENT_ID", "NAME");
            return View();
        }

        // POST: STUDENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STUDENT_ID,LAST_NAME,FIRST_NAME,PHONE,EMAIL,REGISTRATION_DATE,EVENT_ID,IsDeleted")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                sTUDENT.IsDeleted = false;
                db.STUDENTS.Add(sTUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EVENT_ID = new SelectList(db.EVENTS, "EVENT_ID", "NAME", sTUDENT.EVENT_ID);
            return View(sTUDENT);
        }

        // GET: STUDENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTS.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.EVENT_ID = new SelectList(db.EVENTS.Where(e => e.IsDeleted == false), "EVENT_ID", "NAME", sTUDENT.EVENT_ID);
            return View(sTUDENT);
        }

        // POST: STUDENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STUDENT_ID,LAST_NAME,FIRST_NAME,PHONE,EMAIL,REGISTRATION_DATE,EVENT_ID,IsDeleted")] STUDENT sTUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EVENT_ID = new SelectList(db.EVENTS, "EVENT_ID", "NAME", sTUDENT.EVENT_ID);
            return View(sTUDENT);
        }

        // GET: STUDENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT sTUDENT = db.STUDENTS.Find(id);
            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // POST: STUDENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENT sTUDENT = db.STUDENTS.Find(id);
            sTUDENT.IsDeleted = true;
            db.Entry(sTUDENT).State = EntityState.Modified;
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
