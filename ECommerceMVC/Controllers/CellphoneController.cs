using ECommerceMVC.Models;
using ECommerceMVC.Services;
using ECommerceMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class CellPhoneController : Controller
    {
        private readonly ICellphoneService cellphoneService;

        public CellPhoneController(ICellphoneService cellphoneService)
        {
            this.cellphoneService = cellphoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cellphones = await cellphoneService.GetAllAsync();
            return View(cellphones);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cellphone cellphone)
        {
            if (ModelState.IsValid)
            {
                await cellphoneService.CreateAsync(cellphone);
                return RedirectToAction(nameof(Index));
            }
            return View(cellphone);
        }
        public async Task<ActionResult> Details(int id)
        {
            var cellphone = await cellphoneService.GetByIdAsync(id);
            if (cellphone == null)
            {
                return NotFound();
            }
            return View(cellphone);
        }
        public async Task<ActionResult> Delete(int id)
        {
            var cellphone = await cellphoneService.GetByIdAsync(id);
            if (cellphone == null)
            {
                return NotFound();
            }
            return View(cellphone);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await cellphoneService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
