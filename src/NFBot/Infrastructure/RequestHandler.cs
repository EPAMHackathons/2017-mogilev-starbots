
namespace NFBot.Infrastructure
{
	using System;
	#region Usings

	using System.Diagnostics;
	using System.Net.Http;
	using System.Threading.Tasks;
	using NFBot.Models;

	#endregion

	public class RequestHandler
	{
		public void SendRequest(ResponseObject response)
		{
			string url = string.Format(response.Url, response.Message, response.UserId, response.AccessToken, response.Version);

			var client = new HttpClient();
			Task<HttpResponseMessage> responses = client.PostAsync(url, null);
			string responseString = responses.Result.Content.ReadAsStringAsync().Result;

			Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss") + ": " + responseString);
		}
	}
}
