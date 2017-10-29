using System;

namespace ApiServer.Repository.Entities
{
	public class Policy : BaseEntity
	{
		public decimal AmountInsured { get; set; }

		public string Email { get; set; }

		public DateTime InceptionDate { get; set; }

		public bool InstallmentPayment { get; set; }

		public Guid ClientId { get; set; }
	}
}
