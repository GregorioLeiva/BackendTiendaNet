using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Tienda.Repository
{
	public interface ITiendaRepository : IRepository<Tienda.Model.Tienda> { }
	public class TiendaRepository : Repository<Tienda.Model.Tienda>, ITiendaRepository
	{
		public TiendaRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
