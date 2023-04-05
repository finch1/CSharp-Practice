using System.Net;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            //ExecuteSyncClick();    
        }
        
        for (int i = 0; i < 5; i++)
        {
            ExecuteAsyncClick();    
        }

        System.Console.ReadLine();        
    }
    private static List<string> PrepData()
    {
        return new List<string>{
            "https://www.facebook.com",
            "https://www.youtube.com",
            "https://en.wikipedia.org",
            "https://edition.cnn.com/",
            "https://www.microsoft.com/en-mt",
            "https://www.office.com/",
            "https://www.instagram.com",
        };
    }


    private static void ExecuteSyncClick()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        RunDownloadSync();

        watch.Stop();
        var elapsedTimeMs = watch.ElapsedMilliseconds;

        System.Console.WriteLine($"Total Execution Time {Convert.ToDecimal(elapsedTimeMs)/1000}");
    }
    private static void RunDownloadSync()
    {
        List<string> websites = PrepData();

        foreach (string website in websites)
        {            
            WebsiteDataModel results = DownloadWebsite(website);
            ReportWebsiteInfoSync(results);
        }
    }    
    private static WebsiteDataModel DownloadWebsite(string websiteURL)
    {
        if (websiteURL == null || websiteURL.Length == 0)
        {
            throw new ApplicationException("Specify the URI of the resource to retrieve.");
        }
        using(WebClient client = new WebClient())
        {
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            WebsiteDataModel output = new WebsiteDataModel();

            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL); // index HTML

            return output;
        }        
    }
    private static void ReportWebsiteInfoSync(WebsiteDataModel data)
    {

        string text = $"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.";
        System.Console.WriteLine(text);
    }

    private static async void ExecuteAsyncClick()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        await RunDownloadAsyncParallel();

        watch.Stop();
        var elapsedTimeMs = watch.ElapsedMilliseconds;

        System.Console.WriteLine($"Total Execution Time {Convert.ToDecimal(elapsedTimeMs)/1000}");
    }
    // NEVER return void from an ASYNC method. We can return Task or Task<string> = when we have something to return for example. 
    private static async Task RunDownloadAsync()
    {
        List<string> websites = PrepData();

        foreach (string website in websites)
        {           
            // Task executes our custom methods async 
            // await = run this asyncro but wait for it to finish/return. It allows a bit of flexibility for other bits to execute
            WebsiteDataModel results = await Task.Run(() => DownloadWebsite(website)); // => Pass in this code to Task to run.
            ReportWebsiteInfoAsync(results);
        }
    }

    private static async Task RunDownloadAsyncParallel()
    {
        List<string> websites = PrepData();
        List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

        foreach (string website in websites)
        {           
            tasks.Add(Task.Run(() => DownloadWebsite(website))); // a list of tasks running at the same time
        }

        var results = await Task.WhenAll(tasks); // wait until all results are returned. return = A list of WebsiteDataModel

        List<Task> writeToFile = new List<Task>();

        foreach (var result in results)
        {
            writeToFile.Add(Task.Run(() => ReportWebsiteInfoParallel(result)));
        }
    }

    private static async Task ReportWebsiteInfoAsync(WebsiteDataModel data)
    {
        string filePath = "simple.txt";
        string text = $"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.\n";

        File.AppendAllTextAsync(filePath, text);
    }

    private static void ReportWebsiteInfoParallel(WebsiteDataModel data)
    {
        string filePath = "simple.txt";
        string text = $"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.\n";

        File.AppendAllText(filePath, text);
    }
}
public class WebsiteDataModel
{
    public string? WebsiteUrl { get; set; }
    public string? WebsiteData { get; set; }
}