using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Personalizacion.Repository
{
	public interface IPersonalizacionRepository : IRepository<Personalizacion.Model.Personalizacion> {  }
	public class PersonalizacionRepository : Repository<Personalizacion.Model.Personalizacion>, IPersonalizacionRepository
	{
		public PersonalizacionRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
