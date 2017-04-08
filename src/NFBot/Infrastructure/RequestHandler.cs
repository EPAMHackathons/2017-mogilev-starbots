using NFBot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NFBot.Infrastructure
{
    public class RequestHandler
    {
        public async Task SendRequest(ResponseObject response)
        {
            string url = string.Format(response.Url, response.Message, response.UserId, response.AccessToken, response.Version);

            var client = new HttpClient();
            var responses = client.PostAsync(url, null);
            var responseString = responses.Result.Content.ReadAsStringAsync();
        }
    }
}
