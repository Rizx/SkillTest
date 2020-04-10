using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkillTest.Core
{
    public class SkillTestContext : DbContext, ISkillTestContext
    {
        public DbSet<Data> Data {set;get;}
        public DbSet<Lokasi> Lokasi {set;get;}

        protected SkillTestContext()
        {
        }

        public SkillTestContext(DbContextOptions<SkillTestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TEST");

            modelBuilder.Entity<Data>(x=>
            {
                x.ToTable("DATA");
                x.HasKey(k=>k.ID);
                x.Property(p=> p.ID).HasColumnName("DATAID");
                x.Property(p=> p.Foto).HasColumnName("FOTO");
                x.Property(p=> p.Keterangan).HasColumnName("KETERANGAN");
                x.Property(p=> p.Judul).HasColumnName("JUDUL");
                x.Property(p=> p.LokasiID).HasColumnName("LOKASIID");
            });

            modelBuilder.Entity<Lokasi>(x=>
            {
                x.ToTable("LOKASI");
                x.HasKey(k=> k.ID);
                x.Property(p=> p.ID).HasColumnName("LOKASIID");
                x.Property(p=> p.Deskripsi).HasColumnName("DESKRIPSI");
            });
        }
    }
}