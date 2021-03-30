using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
    public class ClientController : Controller
    {

        private readonly ClientService _clientService;

        public ClientController(ClientService _clientService)
        {
            this._clientService = _clientService;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View(_clientService.Get());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.Create(client);
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _clientService.Update(id, client);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(client);
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = _clientService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _clientService.Remove(car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
