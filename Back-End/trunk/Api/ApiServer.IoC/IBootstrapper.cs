using Microsoft.Practices.Unity;

namespace ApiServer.IoC
{
	internal interface IBootstrapper
	{
		IUnityContainer Container { get; set; }

		void Connect();

		void Disconnect();
	}
}
