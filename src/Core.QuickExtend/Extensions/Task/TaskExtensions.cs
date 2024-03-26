namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class TaskExtensions
{
    /// <summary>
    /// Synchronously executes a specified function representing an asynchronous operation and returns its result.
    /// </summary>
    /// <typeparam name="TResult">Type of the result of the task.</typeparam>
    /// <param name="func">Function representing an asynchronous operation.</param>
    /// <returns>Result of the function.</returns>
    public static TResult RunSync<TResult>(this Func<Task<TResult>> func)
    {
        var task = Task.Run(func);
        return task.GetAwaiter().GetResult();
    }
}
