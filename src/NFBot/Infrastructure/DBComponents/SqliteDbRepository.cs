﻿using Microsoft.Data.Sqlite;
using NFBot.Models.DatabaseModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

		public List<User> GetUsers()
		{
			var result = new List<User>();

			const string commandText = @"SELECT * FROM USER;";

			var command = Connection.CreateCommand();
			command.CommandText = commandText;

			Connection.Open();
			var resultReader = command.ExecuteReader();
			while(resultReader.Read())
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
									   "ID INTEGER PRIMARY KEY," +
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
									   "ID INTEGER PRIMARY KEY," +
									   "TEST_ID INTEGER," +
									   "USER_ID INTEGER," +
									   "RESULT TEXT," +
									   "IS_FINISHED INTEGER);";

			var command = _connection.CreateCommand();
			command.CommandText = commandText;

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
