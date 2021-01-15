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
    public class CENTERsController : Controller
    {
        private APTAEntities db = new APTAEntities();
        private List<CenterViewModel> _CenterList;
        public CENTERsController()
        {
            _CenterList = new List<CenterViewModel>()
            {
                new CenterViewModel(){ LocationID =1,Location="Utah",IsDeleted=false},
                new CenterViewModel(){ LocationID =2,Location="Cambridge",IsDeleted=false},
                new CenterViewModel(){ LocationID =3,Location="Michigan",IsDeleted=false}
            };
        }
        // GET: CENTERs
        public ActionResult Index()
        {
            return View(_CenterList);
        }

        // GET: CENTERs/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //CENTER cENTER = db.CENTERs.Find(id);

            CenterViewModel cENTER = _CenterList[id];
            if (cENTER == null)
            {
                return HttpNotFound();
            }
            return View(cENTER);
        }

        // GET: CENTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CENTERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationID,Location,IsDeleted")] CENTER cENTER)
        {
            if (ModelState.IsValid)
            {
                cENTER.IsDeleted = false;
                db.CENTERs.Add(cENTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cENTER);
        }

        // GET: CENTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTER cENTER = db.CENTERs.Find(id);
            if (cENTER == null)
            {
                return HttpNotFound();
            }
            return View(cENTER);
        }

        // POST: CENTERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationID,Location,IsDeleted")] CENTER cENTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cENTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cENTER);
        }

        // GET: CENTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CENTER cENTER = db.CENTERs.Find(id);
            if (cENTER == null)
            {
                return HttpNotFound();
            }
            return View(cENTER);
        }

        // POST: CENTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CENTER cENTER = db.CENTERs.Find(id);
            cENTER.IsDeleted = true;
            db.Entry(cENTER).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

            //if (ModelState.IsValid)     [Bind(Include = "LocationID,Location,IsDeleted")] CENTER cENTER
            //{
            //    db.Entry(cENTER).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(cENTER);
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
