namespace Core.QuickExtend.Tests.ReflectionExtension;

public class ExampleClass
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }

    [CustomAttribute]
    public void CustomMethod()
    {
        // Some custom logic
    }
}
