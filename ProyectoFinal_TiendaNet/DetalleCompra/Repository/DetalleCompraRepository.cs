using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.DetalleCompra.Repository
{
	public interface IDetalleCompraRepository : IRepository<DetalleCompra.Model.DetalleCompra> { }
	public class DetalleCompraRepository : Repository<DetalleCompra.Model.DetalleCompra>, IDetalleCompraRepository
	{
		public DetalleCompraRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
