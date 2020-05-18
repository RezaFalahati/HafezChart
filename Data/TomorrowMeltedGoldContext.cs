using HafezChart.Models;
using Microsoft.EntityFrameworkCore;

namespace HafezChart.Data
{
    public class TomorrowMeltedGoldContext : DbContext
    {
        public TomorrowMeltedGoldContext(DbContextOptions<TomorrowMeltedGoldContext> options)
            : base(options)
        {
        }

        public DbSet<TomorrowMeltedGold> TomorrowMeltedGold { get; set; }
    }
}