using System;

namespace ApiServer.Domain
{
	public class ClientDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Email { get; set; }

		public string Role { get; set; }
	}
}
