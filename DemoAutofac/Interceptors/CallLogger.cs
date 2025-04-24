using Castle.DynamicProxy;

namespace DemoAutofac.Interceptors;

public class CallLogger(TextWriter output, IAsyncInterceptor asyncInterceptor) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        output.WriteLine("Calling method {0} with parameters {1}... ",
            invocation.Method.Name,
            string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

        asyncInterceptor.ToInterceptor().Intercept(invocation);

        output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
    }
}