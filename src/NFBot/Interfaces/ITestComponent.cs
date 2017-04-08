using System.Collections.Generic;
using NFBot.Models.DatabaseModel;

namespace NFBot.Infrastructure.DBComponents
{
	public interface ITestComponent
	{
		List<Test> GetAllTests();
		Test GetCurrentTest(int userId);
		Test GetTestByCode(string code);
	}
}