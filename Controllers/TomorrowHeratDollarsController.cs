using System.Linq;
using System.Threading.Tasks;
using HafezChart.Data;
using HafezChart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HafezChart.Controllers
{
    public class TomorrowHeratDollarsController : Controller
    {
        private readonly TomorrowHeratDollarContext _context;

        public TomorrowHeratDollarsController(TomorrowHeratDollarContext context)
        {
            _context = context;
        }

        // GET: TomorrowHeratDollars
        public async Task<IActionResult> Index()
        {
            return View(await _context.TomorrowHeratDollar.OrderByDescending(item => item.Date).Take(500).ToListAsync());
        }

        // GET: TomorrowHeratDollars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowHeratDollar = await _context.TomorrowHeratDollar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomorrowHeratDollar == null) return NotFound();

            return View(tomorrowHeratDollar);
        }

        // GET: TomorrowHeratDollars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TomorrowHeratDollars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MessageId,Date,Price,MessageText,Remark")]
            TomorrowHeratDollar tomorrowHeratDollar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tomorrowHeratDollar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tomorrowHeratDollar);
        }

        // GET: TomorrowHeratDollars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowHeratDollar = await _context.TomorrowHeratDollar.FindAsync(id);
            if (tomorrowHeratDollar == null) return NotFound();
            return View(tomorrowHeratDollar);
        }

        // POST: TomorrowHeratDollars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MessageId,Date,Price,MessageText,Remark")]
            TomorrowHeratDollar tomorrowHeratDollar)
        {
            if (id != tomorrowHeratDollar.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tomorrowHeratDollar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TomorrowHeratDollarExists(tomorrowHeratDollar.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tomorrowHeratDollar);
        }

        // GET: TomorrowHeratDollars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowHeratDollar = await _context.TomorrowHeratDollar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomorrowHeratDollar == null) return NotFound();

            return View(tomorrowHeratDollar);
        }

        // POST: TomorrowHeratDollars/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tomorrowHeratDollar = await _context.TomorrowHeratDollar.FindAsync(id);
            _context.TomorrowHeratDollar.Remove(tomorrowHeratDollar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TomorrowHeratDollarExists(int id)
        {
            return _context.TomorrowHeratDollar.Any(e => e.Id == id);
        }
    }
}