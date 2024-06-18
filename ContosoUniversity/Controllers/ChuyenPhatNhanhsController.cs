using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class ChuyenPhatNhanhsController : Controller
    {
        private readonly SchoolContext _context;

        public ChuyenPhatNhanhsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: ChuyenPhatNhanhs
        public async Task<IActionResult> Index(string searchString)
        {
            var result = new List<ChuyenPhatNhanh>();
            var query = _context.ChuyenPhatNhanh.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.TenNguoiNhan.Contains(searchString)
                                                                || x.DiaChiNguoiNhan.Contains(searchString)
                                                                || x.SdtNguoiNhan.Contains(searchString)
                                                                || x.ChuyenPhatNhanhID.ToString().Contains(searchString));
            }
            result = await query.ToListAsync();
            return _context.ChuyenPhatNhanh != null ? 
                          View(result) :
                          Problem("Entity set 'SchoolContext.ChuyenPhatNhanh'  is null.");
        }

        public async Task<IActionResult> cau_3()
        {
            if(_context.ChuyenPhatNhanh == null)    return Problem("Entity set 'SchoolContext.ChuyenPhatNhanh'  is null.");
            var result = new List<ChuyenPhatNhanh>();
            result = await _context.ChuyenPhatNhanh.Where(x => x.TinhTrang == (int)ETinhTrang.HoanThanh).ToListAsync();
            var groupNhanVien = result.GroupBy(x => x.MaNhanVien).Select(x => new LietKe
            {
                MaNhanVien = x.Key,
                TongTien = x.Sum(a => a.TienCuoc.Value)
            });
            return _context.ChuyenPhatNhanh != null ?
                        View(groupNhanVien) :
                        Problem("Entity set 'SchoolContext.ChuyenPhatNhanh'  is null.");
        }


        // GET: ChuyenPhatNhanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChuyenPhatNhanh == null)
            {
                return NotFound();
            }

            var chuyenPhatNhanh = await _context.ChuyenPhatNhanh
                .FirstOrDefaultAsync(m => m.ChuyenPhatNhanhID == id);
            if (chuyenPhatNhanh == null)
            {
                return NotFound();
            }

            return View(chuyenPhatNhanh);
        }

        // GET: ChuyenPhatNhanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChuyenPhatNhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChuyenPhatNhanhID,TenNguoiGui,NgayGui,SdtNguoiGui,TenNguoiNhan,SdtNguoiNhan,DiaChiNguoiNhan,TienCuoc,TinhTrang,MaNhanVien")] ChuyenPhatNhanh chuyenPhatNhanh)
        {
            if (ModelState.IsValid)
            {
                chuyenPhatNhanh.TinhTrang = (int)ETinhTrang.MoiTiepNhan;
                _context.Add(chuyenPhatNhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chuyenPhatNhanh);
        }

        // GET: ChuyenPhatNhanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChuyenPhatNhanh == null)
            {
                return NotFound();
            }

            var chuyenPhatNhanh = await _context.ChuyenPhatNhanh.FindAsync(id);
            if (chuyenPhatNhanh == null)
            {
                return NotFound();
            }
            return View(chuyenPhatNhanh);
        }

        // POST: ChuyenPhatNhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChuyenPhatNhanhID,TenNguoiGui,NgayGui,SdtNguoiGui,TenNguoiNhan,SdtNguoiNhan,DiaChiNguoiNhan,TienCuoc,TinhTrang,MaNhanVien")] ChuyenPhatNhanh chuyenPhatNhanh)
        {
            if (id != chuyenPhatNhanh.ChuyenPhatNhanhID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyenPhatNhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyenPhatNhanhExists(chuyenPhatNhanh.ChuyenPhatNhanhID))
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
            return View(chuyenPhatNhanh);
        }

        // GET: ChuyenPhatNhanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChuyenPhatNhanh == null)
            {
                return NotFound();
            }

            var chuyenPhatNhanh = await _context.ChuyenPhatNhanh
                .FirstOrDefaultAsync(m => m.ChuyenPhatNhanhID == id);
            if (chuyenPhatNhanh == null)
            {
                return NotFound();
            }

            return View(chuyenPhatNhanh);
        }

        // POST: ChuyenPhatNhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChuyenPhatNhanh == null)
            {
                return Problem("Entity set 'SchoolContext.ChuyenPhatNhanh'  is null.");
            }
            var chuyenPhatNhanh = await _context.ChuyenPhatNhanh.FindAsync(id);
            if (chuyenPhatNhanh != null)
            {
                _context.ChuyenPhatNhanh.Remove(chuyenPhatNhanh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuyenPhatNhanhExists(int id)
        {
          return (_context.ChuyenPhatNhanh?.Any(e => e.ChuyenPhatNhanhID == id)).GetValueOrDefault();
        }
    }
}
