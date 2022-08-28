using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.String;

namespace leatherman.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class NotEmptyAttribute : ValidationAttribute
{
    private const string _errorMessageString = "Collection can not be empty";

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => true,
            ICollection collection => collection.Count > 0,
            IEnumerable enumerable => enumerable.GetEnumerator().MoveNext(),
            _ => throw new InvalidOperationException("Value is not valid list")
        };
    }

    public override string FormatErrorMessage(string name)
    {
        return Format(CultureInfo.CurrentCulture, _errorMessageString);
    }
}