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

    public class CarsController : Controller
    {
        private readonly CarService _carService;

        public CarsController(CarService _carService)
        {
            this._carService = _carService;
        }

        // GET: CarController
        public ActionResult Index()
        {
            return View(_carService.Get());
        }

        // GET: CarController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Create(car);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _carService.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = _carService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                _carService.Remove(car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
