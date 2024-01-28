namespace Core.QuickExtend.TaskExtensions;

public static partial class TaskExtensions
{
    /// <summary>
    /// Returns true if the Task completes within a specific time, otherwise returns false.
    /// </summary>
    /// <typeparam name="TResult">Type of the Task result.</typeparam>
    /// <param name="task">Task.</param>
    /// <param name="timeout">Timeout duration.</param>
    /// <returns>True if the result is obtained, otherwise false.</returns>
    public static async Task<bool> WaitWithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        using (var cancellationTokenSource = new CancellationTokenSource())
        {
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout, cancellationTokenSource.Token)).ConfigureAwait(false);

            if (completedTask == task)
            {
                cancellationTokenSource.Cancel();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Marks a task as timed out if it does not complete within a specified duration and throws a TimeoutException.
    /// </summary>
    /// <typeparam name="T">Type of the task result.</typeparam>
    /// <param name="task">The task to check for a timeout.</param>
    /// <param name="timeout">The expected timeout duration.</param>
    /// <returns>If the task completes within the specified duration, returns its result; otherwise, throws a TimeoutException.</returns>
    public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
    {
        var completedTask = await Task.WhenAny(task, Task.Delay(timeout));

        if (completedTask == task)
        {
            return await task;
        }
        else
        {
            throw new TimeoutException("Operation timed out.");
        }
    }
}
