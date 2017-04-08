
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

		Test GetTestByCode(string code);
	}
}