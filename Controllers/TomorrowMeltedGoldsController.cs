using System.Linq;
using System.Threading.Tasks;
using HafezChart.Data;
using HafezChart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HafezChart.Controllers
{
    public class TomorrowMeltedGoldsController : Controller
    {
        private readonly TomorrowMeltedGoldContext _context;

        public TomorrowMeltedGoldsController(TomorrowMeltedGoldContext context)
        {
            _context = context;
        }

        // GET: TomorrowMeltedGolds
        public async Task<IActionResult> Index()
        {
            return View(await _context.TomorrowMeltedGold.OrderByDescending(item => item.Date).Take(500).ToListAsync());
        }

        // GET: TomorrowMeltedGolds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowMeltedGold = await _context.TomorrowMeltedGold
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomorrowMeltedGold == null) return NotFound();

            return View(tomorrowMeltedGold);
        }

        // GET: TomorrowMeltedGolds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TomorrowMeltedGolds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MessageId,Date,Price,MessageText,Remark")]
            TomorrowMeltedGold tomorrowMeltedGold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tomorrowMeltedGold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tomorrowMeltedGold);
        }

        // GET: TomorrowMeltedGolds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowMeltedGold = await _context.TomorrowMeltedGold.FindAsync(id);
            if (tomorrowMeltedGold == null) return NotFound();
            return View(tomorrowMeltedGold);
        }

        // POST: TomorrowMeltedGolds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MessageId,Date,Price,MessageText,Remark")]
            TomorrowMeltedGold tomorrowMeltedGold)
        {
            if (id != tomorrowMeltedGold.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tomorrowMeltedGold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TomorrowMeltedGoldExists(tomorrowMeltedGold.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tomorrowMeltedGold);
        }

        // GET: TomorrowMeltedGolds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tomorrowMeltedGold = await _context.TomorrowMeltedGold
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tomorrowMeltedGold == null) return NotFound();

            return View(tomorrowMeltedGold);
        }

        // POST: TomorrowMeltedGolds/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tomorrowMeltedGold = await _context.TomorrowMeltedGold.FindAsync(id);
            _context.TomorrowMeltedGold.Remove(tomorrowMeltedGold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TomorrowMeltedGoldExists(int id)
        {
            return _context.TomorrowMeltedGold.Any(e => e.Id == id);
        }
    }
}