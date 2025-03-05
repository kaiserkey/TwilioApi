using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwilioApi.Models;
using TwilioApi.Services;

namespace TwilioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly TwilioService _twilioService;

        public NotificationController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }

        [HttpPost("sms")]
        public IActionResult SendSms([FromBody] NotificationRequest request)
        {
            var messageId = _twilioService.SendSms(request.To, request.Message);
            return Ok(new { MessageId = messageId, Status = "Sent via SMS" });
        }

        [HttpPost("whatsapp")]
        public IActionResult SendWhatsApp([FromBody] NotificationRequest request)
        {
            var messageId = _twilioService.SendWhatsApp(request.To, request.Message);
            return Ok(new { MessageId = messageId, Status = "Sent via WhatsApp" });
        }
    }
}
