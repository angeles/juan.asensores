using ApiServer.IoC;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ApiServer
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

			Bootstrapper _bootstrapper = new Bootstrapper();
			_bootstrapper.Connect();

			config.DependencyResolver = new UnityDependencyResolver(_bootstrapper.Container);
        }
    }
}