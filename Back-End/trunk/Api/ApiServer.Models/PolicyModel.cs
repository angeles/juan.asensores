using Newtonsoft.Json;
using System;

namespace ApiServer.Models
{
	public class PolicyModel
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("amountInsured")]
		public decimal AmountInsured { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("inceptionDate")]
		public DateTime InceptionDate { get; set; }

		[JsonProperty("installmentPayment")]
		public bool InstallmentPayment { get; set; }

		[JsonProperty("clientId")]
		public Guid ClientId { get; set; }
	}
}
