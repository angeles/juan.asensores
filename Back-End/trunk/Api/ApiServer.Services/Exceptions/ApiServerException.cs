using System;

namespace ApiServer.Services
{
	public class ApiServerException : Exception
	{
		public ApiServerException(string message, Exception innerException) : base(message, innerException) { }
	}
}
