using System;
using System.ComponentModel;
using Mantas.PetShop.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mantas.PetShop.Sql
{
    public class PetShopContext: DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>().HasOne(o => o.Owner).WithMany(p => p.Pets);
            
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity() {Id = 1, Name = "Bob", Color = "Black", Price = 100});
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity() {Id = 2, Name = "Greg", Color = "Orange", Price = 200});
            modelBuilder.Entity<PetEntity>()
                .HasData(new PetEntity() {Id = 3, Name = "Ema", Color = "White", Price = 300});
            
            modelBuilder.Entity<OwnerEntity>()
                .HasData(new OwnerEntity() {Id = 1, FirstName = "Chad", LastName = "Giga", Email = "bruh@gmail.com"});
            modelBuilder.Entity<OwnerEntity>()
                .HasData(new OwnerEntity() {Id = 2, FirstName = "Sonic", LastName = "Speed", Email = "light@gmail.com"});
            
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity() {Id = 1, Type = "Cat"});
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity() {Id = 2, Type = "Dog"});
            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity() {Id = 3, Type = "Goat"});
        }

        public DbSet<PetEntity> Pet { get; set; }
        public DbSet<OwnerEntity> Owner { get; set; }
        public DbSet<PetTypeEntity> PetType { get; set; }
    }
}