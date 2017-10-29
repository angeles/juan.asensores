using ApiServer.Repository.Entities;
using System;

namespace ApiServer.Repository
{
	public interface IClientRepository : IBaseRepository<Client>
	{
		Client GetByName(string name);

		Client GetByPolicy(Guid policyId);
	}
}
