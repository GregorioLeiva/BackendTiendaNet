using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.Admin.Model.Dto;
using ProyectoFinal_TiendaNet.Admin.Services;
using ProyectoFinal_TiendaNet.Comprador.Model.Dto;
using ProyectoFinal_TiendaNet.Comprador.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;

namespace ProyectoFinal_TiendaNet.Admin.Controller
{
	[Route("api/admin")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly AdminServices _adminServices;
		public AdminController(AdminServices adminServices)
		{
			_adminServices = adminServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<AdminsDTO>>> GetAllAdmins()
		{
			try
			{
				var admins = await _adminServices.GetAll();
				return Ok(admins);
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
		public async Task<ActionResult<AdminDTO>> Get(int id)
		{
			try
			{
				var admin = await _adminServices.GetOneById(id);
				return Ok(admin);
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
		public async Task<ActionResult<Admin.Model.Admin>> Post([FromBody] CreateAdminDTO createAdminDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var admin = await _adminServices.CreateOne(createAdminDto);
				return Created(nameof(Post), admin);

			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					new CustomMessage($"Error: {ex.Message} - Inner: {ex.InnerException?.Message}"));
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
				await _adminServices.DeleteOneById(id);
				return Ok(new CustomMessage($"El admin con el Id = {id} fue eliminado!"));

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
	}
}
