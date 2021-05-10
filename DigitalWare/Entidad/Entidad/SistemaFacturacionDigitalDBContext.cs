using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entidad.Entidad
{
    public partial class SistemaFacturacionDigitalDBContext : DbContext
    {
        public SistemaFacturacionDigitalDBContext()
        {
        }

        public SistemaFacturacionDigitalDBContext(DbContextOptions<SistemaFacturacionDigitalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DescripcionFactura> DescripcionFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.EnableSensitiveDataLogging(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                //entity.Property(e => e.CategoriaId).ValueGeneratedNever();

                entity.Property(e => e.CategoriaNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).ValueGeneratedNever();

                entity.Property(e => e.ClienteDireccion).HasMaxLength(100);

                entity.Property(e => e.ClienteNombre).HasMaxLength(50);

                entity.Property(e => e.ClienteTelefono).HasMaxLength(50);
            });

            modelBuilder.Entity<DescripcionFactura>(entity =>
            {
                //entity.Property(e => e.DescripcionFacturaId).ValueGeneratedNever();

                entity.Property(e => e.DescripcionFacturaPrecio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DescripcionFactura)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK_DescripcionFactura_Factura");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DescripcionFactura)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_DescripcionFactura_Producto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                //entity.Property(e => e.FacturaId).ValueGeneratedNever();

                entity.Property(e => e.FacturaFecha).HasColumnType("datetime");

                entity.Property(e => e.FacturaIvaporcentaje)
                    .HasColumnName("FacturaIVAPorcentaje")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.FacturaIvatotal)
                    .HasColumnName("FacturaIVATotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FacturaSubtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FacturaTotal).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_Factura_Cliente");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                //entity.Property(e => e.ProductoId).ValueGeneratedNever();

                entity.Property(e => e.ProductoNombre).HasMaxLength(50);

                entity.Property(e => e.ProductoPrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Producto_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
