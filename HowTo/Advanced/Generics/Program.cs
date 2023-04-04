using System.Diagnostics;


namespace  ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MemUsage.ProcessMemDiag();
            DemostrateTextFileStorageNonGeneric();

            MemUsage.ProcessMemDiag();
            DemostrateTextFileStorageGeneric();

            MemUsage.ProcessMemDiag();
        }

        private static void DemostrateTextFileStorageNonGeneric()
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = "people.csv";
            string logFile = "logs.csv";

            PopulateLists(people, logs); // List passed by reference. This method has no return.

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

            string peopleFile = "people.csv";
            string logFile = "logs.csv";

            PopulateLists(people, logs);

            GenericTextFileProcessor.SaveToTextFile<Person>(people, peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);

            foreach (var p in newPeople)
            {
                System.Console.WriteLine($"{p.FirstName} {p.LastName} Is Alive = {p.IsAlive}");
            }

            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);

            foreach (var l in newLogs)
            {
                System.Console.WriteLine($"{l.ErrorCode} {l.Message} {l.TimeOfEvent} {l.TimeOfEvent.ToShortTimeString()}");
            }

        }


        private static void PopulateLists(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person{FirstName = "FN1", LastName = "LN1"});
            people.Add(new Person{FirstName = "FN2", LastName = "LN2", IsAlive = false});
            people.Add(new Person{FirstName = "FN3", LastName = "LN3"});

            logs.Add(new LogEntry{Message = "ER1", ErrorCode = 1000});
            logs.Add(new LogEntry{Message = "ER2", ErrorCode = 2000});
            logs.Add(new LogEntry{Message = "ER3", ErrorCode = 3000});

        }

    }

    public static class MemUsage
    {
        public static void ProcessMemDiag(){

            Process myProcess = Process.GetCurrentProcess();
            // Refresh the current process property values.
            myProcess.Refresh();

            Console.WriteLine();

            // Display current process statistics.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{myProcess} -");
            Console.WriteLine("-------------------------------------");
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"  Physical memory usage in MB     : {myProcess.WorkingSet64/1024/1024}");
            Console.WriteLine($"  Paged system memory size in MB  : {myProcess.PagedSystemMemorySize64/1024/1024}");
            Console.WriteLine($"  Paged memory size in MB         : {myProcess.PagedMemorySize64/1024/1024}");
            Console.WriteLine($"  Peak paged memory size in MB    : {myProcess.PeakPagedMemorySize64/1024/1024}");
            Console.WriteLine($"  Peak virtual memory size in GB  : {myProcess.PeakVirtualMemorySize64/1024/1024/1024}");
            Console.WriteLine($"  Peak working size in MB         : {myProcess.PeakWorkingSet64/1024/1024}");

            if (myProcess.Responding)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Status = Running");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status = Not Responding");
            }
        
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}

