using ApiServer.IoC.AutoMapperProfile;
using ApiServer.Repository;
using ApiServer.Services.Interfaces;
using ApiServer.Services.Services;
using AutoMapper;
using Microsoft.Practices.Unity;

namespace ApiServer.IoC
{
	public class Bootstrapper : IBootstrapper
	{
		public IUnityContainer Container { get; set; }

		public void Disconnect()
		{
			Container.Dispose();
		}

		public void Connect()
		{
			Container = new UnityContainer();

			//Container.RegisterType<DataContext, DataContext>(new InjectionConstructor());

			//Service
			Container.RegisterType<IClientService, ClientService>();
			Container.RegisterType<IPolicyService, PolicyService>();

			Container.RegisterType<IClientRepository, Repository.MockService.ClientRepository>();
			Container.RegisterType<IPolicyRepository, Repository.MockService.PolicyRepository>();

			Container.RegisterType<IUnitOfWork, Repository.MockService.UnitOfWork>();

			//AutoMapper
			var manager = new ExternallyControlledLifetimeManager();
			var map = ConfigureMapper();
			Container.RegisterInstance(map);
		}

		private IMapper ConfigureMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<DomainToEntitiesMappingProfile>();
				cfg.AddProfile<DomainToModelMappingProfile>();
			});

			return config.CreateMapper();
		}
	}
}
