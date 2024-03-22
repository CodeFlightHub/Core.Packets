using Core.QuickExtend.Tests.Infrastructure.Attributes;

namespace Core.QuickExtend.Tests.Infrastructure.Classes;

public class ExampleClass
{
    public string Name { get; set; } = default!;
    public int Age { get; set; }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }

    [Custom]
    public void CustomMethod()
    {
        // Some custom logic
    }
}
