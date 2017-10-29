using ApiServer.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ApiServer.Repository
{
	public interface IPolicyRepository : IBaseRepository<Policy>
	{
		ICollection<Policy> GetByClientName(string clientName);

		ICollection<Policy> GetByClientId(Guid clientId);
	}
}
