using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class DataContext:DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {
            }

            public DbSet<Product> Products { get; set; }
            public DbSet<Store> Stores { get; set; }
        }
    }