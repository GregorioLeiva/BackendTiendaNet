using AutoMapper;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Tienda.Model.Dto;
using ProyectoFinal_TiendaNet.Tienda.Repository;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;
using ProyectoFinal_TiendaNet.Usuario.Repository;
using ProyectoFinal_TiendaNet.Utils.Encoder;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Tienda.Services
{
	public class TiendaServices
	{
		private readonly IMapper _mapper;
		private readonly ITiendaRepository _tiendarepository;
		private readonly ApplicationDbContext _dbContext;
		public TiendaServices(IMapper mapper, ITiendaRepository tiendaRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_tiendarepository = tiendaRepository;
			_dbContext = dbContext;
		}

		private async Task<Tienda.Model.Tienda> GetOneByIdOrException(int id)
		{
			var tienda = await _tiendarepository.GetOne(t => t.Id == id, "EstadoTienda");
			if (tienda == null)
			{
				throw new CustomHttpException($"No se encontro la tienda con Id = {id}", HttpStatusCode.NotFound);
			}
			return tienda;
		}

		public async Task<Tienda.Model.Tienda> GetOneById(int id)
		{
			var tienda = await GetOneByIdOrException(id);
			return _mapper.Map<Tienda.Model.Tienda>(tienda);
		}
		public async Task<List<TiendasDTO>> GetAll()
		{
			var tienda = await _tiendarepository.GetAll();
			return _mapper.Map<List<TiendasDTO>>(tienda);
		}

		public async Task<Tienda.Model.Tienda> CreateOne(CreateTiendaDTO createTiendaDto)
		{
			var tienda = _mapper.Map<Tienda.Model.Tienda>(createTiendaDto);

			tienda.FechaCreacion = DateTime.UtcNow;

			tienda.EstadoTiendaId = 1; // Asignar estado activo por defecto

			await _tiendarepository.Add(tienda);
			return tienda;
		}

		public async Task<Tienda.Model.Tienda> UpdateOneById(int id, UpdateTiendaDTO updateTiendaDto)
		{
			var tienda = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateTiendaDto, tienda);

			await _tiendarepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var tienda = await GetOneByIdOrException(id);

			await _tiendarepository.Delete(tienda);
		}
	}
}
