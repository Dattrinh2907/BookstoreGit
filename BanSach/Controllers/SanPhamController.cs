using System;
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
    public class SanPhamController : Controller
    {
        private NhaSachEntities db = new NhaSachEntities();

        // GET: SanPham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSach).Include(s => s.NhaXuatBan1).Include(s => s.TacGia1);
            return View(sanPhams.ToList());
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai");
            ViewBag.NhaXuatBan = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            ViewBag.TacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TuaSach,TacGia,NhaXuatBan,NgayXuatBan,TheLoai,SoLuong,DonGia,AnhMinhHoa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sanPham.TheLoai);
            ViewBag.NhaXuatBan = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sanPham.NhaXuatBan);
            ViewBag.TacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sanPham.TacGia);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sanPham.TheLoai);
            ViewBag.NhaXuatBan = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sanPham.NhaXuatBan);
            ViewBag.TacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sanPham.TacGia);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TuaSach,TacGia,NhaXuatBan,NgayXuatBan,TheLoai,SoLuong,DonGia,AnhMinhHoa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TheLoai = new SelectList(db.LoaiSaches, "MaLoai", "TenLoai", sanPham.TheLoai);
            ViewBag.NhaXuatBan = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB", sanPham.NhaXuatBan);
            ViewBag.TacGia = new SelectList(db.TacGias, "MaTacGia", "TenTacGia", sanPham.TacGia);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
