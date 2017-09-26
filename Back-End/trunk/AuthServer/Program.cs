using Microsoft.Owin.Hosting;
using Serilog;
using System;

namespace AuthServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo
				.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
				.CreateLogger();

			using (WebApp.Start<Startup>("http://localhost:5000"))
			{
				Console.WriteLine("AuthServer running...");
				Console.WriteLine("listening on port 5000");
				Console.ReadLine();
			}
		}
	}
}
