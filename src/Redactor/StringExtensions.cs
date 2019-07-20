using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Redaction
{
	internal static class StringExtensions
	{
		internal static string ReplaceAny(this string s, string redactionString, params string[] stringsToRedact)
		{
			return ReplaceAny(s, redactionString, stringsToRedact as IEnumerable<string>);
		}

		internal static string ReplaceAny(this string s, string redactionString, IEnumerable<string> stringsToRedact)
		{
			foreach (var stringToRedact in stringsToRedact)
			{
				s = s.Replace(stringToRedact, redactionString);
			}
			return s;
		}
	}
}
