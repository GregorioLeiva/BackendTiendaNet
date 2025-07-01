using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Plantilla.Repository
{
	public interface IPlantillaRepository : IRepository<Plantilla.Model.Plantilla> { }
	public class PlantillaRepository : Repository<Plantilla.Model.Plantilla>, IPlantillaRepository
	{
		public PlantillaRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
