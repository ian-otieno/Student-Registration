using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KHSchool.Models;

namespace KHSchool.Data
{
    public class KHSchoolContext : DbContext
    {
        public KHSchoolContext (DbContextOptions<KHSchoolContext> options)
            : base(options)
        {
        }

        public DbSet<KHSchool.Models.Registration> Registration { get; set; } = default!;
    }
}
