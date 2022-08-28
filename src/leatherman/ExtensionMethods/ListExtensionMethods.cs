using System.Collections;

namespace leatherman.ExtensionMethods;

public static class ListExtensionMethods
{
    public static bool IsNullOrEmpty(this IList? list)
    {
        return list == null || list.Count == 0;
    }
}