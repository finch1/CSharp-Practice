namespace  ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DemostrateTextFileStorageNonGeneric();
            DemostrateTextFileStorageGeneric();
        }

        private static void DemostrateTextFileStorageNonGeneric()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = "HowTo/Advanced/Generics/people.csv";
            string logFile = "HowTo/Advanced/Generics/logs.csv";

            PopulateLists(people, logs);

            OriginalTextFileProcessor.SavePeople(people, peopleFile);
            OriginalTextFileProcessor.SaveLogs(logs, logFile);

            var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

            foreach (var p in newPeople)
            {
                System.Console.WriteLine($"{p.FirstName} {p.LastName} Is Alive = {p.IsAlive}");
            }

            var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);

            foreach (var l in newLogs)
            {
                System.Console.WriteLine($"{l.ErrorCode} {l.Message} {l.TimeOfEvent} {l.TimeOfEvent.ToShortTimeString()}");
            }

        }

        private static void DemostrateTextFileStorageGeneric()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = "HowTo/Advanced/Generics/people.csv";
            string logFile = "HowTo/Advanced/Generics/logs.csv";

            PopulateLists(people, logs);

            OriginalTextFileProcessor.SavePeople(people, peopleFile);
            OriginalTextFileProcessor.SaveLogs(logs, logFile);

            var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);

            foreach (var p in newPeople)
            {
                System.Console.WriteLine($"{p.FirstName} {p.LastName} Is Alive = {p.IsAlive}");
            }

            var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);

            foreach (var l in newLogs)
            {
                System.Console.WriteLine($"{l.ErrorCode} {l.Message} {l.TimeOfEvent} {l.TimeOfEvent.ToShortTimeString()}");
            }

        }


        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person{FirstName = "FN1", LastName = "LN1"});
            people.Add(new Person{FirstName = "FN3", LastName = "LN2", IsAlive = false});
            people.Add(new Person{FirstName = "FN3", LastName = "LN3"});

            logs.Add(new LogEntry{Message = "ER1", ErrorCode = 1000});
            logs.Add(new LogEntry{Message = "ER2", ErrorCode = 2000});
            logs.Add(new LogEntry{Message = "ER3", ErrorCode = 3000});

        }

    }
}

