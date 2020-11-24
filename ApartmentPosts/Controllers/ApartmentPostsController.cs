using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentPosts.Data;
using ApartmentPosts.Models;

namespace ApartmentPosts.Controllers
{
    public class ApartmentPostsController : Controller
    {
        private readonly ApartmentPostsContext _context;

        public ApartmentPostsController(ApartmentPostsContext context)
        {
            _context = context;
        }

        // GET: ApartmentPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApartmentPost.ToListAsync());
        }

        // GET: ApartmentPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPost = await _context.ApartmentPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartmentPost == null)
            {
                return NotFound();
            }

            return View(apartmentPost);
        }

        // GET: ApartmentPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApartmentPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,MonthlyRent,Sqm,NumberOfRooms")] ApartmentPost apartmentPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartmentPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartmentPost);
        }

        // GET: ApartmentPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPost = await _context.ApartmentPost.FindAsync(id);
            if (apartmentPost == null)
            {
                return NotFound();
            }
            return View(apartmentPost);
        }

        // POST: ApartmentPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,MonthlyRent,Sqm,NumberOfRooms")] ApartmentPost apartmentPost)
        {
            if (id != apartmentPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentPostExists(apartmentPost.Id))
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
            return View(apartmentPost);
        }

        // GET: ApartmentPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentPost = await _context.ApartmentPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartmentPost == null)
            {
                return NotFound();
            }

            return View(apartmentPost);
        }

        // POST: ApartmentPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartmentPost = await _context.ApartmentPost.FindAsync(id);
            _context.ApartmentPost.Remove(apartmentPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentPostExists(int id)
        {
            return _context.ApartmentPost.Any(e => e.Id == id);
        }
    }
}
