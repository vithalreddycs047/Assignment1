using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebinarService.Controllers.Service;
using static WebinarService.Model.UMModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebinarService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WebinarController : ControllerBase
    {
        private IMapper _mapper;
        private IWebinarServices _webinarService;

        public WebinarController(IWebinarServices webinarService, IMapper mapper)
        {
            _webinarService = webinarService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SimpleFetchCall()
        {
            var response = _webinarService.SimpleFetchCall();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetUserdetails(int id)
        {
            var response = _webinarService.GetUserdetails(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult UserDetails(UserDetailsDTO userDetails)
        {
            var response = _webinarService.UserDetails(userDetails);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var response = _webinarService.GetUsers();
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetUsersById(string id)
        {
            var response =  _webinarService.GetuserdataById(id);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetUsersBydate(string id,DateTime activedate)
        {
            var response = _webinarService.GetuserdataByDate(id, activedate);
            return Ok(response);
        }

    }
}
