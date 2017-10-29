using ApiServer.Repository.Entities;
using AutoMapper;
using MockClient;

namespace ApiServer.Repository.MockService.AutoMapper
{
	public class EntitiesToMockMappingProfile : Profile
	{
		public override string ProfileName => "EntitiesToMockMappingProfile";

		public EntitiesToMockMappingProfile()
		{
			CreateMap<CompanyClient, Client>();
			CreateMap<Client, CompanyClient>();
			CreateMap<CompanyPolicy, Policy>();
			CreateMap<Policy, CompanyPolicy>();
		}
	}
}
