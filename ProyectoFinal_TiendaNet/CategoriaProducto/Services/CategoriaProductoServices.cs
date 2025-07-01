using AutoMapper;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaProducto.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using ProyectoFinal_TiendaNet.Vendedor.Model.Dto;
using ProyectoFinal_TiendaNet.Vendedor.Repository;
using System.Net;

namespace ProyectoFinal_TiendaNet.CategoriaProducto.Services
{
	public class CategoriaProductoServices
	{
		private readonly IMapper _mapper;
		private readonly ICategoriaProductoRepository _categoriaproductoRepository;
		private readonly ApplicationDbContext _dbContext;
		public CategoriaProductoServices(IMapper mapper, ICategoriaProductoRepository categoriaproductoRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_categoriaproductoRepository = categoriaproductoRepository;
			_dbContext = dbContext;
		}
		private async Task<CategoriaProducto.Model.CategoriaProducto> GetOneByIdOrException(int id)
		{
			var categoriaproducto = await _categoriaproductoRepository.GetOne(c => c.Id == id);
			if (categoriaproducto  == null)
			{
				throw new CustomHttpException($"No se encontro la categoria de producto con Id = {id}", HttpStatusCode.NotFound);
			}
			return categoriaproducto;
		}

		public async Task<CategoriaProducto.Model.CategoriaProducto> GetOneById(int id)
		{
			var categoriaProducto = await GetOneByIdOrException(id);
			return _mapper.Map<CategoriaProducto.Model.CategoriaProducto>(categoriaProducto);
		}
		public async Task<List<CategoriasProductoDTO>> GetAll()
		{
			var categoriasproducto = await _categoriaproductoRepository.GetAll();
			return _mapper.Map<List<CategoriasProductoDTO>>(categoriasproducto);
		}

		public async Task<CategoriaProducto.Model.CategoriaProducto> CreateOne(CreateCategoriaProductoDTO createCategoriaProductoDto)
		{
			var categoriaproducto = _mapper.Map<CategoriaProducto.Model.CategoriaProducto>(createCategoriaProductoDto);

			await _categoriaproductoRepository.Add(categoriaproducto);
			return categoriaproducto;
		}

		public async Task<CategoriaProducto.Model.CategoriaProducto> UpdateOneById(int id, UpdateCategoriaProductoDTO updateCategoriaProductoDto)
		{
			var categoriaproducto = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateCategoriaProductoDto, categoriaproducto);

			await _categoriaproductoRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var categoria = await GetOneByIdOrException(id);

			await _categoriaproductoRepository.Delete(categoria);
		}
	}
}
