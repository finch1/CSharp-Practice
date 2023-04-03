namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null; // instanciating here. If we do it in the try block, it will be out of scope for the finally block
            try // global exception handler
            {
                sr = new StreamReader("Filepath");
                var content = sr.ReadToEnd();
                throw new Exception("Opps message"); // simulating an error

            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Sumtin went wong: " + ex.Message);
            }
            finally
            {
                if(sr != null) // compiler will show warning if null, so check before disposing
                    sr.Dispose(); // dispose of allocated resources
            }

            // A SHORTER VERSION. USING CREATES A FINALLY BLOCK TO DISPOSE AUTOMATICALLY
            try // global exception handler
            {
                using(StreamReader sr = new StreamReader("Filepath"))
                {
                    var content = sr.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Sumtin went wong: " + ex.Message);
            }

            // INNER EXCEPTIONS
            try
            {
                var api = new YouTubeAPI();
                var video = api.GetVideosOfUser("User Name");
            }
            catch(Exception ex) // the inner exception will be printed from the below catch block
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }

    public class YouTubeAPI
    {
        public List<Video> GetVideosOfUser(string userName)
        {
            try
            {
                // Access YouTube Video data
                throw new Exception("Some low level YouTube Error");
            }
            catch(Exception ex)
            {
                // Log
                throw new YouTubeException("Could not fetch videos from YouTube", ex);

            }

            return new List<Video>();
        }
    }

    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException)
         : base(message, innerException)
        {
            
        }
    }
}