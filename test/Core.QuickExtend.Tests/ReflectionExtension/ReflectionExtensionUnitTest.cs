using System.Reflection;

namespace Core.QuickExtend.Tests.ReflectionExtension;

internal class ReflectionExtensionUnitTest
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
        Assert.AreEqual("John", propertyValues?["Name"]);
        Assert.AreEqual(30, propertyValues?["Age"]);
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

    [Test]
    public void GetMethodsByReturnType_ShouldReturnEmptyArray_WhenObjectIsNull()
    {
        // Arrange
        object? obj = null;
        var returnType = typeof(string);

        // Act
        var methods = obj.GetMethodsByReturnType(returnType);

        // Assert
        Assert.IsEmpty(methods);
    }
    [Test]
    public void InvokeMethodByName_ShouldNotThrowException_WhenObjectIsNull()
    {
        // Arrange
        object? obj = null;

        // Act & Assert
        Assert.DoesNotThrow(() => obj.InvokeMethodByName("SampleMethod", "test"));
    }
}
