using Microsoft.Data.Sqlite;
using NFBot.Models.CompabilityModel;
using NFBot.Models.DatabaseModel;
using System.Collections.Generic;

namespace NFBot.Infrastructure.DBComponents
{
	public class SqliteDbRepository
	{
		#region Private Fields

		private const string ConnectionString = "Data Source = nfbot.db;";
		private SqliteConnection _connection;

		#endregion

		#region Public Properties

		public SqliteConnection Connection
		{
			get
			{
				return this._connection;
			}

			private set
			{
				this._connection = value;
			}
		}

		#endregion

		#region Constructors

		public SqliteDbRepository()
		{
			Connection = new SqliteConnection(ConnectionString);
		}

		#endregion

		~SqliteDbRepository()
		{
			Connection.Close();
		}

		#region Public Interface

		#region DML Statements

		public void InsertUser(int id, string city, int currentTest)
		{
			string commandText = @"INSERT OR IGNORE INTO USER ([ID], [CITY], [CURRENT_TEST]) VALUES (@Id, @City, @CurrentTest);";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;
			command.Parameters.AddWithValue("@Id", id);
			command.Parameters.AddWithValue("@City", city);
			command.Parameters.AddWithValue("@CurrentTest", currentTest);

			ExecuteNonQueryCommand(command);
		}

		public void UpdateUser(int id, string city, int currentTest)
		{
			string commandText = @"UPDATE USER SET CITY = @City WHERE ID = @Id; UPDATE USER SET CURRENT_TEST = @CurrentTest WHERE ID = @Id;";
			var command = Connection.CreateCommand();
			command.CommandText = commandText;
			command.Parameters.AddWithValue("@Id", id);
			command.Parameters.AddWithValue("@City", city);
			command.Parameters.AddWithValue("@CurrentTest", currentTest);

			ExecuteNonQueryCommand(command);
		}

		public void InsertTestResult(int testId, int userId, string result, bool isFinished)
		{
			string commandText = @"INSERT OR IGNORE INTO TEST_RESULT ([TEST_ID], [USER_ID], [RESULT], [IS_FINISHED]) VALUES (@TestId, @UserId, @Result, @IsFinished);";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;
			command.Parameters.AddWithValue("@TestId", testId);
			command.Parameters.AddWithValue("@UserId", userId);
			command.Parameters.AddWithValue("@Result", result);
			command.Parameters.AddWithValue("@IsFinished", isFinished ? 1 : 0);

			ExecuteNonQueryCommand(command);
		}

		public void UpdateTestResult(int id, int testId, int userId, string result, bool isFinished)
		{
			string commandText = "UPDATE TEST_RESULT SET TEST_ID = @TestId WHERE ID = @Id;"
								+ "UPDATE TEST_RESULT SET USER_ID = @UserId WHERE ID = @Id;"
								+ "UPDATE TEST_RESULT SET RESULT = @Result WHERE ID = @Id;"
								+ "UPDATE TEST_RESULT SET IS_FINISHED = @IsFinished WHERE ID = @Id;";
			var command = Connection.CreateCommand();
			command.CommandText = commandText;
			command.Parameters.AddWithValue("@Id", id);
			command.Parameters.AddWithValue("@TestId", testId);
			command.Parameters.AddWithValue("@UserId", userId);
			command.Parameters.AddWithValue("@Result", result);
			command.Parameters.AddWithValue("@IsFinished", isFinished ? 1 : 0);

			ExecuteNonQueryCommand(command);
		}

		#endregion

		#region Data Retrieve

		public List<User> GetUsers()
		{
			var result = new List<User>();

			const string commandText = @"SELECT * FROM USER;";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;

			Connection.Open();
			var resultReader = command.ExecuteReader();
			while (resultReader.Read())
			{
				result.Add(new User
				{
					UserId = int.Parse(resultReader["ID"].ToString()),
					City = resultReader["CITY"].ToString(),
					CurrentTestId = int.Parse(resultReader["CURRENT_TEST"].ToString())
				}
				);
			}

			return result;
		}

		public User GetUserById(int id)
		{
			User result = null;

			const string commandText = @"SELECT * FROM USER WHERE ID = @Id;";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;
			command.Parameters.AddWithValue("@Id", id);

			Connection.Open();
			var resultReader = command.ExecuteReader();
			while (resultReader.Read())
			{
				result = new User();
				result.UserId = int.Parse(resultReader["ID"].ToString());
				result.City = resultReader["CITY"].ToString();
				result.CurrentTestId = int.Parse(resultReader["CURRENT_TEST"].ToString());
			}

			return result;
		}

		public List<Test> GetTests()
		{
			var result = new List<Test>();

			const string commandText = @"SELECT * FROM TEST;";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;

			Connection.Open();
			var resultReader = command.ExecuteReader();
			while (resultReader.Read())
			{
				result.Add(new Test
				{
					Id = int.Parse(resultReader["ID"].ToString()),
					Code = resultReader["CODE"].ToString(),
					Name = resultReader["NAME"].ToString(),
					TestObject = resultReader["TEST"].ToString()
				}
				);
			}

			return result;
		}

		public List<TestResult> GetTestResults()
		{
			var result = new List<TestResult>();

			const string commandText = @"SELECT * FROM TEST_RESULT;";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;

			Connection.Open();
			var resultReader = command.ExecuteReader();
			while (resultReader.Read())
			{
				result.Add(new TestResult
				{
					Id = int.Parse(resultReader["ID"].ToString()),
					TestId = int.Parse(resultReader["TEST_ID"].ToString()),
					UserId = int.Parse(resultReader["USER_ID"].ToString()),
					Result = resultReader["RESULT"].ToString(),
					IsFinished = int.Parse(resultReader["IS_FINISHED"].ToString()) == 1 ? true : false
				}
				);
			}

			return result;
		}

		#endregion

		#region DDL Statements

		public void CreateUserTable()
		{
			const string commandText = "DROP TABLE IF EXISTS USER; " +
									   "CREATE TABLE USER(" +
									   "ID INTEGER PRIMARY KEY," +
									   "CITY TEXT," +
									   "CURRENT_TEST INTEGER);";
			var command = _connection.CreateCommand();
			command.CommandText = commandText;

			ExecuteNonQueryCommand(command);
		}

		public void CreateTestTable()
		{
			const string commandText = "DROP TABLE IF EXISTS TEST; " +
									   "CREATE TABLE TEST(" +
									   "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
									   "CODE TEXT," +
									   "NAME TEXT," +
									   "TEST TEXT);";

			var command = _connection.CreateCommand();
			command.CommandText = commandText;

			ExecuteNonQueryCommand(command);
		}

		public void CreateTestResultTable()
		{
			const string commandText = "DROP TABLE IF EXISTS TEST_RESULT; " +
									   "CREATE TABLE TEST_RESULT(" +
									   "ID INTEGER PRIMARY KEY AUTOINCREMENT," +
									   "TEST_ID INTEGER," +
									   "USER_ID INTEGER," +
									   "RESULT TEXT," +
									   "IS_FINISHED INTEGER);";

			var command = _connection.CreateCommand();
			command.CommandText = commandText;

			ExecuteNonQueryCommand(command);
		}

        public void InitTests()
        {
            string commandText = @"INSERT OR IGNORE INTO TEST ([CODE], [NAME], [TEST]) VALUES (@Code1, @Name1, @Test1);"
                                + "INSERT OR IGNORE INTO TEST ([CODE], [NAME], [TEST]) VALUES (@Code2, @Name2, @Test2);";

            var command = Connection.CreateCommand();
            command.CommandText = commandText;

            command.Parameters.AddWithValue("@Code1", "знакомства");
            command.Parameters.AddWithValue("@Code2", "кино");

            command.Parameters.AddWithValue("@Name1", "знакомства");
            command.Parameters.AddWithValue("@Name2", "кино");

            command.Parameters.AddWithValue("@Test1", TestModel.Init());
            command.Parameters.AddWithValue("@Test2", @"{""Questions"":[{""Question"":""Какой город ? ""},{""Question"":""Название фильма""}]}");

            ExecuteNonQueryCommand(command);
        }

        #endregion

        #endregion

        #region Internal Implementations

        private void ExecuteNonQueryCommand(SqliteCommand command)
		{
			try
			{
				Connection.Open();
				command.ExecuteNonQuery();
			}
			finally
			{
				Connection.Close();
			}
		}

		#endregion
	}
}
