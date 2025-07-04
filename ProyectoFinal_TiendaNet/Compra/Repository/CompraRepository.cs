using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Compra.Repository
{
	public interface ICompraRepository : IRepository<Compra.Model.Compra> { }
	public class CompraRepository : Repository<Compra.Model.Compra>, ICompraRepository
	{
		public CompraRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
