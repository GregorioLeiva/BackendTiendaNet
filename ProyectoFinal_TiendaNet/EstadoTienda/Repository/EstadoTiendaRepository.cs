using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.EstadoTienda.Repository
{
	public interface IEstadoTiendaRepository : IRepository<EstadoTienda.Model.EstadoTienda> { }
	public class EstadoTiendaRepository : Repository<EstadoTienda.Model.EstadoTienda>, IEstadoTiendaRepository
	{
		public EstadoTiendaRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
