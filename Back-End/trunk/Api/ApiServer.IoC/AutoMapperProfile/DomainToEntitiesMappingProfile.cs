using ApiServer.Domain;
using ApiServer.Repository.Entities;
using AutoMapper;

namespace ApiServer.IoC.AutoMapperProfile
{
	public class DomainToEntitiesMappingProfile : Profile
	{
		public override string ProfileName => "DomainToEntitiesMappingProfile";

		public DomainToEntitiesMappingProfile()
		{
			CreateMap<Client, ClientDto>();
			CreateMap<ClientDto, Client>();
			CreateMap<Policy, PolicyDto>();
			CreateMap<PolicyDto, Policy>();
		}
	}
}
