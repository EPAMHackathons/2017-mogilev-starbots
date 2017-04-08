using System.Collections.Generic;
using NFBot.Models.DatabaseModel;

namespace NFBot.Interfaces
{
	public interface IUserComponent
	{
		bool CheckUser(int userId);
		void CreateUser(User user);
		List<User> GetAllUsers();
		void SetupCurrentTest(int userId, int testId);
	}
}