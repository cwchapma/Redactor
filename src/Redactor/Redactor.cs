using Redaction.Exceptions;
using System;
using System.Collections.Concurrent;

namespace Redaction
{
	public class Redactor : IRedactor
	{
		ConcurrentBag<string> stringsToRedact { get; set; } = new ConcurrentBag<string>();

		public static IRedactor Default { get; set; } = new Redactor();

		public string RedactionString { get; set; } = "***";

		public void Add(string stringToRedact)
		{
			stringsToRedact.Add(stringToRedact);
		}

		public string Redact(string input)
		{
			if (String.IsNullOrWhiteSpace(input))
			{
				return input;
			}

#pragma warning disable CA1062 // Validate arguments of public methods
			return input.ReplaceAny(RedactionString, stringsToRedact);
#pragma warning restore CA1062 // Validate arguments of public methods
		}

		public void Remove(string stringToRedact)
		{
			if (!stringsToRedact.TryTake(out string removedStringToRedact))
			{
				throw new RedactionStringNotFoundException();
			}
		}
	}
}
