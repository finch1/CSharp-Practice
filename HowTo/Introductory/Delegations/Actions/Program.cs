namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            
            // [delegate type] [name] = function to point to
            // :) PhotoProcessor.PhotofilterHandler filterHandler = filters.ApplyBrightnessPhoto;
            Action<Photo> filterHandler = filters.ApplyBrightnessPhoto;
            filterHandler += filters.ApplyContrastPhoto;
            filterHandler += RedEyeFilter;

            // this will call the filter method pointed by filter handler. Hence a list of filter functions is passed
            processor.Process("photo.png", filterHandler);

            // In addition, we can add new filters in this scope
            static void RedEyeFilter(Photo photo)
            {
                System.Console.WriteLine("Remove Red Eye.");
            }


        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }
    
    public class PhotoProcessor
    {
        // :) public delegate void PhotofilterHandler(Photo photo);

        // :) public void Process(string path, PhotofilterHandler filterHandler)
        public void Process(string path, Action<Photo> filterHandler) // pass any delegate that takes a photo as an arcument and returns void
        {
            var photo = Photo.Load(path);

            // apply filters. This code whill not know what filters will be applied and it is the responsability of the called function. this way applied filters are flexible.
            filterHandler(photo);

            photo.Save();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightnessPhoto(Photo photo)
        {
            System.Console.WriteLine("Apply brightness filter");
        }

        public void ApplyContrastPhoto(Photo photo)
        {
            System.Console.WriteLine("Apply contrast filter");
        }

        public void ApplyResizePhoto(Photo photo)
        {
            System.Console.WriteLine("Apply resize filter");
        }
    }
}