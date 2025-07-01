using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaProducto.Services;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using ProyectoFinal_TiendaNet.Vendedor.Model.Dto;
using ProyectoFinal_TiendaNet.Vendedor.Services;

namespace ProyectoFinal_TiendaNet.CategoriaProducto.Controller
{
	[Route("api/categoriaproducto")]
	[ApiController]
	public class CategoriaProductoController : ControllerBase
	{
		private readonly CategoriaProductoServices _categoriaproductoServices;
		public CategoriaProductoController(CategoriaProductoServices categoriaproductoServices)
		{
			_categoriaproductoServices = categoriaproductoServices;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<List<CategoriasProductoDTO>>> GetAllCategoriasProducto()
		{
			try
			{
				var categoriasProductos = await _categoriaproductoServices.GetAll();
				return Ok(categoriasProductos);
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
		public async Task<ActionResult<CategoriaProductoDTO>> Get(int id)
		{
			try
			{
				var categoriaProducto = await _categoriaproductoServices.GetOneById(id);
				return Ok(categoriaProducto);
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
		public async Task<ActionResult<CategoriaProducto.Model.CategoriaProducto>> Post([FromBody] CreateCategoriaProductoDTO createCategoriaProductoDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var categoriaProducto = await _categoriaproductoServices.CreateOne(createCategoriaProductoDto);
				return Created(nameof(Post), categoriaProducto);

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
		public async Task<ActionResult<CategoriaProducto.Model.CategoriaProducto>> Put(int id, [FromBody] UpdateCategoriaProductoDTO updateCategoriaProductoDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				var categoriaProducto = await _categoriaproductoServices.UpdateOneById(id, updateCategoriaProductoDto);
				return Ok(categoriaProducto);

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
				await _categoriaproductoServices.DeleteOneById(id);
				return Ok(new CustomMessage($"La categoria de producto con el Id = {id} fue eliminado!"));

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
