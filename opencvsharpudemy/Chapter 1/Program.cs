using System;
using OpenCvSharp;

namespace opencvsharpudemy
{
    class Program
    {
        public static void basic(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("No args");
            }
            else
            {
                string filepath = args[0];
                Console.WriteLine(filepath);
                Mat image = Cv2.ImRead(filepath, ImreadModes.Color);
                Cv2.ImShow("image", image);
                Cv2.ImWrite(@"images/saved_image.jpg", image);
                Cv2.WaitKey();
                Cv2.DestroyAllWindows();
            }
        }
    }
}
