using DalSoft.RestClient;

namespace Masami.Utils
{
    public class RambotAPI
    {
        private const string APIURL = "https://api.rambot.xyz/extended/v9/public/";

        public static async Task<dynamic> Run(string url, string lang = "false")
        {
            string requestUrl = APIURL + url;

            if (lang != "false")
                requestUrl += $"/${lang}";

            var client = new RestClient(requestUrl, new Config()
                .UseRetryHandler(
                    maxRetries: 5,
                    waitToRetryInSeconds: 6,
                    maxWaitToRetryInSeconds: 10,
                    backOffStrategy: DalSoft.RestClient.Handlers.RetryHandler.BackOffStrategy.Linear
                ));

            return await client.Get();


        }
    }
}