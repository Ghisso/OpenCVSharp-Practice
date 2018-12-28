using System;
using OpenCvSharp;

namespace opencvsharpudemy.Chapter4
{
    public class MatObject
    {
        public static void Mats(string[] args)
        {
            // Create Mat object

            Mat mat = new Mat(200, 400, MatType.CV_8UC3, new Scalar(0, 0, 255)); // BGR HERE!!!
            Mat other_mat = new Mat(new Size(400, 300), MatType.CV_8UC3, new Scalar(0, 255, 255));//Care swap rows and cols!
            Cv2.ImShow("mat", mat);
            Cv2.ImShow("other mat", other_mat);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Clone Mat objects

            string filepath = @"images/lenna.png";
            Mat colorImage = Cv2.ImRead(filepath, ImreadModes.Color);
            Cv2.ImShow("image", colorImage);
            Mat clone = colorImage.Clone();
            Cv2.ImShow("clone", clone);
            Mat clone2 = new Mat();
            colorImage.CopyTo(clone2);
            Cv2.ImShow("clone2", clone2);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Get channels

            Mat[] channels;
            Cv2.Split(colorImage, out channels);
            Cv2.ImShow("Blue", channels[0]);
            Cv2.ImShow("Green", channels[1]);
            Cv2.ImShow("Red", channels[2]);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // ROI
            Mat roiImage = new Mat(colorImage, new Rect(50, 50, 250, 250));
            Cv2.ImShow("RoI", roiImage);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Get/Set

            Mat working_image = colorImage.Clone();
            int numRows = working_image.Rows;
            int numCols = working_image.Cols;

            for (int y = 0; y < numCols; y++)
            {
                for (int x = 0; x < numRows; x++)
                {
                    Vec3b pixel = working_image.Get<Vec3b>(y, x);
                    byte blue_pix = pixel.Item0;
                    byte green_pix = pixel.Item1;
                    byte red_pix = pixel.Item2;

                    byte tmp = blue_pix;
                    pixel.Item0 = red_pix;
                    pixel.Item2 = tmp;
                    working_image.Set<Vec3b>(y, x, pixel);
                }
            }
            Cv2.ImShow("Swapped image", working_image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Indexer (faster than get/set)

            var indexer = working_image.GetGenericIndexer<Vec3b>();

            for (int y = 100; y < numCols-100; y++)
            {
                for (int x = 100; x < numRows-100; x++)
                {
                    Vec3b pixel = indexer[y,x];
                    byte blue_pix = pixel.Item0;
                    byte green_pix = pixel.Item1;
                    byte red_pix = pixel.Item2;

                    byte tmp = blue_pix;
                    pixel.Item0 = red_pix;
                    pixel.Item2 = tmp;
                    indexer[y,x] = pixel;
                }
            }
            Cv2.ImShow("Swapped image", working_image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Fastest access: indexer on specific type

            MatOfByte3 mat3 = new MatOfByte3(working_image);
            var indexer2 = mat3.GetIndexer();


            for (int y = 100; y < numCols-100; y++)
            {
                for (int x = 100; x < numRows-100; x++)
                {
                    Vec3b pixel = indexer2[y,x];
                    byte blue_pix = pixel.Item0;
                    byte green_pix = pixel.Item1;
                    byte red_pix = pixel.Item2;

                    byte tmp = blue_pix;
                    pixel.Item0 = red_pix;
                    pixel.Item2 = tmp;
                    indexer2[y,x] = pixel;
                }
            }
            Cv2.ImShow("Swapped image", working_image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Drawing shapes on images

            Mat canvas = new Mat(300, 300, MatType.CV_8UC3, new Scalar(0,0,0));

            var red = new Scalar(0, 0, 255);
            var green = new Scalar(0, 255, 0);
            var blue = new Scalar(255, 0, 0);
            var white = new Scalar(255, 255, 255);

            Cv2.Line(canvas, new Point(100, 100), new Point(200, 200), blue, 2);
            Cv2.Circle(canvas, new Point(150, 150), 50, red, 3);
            Cv2.Rectangle(canvas, new Rect(new Point(50, 50), new Size(50, 100)), green, 1);


            Cv2.ImShow("Canvas", canvas);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
