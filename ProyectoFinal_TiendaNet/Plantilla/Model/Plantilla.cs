using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Plantilla.Model
{
    public class Plantilla
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string BackgroundColor { get; set; }

		public string LetterColor { get; set; }

		public string CardColor { get; set; }

		public string ButtonColor { get; set; }

	}
}
