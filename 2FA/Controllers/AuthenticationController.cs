using Google.Authenticator;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace _2FA.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly TwoFactorAuthenticator _tfa;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(TwoFactorAuthenticator tfa, ILogger<AuthenticationController> logger)
        {
            _tfa = tfa;
            _logger = logger;
        }

        [HttpGet("generateQr/{email}")]
        public ActionResult<string> GenerateQR(string email)
        {
            string key = Guid.NewGuid().ToString().Replace("-","").Substring(0,10);
            SetupCode setupInfo = _tfa.GenerateSetupCode("2FA DO EVALDO", email, key, false, 3);

            _logger.LogInformation(key);

            return Ok(setupInfo.QrCodeSetupImageUrl);
        }

        [HttpPost("validateCode")]
        public ActionResult<bool> GenerateQR(string code, string key)
        {
            return _tfa.ValidateTwoFactorPIN(code, key);
        }
    }
}
