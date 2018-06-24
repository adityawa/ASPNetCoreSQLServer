using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Controllers
{
    public class MataKuliahsController : Controller
    {
        private readonly DBKuliahDataContext _context;

        public MataKuliahsController(DBKuliahDataContext context)
        {
            _context = context;
        }

        // GET: MataKuliahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MataKuliahs.ToListAsync());
        }

        // GET: MataKuliahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliahs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            return View(mataKuliah);
        }

        // GET: MataKuliahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MataKuliahs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sks")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mataKuliah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mataKuliah);
        }

        // GET: MataKuliahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return NotFound();
            }
            return View(mataKuliah);
        }

        // POST: MataKuliahs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sks")] MataKuliah mataKuliah)
        {
            if (id != mataKuliah.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mataKuliah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MataKuliahExists(mataKuliah.Id))
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
            return View(mataKuliah);
        }

        // GET: MataKuliahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mataKuliah = await _context.MataKuliahs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            return View(mataKuliah);
        }

        // POST: MataKuliahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mataKuliah = await _context.MataKuliahs.FindAsync(id);
            _context.MataKuliahs.Remove(mataKuliah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MataKuliahExists(int id)
        {
            return _context.MataKuliahs.Any(e => e.Id == id);
        }
    }
}
