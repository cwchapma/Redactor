using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redaction.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redaction.Test
{
	[TestClass]
	public class RedactorTests
	{
		[TestMethod]
		public void NoRedaction()
		{
			var redactor = new Redactor();

			var actual = redactor.Redact("this is a test");

			Assert.AreEqual("this is a test", actual);
		}

		[TestMethod]
		public void Redaction()
		{
			var redactor = new Redactor();

			redactor.Add("password123");
			var actual = redactor.Redact("this is a password: password123");

			Assert.AreEqual("this is a password: ***", actual);
		}

		[TestMethod]
		public void RedactionString()
		{
			var redactor = new Redactor();

			redactor.RedactionString = "###";
			redactor.Add("password123");
			var actual = redactor.Redact("this is a password: password123");

			Assert.AreEqual("this is a password: ###", actual);
		}

		[TestMethod]
		public void MultiThreaded()
		{
			var redactor = Redactor.Default;

			var passwords = new List<string>();
			for (int i = 0; i < 1000000; i++)
			{
				passwords.Add($"password{i:000000}");
			}

			Parallel.ForEach(passwords, password =>
			{
				redactor.Add(password);
				var actual = redactor.Redact($"this is a password: {password}");
				redactor.Remove(password);
				Assert.AreEqual("this is a password: ***", actual);
			});
		}

		[TestMethod]
		public void Remove()
		{
			var redactor = new Redactor();

			redactor.Add("password123");
			redactor.Remove("password123");
			var actual = redactor.Redact("this is a password: password123");

			Assert.AreEqual("this is a password: password123", actual);
		}

		[TestMethod]
		public void RemoveThrows()
		{
			var redactor = new Redactor();

			try
			{
				redactor.Remove("password123");
				Assert.Fail("Should have thrown exception");
			}
			catch (RedactionStringNotFoundException)
			{
			}
		}
	}
}
