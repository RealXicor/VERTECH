using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VERTECH.Models;

namespace VERTECH.Controllers
{
    public class InquiriesController : Controller
    {
        private readonly InquiriesDatabaseContext _context;

        public InquiriesController(InquiriesDatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult InquireData(Inquiry obj)
        {
            this._context.Inquiries.Add(obj);
            this._context.SaveChanges();

            return View();
        }
        // GET: Inquiries
        public async Task<IActionResult> Index()
        {
              return _context.Inquiries != null ? 
                          View(await _context.Inquiries.ToListAsync()) :
                          Problem("Entity set 'InquiriesDatabaseContext.Inquiries'  is null.");
        }

        // GET: Inquiries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inquiries == null)
            {
                return NotFound();
            }

            var inquiry = await _context.Inquiries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }

        // GET: Inquiries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquiries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,UserEmail,ProductName,ProductPrice,UserMsg")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquiry);
        }

        // GET: Inquiries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inquiries == null)
            {
                return NotFound();
            }

            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }
            return View(inquiry);
        }

        // POST: Inquiries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,UserEmail,ProductName,ProductPrice,UserMsg")] Inquiry inquiry)
        {
            if (id != inquiry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquiry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquiryExists(inquiry.Id))
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
            return View(inquiry);
        }

        // GET: Inquiries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inquiries == null)
            {
                return NotFound();
            }

            var inquiry = await _context.Inquiries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }

        // POST: Inquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inquiries == null)
            {
                return Problem("Entity set 'InquiriesDatabaseContext.Inquiries'  is null.");
            }
            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry != null)
            {
                _context.Inquiries.Remove(inquiry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquiryExists(int id)
        {
          return (_context.Inquiries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
