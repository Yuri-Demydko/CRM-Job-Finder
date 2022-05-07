﻿using CRM.DAL.Models.DatabaseModels.Configs;
using CRM.DAL.Models.DatabaseModels.Files;
using CRM.DAL.Models.DatabaseModels.KontragentInfo;
using CRM.DAL.Models.DatabaseModels.Kontragents;
using CRM.DAL.Models.DatabaseModels.KontragentUsers;
using CRM.DAL.Models.DatabaseModels.ProductsKontragents;
using CRM.DAL.Models.DatabaseModels.ProductsUsers;
using CRM.DAL.Models.DatabaseModels.Tags;
using CRM.DAL.Models.DatabaseModels.Users;
using CRM.DAL.Models.DatabaseModels.Vacancys;
using CRM.DAL.Models.DatabaseModels.VacansysUsers;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL
{
    public class GeneralDbContext : IdentityDbContext<
        User, Role, string,
        UserClaim, UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>, IDataProtectionKeyContext
    {
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        
        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<File> Files { get; set; }
        public DbSet<KontragentInfo> KontragentInfos { get; set; }
        public DbSet<Kontragent> Kontragents { get; set; }
        public DbSet<KontragentUser> KontragentUsers { get; set; }
        public DbSet<Vacancy> Products { get; set; }
        public DbSet<VacancyKontragent> ProductKontragents { get; set; }
        public DbSet<VacancyUser> ProductUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }



        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        // }
        //FOR MIGRATIONS
        public GeneralDbContext()
        {

        }
        public GeneralDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=jf-db-dev.cvt8etkjrnau.eu-central-1.rds.amazonaws.com;Port=5432;Database=postgres;Username=postgres;Password=jfdbmaster123;CommandTimeout=1000");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new ProductUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductKontragentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new KontragentUserConfiguration());
            modelBuilder.ApplyConfiguration(new KontragentConfiguration());
            modelBuilder.ApplyConfiguration(new KontragentInfoConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
        }
    }
}