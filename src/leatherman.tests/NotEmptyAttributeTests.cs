using System;
using System.Collections.Generic;
using FluentAssertions;
using leatherman.Attributes;

namespace leatherman.tests;

public class NotEmptyAttributeTests
{
    private readonly NotEmptyAttribute _sut;

    public NotEmptyAttributeTests()
    {
        _sut = new NotEmptyAttribute();
    }

    [Fact]
    public void IsValid_should_return_true_if_collection_valid()
    {
        var testList = new List<int> { 1, 2, 3 };

        _sut.IsValid(testList).Should().BeTrue();
    }

    [Fact]
    public void IsValid_should_return_true_if_collection_null()
    {
        List<int> testList = null;

        _sut.IsValid(testList).Should().BeTrue();
    }

    [Fact]
    public void IsValid_should_return_false_if_collection_empty()
    {
        var testList = new List<int>();

        _sut.IsValid(testList).Should().BeFalse();
    }

    [Fact]
    public void IsValid_should_throw_if_not_collection()
    {
        var testObject = new { Test = "test" };

        Func<bool> act = () => _sut.IsValid(testObject);

        act.Should().Throw<InvalidOperationException>().Which.Message.Contains("Values is not valid list");
    }
}