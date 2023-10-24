namespace Start.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public Guid Guid = Guid.NewGuid();
        private static object _lock = new object();

        public ConsoleLogger()
        {
            LogLifecycleEvent($"+++ Constructor called on {this}");
        }
        public void LogLessRelevantStuff(string message)
        {
            WriteLine(message, ConsoleColor.DarkGray, 2);
        }

        public void LogLogic(string message)
        {
            WriteLine(message, ConsoleColor.DarkGreen, 3);
        }

        public void LogLifecycleEvent(string message)
        {
            WriteLine(message, ConsoleColor.Yellow, 1);
        }

        public void Error(string message, Exception? exception = null)
        {
            WriteLine(message, ConsoleColor.Red);

            if (exception == null) return;

            WriteLine(exception.Message, ConsoleColor.DarkRed);
            if (exception.StackTrace != null )
                WriteLine(exception.StackTrace, ConsoleColor.DarkRed);
        }

        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, int tabIndentation = 0)
        {
            lock (_lock)
            {
                var indentation = tabIndentation > 1 ? string.Concat(Enumerable.Repeat("   ", tabIndentation)) : "";
                Console.ForegroundColor = color;

                Console.WriteLine($"{indentation}{message}");
                Console.WriteLine($"\r");

                Console.ForegroundColor = ConsoleColor.White;
            }
                
        }

        public override string ToString()
        {
            var type = GetType();
            return $"{type.Name} with id {Guid}";
        }

        ~ConsoleLogger()
        {
            LogLifecycleEvent($"---Destructor called on {this}");
        }
    }
}
