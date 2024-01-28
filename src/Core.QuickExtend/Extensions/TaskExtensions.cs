namespace Core.QuickExtend.Extensions;

public static class TaskExtensions
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
    /// Cancels a Task that does not complete within a specified time.
    /// </summary>
    /// <param name="task">Task to be canceled.</param>
    /// <param name="cancellationTokenSource">CancellationTokenSource providing the cancellation token.</param>
    /// <param name="timeout">Cancellation timeout.</param>
    /// <returns>True if canceled, otherwise false.</returns>
    public static async Task<bool> CancelAfter(this Task task, CancellationTokenSource cancellationTokenSource, TimeSpan timeout)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));
        if (cancellationTokenSource == null)
            throw new ArgumentNullException(nameof(cancellationTokenSource));

        var timeoutTask = Task.Delay(timeout);
        var completedTask = await Task.WhenAny(task, timeoutTask);

        if (completedTask == timeoutTask)
        {
            cancellationTokenSource.Cancel();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Automatically retries a Task for a specified duration.
    /// </summary>
    /// <param name="taskFunc">Function creating the Task to be retried.</param>
    /// <param name="maxRetryCount">Maximum retry count.</param>
    /// <param name="retryInterval">Retry interval.</param>
    /// <returns>Asynchronous Task.</returns>
    public static async Task AutoRetry(this Func<Task> taskFunc, int maxRetryCount, TimeSpan retryInterval)
    {
        if (taskFunc == null)
            throw new ArgumentNullException(nameof(taskFunc));

        int retryCount = 0;

        while (retryCount < maxRetryCount)
        {
            try
            {
                await taskFunc();
                return;
            }
            catch
            {
                retryCount++;
                await Task.Delay(retryInterval);
            }
        }

        throw new InvalidOperationException("Maximum retry count reached.");
    }

}
