using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutomobiliEvidencija.Models;

namespace AutomobiliEvidencija.Controllers
{
    public class AutomobiliController : Controller
    {
        private readonly AutomobiliEvidencijaContext _context;

        public AutomobiliController(AutomobiliEvidencijaContext context)
        {
            _context = context;
        }

        // GET: Automobili
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automobil.ToListAsync());
        }

        // GET: Automobili/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.ID == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobili/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automobili/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Marka,Model,Godina,KonjskaSnaga")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automobil);
        }

        // GET: Automobili/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        // POST: Automobili/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Marka,Model,Godina,KonjskaSnaga")] Automobil automobil)
        {
            if (id != automobil.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.ID))
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
            return View(automobil);
        }

        // GET: Automobili/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.ID == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Automobili/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobil = await _context.Automobil.FindAsync(id);
            _context.Automobil.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobil.Any(e => e.ID == id);
        }
    }
}
