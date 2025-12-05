using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VermutClub.Data;
using VermutClub.Models;

namespace VermutClub.Controllers
{
    public class SubscriptionRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubscriptionRequest
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubscriptionRequests.ToListAsync());
        }

        // GET: SubscriptionRequest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionRequest = await _context.SubscriptionRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionRequest == null)
            {
                return NotFound();
            }

            return View(subscriptionRequest);
        }

        // GET: SubscriptionRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionRequest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Phone,Plan,CreatedAt,Adress,EsRegalo")] SubscriptionRequest subscriptionRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscriptionRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscriptionRequest);
        }

        // GET: SubscriptionRequest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionRequest = await _context.SubscriptionRequests.FindAsync(id);
            if (subscriptionRequest == null)
            {
                return NotFound();
            }
            return View(subscriptionRequest);
        }

        // POST: SubscriptionRequest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Phone,Plan,CreatedAt,Adress,EsRegalo")] SubscriptionRequest subscriptionRequest)
        {
            if (id != subscriptionRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriptionRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionRequestExists(subscriptionRequest.Id))
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
            return View(subscriptionRequest);
        }

        // GET: SubscriptionRequest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriptionRequest = await _context.SubscriptionRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscriptionRequest == null)
            {
                return NotFound();
            }

            return View(subscriptionRequest);
        }

        // POST: SubscriptionRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriptionRequest = await _context.SubscriptionRequests.FindAsync(id);
            if (subscriptionRequest != null)
            {
                _context.SubscriptionRequests.Remove(subscriptionRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionRequestExists(int id)
        {
            return _context.SubscriptionRequests.Any(e => e.Id == id);
        }
    }
}
