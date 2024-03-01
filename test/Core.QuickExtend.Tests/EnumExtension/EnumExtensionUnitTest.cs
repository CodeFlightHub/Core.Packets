namespace Core.QuickExtend.Tests.EnumExtension;

internal class EnumExtensionUnitTest
{
    [Test]
    public void GetDisplayName_WithoutDisplayAttribute_ShouldReturnEnumName()
    {
        // Arrange
        SampleEnum enumValue = SampleEnum.Value3;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.That(displayName, Is.EqualTo("Value3"));
    }
}
