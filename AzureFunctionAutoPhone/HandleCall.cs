namespace AzureFunctionAutoPhone
{
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Twilio.TwiML;
    using System.Net.Http.Headers;
    using System.Net;
    using System.Text;
    using Twilio.TwiML.Voice;

    public static class HandleCall
    {
        [FunctionName("HandleCall")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            foreach(var key in req.Form.Keys)
            {
                log.Info($"{key} = {req.Form[key]}");
            }

            VoiceResponse voiceResponse = new VoiceResponse();

            var gather = new Gather(input: "dtmf, speech, dtmf speech", timeout: 30, numDigits: 1, language: "en-GB", speechTimeout: "1");
            gather.Say("Hello", language: "en-GB", voice: "man");

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("", Encoding.ASCII, "application/xml");
            return response;
        }
    }
}
