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

            TwilioClient.Init("", ""); // Twilio accountSid / authToken

            var call = CallResource.Create(to: new PhoneNumber("+447796758877"), // customer phone
                from: "+441616948114", // Twilio managed number
                applicationSid: ""); // Twilio -> Tools-> TwiML Apps -> Properties SID

            log.Info($"Call started: {call.Sid}");
            return (ActionResult)new OkObjectResult($"Call started: {call.Sid}");
        }
    }
}