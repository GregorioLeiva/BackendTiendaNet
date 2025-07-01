using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.CategoriaTienda.Repository
{
	public interface ICategoriaTiendaRepository : IRepository<CategoriaTienda.Model.CategoriaTienda> { }
	public class CategoriaTiendaRepository : Repository<CategoriaTienda.Model.CategoriaTienda>, ICategoriaTiendaRepository
	{
		public CategoriaTiendaRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
