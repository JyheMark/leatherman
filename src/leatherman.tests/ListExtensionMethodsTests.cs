using System.Collections.Generic;
using FluentAssertions;
using leatherman.ExtensionMethods;

namespace leatherman.tests;

public class ListExtensionMethodsTests
{
    [Fact]
    public void IsNullOrEmpty_should_return_false_if_list_populated()
    {
        var testList = new List<int> { 1, 2, 3 };

        testList.IsNullOrEmpty().Should().BeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_should_return_true_if_list_empty()
    {
        var testList = new List<int>();

        testList.IsNullOrEmpty().Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_should_return_true_if_list_null()
    {
        List<int> testList = null;

        testList.IsNullOrEmpty().Should().BeTrue();
    }
}