using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalSoft.RestClient;

namespace Masami.Utils
{


    class api
    {

        public static async Task<dynamic> Run(string url, string lang = "false")
        {

            string apiurl = $"https://api.rambot.xyz/extended/v9/public/{url}";

            if (lang != "false") apiurl = $"https://api.rambot.xyz/extended/v9/public/{url}/${lang}";

            var config = new Config().UseRetryHandler(
                maxRetries: 5,
                waitToRetryInSeconds: 6,
                maxWaitToRetryInSeconds: 10,
                backOffStrategy: DalSoft.RestClient.Handlers.RetryHandler.BackOffStrategy.Linear
                
                );

            var client = new RestClient(apiurl, config);

            var data = await client.Get();

            

            return data;


        }
    

       

    }

}


