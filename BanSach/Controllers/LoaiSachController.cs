﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;

namespace BanSach.Controllers
{
    public class LoaiSachController : Controller
    {
        private NhaSachEntities db = new NhaSachEntities();

        // GET: LoaiSach
        public ActionResult Index()
        {
            return View(db.LoaiSaches.ToList());
        }

        // GET: LoaiSach/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // GET: LoaiSach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai,GhiChu")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSaches.Add(loaiSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSach);
        }

        // GET: LoaiSach/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: LoaiSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai,GhiChu")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSach);
        }

        // GET: LoaiSach/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            db.LoaiSaches.Remove(loaiSach);
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
