using Newtonsoft.Json;
using NFBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models
{
    public class ResponseObject
    {
        public string Message { get; set; }

        public string UserId { get; set; }

        public string AccessToken
        {
            get
            {
                return BotConstant.AccessToken;
            }
        }

        public string V
        {
            get
            {
                return "5.0";
            }
        }

        public string Url
        {
            get
            {
                return "https://api.vk.com/method/messages.send?message={0}&user_id={1}&access_token={2}&v={3}";
            }
        }
    }
}
