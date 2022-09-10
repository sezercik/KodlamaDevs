using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<PLTechnology> PLTechnologies { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims {get;set;}

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        
        //SQL tablolarını oluştur
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");

                p.HasMany(p => p.PLTechnologies);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.HasMany(c => c.UserOperationClaims);
                p.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<Profile>(p =>
            {
                p.ToTable("Profiles").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.GithubAddress).HasColumnName("GithubAddress");

                p.HasOne(p => p.User);

            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(o => o.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<PLTechnology>(p =>
            {
                p.ToTable("PLTechnologies").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.Property(p => p.Description).HasColumnName("Description");
                p.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                p.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] programminglanguageSeedData = {
                new(1, "C#"), new(2, "JAVA"), new(3,"JavaScript")
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programminglanguageSeedData);

            PLTechnology[] pLTechnologySeedData = {
            new(1,2,"Spring","Greate technology for Java",""),
            new(2,3,"React","From META to Javascript",""),
            new(3,3,"Angular","Google's answer for React",""),
            new(4,1,".NET","Amazing C# Tecnlogy","")
            };
            modelBuilder.Entity<PLTechnology>().HasData(pLTechnologySeedData);

            OperationClaim[] operationClaimsEntitySeeds =
            {
            new(1, "User"),
            new(2, "Moderator"),
            new(3, "Admin")
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);

        }
    }
}
