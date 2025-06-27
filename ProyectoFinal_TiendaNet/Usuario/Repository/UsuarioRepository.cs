using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Usuario.Repository
{
	public interface IUsuarioRepository : IRepository<Usuario.Model.Usuario> { }
	public class UsuarioRepository : Repository<Usuario.Model.Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
