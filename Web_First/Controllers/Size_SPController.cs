using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_First.Data;
using Web_First.Models;

namespace Web_First.Controllers
{

    public class Size_SPController : Controller
    {
        private readonly MvcSPContext _context;

        public Size_SPController(MvcSPContext context)
        {
            _context = context;
        }

        // GET: Size_SP
        public async Task<IActionResult> Index()
        {
            return View(await _context.Size_SP.ToListAsync());
        }

        // GET: Size_SP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size_SP = await _context.Size_SP
                .FirstOrDefaultAsync(m => m.stt == id);
            if (size_SP == null)
            {
                return NotFound();
            }

            return View(size_SP);
        }

        // GET: Size_SP/Create
        [Authorize]
        public IActionResult Create(string id, string? id1)
        {
            Size_SP Size_SP = new Size_SP();
            if (id == null || id1 == null)
                return NotFound();
            else
            {
                Size_SP.Id_SP = id;
                Size_SP.Id_SP_Option = id1;
            }
            return View(Size_SP);
        }
        [Authorize]
        public IActionResult Create1(string id)
        {
            Size_SP Size_SP = new Size_SP();
            if (id == null)
                return NotFound();
            else
            {
                Size_SP.Id_SP = id;
            }
            return View(Size_SP);
        }
        [Authorize]
        public IActionResult Tao()
        {
            return View();
        }

        // POST: Size_SP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("stt,Id_SP,Id_SP_Option,Size,sl")] Size_SP size_SP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(size_SP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(size_SP);
        }
        [Authorize]
        // GET: Size_SP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size_SP = await _context.Size_SP.FindAsync(id);
            if (size_SP == null)
            {
                return NotFound();
            }
            return View(size_SP);
        }

        // POST: Size_SP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("stt,Id_SP,Id_SP_Option,Size,sl")] Size_SP size_SP)
        {
            if (id != size_SP.stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(size_SP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Size_SPExists(size_SP.stt))
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
            return View(size_SP);
        }

        // GET: Size_SP/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size_SP = await _context.Size_SP
                .FirstOrDefaultAsync(m => m.stt == id);
            if (size_SP == null)
            {
                return NotFound();
            }

            return View(size_SP);
        }

        // POST: Size_SP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var size_SP = await _context.Size_SP.FindAsync(id);
            _context.Size_SP.Remove(size_SP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Size_SPExists(int id)
        {
            return _context.Size_SP.Any(e => e.stt == id);
        }
    }
}
