using System;
using System.Runtime.Serialization;

namespace Redaction.Exceptions
{
	[Serializable]
	public class RedactionStringNotFoundException : Exception
	{
		public RedactionStringNotFoundException()
		{
		}

		public RedactionStringNotFoundException(string message) : base(message)
		{
		}

		public RedactionStringNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected RedactionStringNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
