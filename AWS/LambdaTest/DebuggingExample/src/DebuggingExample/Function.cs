using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DebuggingExample
{
    public class Functions
    {
        ITimeProcessor processor = new TimeProcessor();

        void LogMessage(ILambdaContext ctx, string msg)
        {
            ctx.Logger.LogLine(
                string.Format("{0}:{1} - {2}", 
                    ctx.AwsRequestId, 
                    ctx.FunctionName,
                    msg));
        }


        private APIGatewayProxyResponse CreateResponse(DateTime? result)
        {
            int statusCode = new Func<DateTime?, int>( inputDateTime =>
            {
                if (inputDateTime == null)
                {
                    return (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    return (int)HttpStatusCode.OK;
                }
            })(result);

            string body = new Func<DateTime?, string>( inputDateTime =>
            {
                if (inputDateTime == null)
                {
                    return String.Empty;
                }
                else
                {
                    return JsonSerializer.Serialize(inputDateTime);
                }
            }
            )(result);

            var response = new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = body,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" }, 
                    { "Access-Control-Allow-Origin", "*" } 
                }
            };

            return response;
        }

        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {

        }

        public class RequestDataObject
        {
            public int code {get; set;}
        }

        /// <summary>
        /// A Lambda function to respond to HTTP Get methods from API Gateway
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The API Gateway response.</returns>
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            // context.Logger.LogLine("Get Request\n");
            LogMessage(context, "Processing request started");

            var objectToSerialise = new RequestDataObject(){code = 1};
            var jsonText = JsonSerializer.Serialize(objectToSerialise);

            var requestCode = new Func<string, int?>( (requestBody) => {
                if (requestBody == null)
                {
                    return null;
                }

                try {
                    return JsonSerializer.Deserialize<RequestDataObject>(requestBody).code;
                }
                catch (JsonException)
                {
                    return null;
                }

            })(request.Body);

            if (!requestCode.HasValue)
            {
                LogMessage(context, "Unable to understand input");
                return CreateResponse(null);
            }

            APIGatewayProxyResponse response;
            try 
            {
                var result = processor.CurrentTimeUTC();
                response = CreateResponse(result);

                LogMessage(context, "Processing request succeeded.");
            }
            catch (Exception ex)
            {
                LogMessage(context, string.Format("Processing request failed - {0}", ex.Message));
                response = CreateResponse(null);
            }

            return response;
            // var result = processor.CurrentTimeUTC();

            // return CreateResponse(result);

            // var response = new APIGatewayProxyResponse
            // {
            //     StatusCode = (int)HttpStatusCode.OK,
            //     Body = "Hello AWS Serverless",
            //     Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            // };

            // return response;
        }
    }
}
