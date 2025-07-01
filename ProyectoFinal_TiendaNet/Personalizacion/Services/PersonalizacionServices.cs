using AutoMapper;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Personalizacion.Model.Dto;
using ProyectoFinal_TiendaNet.Personalizacion.Repository;
using ProyectoFinal_TiendaNet.Plantilla.Model.Dto;
using ProyectoFinal_TiendaNet.Plantilla.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Personalizacion.Services
{
	public class PersonalizacionServices
	{
		private readonly IMapper _mapper;
		private readonly IPersonalizacionRepository _personalizacionRepository;
		private readonly ApplicationDbContext _dbContext;
		public PersonalizacionServices(IMapper mapper, IPersonalizacionRepository personalizacionRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_personalizacionRepository = personalizacionRepository;
			_dbContext = dbContext;
		}
		private async Task<Personalizacion.Model.Personalizacion> GetOneByIdOrException(int id)
		{
			var personalizacion = await _personalizacionRepository.GetOne(p => p.Id == id);
			if (personalizacion == null)
			{
				throw new CustomHttpException($"No se encontro la personalizacion con Id = {id}", HttpStatusCode.NotFound);
			}
			return personalizacion;
		}

		public async Task<Personalizacion.Model.Personalizacion> GetOneById(int id)
		{
			var personalizacion = await GetOneByIdOrException(id);
			return _mapper.Map<Personalizacion.Model.Personalizacion>(personalizacion);
		}
		public async Task<List<PersonalizacionesDTO>> GetAll()
		{
			var personalizacions = await _personalizacionRepository.GetAll();
			return _mapper.Map<List<PersonalizacionesDTO>>(personalizacions);
		}

		public async Task<Personalizacion.Model.Personalizacion> CreateOne(CreatePersonalizacionDTO createPersonalizacionDto)
		{
			var personalizacion = _mapper.Map<Personalizacion.Model.Personalizacion>(createPersonalizacionDto);

			await _personalizacionRepository.Add(personalizacion);
			return personalizacion;
		}

		public async Task<Personalizacion.Model.Personalizacion> UpdateOneById(int id, UpdatePersonalizacionDTO updatePersonalizacionDto)
		{
			var personalizacion = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updatePersonalizacionDto, personalizacion);

			await _personalizacionRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var personalizacion = await GetOneByIdOrException(id);

			await _personalizacionRepository.Delete(personalizacion);
		}
	}
}
