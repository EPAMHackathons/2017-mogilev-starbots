using Newtonsoft.Json;

namespace NFBot.Models
{
    public class RequestObject
    {
        [JsonProperty(PropertyName="user_id")]
        public string UserId { get; set; }

        public string Body { get; set; }
    }
}
