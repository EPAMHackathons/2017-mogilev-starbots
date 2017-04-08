using NFBot.Models.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFBot.Infrastructure.DBComponents
{
	public class TestResultComponent
	{
		private SqliteDbRepository _repository;

		public TestResultComponent()
		{
			_repository = new SqliteDbRepository();
		}

		public TestResult GetUserResult(int userId, int testId)
		{
			return _repository.GetTestResults().FirstOrDefault(tr => tr.UserId == userId && tr.TestId == testId);
		}

		public TestResult GetCurrentUserResult(int userId)
		{
			return _repository.GetTestResults().First(tr => tr.UserId == userId);
		}

		public void SaveResult(int userId, TestResult results)
		{
			if (results == null) throw new ArgumentNullException("results");

			int currentUserId = userId == 0 ? results.UserId : userId;

			var existingUserTestResult = GetUserResult(currentUserId, results.TestId);

			if(existingUserTestResult == null)
			{
				_repository.InsertTestResult(results.TestId, currentUserId, results.Result, results.IsFinished);
			}
			else
			{
				_repository.UpdateTestResult(existingUserTestResult.Id, results.TestId, currentUserId, results.Result, results.IsFinished);
			}
		}


		public List<TestResult> GetAllResults(int testId)
		{
			return _repository.GetTestResults().Where(tr => tr.TestId == testId).ToList<TestResult>();
		}
	}
}
