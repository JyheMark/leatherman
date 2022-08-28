using System;
using Microsoft.AspNetCore.Mvc;

namespace leatherman.ExtensionMethods;

public static class ActionResultExtensionMethods
{
    public static T UnpackIActionResult<T>(this IActionResult actionResult) where T : class
    {
        if (actionResult == null)
            throw new ArgumentNullException($"{nameof(actionResult)} can not be null");

        var objectResult = actionResult as ObjectResult;

        if (objectResult.Value is not T result)
            throw new InvalidOperationException($"Unable to cast value as type {typeof(T)}");

        return result;
    }
}