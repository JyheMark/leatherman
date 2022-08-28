using System;
using FluentAssertions;
using leatherman.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;

namespace leatherman.tests;

public class IActionResultExtensionMethodsTests
{
    [Fact]
    public void UnpackIActionResult_should_return_unpacked_value()
    {
        const int testInt = 123;
        const string testString = "testString";

        var testObjectResult = new ObjectResult(new TestClass { TestInt = testInt, TestString = testString });

        var result = testObjectResult.UnpackIActionResult<TestClass>();
        result.TestInt.Should().Be(testInt);
        result.TestString.Should().Be(testString);
    }

    [Fact]
    public void UnpackIActionResult_should_throw_if_result_null()
    {
        ObjectResult testObjectResult = null;
        Func<TestClass> act = () => testObjectResult.UnpackIActionResult<TestClass>();

        act.Should().Throw<ArgumentNullException>().Which.Message.Contains("can not be null");
    }

    [Fact]
    public void UnpackIActionResult_should_throw_if_type_invalid()
    {
        Func<TestClass> act = () => new ObjectResult("a string").UnpackIActionResult<TestClass>();

        act.Should().Throw<InvalidOperationException>().Which.Message.Contains("Unable to cast value as type");
    }
}

public class TestClass
{
    public int TestInt { get; init; }
    public string? TestString { get; init; }
}