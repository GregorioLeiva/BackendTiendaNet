using AutoMapper;
using ProyectoFinal_TiendaNet.Comprador.Model;
using ProyectoFinal_TiendaNet.Comprador.Model.Dto;
using ProyectoFinal_TiendaNet.Comprador.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Comprador.Services
{
	public class CompradorServices
	{
		private readonly IMapper _mapper;
		private readonly ICompradorRepository _compradorRepository;
		private readonly ApplicationDbContext _dbContext;
		public CompradorServices(IMapper mapper, ICompradorRepository compradorRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_compradorRepository = compradorRepository;
			_dbContext = dbContext;
		}
		private async Task<Comprador.Model.Comprador> GetOneByIdOrException(int id)
		{
			var comprador = await _compradorRepository.GetOne(c => c.Id == id);
			if (comprador == null)
			{
				throw new CustomHttpException($"No se encontro el comprador con Id = {id}", HttpStatusCode.NotFound);
			}
			return comprador;
		}

		public async Task<Comprador.Model.Comprador> GetOneById(int id)
		{
			var comprador = await GetOneByIdOrException(id);
			return _mapper.Map<Comprador.Model.Comprador>(comprador);
		}
		public async Task<List<CompradoresDTO>> GetAll()
		{
			var compradores = await _compradorRepository.GetAll();
			return _mapper.Map<List<CompradoresDTO>>(compradores);
		}

		public async Task<Comprador.Model.Comprador> CreateOne(CreateCompradorDTO createCompradorDto)
		{
			var comprador = _mapper.Map<Comprador.Model.Comprador>(createCompradorDto);

			await _compradorRepository.Add(comprador);
			return comprador;
		}

		public async Task<Comprador.Model.Comprador> UpdateOneById(int id, UpdateCompradorDTO updateCompradorDto)
		{
			var comprador = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateCompradorDto, comprador);

			await _compradorRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var comprador = await GetOneByIdOrException(id);

			await _compradorRepository.Delete(comprador);
		}
	}
}
