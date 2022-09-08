using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Context
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<PLTechnology> PLTechnologies { get; set; }

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

            modelBuilder.Entity<PLTechnology>(t =>
            {
                t.ToTable("PLTechnologies").HasKey(k => k.Id);
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.Property(p => p.Name).HasColumnName("Name");
                t.Property(p => p.Description).HasColumnName("Description");
                t.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                t.HasOne(p => p.ProgrammingLanguage);

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

        }
    }
}
