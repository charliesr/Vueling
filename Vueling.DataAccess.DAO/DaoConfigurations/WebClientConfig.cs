using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO.DaoConfigurations
{
    public static class WebClientConfig
    {
        public static HttpClient InitClient(HttpClient client)
        {
            client.BaseAddress = new Uri(
                ConfigurationUtils.GetWebClientAddress());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ConfigurationUtils.GetConfigForWebClient()));
            return client;
        }
    }
}
