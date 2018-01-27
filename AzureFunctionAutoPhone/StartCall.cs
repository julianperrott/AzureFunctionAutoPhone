namespace AzureFunctionAutoPhone
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    public static class StartCall
    {
        [FunctionName("StartCall")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Running StartCall");

            TwilioClient.Init("AC12e83e21706054c0a1a997112f44fb84", "41f833750330c488cff9bdb24f8995fb"); // Twilio accountSid / authToken

            var call = CallResource.Create(to: new PhoneNumber("+447796758877"), // customer phone
                from: "+441616948114", // Twilio managed number
                applicationSid: "AP6b5649b78dd87176b849bb993fbf069e"); // Twilio -> Tools-> TwiML Apps -> Properties SID

            log.Info($"Call started: {call.Sid}");
            return (ActionResult)new OkObjectResult($"Call started: {call.Sid}");
        }
    }
}