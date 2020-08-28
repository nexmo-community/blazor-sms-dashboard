using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Vonage.Messaging;
using Vonage.Request;
using VonageSmsDashboard.Shared;
using Vonage.Utility;

namespace VonageSmsDashboard.Server.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IHubContext<Hubs.SmsHub> _hubContext;
        private readonly SmsContext _dbContext;

        public SmsController(IConfiguration config, IHubContext<Hubs.SmsHub> context, SmsContext dbContext)
        {
            _hubContext = context;
            _config = config;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("[controller]/sendsms")]
        public async Task<ActionResult<OutboundSms>> SendSms([FromBody] OutboundSms sms)
        {
            var apiKey = _config["API_KEY"];
            var apiSecret = _config["API_SECRET"];
            var credentials = Credentials.FromApiKeyAndSecret(apiKey, apiSecret);
            var request = new SendSmsRequest { To = sms.To, From = sms.From, Text = sms.Text };
            var client = new SmsClient(credentials);
            var response = client.SendAnSms(request);
            sms.MessagePrice = response.Messages[0].MessagePrice;
            sms.Status = response.Messages[0].Status;
            sms.MessageId = response.Messages[0].MessageId;
            _dbContext.Add(sms);
            await _dbContext.SaveChangesAsync();
            return sms;
        }

        [HttpGet]
        [Route("[controller]/getInboundSms")]
        public ActionResult<List<InboundSmsModel>> GetInboundSms()
        {
            return _dbContext.InboundSms.ToList();

        }

        [HttpGet]
        [Route("[controller]/getDlr")]
        public ActionResult<List<DeliveryReceiptModel>> GetDlr()
        {
            return _dbContext.Dlrs.ToList();
        }

        [HttpGet]
        [Route("[controller]/getOutboundSms")]
        public ActionResult<List<OutboundSms>> GetOutboundSms()
        {
            return _dbContext.OutboundSms.ToList();
        }

        [HttpPost]
        [Route("webhooks/inbound-sms")]
        public async Task<IActionResult> ReceiveSms()
        {
            var inboundSms = WebhookParser.ParseWebhook<InboundSms>(Request.Body,Request.ContentType);
            var inboundSmsModel = new InboundSmsModel { Msisdn = inboundSms.Msisdn, To = inboundSms.To, MessageId = inboundSms.MessageId, Text = inboundSms.Text, MessageTimestamp = inboundSms.MessageTimestamp };
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", inboundSms);
            _dbContext.InboundSms.Add(inboundSmsModel);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        [Route("webhooks/dlr")]
        public async Task<IActionResult> ReceiveDlr()
        {
            var dlr = WebhookParser.ParseWebhook<DeliveryReceipt>(Request.Body,Request.ContentType);
            var dlrModel = new DeliveryReceiptModel { Msisdn = dlr.Msisdn, To = dlr.To, MessageId = dlr.MessageId, Status = dlr.StringStatus, MessageTimestamp = dlr.MessageTimestamp };
            await _hubContext.Clients.All.SendAsync("ReceiveDlr", dlrModel);
            _dbContext.Dlrs.Add(dlrModel);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
