﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Observe.DAL
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=oper;initial catalog=DesignPattern_OBSERVE;integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<WelcomeMessage> WelcomeMessages { get; set; }
        public DbSet<UserProcess> UserProcesses { get; set; }
    }
}