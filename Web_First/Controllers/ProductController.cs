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
using X.PagedList;

namespace Web_First.Controllers
{

    public class ProductController : Controller
    {
        private readonly MvcSPContext _context;

        public ProductController(MvcSPContext context)
        {
            _context = context;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Seach(string searchString, int? page)
        {
            var pageNumber = page ?? 1;
            var movies = from m in _context.all
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Name_SP.Contains(searchString));
                ViewBag.Result = searchString;
            }
            else
            {
                ViewBag.Result = null;
            }    
            ViewBag.Seach = searchString;
            return View( movies.ToPagedList(pageNumber, 60));
        }
        public async Task<IActionResult> Add_SP()
        {

            return View();
        }

        public async Task<IActionResult> Show_SP()
        {
            var tt = await _context.ThongSo_SP.GroupBy(a => a.Id_SP).Select(group => new String[]
            { group.Key,group.Count().ToString(), group.Sum(a=>a.SL_co).ToString()
            }).ToListAsync();
            ViewBag.tt = tt;

            var sp = from b in _context.all
                     select b;
            ViewBag.sp = sp;
            return View();
        }
        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.San_Pham.ToListAsync());
        }

        // select ThongSo_SP.Id_SP,ThongSo_SP.Id_SP_Option,ThongSo_SP.Loai_SP,ThongSo_SP.Image_SP_Option,Size_SP.Size,Size_SP.sl from ThongSo_SP inner join Size_SP on ThongSo_SP.Id_SP_Option=Size_SP.Id_SP_Option
        public class Thong_So
        {
            public string Id_SP { get; set; }

            public string Id_SP_Option { get; set; }
            public string Loai_SP { get; set; }
            public string Image_SP_Option { get; set; }
            public string Size { get; set; }
            public int sl { get; set; }
            public Thong_So(string m, string n, string i, string l, string im, int t)
            {
                Id_SP = m;
                Id_SP_Option = n;
                Loai_SP = i;
                Image_SP_Option = l;
                Size = im;
                sl = t;
            }
        }
        public async Task<IActionResult> ChiTiet(string id)
        {
            var ct_sp = from a in _context.ThongSo_SP
                        join b in _context.Size_SP on a.Id_SP_Option equals b.Id_SP_Option
                        where a.Id_SP == id
                        select new Thong_So
                        (
                            a.Id_SP,
                            a.Id_SP_Option,
                            a.Loai_SP,
                            a.Image_SP_Option,
                            b.Size,
                            b.sl
                        );
            var size_show = from a in _context.ThongSo_SP
                            join b in _context.Size_SP on a.Id_SP_Option equals b.Id_SP_Option
                            where a.Id_SP == id
                            group a by a.Loai_SP into g
                            select g.Key;
            var color_show = from a in _context.ThongSo_SP
                             join b in _context.Size_SP on a.Id_SP_Option equals b.Id_SP_Option
                             where a.Id_SP == id
                             group b by b.Size into g
                             select g.Key;

            ViewBag.ss = size_show;
            ViewBag.cs = color_show;
            foreach (var item in ct_sp)
            {
                Console.WriteLine("" + item.Size + "," + item.Loai_SP + "");
            }

            ViewBag.ts = ct_sp;
            if (id == null)
            {
                return NotFound();
            }

            var san_Pham = await _context.San_Pham
                .FirstOrDefaultAsync(m => m.Id_SP == id);
            if (san_Pham == null)
            {
                return NotFound();
            }
            // sale
            var products = (from a in _context.San_Pham_Sale
                            select a).Take(20);
            ViewBag.SP_Sale = products.ToPagedList(1, 20);
            // image

            var img = from a in _context.ThongSo_SP
                      where a.Id_SP == id
                      select a;
            ViewBag.Img_ts = img;
            var img1 = from a in _context.all
                       where a.Id_SP == id
                       select a;
            ViewBag.Img_ts1 = img1;
            var size = from b in _context.Size_SP
                       where b.Id_SP == id
                       group b by b.Size into g
                       select g.Key;
            ViewBag.Img_ts2 = size;
            var cart = from a in _context.San_Pham
                       group a by a.Loai_SP_2 into g
                       select g.Key;
            ViewBag.LoaiSP = cart;
            var cart1 = from b in _context.San_Pham
                        group b by b.Loai_SP_1 into h
                        select h.Key;
            ViewBag.LoaiSP2 = cart1;



            return View(san_Pham);
        }
        // GET: Product/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var san_Pham = await _context.San_Pham
                .FirstOrDefaultAsync(m => m.Id_SP == id);
            if (san_Pham == null)
            {
                return NotFound();
            }
            // sale
            var products = (from a in _context.San_Pham_Sale
                            select a).Take(20);
            ViewBag.SP_Sale = products.ToPagedList(1, 20);
            // image

            var img = from a in _context.ThongSo_SP
                      where a.Id_SP == id
                      select a;
            ViewBag.Img_ts = img;
            var img1 = from a in _context.all
                       where a.Id_SP == id
                       select a;
            ViewBag.Img_ts1 = img1;
            var size = from b in _context.Size_SP
                       where b.Id_SP == id
                       group b by b.Size into g
                       select g.Key;
            ViewBag.Img_ts2 = size;



            return View(san_Pham);
        }

        // GET: Product/Create

        public async Task<IActionResult> product(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var san_Pham = await _context.San_Pham
                .FirstOrDefaultAsync(m => m.Id_SP == id);
            var cart = from a in _context.San_Pham
                       group a by a.Loai_SP_2 into g
                       select g.Key;
            ViewBag.LoaiSP = cart;
            var cart1 = from b in _context.San_Pham
                        group b by b.Loai_SP_1 into h
                        select h.Key;
            ViewBag.LoaiSP2 = cart1;
            if (san_Pham == null)
            {
                return NotFound();
            }

            return View(san_Pham);
        }

        [Authorize]
        public IActionResult Create()
        {
            var cart = from a in _context.San_Pham
                       group a by a.Loai_SP_2 into g
                       select g.Key;
            ViewBag.LoaiSP = cart;
            var cart1 = from b in _context.San_Pham
                        group b by b.Loai_SP_1 into h
                        select h.Key;
            ViewBag.LoaiSP2 = cart1;
            return View();
        }


        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id_SP,Loai_SP_1,Loai_SP_2,Name_SP,Price_SP,Mo_Ta,ngay_add,Sale")] San_Pham san_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(san_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction("product", "Product", new { id = san_Pham.Id_SP });
            }
            return View(san_Pham);
        }
        [Authorize]
        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var san_Pham = await _context.San_Pham.FindAsync(id);
            if (san_Pham == null)
            {
                return NotFound();
            }
            return View(san_Pham);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id_SP,Loai_SP_1,Loai_SP_2,Name_SP,Price_SP,Mo_Ta")] San_Pham san_Pham)
        {
            if (id != san_Pham.Id_SP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(san_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!San_PhamExists(san_Pham.Id_SP))
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
            return View(san_Pham);
        }

        // GET: Product/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var san_Pham = await _context.San_Pham
                .FirstOrDefaultAsync(m => m.Id_SP == id);
            if (san_Pham == null)
            {
                return NotFound();
            }

            return View(san_Pham);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var san_Pham = await _context.San_Pham.FindAsync(id);
            _context.San_Pham.Remove(san_Pham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool San_PhamExists(string id)
        {
            return _context.San_Pham.Any(e => e.Id_SP == id);
        }
    }
}
