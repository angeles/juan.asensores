using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Repository.Entities
{
	public class Client: BaseEntity
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public string Role { get; set; }
	}
}
