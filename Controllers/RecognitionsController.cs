﻿using System;
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
    public class RecognitionsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Recognitions
        [Authorize]
        public ActionResult Index(string searchString)
        {
            //var employeeSearch = from p in db.profile select p;
            var recognitionSearch = db.recognition.Include(e => e.employeeGetting).Include(e => e.employeeGiving);
            if (!String.IsNullOrEmpty(searchString))
            {
                recognitionSearch = recognitionSearch.Where(p => p.employeeGetting.lastName.Contains(searchString) || p.employeeGetting.firstName.Contains(searchString));
            }
            recognitionSearch = recognitionSearch.OrderByDescending(r => r.recognitionDate).Take(10);
            return View(recognitionSearch.ToList());

        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            string profileID = User.Identity.GetUserId();
            SelectList profiles = new SelectList(db.profile, "profileID", "fullName");
            profiles = new SelectList(profiles.Where(x => x.Value != profileID).ToList(), "Value", "Text");
            ViewBag.recognized = profiles;
            return View();

        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,award,recognizor,recognized,recognitionDate,descritption")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                Guid newProfileID;
                Guid.TryParse(User.Identity.GetUserId(), out newProfileID);
                recognition.recognizor = newProfileID;
                db.recognition.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            string profileID = User.Identity.GetUserId();
            SelectList profiles = new SelectList(db.profile, "profileID", "fullName");
            profiles = new SelectList(profiles.Where(x => x.Value != profileID).ToList(), "Value", "Text");
            ViewBag.recognized = profiles;

            //ViewBag.recognized = new SelectList(db.profile, "profileID", "fullName");
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //string profileID = User.Identity.GetUserId();
            //SelectList profiles = new SelectList(db.profile, "profileID", "fullName");
            //profiles = new SelectList(profiles.Where(x => x.Value != profileID).ToList(), "Value", "Text");

            Recognition recognition = db.recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            Guid recognitionID;
            Guid.TryParse(User.Identity.GetUserId(), out recognitionID);
            if (recognitionID == recognition.recognizor)
            {
                return View(recognition);
            }
            else
            {
                return View("notAuthorizedRecognition");
            }

        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,award,recognizor,recognized,recognitionDate,descritption")] Recognition recognition)
        {

            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //string profileID = User.Identity.GetUserId();
            //SelectList profiles = new SelectList(db.profile, "profileID", "fullName");
            //profiles = new SelectList(profiles.Where(x => x.Value != profileID).ToList(), "Value", "Text");

            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.recognition.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            //string profileID = User.Identity.GetUserId();
            //SelectList profiles = new SelectList(db.profile, "profileID", "fullName");
            //profiles = new SelectList(profiles.Where(x => x.Value != profileID).ToList(), "Value", "Text");

            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognition recognition = db.recognition.Find(id);
            db.recognition.Remove(recognition);
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
