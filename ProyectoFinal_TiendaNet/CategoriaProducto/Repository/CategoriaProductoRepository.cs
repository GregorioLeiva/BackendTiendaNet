using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.CategoriaProducto.Repository
{
	public interface ICategoriaProductoRepository : IRepository<CategoriaProducto.Model.CategoriaProducto> { }
	public class CategoriaProductoRepository : Repository<CategoriaProducto.Model.CategoriaProducto>, ICategoriaProductoRepository
	{
		public CategoriaProductoRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
