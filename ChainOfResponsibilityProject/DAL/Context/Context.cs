using System;
using ChainOfResponsibilityProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainOfResponsibilityProject.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=ChainOfResponsibilityDb;Username=postgres;Password=postgres");

        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}

