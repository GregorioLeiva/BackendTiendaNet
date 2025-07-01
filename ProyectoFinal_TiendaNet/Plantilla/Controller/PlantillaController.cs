using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.MetodoPago.Model.Dto;
using ProyectoFinal_TiendaNet.MetodoPago.Services;
using ProyectoFinal_TiendaNet.Plantilla.Model.Dto;
using ProyectoFinal_TiendaNet.Plantilla.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;

namespace ProyectoFinal_TiendaNet.Plantilla.Controller
{
	[Route("api/plantilla")]
	[ApiController]
	public class PlantillaController : ControllerBase
	{
		private readonly PlantillaServices _plantillaServices;
		public PlantillaController(PlantillaServices plantillaServices)
		{
			_plantillaServices = plantillaServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<PlantillasDTO>>> GetAllPlantillas()
		{
			try
			{
				var plantillas = await _plantillaServices.GetAll();
				return Ok(plantillas);
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
		public async Task<ActionResult<PlantillaDTO>> Get(int id)
		{
			try
			{
				var plantilla = await _plantillaServices.GetOneById(id);
				return Ok(plantilla);
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
		public async Task<ActionResult<Plantilla.Model.Plantilla>> Post([FromBody] CreatePlantillaDTO createPlantillaDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var plantilla = await _plantillaServices.CreateOne(createPlantillaDto);
				return Created(nameof(Post), plantilla);

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
		public async Task<ActionResult<Plantilla.Model.Plantilla>> Put(int id, [FromBody] UpdatePlantillaDTO updatePlantillaDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var plantilla = await _plantillaServices.UpdateOneById(id, updatePlantillaDto);
				return Ok(plantilla);

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
				await _plantillaServices.DeleteOneById(id);
				return Ok(new CustomMessage($"La plantilla con el Id = {id} fue eliminado!"));

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
