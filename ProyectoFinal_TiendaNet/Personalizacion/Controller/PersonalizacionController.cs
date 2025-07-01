using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.Personalizacion.Model.Dto;
using ProyectoFinal_TiendaNet.Personalizacion.Services;
using ProyectoFinal_TiendaNet.Plantilla.Model.Dto;
using ProyectoFinal_TiendaNet.Plantilla.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;

namespace ProyectoFinal_TiendaNet.Personalizacion.Controller
{
	[Route("api/personalizacion")]
	[ApiController]
	public class PersonalizacionController : ControllerBase
	{
		private readonly PersonalizacionServices _personalizacionServices;
		public PersonalizacionController(PersonalizacionServices personalizacionServices)
		{
			_personalizacionServices = personalizacionServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<PersonalizacionesDTO>>> GetAllPlantillas()
		{
			try
			{
				var personalizaciones = await _personalizacionServices.GetAll();
				return Ok(personalizaciones);
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
		public async Task<ActionResult<PersonalizacionDTO>> Get(int id)
		{
			try
			{
				var personalizacion = await _personalizacionServices.GetOneById(id);
				return Ok(personalizacion);
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
		public async Task<ActionResult<Personalizacion.Model.Personalizacion>> Post([FromBody] CreatePersonalizacionDTO createPersonalizacionDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var personalizacion = await _personalizacionServices.CreateOne(createPersonalizacionDto);
				return Created(nameof(Post), personalizacion);

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

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<Personalizacion.Model.Personalizacion>> Put(int id, [FromBody] UpdatePersonalizacionDTO updatePersonalizacionDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var personalizacion = await _personalizacionServices.UpdateOneById(id, updatePersonalizacionDto);
				return Ok(personalizacion);

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
				await _personalizacionServices.DeleteOneById(id);
				return Ok(new CustomMessage($"La personalizacion con el Id = {id} fue eliminada!"));

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
