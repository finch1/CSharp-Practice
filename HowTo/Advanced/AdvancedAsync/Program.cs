﻿using System.Net;
using System.Text;
using System.Threading;

class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        

        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        for (int i = 0; i < 1; i++)
        {
            watch.Start();
            System.Console.WriteLine("StartingSync");
            PrintResults(DemoMethods.RunDownloadSync());
            watch.Stop();
            System.Console.WriteLine($"Elapsed Time {watch.ElapsedMilliseconds}");

            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress; // event we hooked into.

            watch.Restart(); // Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time.
            System.Console.WriteLine("StartingAsync");
            // wrap in try-catch for the cancellation request
            try
            {
                PrintResults(await DemoMethods.RunDownloadAsync(progress, cts.Token)); // if we dont await, the code will exit before finishing
            }
            catch(OperationCanceledException)
            {   
                System.Console.WriteLine("The async download operation was cancelled. ");
            }
            
            watch.Stop();
            System.Console.WriteLine($"Elapsed Time {watch.ElapsedMilliseconds}");

            watch.Restart();
            System.Console.WriteLine("StartingParallelAsync");
            PrintResults(await DemoMethods.RunDownloadParallelAsync());
            watch.Stop();
            System.Console.WriteLine($"Elapsed Time {watch.ElapsedMilliseconds}");
        }
        
        System.Console.WriteLine("Done");
    }

    static void ReportProgress(object sender, ProgressReportModel e)
    {
        System.Console.WriteLine(e.Percentagecomplete);
        PrintResults(e.SitesDownloadedSoFar);
    }
    static void PrintResults(List<WebsiteDataModel> data)
    {
        foreach(WebsiteDataModel result in data)
        {
            System.Console.WriteLine($"Method {result.MethodType}. -  {result.WebsiteUrl} downloaded {result.WebsiteData.Length} characters long.");
        }
    }

    public static class DemoMethods
    {
        public static List<string> PrepData()
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

        public static List<WebsiteDataModel> RunDownloadSync()
        {
            List<string> websites = PrepData();
            List<WebsiteDataModel> output = new List<WebsiteDataModel>();

            foreach (string website in websites)
            {            
                WebsiteDataModel results = DownloadWebsite(website);
                output.Add(results);
            }

            return output;
        }    

        public static async Task<List<WebsiteDataModel>> RunDownloadAsync(IProgress<ProgressReportModel> progress, CancellationToken cancellationToken) // IProgress is a Generic Type. It is a callback to show progress to the user when it happenes.
        {
            List<string> websites = PrepData();
            List<WebsiteDataModel> output = new List<WebsiteDataModel>();
            ProgressReportModel report = new ProgressReportModel();


            foreach (string website in websites)
            {            
                WebsiteDataModel results = await DownloadWebsiteAsync(website, "Async");
                cancellationToken.ThrowIfCancellationRequested();   // the cancel request will throw an exception             
                output.Add(results);

                report.SitesDownloadedSoFar = output;
                report.Percentagecomplete = (output.Count()*100)/websites.Count(); // output * 100 is a trick not to have decimal
                progress.Report(report);
            }

            return output;
        }    

        public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
        {
            List<string> websites = PrepData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
            
            foreach (string website in websites)
            {            
                tasks.Add(DownloadWebsiteAsync(website, "ParallelAsync"));                
            }

            var results = await Task.WhenAll(tasks);

            return new List<WebsiteDataModel>(results);
        }   

        public static List<WebsiteDataModel> RunDownloadParallelSync()
        {
            List<string> websites = PrepData();
            List<WebsiteDataModel> output = new List<WebsiteDataModel>();
            
            // for parallel foreach, specify what we are passing in <string>(the list of strings, (short version of foreach, i.e. iterate the list and get each site)=> (the action))
            // Parallel still locks untill everything is done
            Parallel.ForEach<string>(websites, (site) => 
            {            
                WebsiteDataModel model = RunDownloadSync(site);
                output.Add(model);
            });

            return output;
        }   

        // This is best because as parallel task completes, the output becomes available. Other methods' progress is blocked by Task.WhenAll.
        // In the below method, we should see that the smallest website is downloaded and reported first, while the largest site is downloaded last. 
        public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsyncV2(IProgress<ProgressReportModel> progress)
        {
            List<string> websites = PrepData();
            List<WebsiteDataModel> output = new List<WebsiteDataModel>();
            ProgressReportModel report = new ProgressReportModel();
            
            // for parallel foreach, specify what we are passing in <string>(the list of strings, (short version of foreach, i.e. iterate the list and get each site)=> (the action))
            await Task.Run(() => {
                // Anather advantage of Parallel is the flexibility to code callbacks to monitor progress, such as. 
                Parallel.ForEach<string>(websites, (site) => 
                {            
                    WebsiteDataModel model = RunDownloadSync(site);
                    output.Add(model);

                    report.SitesDownloadedSoFar = output;
                    report.Percentagecomplete = (output.Count()*100)/websites.Count(); // output * 100 is a trick not to have decimal
                    progress.Report(report);
                });
            });
            

            return output;
        }     

        public static WebsiteDataModel DownloadWebsite(string websiteURL)
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
                output.MethodType = "Sync";
                output.WebsiteData = client.DownloadString(websiteURL); // index HTML

                return output;
            }        
        }

        public static async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteURL, string methodType)
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
                output.MethodType = methodType;
                output.WebsiteData = await client.DownloadStringTaskAsync(new Uri(websiteURL)); // index HTML

                return output;
            }        
        }

    }
    
}
public class WebsiteDataModel
{
    public string? WebsiteUrl { get; set; }
    public string? WebsiteData { get; set; }
    public string? MethodType { get; set; }
}

public class ProgressReportModel
{
    public List<WebsiteDataModel> SitesDownloadedSoFar {get; set;} = new List<WebsiteDataModel>();
    public int Percentagecomplete { get; set; } = 0;
}