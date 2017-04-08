using Microsoft.Data.Sqlite;

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

		public void CreateUserTable()
		{
			const string commandText = "DROP TABLE IF EXISTS USER; " +
									   "CREATE TABLE USER(" +
									   "ID INTEGER PRIMARY KEY," +
									   "CITY TEXT," +
									   "CURRENT_TEST INTEGER);";

			ExecuteNonQueryCommand(commandText);
		}

		public void CreateTestTable()
		{
			const string commandText = "DROP TABLE IF EXISTS TEST; " +
									   "CREATE TABLE TEST(" +
									   "ID INTEGER PRIMARY KEY," +
									   "CODE TEXT," +
									   "NAME TEXT," +
									   "TEST TEXT);";

			ExecuteNonQueryCommand(commandText);
		}

		public void CreateTestResultTable()
		{
			const string commandText = "DROP TABLE IF EXISTS TEST_RESULT; " +
									   "CREATE TABLE TEST_RESULT(" +
									   "ID INTEGER PRIMARY KEY," +
									   "TEST_ID INTEGER," +
									   "USER_ID INTEGER," +
									   "RESULT TEXT," +
									   "IS_FINISHED INTEGER);";

			ExecuteNonQueryCommand(commandText);
		}

		#endregion

		#region Internal Implementations

		private void ExecuteNonQueryCommand(string commandText)
		{
			Connection.Open();

			var command = Connection.CreateCommand();
			command.CommandText = commandText;

			try
			{
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
