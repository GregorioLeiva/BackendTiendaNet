using Microsoft.EntityFrameworkCore;
// using UsuarioModel = ProyectoFinal_TiendaNet.Usuario.Model.Usuario;
using ProyectoFinal_TiendaNet.Usuario.Model;

namespace ProyectoFinal_TiendaNet.Config
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		//public DbSet<UsuarioModel> Usuarios { get; set; } = null!;

		public DbSet<Usuario.Model.Usuario> Usuarios { get; set; } = null!;

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
		Rol = "Administrador"
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
		Rol = "Vendedor"
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
		Rol = "Comprador"
	}
);


		}
	}
}
