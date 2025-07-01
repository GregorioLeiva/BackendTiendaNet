using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.MetodoPago.Model
{
    public class MetodoPago
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Nombre { get; set; }

	}
}
