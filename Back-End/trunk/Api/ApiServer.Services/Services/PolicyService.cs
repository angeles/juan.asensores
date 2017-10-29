using System;
using ApiServer.Services.Interfaces;
using ApiServer.Domain;
using ApiServer.Repository;
using AutoMapper;
using System.Collections.Generic;

namespace ApiServer.Services.Services
{
	public class PolicyService : IPolicyService
	{
		private readonly IUnitOfWork _uow;

		private readonly IPolicyRepository _repo;

		private readonly IMapper _mapper;

		public PolicyService(IUnitOfWork uow, IPolicyRepository policyRepository, IMapper iMapper)
		{
			_repo = policyRepository;
			_uow = uow;
			_mapper = iMapper;
		}

		public PolicyDto ById(Guid id)
		{
			throw new NotImplementedException();
		}

		public System.Collections.Generic.List<PolicyDto> GetAll()
		{
			throw new NotImplementedException();
		}

		public ICollection<PolicyDto> GetByClientName(string clientName)
		{
			try
			{
				var policies = _repo.GetByClientName(clientName);

				return _mapper.Map<ICollection<PolicyDto>>(policies);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}

		public ICollection<PolicyDto> GetByClientId(Guid clientId)
		{
			try
			{
				var policies = _repo.GetByClientId(clientId);

				return _mapper.Map<ICollection<PolicyDto>>(policies);
			}
			catch (Exception e)
			{
				throw new ApiServerException("Unexpected error", e);
			}
		}
	}
}
