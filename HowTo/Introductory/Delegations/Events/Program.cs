namespace HelloWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video("The Island");
            var videoEnc = new VideoEncoder(); // Publisher
            var mailService = new MailService(); // Subscriber
            var textService = new TextMessageService(); // Subscriber

            // configure subscribtion prior to Encoding video
            videoEnc.VideoEncoded += mailService.OnVideoEncoded;// register a handler to this event. Note this is a pointer to the method
            videoEnc.VideoEncoded += textService.OnVideoEncoded;
            
            videoEnc.Encode(video);
        }
    }

    // to send additional data on event trigger, create a new class deriving from EventArgs
    public class VideoEventArgs:EventArgs
    {
        public Video Video { get; set; }
    }


    // Publisher
    public class VideoEncoder
    {
        // 1- Define a delegate
        // :) public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        
        // In newer versions of .NET there is no need to create a delegate for event handling. Use the below instead
        public event EventHandler<VideoEventArgs> VideoEncoded;
        // if we dont wanna send any data,use the below
        // public event EventHandler VideoEncoded;

        // 2- Define an event based on that delegate. Whenever we raise this event, we call a method with the same signature as the delegate.
        // events are used to notify system of actions being processed or done. 
        // list of event handlers
        // :) public event VideoEncodedEventHandler VideoEncoded; 

        public void Encode(Video video)
        {
            System.Console.WriteLine("Encoding video '{0}'...", video.title);
            Thread.Sleep(2000);
            
            // this method will notify all the subscribers. its basically a trigger.
            OnVideoEncoded(video);
        }

        // 3- Raise an event. Note the Naming Convention= On...Action
        protected virtual void OnVideoEncoded(Video video)
        {
            // check if there are any subscribers i.e. should be not null
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs(){Video = video});

        }
    }

    // Subscriber
    public class MailService
    {
        // Send mail once video is encoded

        // Event handler. Note this method has same name and signature of delegate.
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            System.Console.WriteLine("Sending Mail Service for {0}", args.Video.title);
        }
    }

    // Subscriber
    public class TextMessageService
    {
        // Send text once video is encoded

        // Event handler. Note this method has same name and signature of delegate.
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            System.Console.WriteLine("Sending Text Message Service for {0}", args.Video.title);
        }
    }

    public class Video{

        private string _title;

        public Video(string Title)
        {
            _title = Title;    
        }

        public string title { get{return _title;} set{_title=title;} }
    }
}