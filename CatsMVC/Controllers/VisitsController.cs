using CatsMVC.DTOs;
using CatsMVC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsMVC.Controllers
{
    public class VisitsController : Controller
    {
        private readonly ICatService _catService;
        private readonly IVetService _vetService;

        public VisitsController(ICatService catService, IVetService vetService)
        {
            _catService = catService;
            _vetService = vetService;
        }

        public async Task<IActionResult> Create()
        {
            var catVisitDto = new CreateCatVisitDTO()
            {
                VisitDate = DateTime.Now,
                Cats = (await _catService.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList(),
                Vets = (await _vetService.GetAllAsync())
                .Select(vet => new SelectListItem { Value = vet.Id.ToString(), Text = $"{vet.FirstName} {vet.LastName}" })
                .ToList()
            };

            return View(catVisitDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CatVisitDTO catVisitDto)
        {
            if (ModelState.IsValid)
            {
                await _catService.AddCatVisitAsync(catVisitDto);

                return RedirectToAction("Index", "Cats");
            }
            return View(catVisitDto);
        }

    }
}
