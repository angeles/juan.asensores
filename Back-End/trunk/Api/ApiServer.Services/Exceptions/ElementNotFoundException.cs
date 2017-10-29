using System;

namespace ApiServer.Services
{
	public class ElementNotFoundException : ApiServerException
	{
		public ElementNotFoundException(Exception innerException) : base(innerException.Message, innerException)
		{
		}
	}
}
