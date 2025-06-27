using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;
using ProyectoFinal_TiendaNet.Usuario.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;

namespace ProyectoFinal_TiendaNet.Usuario.Controller
{
	[Route("api/usuario")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly UsuarioServices _usuarioServices;
		public UsuarioController(UsuarioServices usuarioServices)
		{
			_usuarioServices = usuarioServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<UsuariosDTO>>> Get()
		{
			try
			{
				var users = await _usuarioServices.GetAll();
				return Ok(users);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
			}
		}

		/*Aca tengo un ejemplo de datos*/
		[HttpGet("fake")]
		public IActionResult GetUsuariosFake()
		{
			var usuarios = new List<Usuario.Model.Usuario>
			{
				new Usuario.Model.Usuario
				{
					Id = 1,
					Nombre = "Gregorio",
					Apellido = "Leiva",
					Email = "gleiva@frsn.utn.edu.ar",
					Contraseña = "12345678",
					Username = "gleiva",
					FechaRegistro = DateTime.Now,
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
					FechaRegistro = DateTime.Now,
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
					FechaRegistro = DateTime.Now,
					Rol = "Comprador"
				}
			};

			return Ok(usuarios);
		}
		/*Aca finaliza los datos falsos*/

	}
}
