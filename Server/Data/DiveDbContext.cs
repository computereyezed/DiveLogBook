using DiveLogBook.Shared.Models.DiveInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveLogBook.Server.Data
{
    public class DiveDbContext : DbContext
    {
        public DiveDbContext(DbContextOptions<DiveDbContext> options) : base(options)
        {
        }
        public DbSet<DiveData> Dives { get; set; }
        public DbSet<DiveDropdownData> Lkps { get; set; }

    }
}
