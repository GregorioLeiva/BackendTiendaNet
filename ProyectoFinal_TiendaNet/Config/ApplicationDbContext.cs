using Microsoft.EntityFrameworkCore;
using ProyectoFinal_TiendaNet.Enums;

// using UsuarioModel = ProyectoFinal_TiendaNet.Usuario.Model.Usuario;
using ProyectoFinal_TiendaNet.Usuario.Model;

namespace ProyectoFinal_TiendaNet.Config
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		//public DbSet<UsuarioModel> Usuarios { get; set; } = null!;

		public DbSet<Usuario.Model.Usuario> Usuarios { get; set; } = null!;

		public DbSet<Comprador.Model.Comprador> Compradores { get; set; }

		public DbSet<Vendedor.Model.Vendedor> Vendedores { get; set; }

		public DbSet<Admin.Model.Admin> Admins { get; set; }

		public DbSet<CategoriaProducto.Model.CategoriaProducto> CategoriaProductos { get; set; }

		public DbSet<CategoriaTienda.Model.CategoriaTienda> CategoriaTiendas { get; set; }

		public DbSet<MetodoPago.Model.MetodoPago> MetodoPagos { get; set; }

		public DbSet<Plantilla.Model.Plantilla> Plantillas { get; set; }

		public DbSet<Personalizacion.Model.Personalizacion> Personalizaciones { get; set; }

		public DbSet<Carrito.Model.Carrito> Carritos { get; set; }

		public DbSet<Tienda.Model.Tienda> Tiendas { get; set; }

		public DbSet<Producto.Model.Producto> Productos { get; set; }

		public DbSet<CarritoProducto.Model.CarritoProducto> CarritoProductos { get; set; }

		public DbSet<DetalleCompra.Model.DetalleCompra> DetalleCompras { get; set; }

		public DbSet<Compra.Model.Compra> Compras { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario.Model.Usuario>().HasData(
				new Usuario.Model.Usuario
				{
					Id = 1,
					Nombre = "Gregorio",
					Apellido = "Leiva",
					Email = "gleiva@frsn.utn.edu.ar",
					Contraseña = "12345678",
					Username = "gleiva",
					FechaRegistro = new DateTime(2025, 06, 28, 0, 0, 0),
					RolId = 1
				},
				new Usuario.Model.Usuario
				{
					Id = 2,
					Nombre = "Gregorio",
					Apellido = "Leiva",
					Email = "gleiva@frsn.utn.edu.ar",
					Contraseña = "12345678",
					Username = "gregorio",
					FechaRegistro = new DateTime(2025, 06, 28, 0, 0, 0),
					RolId = 3
				},
				new Usuario.Model.Usuario
				{
					Id = 3,
					Nombre = "Gregorio",
					Apellido = "Leiva",
					Email = "gleiva@frsn.utn.edu.ar",
					Contraseña = "12345678",
					Username = "goyo",
					FechaRegistro = new DateTime(2025, 06, 28, 0, 0, 0),
					RolId = 2
				}
			);

			modelBuilder.Entity<Rol.Model.Rol>().HasData(
				new Rol.Model.Rol { Id = 1, Nombre = ROLES.ADMIN },
				new Rol.Model.Rol { Id = 2, Nombre = ROLES.COMPRADOR },
				new Rol.Model.Rol { Id = 3, Nombre = ROLES.VENDEDOR }
			);

			modelBuilder.Entity<EstadoTienda.Model.EstadoTienda>().HasData(
				new EstadoTienda.Model.EstadoTienda { Id = 1, Nombre = ESTADOSTIENDA.ACTIVA },
				new EstadoTienda.Model.EstadoTienda { Id = 2, Nombre = ESTADOSTIENDA.INACTIVA },
				new EstadoTienda.Model.EstadoTienda { Id = 3, Nombre = ESTADOSTIENDA.EN_PROCESO_ELIMINACION },
				new EstadoTienda.Model.EstadoTienda { Id = 4, Nombre = ESTADOSTIENDA.ELIMINADA }
			);

			modelBuilder.Entity<EstadoCompra.Model.EstadoCompra>().HasData(
				new EstadoCompra.Model.EstadoCompra { Id = 1, Nombre = ESTADOSCOMPRAS.PENDIENTE },
				new EstadoCompra.Model.EstadoCompra { Id = 2, Nombre = ESTADOSCOMPRAS.FINALIZADA },
				new EstadoCompra.Model.EstadoCompra { Id = 3, Nombre = ESTADOSCOMPRAS.CANCELADA },
				new EstadoCompra.Model.EstadoCompra { Id = 4, Nombre = ESTADOSCOMPRAS.EN_PREPARACION }
			);

			modelBuilder.Entity<Tienda.Model.Tienda>()
				.HasOne(t => t.Personalizacion)
				.WithOne(p => p.Tienda)
				.HasForeignKey<Tienda.Model.Tienda>(t => t.PersonalizacionId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Producto.Model.Producto>()
				.Property(p => p.PrecioUnitario)
				.HasPrecision(18, 2); // 18 dígitos en total, 2 decimales

			modelBuilder.Entity<Tienda.Model.Tienda>()
				.HasOne(t => t.Vendedor)
				.WithMany(v => v.Tiendas)
				.HasForeignKey(t => t.VendedorId)
				.OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<Vendedor.Model.Vendedor>()
				.HasOne(v => v.Usuario)
				.WithMany() // Asumo que Usuario no tiene lista de Vendedores
				.HasForeignKey(v => v.UsuarioID)
				.OnDelete(DeleteBehavior.Restrict);






		}
	}
}
