
namespace NFBot.Models
{
	#region Usings

	using Newtonsoft.Json;

	#endregion

	public class RequestModel
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("object")]
		public RequestObject RequestObject { get; set; }

		[JsonIgnore]
		public string Message
		{
			get
			{
				return this.RequestObject.Body;
			}
		}

		[JsonIgnore]
		public int UserId
		{
			get
			{
				return this.RequestObject.UserId;
			}
		}
	}
}
