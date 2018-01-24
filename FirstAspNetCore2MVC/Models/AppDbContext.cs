﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstAspNetCore2MVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {  
        }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<FeedBack> FeedBacks { get; set; }
    }
}
