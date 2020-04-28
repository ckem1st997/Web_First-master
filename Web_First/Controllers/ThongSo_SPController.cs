using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_First.Data;
using Web_First.Models;

namespace Web_First.Controllers
{
    public class ThongSo_SPController : Controller
    {
        private readonly MvcSPContext _context;

        public ThongSo_SPController(MvcSPContext context)
        {
            _context = context;
        }

        // GET: ThongSo_SP
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThongSo_SP.ToListAsync());
        }

        // GET: ThongSo_SP/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongSo_SP = await _context.ThongSo_SP
                .FirstOrDefaultAsync(m => m.Image_SP_Option == id);
            if (thongSo_SP == null)
            {
                return NotFound();
            }

            return View(thongSo_SP);
        }

        // GET: ThongSo_SP/Create
        public IActionResult Create(string id)
        {
            ThongSo_SP thongSo_SP = new ThongSo_SP();
            if (id == null)
                return NotFound();
            else
                thongSo_SP.Id_SP = id;
            return View(thongSo_SP);
        }

        // POST: ThongSo_SP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_SP,Id_SP_Option,Loai_SP,Size,SL_co,Ngay_ADD,Image_SP_Option")] ThongSo_SP thongSo_SP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongSo_SP);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Size_SP", new { id = thongSo_SP.Id_SP, id1 = thongSo_SP.Id_SP_Option });
            }
            return View(thongSo_SP);
        }

        // GET: ThongSo_SP/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            id = id.Replace("%2F", "/");
            var thongSo_SP = await _context.ThongSo_SP.FindAsync(id);
            if (thongSo_SP == null)
            {
                return NotFound();
            }
            ViewBag.image = thongSo_SP.Image_SP_Option;
            return View(thongSo_SP);
        }

        // POST: ThongSo_SP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id_SP,Id_SP_Option,Loai_SP,Size,SL_co,Ngay_ADD,Image_SP_Option")] ThongSo_SP thongSo_SP)
        {
            id = id.Replace("%252F", "/");
            // viết bằng ajax
            if (id != thongSo_SP.Image_SP_Option)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongSo_SP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongSo_SPExists(thongSo_SP.Image_SP_Option))
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
            return View(thongSo_SP);
        }

        // GET: ThongSo_SP/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongSo_SP = await _context.ThongSo_SP
                .FirstOrDefaultAsync(m => m.Image_SP_Option == id);
            if (thongSo_SP == null)
            {
                return NotFound();
            }

            return View(thongSo_SP);
        }

        // POST: ThongSo_SP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thongSo_SP = await _context.ThongSo_SP.FindAsync(id);
            _context.ThongSo_SP.Remove(thongSo_SP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongSo_SPExists(string id)
        {
            return _context.ThongSo_SP.Any(e => e.Image_SP_Option == id);
        }

        [HttpPost]
        public JsonResult Check_Id(string id, string loai)
        {
            var cart = from a in _context.ThongSo_SP
                       where a.Id_SP == id && a.Loai_SP == loai
                       select a.Id_SP_Option;
            var result = false;
            if (cart.Count() > 0)
                result = true;
            else
                result = false;
            return Json(new
            {
                cart,
                id,
                loai,
                result
            });

        }

        [HttpPost]
        public JsonResult Check_sl(string id)
        {
            var cart = from a in _context.Size_SP
                       where a.Id_SP_Option == id
                       select a;
            var result = false;
            if (cart.Count() > 0)
                result = true;
            else
                result = false;
            return Json(new
            {
                cart,
                id,
                result
            });

        }


        [HttpPost]
        public JsonResult Check_Size_Null(string id, string id_sp)
        {
            // Viet Sub By Hợp nha!!
            var cart = from a in _context.Size_SP
                       where a.Id_SP == id && !(
                       from b in _context.Size_SP
                       where b.Id_SP_Option == id_sp
                       select b.Size).Contains(a.Size)
                       group a by a.Size into g
                       select g.Key;
            var result = false;
            if (cart.Count() > 0)
                result = true;
            else
                result = false;
            return Json(new
            {
                cart,
                id,
                id_sp,
                result
            });

        }
        [HttpPost]
        public JsonResult Edit_ThongSo(string id_op, string cl, string size, int sl, DateTime ngay, string img, string ss)
        {
            var cart = _context.ThongSo_SP.FirstOrDefault(a => a.Image_SP_Option == ss);
            cart.Id_SP_Option = id_op;
            cart.Loai_SP = cl;
            cart.Size = size;
            cart.SL_co = sl;
            cart.Ngay_ADD = ngay;
            cart.Image_SP_Option = img;
            var result = false;
            if (cart != null)
            {
                try
                {
                    _context.Update(cart);
                    _context.SaveChangesAsync();
                    result = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    result = false;
                }
            }
            else
                result = false;
            return Json(new
            {
                ss,
                cart,
                result
            });

        }




    }
}
