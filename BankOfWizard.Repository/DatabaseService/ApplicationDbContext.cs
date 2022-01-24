using BankOfWizard.Repository.DatabaseService.AccountRepositories;
using BankOfWizard.Repository.DatabaseService.CustomerRepositories;
using BankOfWizard.Repository.DatabaseService.TransactionRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;



namespace BankOfWizard.Repository.DatabaseService
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
        {
            

        }

        public DbSet<CustomerDbModel> Customer { get; set; }
        public DbSet<AccountDbModel> AccountTable { get; set; }
        public DbSet<TransactionDbModel> TransactionTable { get; set; }
        public DbSet<IdentityUser> IdentityUserTable { get; set; }
        public DbSet<IdentityRole> IdentityRoleTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<CustomerDbModel>().ToTable("Customers");
            modelBuilder.Entity<AccountDbModel>().ToTable("Accounts");
            modelBuilder.Entity<TransactionDbModel>().ToTable("Transactions");
            modelBuilder.Entity<IdentityUser>().ToTable("IdentityUser");
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();    
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

        }
    }

}
