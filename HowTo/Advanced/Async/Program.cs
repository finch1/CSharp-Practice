using System.Net;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static async Task Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            ExecuteSyncClick();    
        }
        
        for (int i = 0; i < 3; i++)
        {
            // if we dont await, the code will exit before finishing
            await ExecuteAsyncClick();    
        }

        // string[] downloadedSites = File.ReadAllLines("resultsParallel.txt");
        string[] downloadedSites = File.ReadAllLines("resultsAsync.txt");

        Regex match = new Regex("^http.*?.(com|org)");
        List<string> downloadedSitesClean = downloadedSites.Select(x => match.Match(x).Value).ToList();

        // since we are outputing and "annonymous class" the returned result is of type IGrouping<int, class>, where each group is an array
        // keeps all the data
        var dataResults = downloadedSitesClean.GroupBy(x => x).Select(x => new {Website = x, WebsiteCount = x.Count()}).Distinct();

        // keeps only one copy of the data key. We loose the anonymous class though
        var dataResults2 = downloadedSitesClean.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        foreach (var data in dataResults2)
        {
            System.Console.WriteLine($"{data.Key} \t: {data.Value}");
        }

        // System.Console.WriteLine();  
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
            ReportWebsiteInfoSync(results, "resultsSync.txt");
        }
    }    
    private static void ReportWebsiteInfoSync(WebsiteDataModel data, string filePath)
    {
        if(data is not null)
        {
            string text = $"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.\n";
            File.AppendAllText(filePath, text);
        }
        
    }



    private static async Task ExecuteAsyncClick()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        //await RunDownloadAsync();
        await RunDownloadAsyncParallel();
        

        watch.Stop();
        var elapsedTimeMs = watch.ElapsedMilliseconds;

        System.Console.WriteLine($"Total Execution Time {Convert.ToDecimal(elapsedTimeMs)/1000}");
    }
    // NEVER return void from an ASYNC method. We can return Task or Task<string> = when we have something to return for example. 
    private static async Task RunDownloadAsync()
    {
        // NOT ALL RESULTS ARE SAVED TO FILE
        List<string> websites = PrepData();

        foreach (string website in websites)
        {           
            // Task executes our custom methods async 
            // await = run this asyncro but wait for it to finish/return. It allows a bit of flexibility for other bits to execute
            WebsiteDataModel results = await Task.Run(() => DownloadWebsite(website)); // => Pass in this code to Task to run.
            await ReportWebsiteInfoAsync(results);
        }
    }
    private static async Task ReportWebsiteInfoAsync(WebsiteDataModel data)
    {
        if(data is not null)
        {
            string filePath = "resultsAsync.txt";
            string text = $"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.\n";
            // simulating sending to DB
            await File.AppendAllTextAsync(filePath, text);
        }
        
    }



    private static async Task RunDownloadAsyncParallel()
    {
        List<string> websites = PrepData();
        List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
        StringBuilder sb = new StringBuilder();

        foreach (string website in websites)
        {           
            tasks.Add(Task.Run(() => DownloadWebsite(website))); // a list of tasks running at the same time
        }

        var results = await Task.WhenAll(tasks); // wait until all results are returned. return = A list of WebsiteDataModel

        // simulateing bulk insert: using a buffer to write data at once
        foreach (var data in results)
        {
            if(data is not null)
                sb.Append($"{data.WebsiteUrl} downloaded {data.WebsiteData.Length} characters long.\n");
        }

        string filePath = "resultsParallel.txt";

        await File.AppendAllTextAsync(filePath, sb.ToString());
    }

}
public class WebsiteDataModel
{
    public string? WebsiteUrl { get; set; }
    public string? WebsiteData { get; set; }
}