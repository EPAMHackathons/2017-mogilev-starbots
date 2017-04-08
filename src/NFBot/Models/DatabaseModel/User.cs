namespace NFBot.Models.DatabaseModel
{
	public class User
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="User" /> class.
		/// </summary>
		public User()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="User" /> class.
		/// </summary>
		public User(int userId)
		{
			this.UserId = userId;
		}

		#endregion

		public int UserId { get; set; }

		public string City { get; set; }

		public int CurrentTestId { get; set; }
	}
}
