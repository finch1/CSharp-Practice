namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // This class cannot take null
            // DateTime bday = null;

            DateTime? bday = null;

            System.Console.WriteLine(bday.GetValueOrDefault());
            System.Console.WriteLine(bday.HasValue);

            bday = new DateTime(2020, 10, 10);
            System.Console.WriteLine(bday.Value);

            // we cannot assign a nullable to a non nullable, so we use GetValueOrDefault as a switch
            DateTime dob = bday.GetValueOrDefault();

            //NULL COALESING OPERATOR : IF DATE IS NULL THEN USE DEFAULT
            bday = null;
            dob = bday ?? new DateTime(2025, 10, 10);
            System.Console.WriteLine(dob.ToString());
        }
    }
}