using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IndianDresses.Models;

namespace IndianDresses.Data
{
    public class IndianDressesContext : DbContext
    {
        public IndianDressesContext (DbContextOptions<IndianDressesContext> options)
            : base(options)
        {
        }

        public DbSet<IndianDresses.Models.RegularClient> RegularClient { get; set; }

        public DbSet<IndianDresses.Models.OurEmployee> OurEmployee { get; set; }

        public DbSet<IndianDresses.Models.AvalibleStock> AvalibleStock { get; set; }

        public DbSet<IndianDresses.Models.OnlineSale> OnlineSale { get; set; }
    }
}
