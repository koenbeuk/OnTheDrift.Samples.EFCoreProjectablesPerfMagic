using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using OnTheDrift.Samples.EFCoreProjectablesPerfMagic.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheDrift.Samples.EFCoreProjectablesPerfMagic
{
    [MarkdownExporterAttribute.Default]
    public class FullNameBenchmark
    {
        SampleDbContext dbContext;

        [GlobalSetup(Target = nameof(WithoutProjectables))]
        public void SetupWithoutProjectables()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                .UseSqlServer("Server=(localdb)\v11.0;Integrated Security=true;") // We're never connecting to the database so the connection string is really just here to satisfy EF
                .Options;

            dbContext = new SampleDbContext(dbContextOptions);
        }


        [GlobalSetup(Target = nameof(WithProjectables))]
        public void SetupWithProjectables()
        {
            var dbContextOptions = new DbContextOptionsBuilder()
                .UseSqlServer("Server=(localdb)\v11.0;Integrated Security=true;") // We're never connecting to the database so the connection string is really just here to satisfy EF
                .UseProjectables()
                .Options;

            dbContext = new SampleDbContext(dbContextOptions);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            dbContext.Dispose();
            dbContext = null;
        }

        [Benchmark(Baseline = true)]
        public void WithoutProjectables()
        {
            for (var i = 0; i < 1000; i++)
            {
                var query = dbContext.Users
                    .Select(x => x.FirstName + " " + x.LastName);

                query.ToQueryString();
            }
        }

        [Benchmark]
        public void WithProjectables()
        {
            for (var i = 0; i < 1000; i++)
            {
                var query = dbContext.Users
                    .Select(x => x.FullName());

                query.ToQueryString();
            }
        }
    }
}
