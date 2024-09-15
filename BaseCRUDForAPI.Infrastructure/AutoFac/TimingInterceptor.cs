using Castle.DynamicProxy;
using System.Diagnostics;

namespace BaseCRUDForAPI.Infrastructure.AutoFac
{
    public class TimingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                invocation.Proceed();
            }
            finally
            {
                stopwatch.Stop();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Method {invocation.Method.DeclaringType?.Name}/{invocation.Method.Name} took {stopwatch.Elapsed.TotalSeconds} ms");
                Console.ResetColor();
            }
        }
    }
}
