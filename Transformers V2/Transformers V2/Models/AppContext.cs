using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Transformers_V2.Models
{
    public class AppContext:DbContext
    {
        public DbSet<Manufacture> manufactures { get; set; }
        public DbSet<Transformer> transformers { get; set; }
        public AppContext(DbContextOptions<AppContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}
