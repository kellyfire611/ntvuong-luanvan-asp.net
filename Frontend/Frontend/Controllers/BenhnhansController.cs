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
            //TODO: update to new schema KEY, RECORD (not finish)
            string dataFilePath = Server.MapPath("~/App_Data/danhsach.json");
            JArray jaRoot = JArray.Parse(System.IO.File.ReadAllText(dataFilePath));
            if (jaRoot != null)
            {
                List<Benhnhan> lstBenhNhan = new List<Benhnhan>();
                foreach (JObject joBenhNhan in jaRoot)
                {
                    string key = joBenhNhan["Key"].Value<string>();
                    JObject joRecord = joBenhNhan["Record"] as JObject;
                    if(joRecord != null)
                    {
                        Benhnhan bn = new Benhnhan();
                        bn.mabn = joRecord.GetValue("mabn").ToString();
                        bn.hoten = joRecord.GetValue("hoten").ToString();
                        bn.ngaysinh = joRecord.GetValue("ngaysinh").ToString();
                        bn.gioitinh = joRecord.GetValue("gioitinh").ToString();
                        bn.diachi = joRecord.GetValue("diachi").ToString();
                        bn.maxa = joRecord.GetValue("maxa").ToString();
                        bn.cmnd = joRecord.GetValue("cmnd").ToString();
                        bn.ba = joRecord.GetValue("ba").ToString();

                        // Insert or Update to database
                        Benhnhan bnInDatabase = db.BenhNhans.Find(bn.mabn);
                        if(bnInDatabase == null)
                        {
                            db.BenhNhans.Add(bn);
                        } else
                        {
                            bnInDatabase.mabn = bn.mabn;
                            bnInDatabase.hoten = bn.hoten;
                            bnInDatabase.ngaysinh = bn.ngaysinh;
                            bnInDatabase.gioitinh = bn.gioitinh;
                            bnInDatabase.diachi = bn.diachi;
                            bnInDatabase.maxa = bn.maxa;
                            bnInDatabase.cmnd = bn.cmnd;
                            bnInDatabase.ba = bn.ba;
                        }
                    }
                }
            }

            db.SaveChanges();
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

            ChiTietBenhAn chitietBenhAn = null;
            if (!String.IsNullOrEmpty(benhnhan.ba))
            {
                string baDecode = Base64Decode(benhnhan.ba);
                chitietBenhAn = JsonConvert.DeserializeObject<ChiTietBenhAn>(baDecode);
                ViewBag.ChiTietBenhAn = chitietBenhAn;
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

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
