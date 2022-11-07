using AutoMapper;
using Confitec.API.Domain.Commands.Requests.User;
using Confitec.API.Domain.Commands.Responses;
using Confitec.API.Domain.Contracts;
using Confitec.API.Domain.Handlers;
using Confitec.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _handler;
        private readonly IMapper _mapper;
        public UserController(UserHandler handler, IMapper mapper)
        {
            _handler = handler;
            _mapper = mapper;
        }



        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            var response = new List<GetAllResponse>();
            var result = _handler.GetAll().Result;

            if (result == null)
            {
                return NotFound();
            }

            foreach (var item in result)
            {
                response.Add(new GetAllResponse(item.Id, item.Name, item.LastName, item.Email, item.Education, item.BirthDate));
            }

           return Ok(response);
        }
        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _handler.GetById<User>(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result.Result);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody]CreateUserRequest obj)
        {
            var request = _mapper.Map<User>(obj);

            var result = _handler.Create(request).Result;

            return Ok(result);

        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateUserRequest request)
        {
            var obj = _mapper.Map<User>(request);

            return  Ok(_handler.Update(obj));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _handler.GetById<User>(id).Result;

            if (obj == null)
            {
                return NotFound();
            }

            var result = _handler.Delete(obj);

            return Ok(result);
        }
    }
}
