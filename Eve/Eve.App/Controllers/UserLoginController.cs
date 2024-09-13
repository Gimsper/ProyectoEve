using Eve.Core.DTO;
using Eve.Core.Entities;
using Eve.Infraestructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace Eve.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _service;

        public UserLoginController(IUserLoginService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result.Results);
        }
        
        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result.Result != null ? Ok(result.Result) : NotFound();
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add(UserLoginDTO userLogin)
        {
            UserLogin entity = new UserLogin
            {
                Username = userLogin.Username,
                Pass = userLogin.Pass,
                Email = userLogin.Email
            };

            var response = _service.Add(entity); 
            return response.StateOperation ? Created(nameof(entity), entity) : BadRequest(userLogin);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Update(UserLogin userLogin)
        {
            var response = _service.Update(userLogin);
            return response.Result ? Ok(response.Result) : BadRequest(userLogin);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = _service.DeleteById(id);
            return response.Result ? Ok(response.Result) : NotFound();
        }
    }
}
