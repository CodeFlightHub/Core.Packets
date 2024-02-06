namespace Core.QuickExtend.Extensions;

public static partial class TaskExtensions
{
    /// <summary>
    /// Associates a CancellationToken with a Task, allowing external cancellation.
    /// </summary>
    /// <typeparam name="T">Type of the Task result.</typeparam>
    /// <param name="task">The Task to be associated with the cancellation token.</param>
    /// <param name="cancellationToken">The CancellationToken to use for cancellation.</param>
    /// <returns>The result of the Task if completed successfully; otherwise, throws an OperationCanceledException if canceled.</returns>
    public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>();

        using (cancellationToken.Register(s => ((TaskCompletionSource<bool>)s!).TrySetResult(true), tcs))
        {
            if (task != await Task.WhenAny(task, tcs.Task))
            {
                throw new OperationCanceledException(cancellationToken);
            }
        }

        return await task;
    }
}
