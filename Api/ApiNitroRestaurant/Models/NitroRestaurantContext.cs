using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiNitroRestaurant.Models
{
    public partial class NitroRestaurantContext : DbContext
    {
        public NitroRestaurantContext()
        {
        }

        public NitroRestaurantContext(DbContextOptions<NitroRestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<Operacione> Operaciones { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; } = null!;
        public virtual DbSet<TipoOperacione> TipoOperaciones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("PRIMARY");

                entity.ToTable("cuentas");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_pedidos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdProducto, "FK1_producto");

                entity.HasIndex(e => e.IdPedido, "FK2_pedido");

                entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_pedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_producto");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdCuenta, "FK1_cuenta");

                entity.HasIndex(e => e.IdTipoEmpleado, "FK2_tipo_empleado");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("id_tipo_empleado");

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .HasColumnName("materno")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .HasColumnName("paterno")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK1_cuenta");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_tipo_empleado");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PRIMARY");

                entity.ToTable("modulos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PRIMARY");

                entity.ToTable("operaciones");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdModulo, "FK1_modulos");

                entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");

                entity.Property(e => e.IdModulo).HasColumnName("id_modulo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_modulos");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdEmpleado, "FK1_empleado");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("fecha_hora")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.NumeroMesa)
                    .HasMaxLength(3)
                    .HasColumnName("numero_mesa");

                entity.Property(e => e.Terminado)
                    .HasColumnType("bit(1)")
                    .HasColumnName("terminado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_empleado");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdCategoria, "FK1_categoria");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Inversion)
                    .HasPrecision(8, 2)
                    .HasColumnName("inversion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasPrecision(8, 2)
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_categoria");
            });

            modelBuilder.Entity<TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_empleados");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("id_tipo_empleado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<TipoOperacione>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_operaciones");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdOperacion, "FK1_operaciones");

                entity.HasIndex(e => e.IdTipoEmpleado, "FK2_tipos_empleados");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("id_tipo_operacion");

                entity.Property(e => e.IdOperacion).HasColumnName("id_operacion");

                entity.Property(e => e.IdTipoEmpleado).HasColumnName("id_tipo_empleado");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.TipoOperaciones)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_operaciones");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.TipoOperaciones)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2_tipos_empleados");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
