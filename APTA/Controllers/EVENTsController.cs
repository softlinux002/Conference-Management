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
    public class EVENTsController : Controller
    {
        private APTAEntities db = new APTAEntities();
        private List<EventsViewModel> _eventList;
        private List<StudentsViewModel> _StudentList;
        public EVENTsController()
        {
            _eventList = new List<EventsViewModel>()
            {
                new EventsViewModel(){ EVENT_ID =1,NAME="Event1",DATE=DateTime.Today,ORGANISER="Jhon",CENTER="Utah",IsDeleted=false},
                new EventsViewModel(){ EVENT_ID =2,NAME="Event2",DATE=DateTime.Today,ORGANISER="Jhonson",CENTER="Cambridge",IsDeleted=false},
                new EventsViewModel(){ EVENT_ID =3,NAME="Event3",DATE=DateTime.Today,ORGANISER="kim",CENTER="Michigan",IsDeleted=false}
            };
            _StudentList = new List<StudentsViewModel>()
            {
                new StudentsViewModel(){ STUDENT_ID=1,EVENT="Event1",LAST_NAME="Jhon",FIRST_NAME="Mike",PHONE="9999999999",EMAIL="Jhon@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false},
                new StudentsViewModel(){ STUDENT_ID=2,EVENT="Event2",LAST_NAME="Jhonson",FIRST_NAME="Roger",PHONE="8888888888",EMAIL="Jhonson@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false},
                new StudentsViewModel(){ STUDENT_ID=3,EVENT="Event3",LAST_NAME="Kim",FIRST_NAME="Adam",PHONE="7777777777",EMAIL="Kim@gmail.com",REGISTRATION_DATE=DateTime.Today,IsDeleted=false}
            };
        }
        // GET: EVENTs
        public ActionResult Index()
        {
            //var eVENTS = db.EVENTS.Include(e => e.CENTER).Include(e => e.ORGANISER); //when using data base
            return View(_eventList); //pass eVENTS to view for entity framework
        }

        // GET: EVENTs/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //EVENT eVENT = db.EVENTS.Find(id);

            //var student = db.STUDENTS.Where(z => z.EVENT_ID == id).ToList();
            EventsViewModel eVENT = _eventList[id];
            var student = _StudentList.Where(z => z.EVENT == eVENT.NAME).ToList();
            var ListStudents = new List<string>();
            foreach (var item in student)
            {
                var studentName = item.FIRST_NAME + " " + item.LAST_NAME ;
                ListStudents.Add(studentName);
            }

            ViewBag.ListStudents = ListStudents;
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            return View(eVENT);
        }

        // GET: EVENTs/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.CENTERs.Where(e => e.IsDeleted == false), "LocationID", "Location");
            ViewBag.ORGANISER_ID = new SelectList(db.ORGANISERs.Where(e => e.IsDeleted == false), "ORGANISER_ID", "FIRST_NAME");
            return View();
        }

        // POST: EVENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EVENT_ID,NAME,DATE,ORGANISER_ID,LocationID,IsDeleted")] EVENT eVENT)
        {
            if (ModelState.IsValid)
            {
                eVENT.IsDeleted = false;
                db.EVENTS.Add(eVENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.CENTERs, "LocationID", "Location", eVENT.LocationID);
            ViewBag.ORGANISER_ID = new SelectList(db.ORGANISERs, "ORGANISER_ID", "LAST_NAME", eVENT.ORGANISER_ID);
            return View(eVENT);
        }

        // GET: EVENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENT eVENT = db.EVENTS.Find(id);
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.CENTERs.Where(e => e.IsDeleted == false), "LocationID", "Location", eVENT.LocationID);
            ViewBag.ORGANISER_ID = new SelectList(db.ORGANISERs.Where(e => e.IsDeleted == false), "ORGANISER_ID", "LAST_NAME", eVENT.ORGANISER_ID);
            return View(eVENT);
        }

        // POST: EVENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EVENT_ID,NAME,DATE,ORGANISER_ID,LocationID,IsDeleted")] EVENT eVENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.CENTERs, "LocationID", "Location", eVENT.LocationID);
            ViewBag.ORGANISER_ID = new SelectList(db.ORGANISERs, "ORGANISER_ID", "LAST_NAME", eVENT.ORGANISER_ID);
            return View(eVENT);
        }

        // GET: EVENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENT eVENT = db.EVENTS.Find(id);
            if (eVENT == null)
            {
                return HttpNotFound();
            }
            return View(eVENT);
        }

        // POST: EVENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENT eVENT = db.EVENTS.Find(id);
            eVENT.IsDeleted = false;
            db.Entry(eVENT).State = EntityState.Modified;
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
