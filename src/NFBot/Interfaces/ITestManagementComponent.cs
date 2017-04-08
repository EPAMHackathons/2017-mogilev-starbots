
namespace NFBot.Interfaces
{
	#region Usings

	using System.Collections.Generic;
	using NFBot.Models.DatabaseModel;

	#endregion

	interface ITestManagementComponent
	{
		ICollection<Test> GetAllTests();

		Test GetCurrentTest(int userId);

		void SaveAnswer(string body);

		Test GetTestByCode(string code);
	}
}