using ApiServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiServer.Domain;
using ApiServer.Repository;
using AutoMapper;

namespace ApiServer.Services.Services
{
	public class ClientService : IClientService
	{
		private readonly IUnitOfWork _uow;

		private readonly IClientRepository _repo;

		private readonly IMapper _mapper;

		public ClientService(IUnitOfWork uow, IClientRepository clientRepository, IMapper iMapper)
		{
			_repo = clientRepository;
			_uow = uow;
			_mapper = iMapper;
		}

		public ClientDto ById(Guid id)
		{
			try
			{
				var client = _repo.GetById(id);

				return _mapper.Map<ClientDto>(client);
			}
			catch (EntityNotFoundException e)
			{
				throw new ElementNotFoundException(e);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}

		public List<ClientDto> GetAll()
		{
			try
			{
				var result = _repo.GetAll();

				return _mapper.Map<List<ClientDto>>(result);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}

		public ClientDto GetByName(string name)
		{
			try
			{
				var client = _repo.GetByName(name);

				return _mapper.Map<ClientDto>(client);
			}
			catch (EntityNotFoundException e)
			{
				throw new ElementNotFoundException(e);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}

		public ClientDto GetByPolicyId(Guid policyId)
		{
			try
			{
				var client = _repo.GetByPolicy(policyId);

				return _mapper.Map<ClientDto>(client);
			}
			catch (EntityNotFoundException e)
			{
				throw new ElementNotFoundException(e);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}
	}
}
