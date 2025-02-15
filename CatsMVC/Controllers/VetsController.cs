using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.DTOs;
using CatsMVC.Services.Abstractions;

namespace CatsMVC.Controllers
{
    public class VetsController : Controller
    {
        private readonly IVetService _vetService;

        public VetsController(IVetService vetService)
        {
            _vetService = vetService;
        }

        // GET: Vets
        public async Task<IActionResult> Index()
        {
            return View(await _vetService.GetAllAsync());
        }

        // GET: Vets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _vetService.GetByIdAsync(id.Value);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }

        // GET: Vets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id")] VetDTO vetDto)
        {
            if (ModelState.IsValid)
            {
                await _vetService.CreateAsync(vetDto);
                return RedirectToAction(nameof(Index));
            }
            return View(vetDto);
        }

        // GET: Vets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _vetService.GetByIdAsync(id.Value);
            if (vet == null)
            {
                return NotFound();
            }
            return View(vet);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id")] VetDTO vetDto)
        {
            if (id != vetDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vetService.UpdateAsync(vetDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await VetExistsAsync(vetDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vetDto);
        }

        // GET: Vets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _vetService.GetByIdAsync(id.Value);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vetService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VetExistsAsync(int id)
        {
            return (await _vetService.GetByIdAsync(id)) != null;
        }
    }
}
