using System.Reflection;

namespace BaseCRUDForAPI.Infrastructure
{
    public static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, long milliseconds, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Method {methodBase.DeclaringType?.Name}/{methodBase.Name} took {milliseconds} ms");
            Console.ResetColor();
        }
    }
}
