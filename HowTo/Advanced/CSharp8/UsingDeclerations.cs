using System.IO;


namespace CSharp8
{

    public class UsingDeclerations
    {
        public static void ConvertFilesOldWay()
        {
            // since StreamReader implements IDispose, at the end of the using curly brace, the dispose method will be called to 
            // garbage the stream and retain no resources. 
            using(var input = new StreamReader(@"filename.txt"))
            {
                using(var output = new StreamWriter(@"filename.txt"))
                {
                    string line;

                    while ((line = input.ReadLine()) is not null)
                    {
                        System.Console.WriteLine(line);
                    }
                }

            }
        }

        public static void ConvertFilesNewWay()
        {
            // once the using variable goes out of scope, the dispose method is called
            using var input = new StreamReader(@"filename.txt");
            using var output = new StreamWriter(@"filename.txt");

            string line;

            while ((line = input.ReadLine()) is not null)
            {
                System.Console.WriteLine(line);
            }
    
        }
    }
}