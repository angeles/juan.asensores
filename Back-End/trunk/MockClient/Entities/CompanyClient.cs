using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MockClient
{
	public class CompanyClient
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

	public class CompanyClients
	{
		[JsonProperty("clients")]
		public List<CompanyClient> Clients;
	}
}
