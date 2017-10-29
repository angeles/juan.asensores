using ApiServer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiServer.Repository.MockService
{
	public class ClientRepository : BaseMockRepository, IClientRepository
	{
		public void Add(Client entity)
		{
			throw new NotSupportedException();
		}

		public Client GetById(Guid id)
		{
			var data = _client.GetClients().SingleOrDefault(x => x.Id == id);

			if (data == null)
			{
				throw new EntityNotFoundException(typeof(Client));
			}

			return _mapper.Map<Client>(data);
		}

		public void Delete(Guid Id)
		{
			throw new NotSupportedException();
		}

		public void Delete(Client entity)
		{
			throw new NotSupportedException();
		}

		public ICollection<Client> GetAll()
		{
			var data = _client.GetClients();

			return _mapper.Map<ICollection<Client>>(data);
		}

		public void Update(Client entity)
		{
			throw new NotSupportedException();
		}

		public Client GetByName(string name)
		{
			var data = _client.GetClients().SingleOrDefault(x => x.Name == name);

			if (data == null)
				throw new EntityNotFoundException(typeof(Client));

			return _mapper.Map<Client>(data);
		}

		public Client GetByPolicy(Guid policyId)
		{
			var policy = _client.GetPolicies().FirstOrDefault(x => x.Id == policyId);

			if (policy == null)
				throw new EntityNotFoundException(typeof(Policy));

			var client = _client.GetClients().FirstOrDefault(x => x.Id == policy.ClientId);

			if (client == null)
				throw new EntityNotFoundException(typeof(Client));

			return _mapper.Map<Client>(client);
		}
	}
}
