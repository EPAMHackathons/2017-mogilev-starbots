using System;
using System.Collections.Generic;
using NFBot.Interfaces;
using NFBot.Models.DatabaseModel;

namespace NFBot.Infrastructure.DBComponents
{
	public class TestComponent : ITestManagementComponent
	{
		private SqliteDbRepository _repository;

		public TestComponent()
		{
			_repository = new SqliteDbRepository();
		}

		public ICollection<Test> GetAllTests()
		{
			return _repository.GetTests();
		}

		public Test GetCurrentTest(int userId)
		{
			var user = _repository.GetUserById(userId);

			if(user != null)
			{
				var userTestId = user.CurrentTestId;
				var tests = _repository.GetTests();
				return tests.Find(t => t.Id == userTestId);
			}

			return null;
		}

		public Test GetTestByCode(string code)
		{
			if (string.IsNullOrEmpty(code)) throw new ArgumentNullException("code");

			var tests = _repository.GetTests();
			return tests.Find(t => t.Code == code);
		}

       
    }
}