using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace _2FA.Controllers
{
    [Route("/costumer")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ILogger<CostumerController> _logger;
        private readonly IMapper _mapper;
        private readonly IDbConnection _connection;

        public CostumerController(ILogger<CostumerController> logger, IMapper mapper, IDbConnection connection)
        {
            _connection = connection;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("costumer/register")]
        public ActionResult<bool> 
    }
}
