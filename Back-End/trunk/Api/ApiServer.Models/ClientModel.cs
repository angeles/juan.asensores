using Newtonsoft.Json;
using System;

namespace ApiServer.Models
{
	public class ClientModel
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
