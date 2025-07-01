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


		}
	}
}
