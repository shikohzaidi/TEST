using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class mVanAreasController : Controller
    {
        private DBUrbanHealthEntities db = new DBUrbanHealthEntities();

        // GET: mVanAreas
        public ActionResult Index()
        {
            return View(db.mVanAreas.ToList());
        }

        // GET: mVanAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mVanArea mVanArea = db.mVanAreas.Find(id);
            if (mVanArea == null)
            {
                return HttpNotFound();
            }
            return View(mVanArea);
        }

        // GET: mVanAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mVanAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VanAreaId,VanAreaName,Creationdate,Isactive,Userid")] mVanArea mVanArea)
        {
            if (ModelState.IsValid)
            {
                db.mVanAreas.Add(mVanArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mVanArea);
        }

        // GET: mVanAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mVanArea mVanArea = db.mVanAreas.Find(id);
            if (mVanArea == null)
            {
                return HttpNotFound();
            }
            return View(mVanArea);
        }

        // POST: mVanAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VanAreaId,VanAreaName,Creationdate,Isactive,Userid")] mVanArea mVanArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mVanArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mVanArea);
        }

        // GET: mVanAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mVanArea mVanArea = db.mVanAreas.Find(id);
            if (mVanArea == null)
            {
                return HttpNotFound();
            }
            return View(mVanArea);
        }

        // POST: mVanAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mVanArea mVanArea = db.mVanAreas.Find(id);
            db.mVanAreas.Remove(mVanArea);
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
