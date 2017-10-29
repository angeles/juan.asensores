using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Services.Interfaces
{
	public interface IServiceBase<TDto> where TDto: class
	{
		TDto ById(Guid id);

		List<TDto> GetAll();
	}
}
