using Core.QuickExtend.Tests.Infrastructure.Attributes;
using Core.QuickExtend.Tests.Infrastructure.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.ReflectionExtensions;

internal class GetTests
{
    [Test]
    public void GetPropertyNames_ReturnsCorrectPropertyNames()
    {
        // Arrange
        object obj = new ExampleClass();

        // Act
        List<string>? propertyNames = obj.GetPropertyNames();

        // Assert
        CollectionAssert.AreEquivalent(new List<string> { "Name", "Age" }, propertyNames);
    }

    [Test]
    public void GetPropertyValues_ReturnsCorrectPropertyValues()
    {
        // Arrange
        var example = new ExampleClass { Name = "John", Age = 30 };

        // Act
        Dictionary<string, object>? propertyValues = example.GetPropertyValues();

        // Assert
        Assert.That(propertyValues?["Name"], Is.EqualTo("John"));
        Assert.That(propertyValues?["Age"], Is.EqualTo(30));
    }

    [Test]
    public void GetMethodsByAttribute_ReturnsCorrectMethods()
    {
        // Arrange
        object obj = new ExampleClass();

        // Act
        MethodInfo[]? methods = obj.GetMethodsByAttribute(typeof(CustomAttribute));

        // Assert
        CollectionAssert.AreEquivalent(new List<string> { "CustomMethod" }, methods?.Select(m => m.Name));
    }

    [Test]
    public void GetMethodsByReturnType_ShouldReturnMethods_WhenMethodsExist()
    {
        // Arrange
        var obj = new SampleClass();
        var returnType = typeof(string);

        // Act
        var methods = obj.GetMethodsByReturnType(returnType);

        // Assert
        Assert.IsNotEmpty(methods);
        Assert.IsTrue(methods.All(m => m.ReturnType == returnType));
    }
}
