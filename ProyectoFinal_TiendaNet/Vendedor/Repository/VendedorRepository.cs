using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Vendedor.Repository
{
	public interface IVendedorRepository : IRepository<Vendedor.Model.Vendedor> { }
	public class VendedorRepository : Repository<Vendedor.Model.Vendedor>, IVendedorRepository
	{
		public VendedorRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
