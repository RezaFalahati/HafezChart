using HafezChart.Models;
using Microsoft.EntityFrameworkCore;

namespace HafezChart.Data
{
    public class TomorrowHeratDollarContext : DbContext
    {
        public TomorrowHeratDollarContext(DbContextOptions<TomorrowHeratDollarContext> options)
            : base(options)
        {
        }

        public DbSet<TomorrowHeratDollar> TomorrowHeratDollar { get; set; }
    }
}