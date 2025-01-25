using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.Helpers.DictionaryUtilities;

public interface IDictionarizable
{
	public Dictionary<string, string> Dictionarize();
}
