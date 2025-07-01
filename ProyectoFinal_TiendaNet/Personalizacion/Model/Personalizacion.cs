using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Personalizacion.Model
{
    public class Personalizacion
    {
		//Poner que se genera Automáticamente

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string BackgroundColor { get; set; }

		public string LetterColor { get; set; }

		public string CardColor { get; set; }

		public string ButtonColor { get; set; }

		public DateTime FechaActualizacion { get; set; }

		//Relacion con la tabla tienda
		public int TiendaID { get; set; }

		public Tienda.Model.Tienda Tienda { get; set; }

	}
}
