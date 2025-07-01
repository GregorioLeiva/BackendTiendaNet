using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaProducto.Services;
using ProyectoFinal_TiendaNet.CategoriaTienda.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaTienda.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;

namespace ProyectoFinal_TiendaNet.CategoriaTienda.Controller
{
	[Route("api/categoriatienda")]
	[ApiController]
	public class CategoriaTiendaController : ControllerBase
	{
		private readonly CategoriaTiendaServices _categoriatiendaServices;
		public CategoriaTiendaController(CategoriaTiendaServices categoriatiendaServices)
		{
			_categoriatiendaServices = categoriatiendaServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<CategoriasTiendaDTO>>> GetAllCategoriasTienda()
		{
			try
			{
				var categoriasTienda = await _categoriatiendaServices.GetAll();
				return Ok(categoriasTienda);
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
		public async Task<ActionResult<CategoriaTiendaDTO>> Get(int id)
		{
			try
			{
				var categoriaTienda = await _categoriatiendaServices.GetOneById(id);
				return Ok(categoriaTienda);
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
		public async Task<ActionResult<CategoriaTienda.Model.CategoriaTienda>> Post([FromBody] CreateCategoriaTiendaDTO createCategoriaTiendaDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var categoriaTienda = await _categoriatiendaServices.CreateOne(createCategoriaTiendaDto);
				return Created(nameof(Post), categoriaTienda);

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
		public async Task<ActionResult<CategoriaTienda.Model.CategoriaTienda>> Put(int id, [FromBody] UpdateCategoriaTiendaDTO updateCategoriaTiendaDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var categoriaTienda = await _categoriatiendaServices.UpdateOneById(id, updateCategoriaTiendaDto);
				return Ok(categoriaTienda);

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
				await _categoriatiendaServices.DeleteOneById(id);
				return Ok(new CustomMessage($"La categoria de tienda con el Id = {id} fue eliminado!"));

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
