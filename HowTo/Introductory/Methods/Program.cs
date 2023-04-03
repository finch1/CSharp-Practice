namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // param example
            Point.Add(new int[] {1,3,5,7});
            Point.Add(1,3,5,7);

            // passing by reference
            int a = 1;
            Point.RefExample(ref a);
            System.Console.WriteLine(a);

            Point.Move(new Point(10, 5));
            //Point.Move(null); // if we leave this here, the program will exit. in the try block, the program moves on

            // global exception handler for the program
            try
            {
                Point.Move(null); // this will fail but the code continues
                var num = int.Parse("abs");
            }
            catch(Exception)
            {
                System.Console.WriteLine("Conversion Failed");
            }

            int number;
            // we use out because the method returns bool as conversion indicator so the actual number is given back in out variable
            var results = int.TryParse("69", out number);
            if(results)
            {
                System.Console.WriteLine("Number is {0}", number);
            }
            else
                System.Console.WriteLine("Conversion Failed");

            UseParams();

        }

        static void UseParams()
        {
            var calculator = new Calculator();
            System.Console.WriteLine(calculator.Add(1,2,3,4));
            System.Console.WriteLine(calculator.Add(1,2,3,4,5,6));
            System.Console.WriteLine(calculator.Add(new int[] {1,2,3,4}));

        }
    }

    class Calculator
    {
        public int Add(params int[] number)
        {
            int result = 0;
            foreach(int i in number)
            {
                result += i;
            }

            return result;
        }
    }

    class Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Signiture of a method = Name, Number and Type of parameters
        public static void Move(int x, int y)
        {

        }

        // Method overloading
        public static void Move(Point newLocation)
        {
            // newLocation could be null
            if(newLocation == null)
                throw new ArgumentNullException("newLovation"); // this is actually a class

            Move(newLocation.x, newLocation.y);

        }
        public void Move(Point newLovation, int speed)
        {
            
        }

        // how to use params = allows variable number of input values
        public static void Add(params int[] numbers)
        {

        }

        // passing by reference
        public static void RefExample(ref int a)
        {
            a++;
        }

    }
}