using Microsoft.EntityFrameworkCore;
using OnTheDrift.Samples.EFCoreProjectablesPerfMagic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheDrift.Samples.EFCoreProjectablesPerfMagic
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}
