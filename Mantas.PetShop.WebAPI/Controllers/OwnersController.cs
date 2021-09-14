using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantas.PetShop.WebAPI.Controllers
{
    public class OwnersController : Controller
    {
        // GET: Owners
        public ActionResult Index()
        {
            return null;
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            return null;
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return null;
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int id)
        {
            return null;
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int id)
        {
            return null;
        }

        // POST: Owners/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return null;
            }
        }
    }
}