using ApiServer.Domain;
using ApiServer.Models;
using AutoMapper;

namespace ApiServer.IoC.AutoMapperProfile
{
	public class DomainToModelMappingProfile : Profile
	{
		public override string ProfileName => "DomainToModelMappingProfile";

		public DomainToModelMappingProfile()
		{
			CreateMap<ClientModel, ClientDto>();
			CreateMap<ClientDto, ClientModel>();
			CreateMap<PolicyModel, PolicyDto>();
			CreateMap<PolicyDto, PolicyModel>();
		}
	}
}
