
namespace NFBot.Infrastructure
{
	#region Usings

	using System.Diagnostics;
	using System.Net.Http;
	using System.Threading.Tasks;
	using NFBot.Models;

	#endregion

	public class RequestHandler
	{
		public async Task SendRequest(ResponseObject response)
		{
			string url = string.Format(response.Url, response.Message, response.UserId, response.AccessToken, response.Version);

			var client = new HttpClient();
			var responses = client.PostAsync(url, null);
			var responseString = responses.Result.Content.ReadAsStringAsync();

			Debug.WriteLine(responseString);
		}
	}
}
