﻿namespace ProyectoFinal_TiendaNet.Utils.Exceptions
{
	public class CustomMessage
	{
		public string Message { get; set; } = null!;

		public CustomMessage(string message)
		{
			Message = message;
		}
	}
}
