﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Rol.Model
{
    public class Rol
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }

		//Observacion: Podria ser un Enum

	}
}
