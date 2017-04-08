using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.DatabaseModel
{
	public class Test
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }

		/// <summary>
		/// Serialized representation of the TestModel object.
		/// </summary>
		public string TestObject { get; set; }

		public TestStatus Status { get; set; }
	}
}