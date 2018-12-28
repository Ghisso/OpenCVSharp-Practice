using System;
using OpenCvSharp;
namespace opencvsharpudemy.Chapter5
{
    public class ImageOperations
    {
        public static void Main(string[] args)
        {
            string filepath = @"images/lenna.png";
            Mat colorImage = Cv2.ImRead(filepath, ImreadModes.Color);

            // Image Shifting, we need translation matrix in the form:
            // [1,0, tx]
            // [0,1, ty]
            // So a 2*3 matrix set like above where we change tx and ty by number of pixels we want to shift in x and y

            //float[] shift = { 1, 0, 50, 0, 1, 100 };
            //Mat translation_matrix = new Mat(2, 3, MatType.CV_32FC1, shift);
            //Mat destination = new Mat();
            //Cv2.WarpAffine(colorImage, dest, translation_matrix, new Size(colorImage.Width + 60, colorImage.Height + 110));

            //Cv2.ImShow("Shifted Lenna", dest);
            //Cv2.WaitKey();
            //Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Image Rotation, need center point of rotation and rotation matrix of type float
            // We use same Warp affine but give different matrix
            //var center = new Point2f(colorImage.Width / 2, colorImage.Height / 2);
            //double angle = 60.0;
            //double scale = 1.0;
            //Mat rotation_matrix = Cv2.GetRotationMatrix2D(center, angle, scale);
            //Mat destination = new Mat();
            //Cv2.WarpAffine(colorImage, destination, rotation_matrix, new Size(colorImage.Width, colorImage.Height));

            //Cv2.ImShow("Rotated Lenna", destination);
            //Cv2.WaitKey();
            //Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Image flipping, 3 different modes

            //Mat x_flip = new Mat();
            //Cv2.Flip(colorImage, x_flip, FlipMode.X);

            //Mat y_flip = new Mat();
            //Cv2.Flip(colorImage, y_flip, FlipMode.Y);

            //Mat xy_flip = new Mat();
            //Cv2.Flip(colorImage, xy_flip, FlipMode.XY);

            //Cv2.ImShow("X Flipped Lenna", x_flip);
            //Cv2.ImShow("Y Flipped Lenna", y_flip);
            //Cv2.ImShow("XY Flipped Lenna", xy_flip);
            //Cv2.WaitKey();
            //Cv2.DestroyAllWindows();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Bitwise Ops : AND, OR, XOR, NOT

            Mat image1 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);
            Mat image2 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);

            Cv2.Rectangle(image1, new Rect(new Point(0, 0), new Size(image1.Cols / 2, image1.Rows)), new Scalar(255, 255, 255), -1);
            Cv2.ImShow("image 1", image1);

            Cv2.Rectangle(image2, new Rect(new Point(150, 100), new Size(200, 50)), new Scalar(255, 255, 255), -1);
            Cv2.ImShow("image 2", image2);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
