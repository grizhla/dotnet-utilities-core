using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grizhla.UtilitiesCore.Helpers.Extensions;

public static class GrizhlaStringExtensions
{
    public static string ToCamelCase(this string str)
    {
        return System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(str);
    }
}
