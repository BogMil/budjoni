﻿using Budjoni.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Budjoni.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options){}

        public DbSet<Model> Modeli{ get; set; }
        public DbSet<Narudzbina> Naruzbine { get; set; }
    }
}
