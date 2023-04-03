namespace RandNumGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();

            System.Console.WriteLine("Random numbers, ceil 10 ->");
            for(int i = 0; i < 10; i++)
            {
                System.Console.Write(number.Next(11) + ",");
            }

            System.Console.WriteLine();

            System.Console.WriteLine("Random numbers, 2-9 ->");
            for(int i = 0; i < 10; i++)
            {
                System.Console.Write(number.Next(2, 10) + ",");
            }

            System.Console.WriteLine();            

            System.Console.WriteLine("Random decimal numbers, 0-1 ->");
            for(int i = 0; i < 10; i++)
            {
                System.Console.Write(number.NextDouble() + ",");
            }

            System.Console.WriteLine();    

            System.Console.WriteLine("Random numbers, ceil 10 ->");
            for(int i = 0; i < 10; i++)
            {
                System.Console.Write(number.NextDouble()*10 + ",");
            }

            System.Console.WriteLine();

            List<double> doubRand = new List<double>();

            for(int i = 0; i < 11; i++)
            {
                doubRand.Add(number.NextDouble()*5);
            }

            // inplace order use .Sort()
            // otherwise assign
            doubRand = doubRand.OrderBy(x => x).ToList();

            System.Console.WriteLine("Ordered Random Double ->");
            for(int i = 0; i < 10; i++)
            {
                System.Console.Write(String.Format("{0:C}", doubRand[i]) + ",");
            }

            System.Console.WriteLine();


            System.Console.WriteLine("Shuffle a list of items ->");

            List<People> people = new List<People>
            {
                new People(){Name = "Name1"},
                new People(){Name = "Name2"},
                new People(){Name = "Name3"},
                new People(){Name = "Name4"},
                new People(){Name = "Name5"},
                new People(){Name = "Name6"},
                new People(){Name = "Name7"},
                new People(){Name = "Name8"},
            };

            var shuffledPeople = people.OrderBy(x => number.Next());

            foreach(var p in shuffledPeople)
            {
                System.Console.Write(p.Name + ",");
            }

            System.Console.WriteLine();

        }
    }

    public class People
    {
        public string Name { get; set; }
    }
}