using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatsMVC.Data;
using CatsMVC.Data.Entities;
using CatsMVC.Services.Abstractions;
using CatsMVC.DTOs;

namespace CatsMVC.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            _catService = catService;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
            return View(await _catService.GetAllAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Breed,ImageUrl")] CatDTO catDto)
        {
            if (ModelState.IsValid)
            {
                await _catService.CreateAsync(catDto);
                return RedirectToAction(nameof(Index));
            }
            return View(catDto);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Breed,ImageUrl")] CatDTO catDto)
        {
            if (id != catDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _catService.UpdateAsync(catDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CatExistsAsync(catDto.Id))
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
            return View(catDto);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _catService.GetByIdAsync(id.Value);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _catService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CatExistsAsync(int id)
        {
            var item = await _catService.GetByIdAsync(id);
            return item != null;
        }
    }
}
