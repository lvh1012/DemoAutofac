using System.Reflection;
using Castle.DynamicProxy;
using DemoAutofac.Attributes;

namespace DemoAutofac.Interceptors;

public class CallTransaction(TextWriter output) : IAsyncInterceptor
{
    // nếu hàm sync thì sẽ nhảy vào hàm này
    public void InterceptSynchronous(IInvocation invocation)
    {
        // Step 1. Do something prior to invocation.

        invocation.Proceed();

        // Step 2. Do something after invocation.
    }

    public void InterceptAsynchronous(IInvocation invocation)
    {
        invocation.ReturnValue = InternalInterceptAsynchronous(invocation);
    }

    // nếu hàm async không có kết quả thì sẽ nhảy vào hàm này
    private async Task InternalInterceptAsynchronous(IInvocation invocation)
    {
        // Step 1. Do something prior to invocation.

        invocation.Proceed();
        var task = (Task)invocation.ReturnValue;
        await task;

        // Step 2. Do something after invocation.
    }

    public void InterceptAsynchronous<TResult>(IInvocation invocation)
    {
        invocation.ReturnValue = InternalInterceptAsynchronous<TResult>(invocation);
    }

    // nếu hàm async return kết quả thì sẽ nhảy vào hàm này
    private async Task<TResult> InternalInterceptAsynchronous<TResult>(IInvocation invocation)
    {
        // Step 1. Do something prior to invocation.

        // Check if the method has the TransactionAttribute
        var transactionAttr = invocation.GetConcreteMethodInvocationTarget().GetCustomAttribute<TransactionAttribute>(true);

        if (transactionAttr is null)
        {
            // Proceed with the method invocation if no TransactionAttribute is present
            invocation.Proceed();
        }
        else
        {
            // Create a transaction before proceeding with the method invocation
            output.WriteLine("Create transaction");
            invocation.Proceed();
            // Commit the transaction after the method invocation
            output.WriteLine("Commit transaction");
        }

        var task = (Task<TResult>)invocation.ReturnValue;
        TResult result = await task;

        // Step 2. Do something after invocation.

        return result;
    }
}