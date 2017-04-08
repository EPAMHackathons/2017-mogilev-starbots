
namespace NFBot.Infrastructure.DBComponents
{
	using System;
	#region Using

	using System.Collections.Generic;
	using NFBot.Interfaces;
	using NFBot.Models.DatabaseModel;


	#endregion

	public class TestComponent : ITestManagementComponent
	{
		public ICollection<Test> GetAllTests()
		{
			return null;
		}

		public Test GetCurrentTest(int userId)
		{
			return null;
		}

		public Test GetTestByCode(string code)
		{
			return null;
		}

		public void SaveAnswer(string body)
		{
			throw new NotImplementedException();
		}
	}
}