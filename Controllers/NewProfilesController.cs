using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200_Team8.DAL;
using MIS4200_Team8.Models;

namespace MIS4200_Team8.Controllers
{
    public class NewProfilesController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: NewProfiles
        [Authorize]
        public ActionResult Index(string searchString)
        {
            //var employeeSearch = from p in db.profile select p;
            var employeeSearch = db.profile.Include(e => e.employeeGetting).Include(e => e.employeeGiving);
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeSearch = employeeSearch.Where(p => p.lastName.Contains(searchString)); /*|| p.firstName.Contains(searchString);*/
            }

            //var rec = db.recognition.Where(r => r.recognitionID == recognitionID);

            //var recList = rec.ToList();
            //ViewBag.rec = recList;
            //var totalCnt = recList.Count();

            return View(employeeSearch.ToList());
        }

        // GET: NewProfiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: NewProfiles/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileID,firstName,lastName,businessUnitLocation,hireDate,jobTitleName")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //profile.profileID = Guid.NewGuid();
                Guid newProfileID;
                Guid.TryParse(User.Identity.GetUserId(), out newProfileID);
                profile.profileID = newProfileID;
                db.profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(profile);
        }

        // GET: NewProfiles/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            Guid profileID;
            Guid.TryParse(User.Identity.GetUserId(), out profileID);
            if (profileID == id)
            {
                return View(profile);
            }
            else
            {
                return View("notAuthorized");
            }
        }

        // POST: NewProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileID,firstName,lastName,businessUnitLocation,hireDate,jobTitleName")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: NewProfiles/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            Guid profileID;
            Guid.TryParse(User.Identity.GetUserId(), out profileID);
            if (profileID == id)
            {
                return View(profile);
            }
            else
            {
                return View("notAuthorized");
            }
        }

        // POST: NewProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.profile.Find(id);
            db.profile.Remove(profile);
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
