using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context.Generic;

namespace Persistence.Context
{
    public class PersistenceContext : ContextGen
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options){}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<Lote> Lotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PalestranteEvento>().HasKey(pe => new {pe.EventoId, pe.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedeSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}