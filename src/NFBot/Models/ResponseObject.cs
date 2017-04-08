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
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseObject" /> class.
		/// </summary>
		public ResponseObject()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ResponseObject" /> class.
		/// </summary>
		public ResponseObject(string message, int userId)
		{
			this.Message = message;
			this.UserId = userId;
		}

		#endregion

		public string Message { get; set; }

		public int UserId { get; set; }

		public string AccessToken
		{
			get
			{
				return BotConstant.AccessToken;
			}
		}

		public string Version
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
