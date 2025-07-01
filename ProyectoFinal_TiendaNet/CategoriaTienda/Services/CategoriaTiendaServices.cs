using AutoMapper;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaProducto.Repository;
using ProyectoFinal_TiendaNet.CategoriaTienda.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaTienda.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.CategoriaTienda.Services
{
	public class CategoriaTiendaServices
	{
		private readonly IMapper _mapper;
		private readonly ICategoriaTiendaRepository _categoriatiendaRepository;
		private readonly ApplicationDbContext _dbContext;
		public CategoriaTiendaServices(IMapper mapper, ICategoriaTiendaRepository categoriatiendaRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_categoriatiendaRepository = categoriatiendaRepository;
			_dbContext = dbContext;
		}
		private async Task<CategoriaTienda.Model.CategoriaTienda> GetOneByIdOrException(int id)
		{
			var categoriatienda = await _categoriatiendaRepository.GetOne(c => c.Id == id);
			if (categoriatienda == null)
			{
				throw new CustomHttpException($"No se encontro la categoria de tienda con Id = {id}", HttpStatusCode.NotFound);
			}
			return categoriatienda;
		}

		public async Task<CategoriaTienda.Model.CategoriaTienda> GetOneById(int id)
		{
			var categoriaTienda = await GetOneByIdOrException(id);
			return _mapper.Map<CategoriaTienda.Model.CategoriaTienda>(categoriaTienda);
		}
		public async Task<List<CategoriasTiendaDTO>> GetAll()
		{
			var categoriastienda = await _categoriatiendaRepository.GetAll();
			return _mapper.Map<List<CategoriasTiendaDTO>>(categoriastienda);
		}

		public async Task<CategoriaTienda.Model.CategoriaTienda> CreateOne(CreateCategoriaTiendaDTO createCategoriaTiendaDto)
		{
			var categoriatienda = _mapper.Map<CategoriaTienda.Model.CategoriaTienda>(createCategoriaTiendaDto);

			await _categoriatiendaRepository.Add(categoriatienda);
			return categoriatienda;
		}

		public async Task<CategoriaTienda.Model.CategoriaTienda> UpdateOneById(int id, UpdateCategoriaTiendaDTO updateCategoriaTiendaDto)
		{
			var categoriatienda = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateCategoriaTiendaDto, categoriatienda);

			await _categoriatiendaRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var categoriaTienda = await GetOneByIdOrException(id);

			await _categoriatiendaRepository.Delete(categoriaTienda);
		}
	}
}
