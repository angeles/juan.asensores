using ApiServer.Filters;
using ApiServer.Models;
using ApiServer.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiServer.Controllers
{
	public class PolicyController : ApiController
	{
		public readonly IPolicyService _service;

		public readonly IMapper _iMapper;

		public PolicyController(IPolicyService service, IMapper iMapper)
		{
			_service = service;
			_iMapper = iMapper;
		}

		[Route("users/{userName}/policies")]
		[Route("policies")]
		[ApiAuthorize(Roles = "admin")]
		[ResponseType(typeof(ICollection<PolicyModel>))]
		public IHttpActionResult GetByClientName(string userName)
		{
			var policies = _service.GetByClientName(userName);

			return Ok(_iMapper.Map<ICollection<PolicyModel>>(policies));
		}
	}
}
