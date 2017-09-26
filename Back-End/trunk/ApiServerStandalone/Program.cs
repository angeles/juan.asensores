using ApiServer;
using Microsoft.Owin.Hosting;
using Serilog;
using System;

namespace ApiServerStandalone
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo
				.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
				.CreateLogger();

			using (WebApp.Start<Startup>("http://localhost:1912"))
			{
				Console.WriteLine("ApiServer running...");
				Console.WriteLine("listening on port 1912");
				Console.ReadLine();
			}
		}
	}
}
