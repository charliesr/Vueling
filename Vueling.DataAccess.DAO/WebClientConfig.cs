using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    public static class WebClientConfig
    {
        public static HttpClient InitClient(HttpClient client)
        {
            client.BaseAddress = new Uri(
                ConfigurationUtils.GetWebClientAddress());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
