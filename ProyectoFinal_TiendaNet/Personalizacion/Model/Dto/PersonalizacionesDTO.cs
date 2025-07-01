namespace ProyectoFinal_TiendaNet.Personalizacion.Model.Dto
{
	public class PersonalizacionesDTO
	{
		public int Id { get; set; }

		public string BackgroundColor { get; set; }

		public string LetterColor { get; set; }

		public string CardColor { get; set; }

		public string ButtonColor { get; set; }

		public DateTime FechaActualizacion { get; set; }

		//Relacion con la tabla tienda
		public int TiendaID { get; set; }
	}
}
