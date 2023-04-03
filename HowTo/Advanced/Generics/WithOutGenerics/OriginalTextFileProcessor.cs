namespace ConsoleUI
{
    public static class OriginalTextFileProcessor
    {
        public static List<Person> LoadPeople(string filepath)
        {
            List<Person> output = new List<Person>();
            Person p;
            var lines = System.IO.File.ReadAllLines(filepath).ToList();

            // Remove Header Row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                p = new Person();

                p.FirstName = vals[0];
                p.LastName = vals[2];
                p.IsAlive = bool.Parse(vals[1]); // Stream reads string so we cast to bool. Still requires ERROR Checking for production matters

                output.Add(p);
            }

            return output;
        }

        public static void SavePeople(List<Person> people, string filepath)
        {
            List<string> lines = new List<string>();

            // Add a Header row
            lines.Add("FirstName,IsAlive,LastName");

            foreach (var p in people)
            {
                lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}");
            }

            System.IO.File.WriteAllLines(filepath, lines);
        }

        public static List<LogEntry> LoadLogs(string filepath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry l;
            var lines = System.IO.File.ReadAllLines(filepath).ToList();

            // Remove Header Row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                l = new LogEntry();

                l.ErrorCode = Int32.Parse(vals[0]);
                l.Message = vals[1];
                l.TimeOfEvent = DateTime.Parse(vals[2]); // Stream reads string so we cast to DateTime. Still requires ERROR Checking for production matters

                output.Add(l);
            }

            return output;
        }

        public static void SaveLogs(List<LogEntry> logs, string filepath)
        {
            List<string> lines = new List<string>();

            // Add a Header row
            lines.Add("ErrorCode,Message,TimeOfEvent");

            foreach (var l in logs)
            {
                lines.Add($"{l.ErrorCode},{l.Message},{l.TimeOfEvent}");
            }

            System.IO.File.WriteAllLines(filepath, lines);
        }
    }
}
