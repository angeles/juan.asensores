using ApiServer.Domain;
using System;
using System.Collections.Generic;

namespace ApiServer.Services.Interfaces
{
	public interface IPolicyService : IServiceBase<PolicyDto>
	{
		ICollection<PolicyDto> GetByClientName(string clientName);

		ICollection<PolicyDto> GetByClientId(Guid clientId);
	}
}
