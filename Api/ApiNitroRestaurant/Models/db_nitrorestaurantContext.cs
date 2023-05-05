using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiNitroRestaurant.Models
{
    public partial class db_nitrorestaurantContext : DbContext
    {
        public db_nitrorestaurantContext()
        {
        }

        public db_nitrorestaurantContext(DbContextOptions<db_nitrorestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Entrada> Entradas { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<Operacione> Operaciones { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Sucursale> Sucursales { get; set; } = null!;
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; } = null!;
        public virtual DbSet<TipoPedido> TipoPedidos { get; set; } = null!;
        public virtual DbSet<TipoeOperacione> TipoeOperaciones { get; set; } = null!;
        public virtual DbSet<UnidadMedida> UnidadMedidas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf16_general_ci")
                .HasCharSet("utf16");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("IMG_URL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_pedidos");

                entity.HasIndex(e => e.IdProducto, "FK_REFERENCE_1");

                entity.HasIndex(e => e.IdPedido, "FK_REFERENCE_2");

                entity.Property(e => e.IdDetalle)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_DETALLE");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("CANTIDAD");

                entity.Property(e => e.IdPedido)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PEDIDO");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PRODUCTO");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_2");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_1");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleados");

                entity.HasIndex(e => e.IdSucursal, "FK_REFERENCE_18");

                entity.HasIndex(e => e.IdTipoEmpleado, "FK_REFERENCE_5");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit(1)")
                    .HasColumnName("ACTIVO");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(64)
                    .HasColumnName("CONTRASENIA");

                entity.Property(e => e.ContraseniaAnterior)
                    .HasMaxLength(64)
                    .HasColumnName("CONTRASENIA_ANTERIOR");

                entity.Property(e => e.IdSucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.IdTipoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_EMPLEADO");

                entity.Property(e => e.Materno)
                    .HasMaxLength(50)
                    .HasColumnName("MATERNO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Paterno)
                    .HasMaxLength(50)
                    .HasColumnName("PATERNO");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("TELEFONO");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(30)
                    .HasColumnName("USUARIO");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_18");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_5");
            });

            modelBuilder.Entity<Entrada>(entity =>
            {
                entity.HasKey(e => e.IdEntrada)
                    .HasName("PRIMARY");

                entity.ToTable("entradas");

                entity.HasIndex(e => e.IdProducto, "FK_REFERENCE_13");

                entity.HasIndex(e => e.IdProveedor, "FK_REFERENCE_14");

                entity.Property(e => e.IdEntrada)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_ENTRADA");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("CANTIDAD");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_HORA");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdProveedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PROVEEDOR");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_13");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_REFERENCE_14");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.IdMesa)
                    .HasName("PRIMARY");

                entity.ToTable("mesas");

                entity.HasIndex(e => e.IdSucursal, "FK_REFERENCE_15");

                entity.HasIndex(e => e.IdEmpleado, "FK_REFERENCE_16");

                entity.Property(e => e.IdMesa)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MESA");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.IdSucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.NumMesa)
                    .HasMaxLength(3)
                    .HasColumnName("NUM_MESA")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_REFERENCE_16");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_15");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PRIMARY");

                entity.ToTable("modulos");

                entity.Property(e => e.IdModulo)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MODULO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Operacione>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PRIMARY");

                entity.ToTable("operaciones");

                entity.HasIndex(e => e.IdModulo, "FK_REFERENCE_6");

                entity.Property(e => e.IdOperacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_OPERACION");

                entity.Property(e => e.IdModulo)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MODULO");

                entity.Property(e => e.Nombre)
                    .HasColumnType("int(11)")
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Operaciones)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_6");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedidos");

                entity.HasIndex(e => e.IdSucursal, "FK_REFERENCE_11");

                entity.HasIndex(e => e.IdTipoPedido, "FK_REFERENCE_12");

                entity.HasIndex(e => e.IdMesa, "FK_REFERENCE_20");

                entity.HasIndex(e => e.IdEmpleado, "FK_REFERENCE_9");

                entity.Property(e => e.IdPedido)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PEDIDO");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(100)
                    .HasColumnName("COMENTARIO");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_HORA");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_EMPLEADO");

                entity.Property(e => e.IdMesa)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MESA");

                entity.Property(e => e.IdSucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.IdTipoPedido)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_PEDIDO");

                entity.Property(e => e.Terminado)
                    .HasColumnType("bit(1)")
                    .HasColumnName("TERMINADO");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_9");

                entity.HasOne(d => d.IdMesaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdMesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_20");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_11");

                entity.HasOne(d => d.IdTipoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdTipoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_12");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasIndex(e => e.IdUm, "FK_REFERENCE_10");

                entity.HasIndex(e => e.IdSucursal, "FK_REFERENCE_19");

                entity.HasIndex(e => e.IdCategoria, "FK_REFERENCE_8");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("CANTIDAD");

                entity.Property(e => e.Contable)
                    .HasColumnType("bit(1)")
                    .HasColumnName("CONTABLE");

                entity.Property(e => e.IdCategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_CATEGORIA");

                entity.Property(e => e.IdSucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.IdUm)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_UM");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .HasColumnName("IMG_URL");

                entity.Property(e => e.Inversion)
                    .HasPrecision(8, 2)
                    .HasColumnName("INVERSION");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Precio)
                    .HasPrecision(8, 2)
                    .HasColumnName("PRECIO");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_8");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_19");

                entity.HasOne(d => d.IdUmNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdUm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_10");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("proveedores");

                entity.Property(e => e.IdProveedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_PROVEEDOR");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Sucursale>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PRIMARY");

                entity.ToTable("sucursales");

                entity.Property(e => e.IdSucursal)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SUCURSAL");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.NumMesas)
                    .HasMaxLength(3)
                    .HasColumnName("NUM_MESAS");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(100)
                    .HasColumnName("UBICACION");
            });

            modelBuilder.Entity<TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_empleados");

                entity.Property(e => e.IdTipoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_EMPLEADO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TipoPedido>(entity =>
            {
                entity.HasKey(e => e.IdTipoPedido)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_pedidos");

                entity.Property(e => e.IdTipoPedido)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_PEDIDO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TipoeOperacione>(entity =>
            {
                entity.HasKey(e => e.IdTipoeOperaciones)
                    .HasName("PRIMARY");

                entity.ToTable("tipoe_operaciones");

                entity.HasIndex(e => e.IdTipoEmpleado, "FK_REFERENCE_3");

                entity.HasIndex(e => e.IdTipoOperacion, "FK_REFERENCE_4");

                entity.Property(e => e.IdTipoeOperaciones)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPOE_OPERACIONES");

                entity.Property(e => e.IdTipoEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_EMPLEADO");

                entity.Property(e => e.IdTipoOperacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_TIPO_OPERACION");

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.TipoeOperaciones)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_3");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.TipoeOperaciones)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REFERENCE_4");
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.HasKey(e => e.IdUm)
                    .HasName("PRIMARY");

                entity.ToTable("unidad_medidas");

                entity.Property(e => e.IdUm)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_UM");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .HasColumnName("NOMBRE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
