using ApiServer.Domain;
using System;

namespace ApiServer.Services.Interfaces
{
	public interface IClientService : IServiceBase<ClientDto>
	{
		ClientDto GetByName(string name);

		ClientDto GetByPolicyId(Guid policyId);
	}
}
