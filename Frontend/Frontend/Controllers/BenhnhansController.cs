using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Frontend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Frontend.Controllers
{
    public class BenhnhansController : Controller
    {
        private BenhNhanModel db = new BenhNhanModel();

        // GET: Benhnhans
        public ActionResult Index()
        {
            // Đọc từ file JSON
            string dataFilePath = Server.MapPath("~/App_Data/DanhSachBenhNhan.json");
            JObject joRoot = JObject.Parse(System.IO.File.ReadAllText(dataFilePath));
            if (joRoot != null)
            {
                JArray jaBenhNhan = joRoot["benhnhan"] as JArray;
                if (jaBenhNhan != null)
                {
                    List<Benhnhan> lstBenhNhan = new List<Benhnhan>();
                    foreach (JObject joBenhNhan in jaBenhNhan)
                    {
                        Benhnhan bn = new Benhnhan();
                        bn.mabn = joBenhNhan.GetValue("mabn").ToString();
                        bn.hoten = joBenhNhan.GetValue("hoten").ToString();
                        bn.ngaysinh = joBenhNhan.GetValue("ngaysinh").ToString();
                        bn.gioitinh = joBenhNhan.GetValue("gioitinh").ToString();
                        bn.diachi = joBenhNhan.GetValue("diachi").ToString();
                        bn.maxa = joBenhNhan.GetValue("maxa").ToString();
                        lstBenhNhan.Add(bn);
                    }
                    return View(lstBenhNhan);
                }
            }

            // Đọc từ file JSON
            //TODO: update to new schema KEY, RECORD (not finish)
            //string dataFilePath = Server.MapPath("~/App_Data/danhsach.json");
            //JArray jaRoot = JArray.Parse(System.IO.File.ReadAllText(dataFilePath));
            //if(jaRoot != null)
            //{
            //    JArray jaBenhNhan = joRoot["benhnhan"] as JArray;
            //    if(jaBenhNhan != null)
            //    {
            //        List<Benhnhan> lstBenhNhan = new List<Benhnhan>();
            //        foreach (JObject joBenhNhan in jaBenhNhan)
            //        {
            //            Benhnhan bn = new Benhnhan();
            //            bn.mabn = joBenhNhan.GetValue("mabn").ToString();
            //            bn.hoten = joBenhNhan.GetValue("hoten").ToString();
            //            bn.ngaysinh = joBenhNhan.GetValue("ngaysinh").ToString();
            //            bn.gioitinh = joBenhNhan.GetValue("gioitinh").ToString();
            //            bn.diachi = joBenhNhan.GetValue("diachi").ToString();
            //            bn.maxa = joBenhNhan.GetValue("maxa").ToString();
            //            lstBenhNhan.Add(bn);
            //        }
            //        return View(lstBenhNhan);
            //    }
            //}

            return View(db.BenhNhans.ToList());
        }

        // GET: Benhnhans/Details/5
        public ActionResult Details(string mabn)
        {
            if (mabn == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benhnhan benhnhan = db.BenhNhans.Find(mabn);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        // GET: Benhnhans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benhnhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mabn,hoten,ngaysinh,gioitinh,cmnd,diachi,maxa")] Benhnhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                db.BenhNhans.Add(benhnhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benhnhan);
        }

        // GET: Benhnhans/Edit/5
        public ActionResult Edit(string mabn)
        {
            if (mabn == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benhnhan benhnhan = db.BenhNhans.Find(mabn);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        // POST: Benhnhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mabn,hoten,ngaysinh,gioitinh,cmnd,diachi,maxa")] Benhnhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benhnhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benhnhan);
        }

        // GET: Benhnhans/Delete/5
        public ActionResult Delete(string mabn)
        {
            if (mabn == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benhnhan benhnhan = db.BenhNhans.Find(mabn);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        // POST: Benhnhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string mabn)
        {
            Benhnhan benhnhan = db.BenhNhans.Find(mabn);
            db.BenhNhans.Remove(benhnhan);
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
