using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Grizhla.UtilitiesCore.Helpers.Comparers;
public static class DictionaryEqualityComparer<TKey, TValue>
{
	public static bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
	{
		// Check whether the dictionaries are equal
		return x.Count == y.Count && !x.Except(y).Any() && GetHashCode(x) == GetHashCode(y);
	}

	public static int GetHashCode(Dictionary<TKey, TValue> obj)
	{
		int hash = 0;
		foreach(var pair in obj)
		{
			hash ^= pair.GetHashCode();
		}
		return hash;
	}
}
