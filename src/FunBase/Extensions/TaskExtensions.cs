using System;
using System.Threading.Tasks;

namespace FunBase.Extensions
{
    public static class TaskExtensions
    {
        public static Task<T2> Then<T1, T2>(this Task<T1> first, Func<T1, Task<T2>> next)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (next == null) throw new ArgumentNullException(nameof(next));

            var taskCompletitionSource = new TaskCompletionSource<T2>();

            first.ContinueWith(delegate
            {
                if (first.IsFaulted) taskCompletitionSource.TrySetException(first.Exception.InnerException);
                else if (first.IsCanceled) taskCompletitionSource.SetCanceled();
                else
                {
                    try
                    {
                        var result = first.Result;
                        var nextResult = next(result);
                        if (nextResult == null) taskCompletitionSource.SetCanceled();
                        else nextResult.ContinueWith(delegate
                        {
                            if (nextResult.IsFaulted) taskCompletitionSource.TrySetException(nextResult.Exception.InnerException);
                            else if (nextResult.IsCanceled) taskCompletitionSource.SetCanceled();
                            else taskCompletitionSource.SetResult(nextResult.Result);
                        }, TaskContinuationOptions.ExecuteSynchronously);
                    }
                    catch (Exception e)
                    {
                        taskCompletitionSource.SetException(e);
                    }
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
            return taskCompletitionSource.Task;
        }
    }
}
