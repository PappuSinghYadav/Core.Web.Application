using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Core.Web.Api.Controllers
{
    [System.Web.Http.Authorize]
    [ApiController]
    [System.Web.Http.Route("api/[controller]")]
    public class LoginController : ApiController
    {
        IMapper _mapper;
        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
        }

    }
}
