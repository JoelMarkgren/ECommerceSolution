using ECommerceMVC.Models;
using ECommerceMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class CellphoneController : Controller
    {
        private readonly ICellphoneService cellphoneService;

        // GET: CellphoneController
        public CellphoneController(ICellphoneService cellphoneService)
        {
            this.cellphoneService = cellphoneService;
        }
        public async Task<ActionResult> Index()
        {
            var cellphones = await cellphoneService.GetAllAsync();
            if (cellphones == null)
            {
                return View(new List<Cellphone>());
            }
            return View(cellphones);
        }

        // GET: CellphoneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CellphoneController/Create
        public async Task<ActionResult> Create(Cellphone cellphone)
        {
            cellphone = await cellphoneService.CreateAsync();
            return View(cellphone);
        }

        // POST: CellphoneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CellphoneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CellphoneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CellphoneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CellphoneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
