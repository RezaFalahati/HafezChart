using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HafezChart.Data;
using Highsoft.Web.Mvc.Stocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HafezChart.Controllers
{
    public class TomorrowHeratDollarsChartController : Controller
    {
        private readonly TomorrowHeratDollarContext _context;

        public TomorrowHeratDollarsChartController(TomorrowHeratDollarContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var tomorrowHeratDollarList = await _context.TomorrowHeratDollar.OrderByDescending(item => item.Date)
                .Take(10000).ToListAsync();
            var tomorrowHeratDollarData = tomorrowHeratDollarList.Select(data => new LineSeriesData
            { X = data.Date.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds, Y = data.Price }).ToList();

            ViewBag.TomorrowHeratDollarData = tomorrowHeratDollarData.OrderBy(o => o.X).ToList();

            return View(ViewBag);
        }
    }
}