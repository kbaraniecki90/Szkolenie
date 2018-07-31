using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Szkolenie.Helpers;
using Szkolenie.Models;

namespace Szkolenie.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string decryptedId;
            try
            {
                decryptedId = Encryption.decrypt(id);
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

            
            int decryptedIntId = Convert.ToInt32(decryptedId);

            Client client = db.Clients.Find(decryptedIntId);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Login,Data,ProblemDetails,Email,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                var lastClientId = client.Id;
                var encryptedId = Encryption.encrypt(lastClientId.ToString());

                MailMessage email = new MailMessage();
                email.From = new MailAddress("szkolenie@asystent-unijny.pl");

                MailAddress recipient = new MailAddress(client.Email);

                List<MailAddress> recipients = new List<MailAddress>();
                recipients.Add(recipient);

                email.To.Add(recipient);
                email.Subject = "Potwierdzenie rejstracji zgłoszenia";
                email.Body = "<br>Twój link to: </br> <a href='http://localhost:54655/Clients/Details/" + encryptedId + "'>Kliknij tutaj by zobaczyć zgłoszenie </a>";
                email.BodyEncoding = System.Text.Encoding.UTF8;
                email.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(email);

                return RedirectToAction("Thanks");
            }

            return View(client);
        }

        public ActionResult Thanks()
        {
            return View();
        }

        // GET: Clients/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Login,Data,ProblemDetails,Email,Phone,FixDetails,FixData,IsFixed")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
