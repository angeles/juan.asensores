using ApiServer.Models;
using ApiServer.Services.Interfaces;
using AutoMapper;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiServer.Controllers
{
	public class UserController : ApiController
	{
		public readonly IClientService _service;

		public readonly IMapper _iMapper;

		public UserController(IClientService service, IMapper iMapper)
		{
			_service = service;
			_iMapper = iMapper;
		}

		[Route("users/{id:guid}")]
		[Authorize(Roles = "user,admin")]
		[ResponseType(typeof(ClientModel))]
		public IHttpActionResult Get(Guid id)
		{
			var client = _service.ById(id);

			return Ok(_iMapper.Map<ClientModel>(client));
		}

		[Route("users/{name}")]
		[Authorize(Roles = "user,admin")]
		[ResponseType(typeof(ClientModel))]
		public IHttpActionResult GetByName(string name)
		{
			var client = _service.GetByName(name);

			return Ok(_iMapper.Map<ClientModel>(client));
		}

		[Route("policies/{number:guid}/user")]
		[Authorize(Roles = "admin")]
		[ResponseType(typeof(ClientModel))]
		public IHttpActionResult GetByPolicy(Guid number)
		{
			var client = _service.GetByPolicyId(number);

			return Ok(_iMapper.Map<ClientModel>(client));
		}
	}
}
