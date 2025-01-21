using _2FA.DTOs;
using AutoMapper;
using Google.Authenticator;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using Dapper;
using Microsoft.Extensions.Logging;
using _2FA.Models;

namespace _2FA.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TwoFactorAuthenticator _tfa;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;
        private readonly TokenController _tokenController;

        public AuthenticationController(TokenController tokenController, IMapper mapper, TwoFactorAuthenticator tfa, ILogger<AuthenticationController> logger, IDbConnection connection)
        {
            _mapper = mapper;
            _tfa = tfa;
            _logger = logger;
            _connection = connection;
            _tokenController = tokenController;
        }

        [HttpGet("generateQr/{email}")]
        public ActionResult<string> GenerateQR(string email)
        {
            try
            {
                string key = Guid.NewGuid().ToString().Replace("-","").Substring(0,10);
                SetupCode setupInfo = _tfa.GenerateSetupCode("2FA DO EVALDO", email, key, false, 3);

                _logger.LogInformation(key);

                return setupInfo.QrCodeSetupImageUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao gerar QR code");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("validateCode")]
        public ActionResult<bool> ValidateCode(string code, string key)
        {
            try
            {
                return _tfa.ValidateTwoFactorPIN(code, key);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao validar QR code");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("auth/validateUser")]
        public ActionResult<LoginDTO> ValidateUser([FromBody] LoginDTO login)
        {
            try
            {
                var sql = "SELECT * FROM Costumers WHERE Email = @Email AND Password = @Password";

                var costumerDb = _connection.QueryFirstOrDefault<Costumer>(sql, new { Email = login.Email, Password = login.Password });

                if (costumerDb == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                var token = _tokenController.CreateToken(costumerDb);

                return Ok(token);
            }
            catch (Exception ex) 
            {
                _logger.LogError("Erro ao verificar cliente: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
