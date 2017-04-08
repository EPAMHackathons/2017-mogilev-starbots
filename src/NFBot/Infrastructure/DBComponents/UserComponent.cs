
namespace NFBot.Infrastructure.DBComponents
{
	#region Usings

	using System.Collections.Generic;
	using Interfaces;
	using NFBot.Models.DatabaseModel;

	#endregion

	public class UserComponent : IUserComponent
	{
		public void CreateUser(User user)
		{

		}

		public void SetupCurrentTest(int userId, int testId)
		{

		}

		public List<User> GetAllUsers()
		{
			return null;
		}

		public bool CheckUser(int userId)
		{
			return false;
		}
	}
}
