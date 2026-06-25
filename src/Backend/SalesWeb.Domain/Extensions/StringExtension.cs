using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SalesWeb.Domain.Extensions;

public static partial class StringExtension
{
    public static string RemoveExtraSpaces(this string value)
    {
        return RemoveExtraBlankSpace()
            .Replace(value.Trim(), " ");
    }
    [GeneratedRegex(@"\s+")]
    private static partial Regex RemoveExtraBlankSpace();
}
