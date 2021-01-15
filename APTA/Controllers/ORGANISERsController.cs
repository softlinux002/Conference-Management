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
    public class ORGANISERsController : Controller
    {
        private APTAEntities db = new APTAEntities();
        private List<OrganiserViewModel> _OrganiserList;
        public ORGANISERsController()
        {
            _OrganiserList = new List<OrganiserViewModel>()
            {
                new OrganiserViewModel(){ EVENTS="Event1",ORGANISER_ID=1,LAST_NAME="Organizer1",FIRST_NAME="Mike",PHONE="9999999999",EMAIL="Jhon@gmail.com",IsDeleted=false},
                new OrganiserViewModel(){ EVENTS="Event2",ORGANISER_ID=2,LAST_NAME="Organizer2",FIRST_NAME="Roger",PHONE="8888888888",EMAIL="Jhonson@gmail.com",IsDeleted=false},
                new OrganiserViewModel(){ EVENTS="Event3",ORGANISER_ID=3,LAST_NAME="Organizer3",FIRST_NAME="Adam",PHONE="7777777777",EMAIL="Kim@gmail.com",IsDeleted=false}
            };
        }
        // GET: ORGANISERs
        public ActionResult Index()
        {
            return View(_OrganiserList); //pass db.ORGANISERs.ToList() to view when database is used
        }

        // GET: ORGANISERs/Details/5
        public ActionResult Details(int id)
        {
            ////this block of code is used when you have connected database
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ORGANISER oRGANISER = db.ORGANISERs.Find(id);
            ////
            OrganiserViewModel oRGANISER = _OrganiserList[id];
            if (oRGANISER == null)
            {
                return HttpNotFound();
            }
            return View(oRGANISER);
        }

        // GET: ORGANISERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ORGANISERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ORGANISER_ID,LAST_NAME,FIRST_NAME,PHONE,EMAIL,IsDeleted")] ORGANISER oRGANISER)
        {
            if (ModelState.IsValid)
            {
                oRGANISER.IsDeleted = false;
                db.ORGANISERs.Add(oRGANISER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oRGANISER);
        }

        // GET: ORGANISERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORGANISER oRGANISER = db.ORGANISERs.Find(id);
            if (oRGANISER == null)
            {
                return HttpNotFound();
            }
            return View(oRGANISER);
        }

        // POST: ORGANISERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ORGANISER_ID,LAST_NAME,FIRST_NAME,PHONE,EMAIL,IsDeleted")] ORGANISER oRGANISER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRGANISER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oRGANISER);
        }

        // GET: ORGANISERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORGANISER oRGANISER = db.ORGANISERs.Find(id);
            if (oRGANISER == null)
            {
                return HttpNotFound();
            }
            return View(oRGANISER);
        }

        // POST: ORGANISERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORGANISER oRGANISER = db.ORGANISERs.Find(id);
            oRGANISER.IsDeleted = false;
            db.Entry(oRGANISER).State = EntityState.Modified;
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
