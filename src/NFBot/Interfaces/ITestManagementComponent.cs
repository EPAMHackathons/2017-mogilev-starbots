
namespace NFBot.Interfaces
{
	#region Usings

	using System.Collections.Generic;
	using NFBot.Models.DatabaseModel;

	#endregion

	interface ITestManagementComponent
	{
		long UpdateUser(int userExternalId);

		ICollection<User> GetAllUsers();

		ICollection<Test> GetAllTests();
		Test GetCurrentTest(int userId);
	}
}