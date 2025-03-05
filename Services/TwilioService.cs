using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioApi.Services
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _phoneNumber;
        private readonly string _whatsappNumber;

        public TwilioService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSID"]!;
            _authToken = configuration["Twilio:AuthToken"]!;
            _phoneNumber = configuration["Twilio:PhoneNumber"]!;
            _whatsappNumber = configuration["Twilio:WhatsAppNumber"]!;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public string SendSms(string to, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber(to))
            {
                From = new PhoneNumber(_phoneNumber),
                Body = message
            };

            var sentMessage = MessageResource.Create(messageOptions);
            return sentMessage.Sid;
        }

        public string SendWhatsApp(string to, string message)
        {
            var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{to}"))
            {
                From = new PhoneNumber(_whatsappNumber),
                Body = message
            };

            var sentMessage = MessageResource.Create(messageOptions);
            return sentMessage.Sid;
        }
    }
}
