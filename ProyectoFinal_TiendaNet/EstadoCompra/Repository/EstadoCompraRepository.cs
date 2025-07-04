using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.EstadoCompra.Repository
{
	public interface IEstadoCompraRepository : IRepository<EstadoCompra.Model.EstadoCompra> { }
	public class EstadoCompraRepository : Repository<EstadoCompra.Model.EstadoCompra>, IEstadoCompraRepository
	{
		public EstadoCompraRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
