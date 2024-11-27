using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebHamburgueseria.Models;

public partial class LabHamburgueseriaContext : DbContext
{
    public LabHamburgueseriaContext()
    {
    }

    public LabHamburgueseriaContext(DbContextOptions<LabHamburgueseriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LabHamburgueseria;User ID=usrhambu;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10037D3BD2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3213E83F19996185");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210275F7A96");

            entity.ToTable("Producto");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Stock).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__IdCate__2C3393D0");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97BA9272D1");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("usuario");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__VentaDet__AAA5CEC2E413DA1D");

            entity.ToTable("VentaDetalle");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaDeta__IdPro__38996AB5");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VentaDeta__IdVen__37A5467C");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__BC1240BD66A79DCB");

            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasDefaultValue((short)1)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.MontoCambio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoPago).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__IdUsuario__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
