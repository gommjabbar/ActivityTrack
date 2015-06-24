using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ActivityTrack.Models;
//   MEMORY USAGE STUFF
namespace ActivityTrack.Controllers
{
    public class KnockoutActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KnockoutActivities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.Project);
            return View(activities.ToList());
        }

        // GET: KnockoutActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityEO activityEO = db.Activities.Find(id);
            if (activityEO == null)
            {
                return HttpNotFound();
            }
            return View(activityEO);
        }

        // GET: KnockoutActivities/Create
        public ActionResult Create()
        {
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Type");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: KnockoutActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EndDate,Description,ActivityState,ActivityTypeId,ProjectId,ElapsedTime,EstimatedEffort,EstimatedStartDate,CreateDate,UpdateDate,DeleteDate")] ActivityEO activityEO)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activityEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Type", activityEO.ActivityTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", activityEO.ProjectId);
            return View(activityEO);
        }

        // GET: KnockoutActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityEO activityEO = db.Activities.Find(id);
            if (activityEO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Type", activityEO.ActivityTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", activityEO.ProjectId);
            return View(activityEO);
        }

        // POST: KnockoutActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EndDate,Description,ActivityState,ActivityTypeId,ProjectId,ElapsedTime,EstimatedEffort,EstimatedStartDate,CreateDate,UpdateDate,DeleteDate")] ActivityEO activityEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "Type", activityEO.ActivityTypeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", activityEO.ProjectId);
            return View(activityEO);
        }

        // GET: KnockoutActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityEO activityEO = db.Activities.Find(id);
            if (activityEO == null)
            {
                return HttpNotFound();
            }
            return View(activityEO);
        }

        // POST: KnockoutActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityEO activityEO = db.Activities.Find(id);
            db.Activities.Remove(activityEO);
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
