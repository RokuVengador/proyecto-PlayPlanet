using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlayPlanetWeb.ViewModel;

namespace PlayPlanetWeb.Models;

public partial class PlayPlanetContext : DbContext
{
    public PlayPlanetContext()
    {
    }

    public PlayPlanetContext(DbContextOptions<PlayPlanetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleCompraJuego> DetalleCompraJuegos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Videojuego> Videojuegos { get; set; }

    public virtual DbSet<DetalleCompraViewModel> DetalleCompraViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-519E3A7\\MSSQLSERVER01; database=PlayPlanet; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DetalleCompraViews>().HasNoKey();

        modelBuilder.Entity<DetalleCompraJuego>(entity =>
        {
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");
            entity.Property(e => e.VideojuegosId).HasColumnName("Videojuegos_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.DetalleCompraJuegos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompraJuegos_Usuarios");

            entity.HasOne(d => d.Videojuegos).WithMany(p => p.DetalleCompraJuegos)
                .HasForeignKey(d => d.VideojuegosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompraJuegos_Videojuegos");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.CodProveedor);

            entity.Property(e => e.CodProveedor).ValueGeneratedNever();
            entity.Property(e => e.Contacto).HasColumnName("contacto");
            entity.Property(e => e.NombredelProveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.ApellidoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dui).HasColumnName("DUI");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Videojuego>(entity =>
        {
            entity.Property(e => e.Clasificacion)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NombreJuego)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProveedoresId).HasColumnName("Proveedores_id");

            entity.HasOne(d => d.Proveedores).WithMany(p => p.Videojuegos)
                .HasForeignKey(d => d.ProveedoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Videojuegos_Proveedores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
