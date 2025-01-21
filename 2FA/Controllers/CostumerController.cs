using _2FA.DTOs;
using AutoMapper;
using Dapper;
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

        [HttpPost("register")]
        public ActionResult<RegisterDTO> RegisterCostumer([FromBody] RegisterDTO register)
        {
            try
            {
                var sql = "INSERT INTO Costumers (CPF,Username,Email,Password) VALUES (@CPF,@Username,@Email,@Password)";

                _connection.Execute(sql, new
                {
                    CPF = register.CPF,
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                });

                return Ok(register.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possível criar o cliente: " + ex.Message);
                return BadRequest("Não foi possível criar o cliente: " + ex.Message);
            }
        }
    }
}
