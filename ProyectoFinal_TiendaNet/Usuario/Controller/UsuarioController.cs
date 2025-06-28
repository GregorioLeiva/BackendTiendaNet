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

		[HttpGet("{id}")]
		//[Authorize(Roles = $"{ROLES.ADMIN}, {ROLES.MOD}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UsuarioDTO>> Get(int id)
		{
			try
			{
				var user = await _usuarioServices.GetOneById(id);
				return Ok(user);
			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
			}
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<Usuario.Model.Usuario>> Post([FromBody] CreateUsuarioDTO createUserDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var user = await _usuarioServices.CreateOne(createUserDto);
				return Created(nameof(Post), user);

			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
			}
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<Usuario.Model.Usuario>> Put(int id, [FromBody] UpdateUsuarioDTO updateUserDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var user = await _usuarioServices.UpdateOneById(id, updateUserDto);
				return Ok(user);

			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
			}
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				await _usuarioServices.DeleteOneById(id);
				return Ok(new CustomMessage($"El Usuario con el Id = {id} fue eliminado!"));

			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
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
