using Redaction.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Redaction
{
	public interface IRedactor
	{
		string Redact(string input);

		void Add(string stringToRedact);

		void Remove(string stringToRedact);

		string RedactionString { get; set; }
	}
}
