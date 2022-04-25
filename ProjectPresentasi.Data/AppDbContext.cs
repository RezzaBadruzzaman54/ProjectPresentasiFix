using Microsoft.EntityFrameworkCore;
using ProjectPresentasi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPresentasi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Sword> Swords { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=PresentasiSamuraiDB")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name,
                DbLoggerCategory.Database.Transaction.Name},
                Microsoft.Extensions.Logging.LogLevel.Debug)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sword>()
                .HasMany(sw => sw.Elements)
                 .WithMany(el => el.Swords)
                .UsingEntity<SwordElement>(
                     se => se.HasOne<Element>().WithMany(),
                     se => se.HasOne<Sword>().WithMany());

            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(
                     bs => bs.HasOne<Battle>().WithMany(),
                     bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getDate()");

            modelBuilder.Entity<Horse>().ToTable("Horses");

            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");


        }
    }
}
