using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wiseapp.Business;
using wiseapp.Service;

namespace wiseapp.Controllers
{
    public class PeopleController : Controller
    {
        IPersonService _PersonService;
        ICountryService _CountryService;

        public PeopleController(IPersonService PersonService, ICountryService CountryService)
        {
            _PersonService = PersonService;
            _CountryService = CountryService;
        }

        // GET: People
        public ActionResult Index()
        {
            return View(_PersonService.GetAll());
        }

        // GET: People/Details/5
        public ActionResult Details(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,State,CountryId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                _PersonService.Create(person);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(long id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,State,CountryId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                _PersonService.Update(person);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Person person = _PersonService.GetById(id);
            _PersonService.Delete(person);
            return RedirectToAction("Index");
        }

        
    }
}
