using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ligjerata_7___xhelali2.Data;
using Ligjerata_7___xhelali2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ligjerata_7___xhelali2.Controllers
{
    [Authorize]
    public class MesuesisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MesuesisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mesuesis
        public async Task<IActionResult> Index(int pg = 1)
        {
            //return View(await _context.Mesuesi.ToListAsync());


            List<Mesuesi> mesuesi= _context.Mesuesi.ToList();

            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = mesuesi.Count();
            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = mesuesi.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            //return View(await _context.Students.ToListAsync());
            return View(data);
        }


       


        // GET: Mesuesis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (mesuesi == null)
            {
                return NotFound();
            }

            return View(mesuesi);
        }

        // GET: Mesuesis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesuesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Surname,Photo, Image")] Mesuesi mesuesi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesuesi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesuesi);
        }

        // GET: Mesuesis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi.FindAsync(id);
            if (mesuesi == null)
            {
                return NotFound();
            }
            return View(mesuesi);
        }

        // POST: Mesuesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Surname,Photo")] Mesuesi mesuesi)
        {
            if (id != mesuesi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesuesi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesuesiExists(mesuesi.id))
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
            return View(mesuesi);
        }

        // GET: Mesuesis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mesuesi == null)
            {
                return NotFound();
            }

            var mesuesi = await _context.Mesuesi
                .FirstOrDefaultAsync(m => m.id == id);
            if (mesuesi == null)
            {
                return NotFound();
            }

            return View(mesuesi);
        }

        // POST: Mesuesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mesuesi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mesuesi'  is null.");
            }
            var mesuesi = await _context.Mesuesi.FindAsync(id);
            if (mesuesi != null)
            {
                _context.Mesuesi.Remove(mesuesi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesuesiExists(int id)
        {
          return _context.Mesuesi.Any(e => e.id == id);
        }
    }
}
