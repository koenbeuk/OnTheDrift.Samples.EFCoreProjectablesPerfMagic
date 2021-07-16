using Microsoft.EntityFrameworkCore;
using OnTheDrift.Samples.EFCoreProjectablesPerfMagic;
using OnTheDrift.Samples.EFCoreProjectablesPerfMagic.Models.Extensions;
using System;
using System.Linq;

namespace Spike
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                .UseSqlServer("Server=(localdb)\v11.0;Integrated Security=true;") // We're never connecting to the database so the connection string is really just here to satisfy EF
                .UseProjectables()
                .Options;

            using var dbContext = new SampleDbContext(dbContextOptions);

            var q1 = dbContext.Users.Where(x => x.Id == 1);

            var query = dbContext.Users.Select(x => x.FirstName + " " + x.LastName);

            var q2 = dbContext.Users.Select(x => x.FullName());

            Console.WriteLine("Hello World!");
        }
    }
}
