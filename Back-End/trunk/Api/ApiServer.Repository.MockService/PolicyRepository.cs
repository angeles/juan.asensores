using ApiServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiServer.Repository.MockService
{
	public class PolicyRepository : BaseMockRepository, IPolicyRepository
	{
		public void Add(Policy entity)
		{
			throw new NotSupportedException();
		}

		public Policy GetById(Guid id)
		{
			var data = _client.GetPolicies().SingleOrDefault(x => x.Id == id);

			return _mapper.Map<Policy>(data);
		}

		public void Delete(Guid Id)
		{
			throw new NotSupportedException();
		}

		public void Delete(Policy entity)
		{
			throw new NotSupportedException();
		}

		public ICollection<Policy> GetAll()
		{
			var data = _client.GetPolicies();

			return _mapper.Map<ICollection<Policy>>(data);
		}

		public void Update(Policy entity)
		{
			throw new NotSupportedException();
		}

		public ICollection<Policy> GetByClientName(string clientName)
		{
			var client = _client.GetClients().FirstOrDefault(x => x.Name == clientName);
			if (client == null)
				return new List<Policy>();

			var data = _client.GetPolicies().Where(x => x.ClientId == client.Id).ToList();

			return _mapper.Map<ICollection<Policy>>(data);
		}

		public ICollection<Policy> GetByClientId(Guid clientId)
		{
			var data = _client.GetPolicies().Where(x => x.ClientId == clientId).ToList();

			return _mapper.Map<ICollection<Policy>>(data);
		}
	}
}
