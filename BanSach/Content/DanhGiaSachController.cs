using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BanSach.Models;

namespace BanSach.Content
{
    public class DanhGiaSachController : Controller
    {
        private NhaSachEntities db = new NhaSachEntities();

        // GET: DanhGiaSach
        public ActionResult Index()
        {
            var danhGiaSaches = db.DanhGiaSaches.Include(d => d.KhachHang).Include(d => d.SanPham);
            return View(danhGiaSaches.ToList());
        }

        // GET: DanhGiaSach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaSach danhGiaSach = db.DanhGiaSaches.Find(id);
            if (danhGiaSach == null)
            {
                return HttpNotFound();
            }
            return View(danhGiaSach);
        }

        // GET: DanhGiaSach/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH");
            ViewBag.MaSach = new SelectList(db.SanPhams, "MaSach", "TuaSach");
            return View();
        }

        // POST: DanhGiaSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaKH,NoiDungDanhGia,ThoiGianDang")] DanhGiaSach danhGiaSach)
        {
            if (ModelState.IsValid)
            {
                db.DanhGiaSaches.Add(danhGiaSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", danhGiaSach.MaKH);
            ViewBag.MaSach = new SelectList(db.SanPhams, "MaSach", "TuaSach", danhGiaSach.MaSach);
            return View(danhGiaSach);
        }

        // GET: DanhGiaSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaSach danhGiaSach = db.DanhGiaSaches.Find(id);
            if (danhGiaSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", danhGiaSach.MaKH);
            ViewBag.MaSach = new SelectList(db.SanPhams, "MaSach", "TuaSach", danhGiaSach.MaSach);
            return View(danhGiaSach);
        }

        // POST: DanhGiaSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaKH,NoiDungDanhGia,ThoiGianDang")] DanhGiaSach danhGiaSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhGiaSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", danhGiaSach.MaKH);
            ViewBag.MaSach = new SelectList(db.SanPhams, "MaSach", "TuaSach", danhGiaSach.MaSach);
            return View(danhGiaSach);
        }

        // GET: DanhGiaSach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGiaSach danhGiaSach = db.DanhGiaSaches.Find(id);
            if (danhGiaSach == null)
            {
                return HttpNotFound();
            }
            return View(danhGiaSach);
        }

        // POST: DanhGiaSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGiaSach danhGiaSach = db.DanhGiaSaches.Find(id);
            db.DanhGiaSaches.Remove(danhGiaSach);
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
