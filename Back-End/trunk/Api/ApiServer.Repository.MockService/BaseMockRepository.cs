using ApiServer.Repository.MockService.AutoMapper;
using AutoMapper;
using System;
using ServiceClient = MockClient.MockClient;

namespace ApiServer.Repository.MockService
{
	public abstract class BaseMockRepository : IDisposable
	{
		protected ServiceClient _client;

		protected static IMapper _mapper;

		public BaseMockRepository()
		{
			_client = new ServiceClient();

			if (_mapper == null)
			{
				var config = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesToMockMappingProfile>());
				_mapper = config.CreateMapper();
			}
		}

		public void Dispose()
		{
			_client.Dispose();
			GC.SuppressFinalize(_client);
		}
	}
}
