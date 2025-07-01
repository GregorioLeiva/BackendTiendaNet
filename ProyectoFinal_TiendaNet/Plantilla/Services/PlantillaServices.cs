using AutoMapper;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.MetodoPago.Model.Dto;
using ProyectoFinal_TiendaNet.MetodoPago.Repository;
using ProyectoFinal_TiendaNet.Plantilla.Model.Dto;
using ProyectoFinal_TiendaNet.Plantilla.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Plantilla.Services
{
	public class PlantillaServices
	{
		private readonly IMapper _mapper;
		private readonly IPlantillaRepository _plantillaRepository;
		private readonly ApplicationDbContext _dbContext;
		public PlantillaServices(IMapper mapper, IPlantillaRepository plantillaRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_plantillaRepository = plantillaRepository;
			_dbContext = dbContext;
		}
		private async Task<Plantilla.Model.Plantilla> GetOneByIdOrException(int id)
		{
			var plantilla = await _plantillaRepository.GetOne(p => p.Id == id);
			if (plantilla == null)
			{
				throw new CustomHttpException($"No se encontro la plantilla con Id = {id}", HttpStatusCode.NotFound);
			}
			return plantilla;
		}

		public async Task<Plantilla.Model.Plantilla> GetOneById(int id)
		{
			var plantilla = await GetOneByIdOrException(id);
			return _mapper.Map<Plantilla.Model.Plantilla>(plantilla);
		}
		public async Task<List<PlantillasDTO>> GetAll()
		{
			var plantilla = await _plantillaRepository.GetAll();
			return _mapper.Map<List<PlantillasDTO>>(plantilla);
		}

		public async Task<Plantilla.Model.Plantilla> CreateOne(CreatePlantillaDTO createPlantillaDto)
		{
			var plantilla = _mapper.Map<Plantilla.Model.Plantilla>(createPlantillaDto);

			await _plantillaRepository.Add(plantilla);
			return plantilla;
		}

		public async Task<Plantilla.Model.Plantilla> UpdateOneById(int id, UpdatePlantillaDTO updatePlantillaDto)
		{
			var plantilla = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updatePlantillaDto, plantilla);

			await _plantillaRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var plantilla = await GetOneByIdOrException(id);

			await _plantillaRepository.Delete(plantilla);
		}
	}
}
