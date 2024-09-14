using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace BaseCRUDForAPI.Infrastructure
{
    public class QueryLoggingInterceptor : DbCommandInterceptor
    {
        private readonly Dictionary<DbCommand, Stopwatch> _stopwatchDict = new Dictionary<DbCommand, Stopwatch>();

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _stopwatchDict[command] = stopwatch;

            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _stopwatchDict[command] = stopwatch;

            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            StopAndLogQueryExecutionTime(command);
            return base.ReaderExecuted(command, eventData, result);
        }

        public override ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            StopAndLogQueryExecutionTime(command);
            return base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }

        private void StopAndLogQueryExecutionTime(DbCommand command)
        {
            if (_stopwatchDict.TryGetValue(command, out var stopwatch))
            {
                stopwatch.Stop();
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"SQL Query executed in {elapsedMilliseconds} ms: {command.CommandText}");
                Console.ResetColor();

                _stopwatchDict.Remove(command);
            }
        }
    }
}
