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
    public class cartController : Controller
    {
        private readonly MvcSPContext _context;

        public cartController(MvcSPContext context)
        {
            _context = context;
        }

        // GET: cart
        public async Task<IActionResult> Index()
        {
            return View(await _context.cart_clone.ToListAsync());
        }

        // GET: cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_clone = await _context.cart_clone
                .FirstOrDefaultAsync(m => m.stt == id);
            if (cart_clone == null)
            {
                return NotFound();
            }

            return View(cart_clone);
        }

        // GET: cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("stt,Id_SP,Name_SP,Price_SP,sl,image_sp,Size,Loai_SP")] cart_clone cart_clone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart_clone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart_clone);
        }

        // GET: cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_clone = await _context.cart_clone.FindAsync(id);
            if (cart_clone == null)
            {
                return NotFound();
            }
            return View(cart_clone);
        }

        // POST: cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("stt,Id_SP,Name_SP,Price_SP,sl,image_sp,Size,Loai_SP")] cart_clone cart_clone)
        {
            if (id != cart_clone.stt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart_clone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cart_cloneExists(cart_clone.stt))
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
            return View(cart_clone);
        }

        // GET: cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart_clone = await _context.cart_clone
                .FirstOrDefaultAsync(m => m.stt == id);
            if (cart_clone == null)
            {
                return NotFound();
            }

            return View(cart_clone);
        }

        // POST: cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart_clone = await _context.cart_clone.FindAsync(id);
            _context.cart_clone.Remove(cart_clone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cart_cloneExists(int id)
        {
            return _context.cart_clone.Any(e => e.stt == id);
        }


        [HttpPost]
        public JsonResult show_sp()
        {
            var cart = from a in _context.cart_clone
                       select a;
            var result = false;
            var sum = 0;
            if (cart.Count() > 0)
            {
                sum = cart.Count();
                result = true;
            }
            else
                result = false;
            return Json(new
            {
                sum,
                cart,
                result
            });

        }

        [HttpPost]
        public JsonResult Add_sp(string id, string name, int price, int sl, string image, string size, string loai)
        {
            cart_clone cart = new cart_clone();
            cart.Id_SP = id;
            cart.Name_SP = name;
            cart.Price_SP = price;
            cart.sl = sl;
            cart.image_sp = image;
            cart.Size = size;
            cart.Loai_SP = loai;
            var result = false;
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                _context.SaveChangesAsync();
                result = true; ;
            }
            else
                result = false;
            return Json(new
            {
                cart,
                result
            });

        }

        [HttpPost]
        public JsonResult Test_sp(string id, string size, string loai)
        {

            var cart = from a in _context.cart_clone
                       where a.Id_SP == id && a.Size == size && a.Loai_SP == loai
                       select a;
            var result = false;
            if (cart.Count() > 0)
            {
                result = true; ;
            }
            else
                result = false;
            return Json(new
            {
                cart,
                result
            });

        }

       
        [HttpPost]
        public JsonResult Update_sp(string id, string size, string loai, int sl, int idsp)
        {
            var cart = _context.cart_clone.FirstOrDefault(a => a.stt == idsp && a.Size == size && a.Id_SP == id && a.Loai_SP == loai);
            cart.sl = sl;
            //  cart.stt = idsp;
            var result = false;
            if (cart!=null)
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
                cart,
                result
            });

        }
        [HttpPost]
        public JsonResult Delete_sp(int id)
        {
            var cart = _context.cart_clone.FirstOrDefault(a => a.stt==id);
            var result = false;
            if (cart != null)
            {
                try
                {
                    _context.Remove(cart);
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
                cart,
                result
            });

        }
       
    }

}
