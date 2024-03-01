namespace Core.QuickExtend.Tests.StringExtension;

internal class StringExtensionUnitTest
{
    [Test]
    public void AddPrefix_IncludeSpaceTrue_ShouldAddPrefixWithSpace()
    {
        // Arrange
        string input = "world";
        string prefix = "hello";

        // Act
        string result = input.AddPrefix(prefix, includeSpace: true);

        // Assert
        Assert.That(result, Is.EqualTo("hello world"));
    }

    [Test]
    public void AddPrefix_IncludeSpaceFalse_ShouldAddPrefixWithoutSpace()
    {
        // Arrange
        string input = "world";
        string prefix = "hello";

        // Act
        string result = input.AddPrefix(prefix, includeSpace: false);

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }

    [Test]
    public void AddSuffix_IncludeSpaceTrue_ShouldAddSuffixWithSpace()
    {
        // Arrange
        string input = "hello";
        string suffix = "world";

        // Act
        string result = input.AddSuffix(suffix, includeSpace: true);

        // Assert
        Assert.That(result, Is.EqualTo("hello world"));
    }

    [Test]
    public void AddSuffix_IncludeSpaceFalse_ShouldAddSuffixWithoutSpace()
    {
        // Arrange
        string input = "hello";
        string suffix = "world";

        // Act
        string result = input.AddSuffix(suffix, includeSpace: false);

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }

    [Test]
    public void AreParenthesesMatched_ValidInput_ShouldReturnTrue()
    {
        // Arrange
        string input = "((a + b) * (c - d))";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void AreParenthesesMatched_InvalidInput_ShouldReturnFalse()
    {
        // Arrange
        string input = "((a + b) * (c - d)";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void AreParenthesesMatched_EmptyInput_ShouldReturnTrue()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_ValidAlphaNumericString_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABC13";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_InvalidStringWithSpecialCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123!";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_WhitespaceInput_ShouldReturnFalse()
    {
        // Arrange
        string input = "   ";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmail_ValidEmailAddress_ShouldReturnTrue()
    {
        // Arrange
        string input = "serhatkacmaz3@gmail.com";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEmail_InvalidEmailAddress_ShouldReturnFalse()
    {
        // Arrange
        string input = "invalid-email";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmail_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_StringContainsHtmlTags_ShouldReturnTrue()
    {
        // Arrange
        string input = "<p>This is HTML content</p>";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsHtml_StringDoesNotContainHtmlTags_ShouldReturnFalse()
    {
        // Arrange
        string input = "This is plain text";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_StringContainsLetters_ShouldReturnTrue()
    {
        // Arrange
        string input = "a123";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsLetter_NoLetters_ShouldReturnFalse()
    {
        // Arrange
        string input = "123456";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsNumeric_ContainsNumericCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsNumeric_NoNumericCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }
    [Test]
    public void ContainsOnlyLetters_OnlyAlphabeticalCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABCDE";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsOnlyLetters_NonAlphabeticalCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_MixedCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_OnlyNumericCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "12345";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsOnlyNumeric_NonNumericCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_MixedCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "123ABC";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ToBool_ValidTrueInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "true";
        bool expected = true;

        // Act
        bool result = input.ToBool();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToBool_ValidFalseInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "false";
        bool expected = false;

        // Act
        bool result = input.ToBool();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToBool_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "invalid";
        bool defaultValue = true;

        // Act
        bool result = input.ToBool(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDateTime_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "2022-01-28";
        DateTime expected = new DateTime(2022, 01, 28);

        // Act
        DateTime result = input.ToDateTime();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToDateTime_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "abc";
        DateTime defaultValue = DateTime.MinValue;

        // Act
        DateTime result = input.ToDateTime(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDateTime_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "xyz";
        DateTime defaultValue = new DateTime(2000, 01, 01);

        // Act
        DateTime result = input.ToDateTime(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDouble_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "123.45";
        double expected = 123.45;

        // Act
        double result = input.ToDouble();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToDouble_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "abc";
        double defaultValue = 0.0;

        // Act
        double result = input.ToDouble(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDouble_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "xyz";
        double defaultValue = 99.99;

        // Act
        double result = input.ToDouble(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToInt_Should_Convert_String_To_Integer()
    {
        // Arrange
        string input = "123";

        // Act
        int result = input.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public void ToInt_Should_Return_Default_Value_If_Conversion_Fails()
    {
        // Arrange
        string input = "abc";

        // Act
        int result = input.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void ToInt_Should_Return_Custom_Default_Value_If_Conversion_Fails()
    {
        // Arrange
        string input = "abc";
        int defaultValue = -1;

        // Act
        int result = input.ToInt(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToTimeSpan_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "12:30:45";
        TimeSpan expected = new TimeSpan(12, 30, 45);

        // Act
        TimeSpan result = input.ToTimeSpan();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToTimeSpan_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "invalid";
        TimeSpan defaultValue = TimeSpan.FromHours(1);

        // Act
        TimeSpan result = input.ToTimeSpan(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToTimeSpan_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "invalid";
        TimeSpan defaultValue = TimeSpan.FromMinutes(30);

        // Act
        TimeSpan result = input.ToTimeSpan(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToTurkishLowerCase_Should_Convert_String_To_Lowercase_With_Turkish_Character_Sensitivity()
    {
        // Arrange
        string input = "Merhaba Dünya";

        // Act
        string result = input.ToTurkishLowerCase();

        // Assert
        Assert.That(result, Is.EqualTo("merhaba dünya"));
    }

    [Test]
    public void ToTurkishLowerCase_Should_Handle_Empty_String()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string result = input.ToTurkishLowerCase();

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void FindMostRepeatedSubstring_ValidInput_ShouldReturnMostRepeatedSubstring()
    {
        // Arrange
        string input = "abcabcabcdabcd";

        // Act
        string result = input.FindMostRepeatedSubstring(3);

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void FindMostRepeatedSubstring_SubstringLengthGreaterThanInputLength_ShouldThrowArgumentException()
    {
        // Arrange
        string input = "abcdef";
        int subStringLength = 10;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => input.FindMostRepeatedSubstring(subStringLength));
    }

    [Test]
    public void FindMostRepeatedSubstring_SubstringLengthZero_ShouldThrowArgumentException()
    {
        // Arrange
        string input = "abcdef";
        int subStringLength = 0;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => input.FindMostRepeatedSubstring(subStringLength));
    }

    [Test]
    public void FindMostRepeatedWord_SingleWord_ShouldReturnSameWord()
    {
        // Arrange
        string input = "apple";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo("apple"));
    }

    [Test]
    public void FindMostRepeatedWord_MultipleWords_ShouldReturnMostRepeatedWord()
    {
        // Arrange
        string input = "apple banana orange banana apple apple";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo("apple"));
    }

    [Test]
    public void FindMostRepeatedWord_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void FormatPadToLength_LeftAlign_ShouldPadFromLeft()
    {
        // Arrange
        string text = "Hello";
        int length = 10;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello-----"));
    }

    [Test]
    public void FormatPadToLength_RightAlign_ShouldPadFromRight()
    {
        // Arrange
        string text = "Hello";
        int length = 10;
        char paddingChar = '-';
        bool alignLeft = false;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("-----Hello"));
    }

    [Test]
    public void FormatPadToLength_TextAlreadyEqualLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Hello";
        int length = 5;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello"));
    }

    [Test]
    public void FormatPadToLength_TextLongerThanLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Hello";
        int length = 3;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello"));
    }

    [Test]
    public void FormatPhoneNumber_DefaultFormat_ShouldReturnFormattedPhoneNumber()
    {
        // Arrange
        string phoneNumber = "1234567890";

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo("0(123)-456-78-90"));
    }

    [Test]
    public void FormatPhoneNumber_CustomFormat_ShouldReturnFormattedPhoneNumberWithCustomFormat()
    {
        // Arrange
        string phoneNumber = "9876543210";
        string customFormat = "0-XXX-XXXX-XXX";

        // Act
        string? result = phoneNumber.FormatPhoneNumber(customFormat);

        // Assert
        Assert.That(result, Is.EqualTo("0-987-6543-210"));
    }

    [Test]
    public void FormatPhoneNumber_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string phoneNumber = "";

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void FormatPhoneNumber_NullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? phoneNumber = null;

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void FormatTruncateWithEllipsis_TextShorterThanMaxLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Short Text";
        int maxLength = 50;

        // Act
        string result = text.FormatTruncateWithEllipsis(maxLength);

        // Assert
        Assert.That(result, Is.EqualTo("Short Text"));
    }

    [Test]
    public void FormatTruncateWithEllipsis_TextLongerThanMaxLength_ShouldReturnTruncatedTextWithEllipsis()
    {
        // Arrange
        string text = "This is a longer text that exceeds the maximum length.";
        int maxLength = 20;

        // Act
        string result = text.FormatTruncateWithEllipsis(maxLength);

        // Assert
        Assert.That(result, Is.EqualTo("This is a longer tex..."));
    }

    [Test]
    public void FormatTruncateWithEllipsis_EmptyText_ShouldReturnEmptyString()
    {
        // Arrange
        string text = "";

        // Act
        string result = text.FormatTruncateWithEllipsis();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void CapitalizeFirstLetter_ValidInput_ShouldCapitalizeFirstLetterOfEachWord()
    {
        // Arrange
        string input = "hello world";

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void CapitalizeFirstLetter_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void CapitalizeFirstLetter_NullInput_ShouldReturnNull()
    {
        // Arrange
        string? input = null;

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void ParseFromString_ValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "Value2";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value2));
    }

    [Test]
    public void ParseFromString_InvalidValue_ShouldReturnDefaultEnumItem()
    {
        // Arrange
        string invalidValue = "InvalidValue";

        // Act
        SampleEnum result = invalidValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(default(SampleEnum)));
    }

    [Test]
    public void ParseFromString_CaseInsensitiveValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "value3";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value3));
    }

    [Test]
    public void SumDigits_WhenGivenStringWithDigits_ReturnsSumOfDigits()
    {
        // Arrange
        string input = "abc123def45";

        // Action
        int result = input.SumDigits();

        // Assert
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void SumDigits_WhenGivenStringWithoutDigits_ReturnsZero()
    {
        // Arrange
        string input = "abcxyz";

        // Action
        int result = input.SumDigits();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void RemoveDuplicateCharacters_NoDuplicates_ShouldReturnSameString()
    {
        // Arrange
        string input = "abcdef";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void RemoveDuplicateCharacters_WithDuplicates_ShouldRemoveDuplicates()
    {
        // Arrange
        string input = "aabbcc";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void RemoveDuplicateCharacters_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void RemoveSpaces_Should_Remove_Spaces_From_String()
    {
        // Arrange
        string input = "Hello World";

        // Act
        string result = input.RemoveSpaces();

        // Assert
        Assert.That(result, Is.EqualTo("HelloWorld"));
    }
}
