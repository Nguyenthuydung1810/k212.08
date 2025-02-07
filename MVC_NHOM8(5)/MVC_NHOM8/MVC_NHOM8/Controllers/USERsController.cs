﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_NHOM8.Models;

namespace MVC_NHOM8.Controllers
{
    public class USERsController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        // GET: USERs
        public ActionResult Index()
        {
            var uSERs = db.USERs.Include(u => u.QuyenDangNhaps);
            return View(uSERs.ToList());
        }

        // GET: USERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERs.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: USERs/Create
        public ActionResult Create()
        {
            ViewBag.QuyenDNID = new SelectList(db.QuyenDangNhaps, "QuyenDNID", "TenQuyenDN");
            return View();
        }

        // POST: USERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,TenDangNhap,MatKhau,EmailDK,DiaChiDK,TenDayDu,Cauhoibaomat,NgaySinh,GioiTinh,QuyenDNID")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.USERs.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuyenDNID = new SelectList(db.QuyenDangNhaps, "QuyenDNID", "TenQuyenDN", uSER.QuyenDNID);
            return View(uSER);
        }

        // GET: USERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERs.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuyenDNID = new SelectList(db.QuyenDangNhaps, "QuyenDNID", "TenQuyenDN", uSER.QuyenDNID);
            return View(uSER);
        }

        // POST: USERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,TenDangNhap,MatKhau,EmailDK,DiaChiDK,TenDayDu,Cauhoibaomat,NgaySinh,GioiTinh,QuyenDNID")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuyenDNID = new SelectList(db.QuyenDangNhaps, "QuyenDNID", "TenQuyenDN", uSER.QuyenDNID);
            return View(uSER);
        }

        // GET: USERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = db.USERs.Find(id);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // POST: USERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USER uSER = db.USERs.Find(id);
            db.USERs.Remove(uSER);
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
