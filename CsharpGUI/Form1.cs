using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace CsharpGUI
{
    public partial class Form1 : Form
    {

        [DllImport("Project.dll")]
        private static extern int Sum(int y, int b);

        [DllImport("Project.dll")]
        private static extern int SumArr([In] int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void ToUpper([In, Out]char[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void AddImages([In] int[] firstChannelToAdd, [In] int[] secondChannelToAdd
                                            , [Out] int[] output, int imageSize);


        [DllImport("Project.dll")]
        private static extern void SubImages([In] int[] firstChannelToSub, [In] int[] secondChannelToSub
                                            , [Out] int[] output, int imageSize);

        [DllImport("Project.dll")]
        private static extern void Invert([In, Out] int[] redChannel, [In, Out] int[] greenChannel,
                                            [In, Out] int[] blueChannel, int imageSize);

        [DllImport("Project.dll")]
        private static extern void ToGray([In] int[] redChannel, [In] int[] greenChannel, [In] int[] blueChannel,[Out] int[] grayImage, int imageSize);

        [DllImport("Project.dll")]
        private static extern void PadWithZero([In] int[] image, [Out] int[] NewImage, int Width, int Height);

        [DllImport("Project.dll")]
        private static extern void Conv([In] int[] image, [Out] int[] NewImage, [In] int[] Kernel, int Width, int Height);

        [DllImport("Project.dll")]
        private static extern void Scale([In, Out] int[] image, int imageSize);

        [DllImport("Project.dll")]
        private static extern void DDiv([In, Out] int[] image, int imageSize);

        [DllImport("Project.dll")]
        private static extern void FreqArr([In] int[] image, [Out]int[] farr, int sz);

        [DllImport("Project.dll")]
        private static extern void CumSum([In, Out] int[] arr);

        [DllImport("Project.dll")]
        private static extern void Equalize([In, Out] int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void Equalize2([In, Out] int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void NewImage([In, Out] int[] image, [In]int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void EqualizeHistogram([In, Out] int[] redChannel, [In, Out] int[] greenChannel,
                                            [In, Out] int[] blueChannel, int imageSize);


        public ImageBuffers BuffersFirstImage
        {
            get
            {
                if (this.inputImage_pictureBox != null && this.inputImage_pictureBox.Image != null && FirstImage != null)
                {
                    return ImageHelper.GetBuffersFromImage(this.FirstImage);
                }
                return null;
            }
        }

        public ImageBuffers BuffersSecondImage
        {
            get
            {
                if (this.inputImage2_pictureBox != null && this.inputImage2_pictureBox.Image != null && SecondImage != null)
                {
                    return ImageHelper.GetBuffersFromImage(this.SecondImage);
                }
                return null;
            }
        }

        public Bitmap FirstImage { get; set; }

        public Bitmap SecondImage { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void equalize_button_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            //Get first image buffers
            var buffersOfFirstImage = BuffersFirstImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;

            int[] redArr = new int[256];
            int[] blueArr = new int[256];
            int[] greenArr = new int[256];


            FreqArr(buffersOfFirstImage.RedChannel, redArr, imageSize);
            FreqArr(buffersOfFirstImage.BlueChannel, blueArr, imageSize);
            FreqArr(buffersOfFirstImage.GreenChannel, greenArr, imageSize);

            CumSum(redArr);
            CumSum(blueArr);
            CumSum(greenArr);

            Equalize(redArr, imageSize);
            Equalize(greenArr, imageSize);
            Equalize(blueArr, imageSize);

            /*Equalize2(redArr, imageSize);
            Equalize2(greenArr, imageSize);
            Equalize2(blueArr, imageSize);*/

            NewImage(buffersOfFirstImage.RedChannel, redArr, imageSize);
            NewImage(buffersOfFirstImage.BlueChannel, blueArr, imageSize);
            NewImage(buffersOfFirstImage.GreenChannel, greenArr, imageSize);

            //Refelct the result to the GUI
            //1. Convert the output channels into bitmap
            var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(buffersOfFirstImage.RedChannel, buffersOfFirstImage.GreenChannel, buffersOfFirstImage.BlueChannel, width, height);
            this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
        }


        private void sobel_button_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            //Get first image buffers
            var buffersOfFirstImage = BuffersFirstImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;
            int paddedImageSize = (width + 2) * (height + 2);

            int[] grayImage = new int[imageSize];
            int[] paddedImage = new int[paddedImageSize];
            int[] sobelEdgeVertical = new int[imageSize];
            int[] sobelEdgeHorizontal = new int[imageSize];
            int[] sobelEdge = new int[imageSize];
            int[] HorizontalKernel = new int[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
            int[] VerticalKernel = new int[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
            
            //Invert(buffersOfFirstImage.RedChannel, buffersOfFirstImage.GreenChannel, buffersOfFirstImage.BlueChannel, imageSize);

            ToGray(buffersOfFirstImage.RedChannel, buffersOfFirstImage.GreenChannel, buffersOfFirstImage.BlueChannel, grayImage, imageSize);

            PadWithZero(grayImage, paddedImage, height, width);

            Conv(paddedImage, sobelEdgeVertical, VerticalKernel, height, width);

            Conv(paddedImage, sobelEdgeHorizontal, HorizontalKernel, height, width);


            for (int i = 0; i < imageSize; i++)
            {
                sobelEdge[i] = (int)Math.Sqrt(sobelEdgeVertical[i] * sobelEdgeVertical[i] + sobelEdgeHorizontal[i] * sobelEdgeHorizontal[i]);
            }

            Scale(sobelEdge, imageSize);

            //Refelct the result to the GUI
            //1. Convert the output channels into bitmap
            var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(sobelEdge, sobelEdge, sobelEdge, width, height);
            this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
        }

        private void LoadFirstImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\Libraries\\Pictures";
            openFileDialog1.Filter = "*.BMP;*.PPM;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string fname = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        string ext = Path.GetExtension(openFileDialog1.FileName);
                        fname = openFileDialog1.FileName;
                        using (myStream)
                        {
                            this.FirstImage = new Bitmap(myStream);
                            this.inputImage_pictureBox.Image = this.FirstImage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void loadSecondImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\Libraries\\Pictures";
            openFileDialog1.Filter = "*.BMP;*.PPM;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string fname = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        string ext = Path.GetExtension(openFileDialog1.FileName);
                        fname = openFileDialog1.FileName;
                        using (myStream)
                        {
                            this.SecondImage = new Bitmap(myStream);
                            this.inputImage2_pictureBox.Image = this.SecondImage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void addImage_btn_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            if (BuffersSecondImage == null)
            {
                MessageBox.Show("Second image is not available");
                return;
            }
            var buffersOfFirstImage = BuffersFirstImage;
            var buffersOfSecondImage = BuffersSecondImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;

            if(width == buffersOfSecondImage.Width && height == buffersOfSecondImage.Height)
            {
                int[] outputImageRed = new int[imageSize];
                int[] outputImageGreen = new int[imageSize];
                int[] outputImageBlue = new int[imageSize];

                AddImages(buffersOfFirstImage.RedChannel, buffersOfSecondImage.RedChannel, outputImageRed, imageSize);
                AddImages(buffersOfFirstImage.GreenChannel, buffersOfSecondImage.GreenChannel, outputImageGreen, imageSize);
                AddImages(buffersOfFirstImage.BlueChannel, buffersOfSecondImage.BlueChannel, outputImageBlue, imageSize);
                Scale(outputImageRed, imageSize);
                Scale(outputImageGreen, imageSize);
                Scale(outputImageBlue, imageSize);

                var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(outputImageRed, outputImageGreen, outputImageBlue, width, height);
                this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
            }
            else
            {
                MessageBox.Show("Images Are Not The Same Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void subImage_btn_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            if(BuffersSecondImage == null)
            {
                MessageBox.Show("Second image is not available");
                return;
            }
            var buffersOfFirstImage = BuffersFirstImage;
            var buffersOfSecondImage = BuffersSecondImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;

            if(width == buffersOfSecondImage.Width && height == buffersOfSecondImage.Height)
            {
                int[] outputImageRed = new int[imageSize];
                int[] outputImageGreen = new int[imageSize];
                int[] outputImageBlue = new int[imageSize];

                SubImages(buffersOfFirstImage.RedChannel, buffersOfSecondImage.RedChannel, outputImageRed, imageSize);
                SubImages(buffersOfFirstImage.GreenChannel, buffersOfSecondImage.GreenChannel, outputImageGreen, imageSize);
                SubImages(buffersOfFirstImage.BlueChannel, buffersOfSecondImage.BlueChannel, outputImageBlue, imageSize);
                Scale(outputImageRed, imageSize);
                Scale(outputImageGreen, imageSize);
                Scale(outputImageBlue, imageSize);

                var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(outputImageRed, outputImageGreen, outputImageBlue, width, height);
                this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
            }
            else
            {
                MessageBox.Show("Images Are Not The Same Size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            var buffersOfFirstImage = BuffersFirstImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;

            int[] redArr = new int[256];
            int[] blueArr = new int[256];
            int[] greenArr = new int[256];


            FreqArr(buffersOfFirstImage.RedChannel, redArr, imageSize);
            FreqArr(buffersOfFirstImage.BlueChannel, blueArr, imageSize);
            FreqArr(buffersOfFirstImage.GreenChannel, greenArr, imageSize);

            CumSum(redArr);
            CumSum(blueArr);
            CumSum(greenArr);

            Equalize(redArr, imageSize);
            Equalize(greenArr, imageSize);
            Equalize(blueArr, imageSize);

            /*Equalize2(redArr, imageSize);
            Equalize2(greenArr, imageSize);
            Equalize2(blueArr, imageSize);*/

            NewImage(buffersOfFirstImage.RedChannel, redArr, imageSize);
            NewImage(buffersOfFirstImage.BlueChannel, blueArr, imageSize);
            NewImage(buffersOfFirstImage.GreenChannel, greenArr, imageSize);

            //Refelct the result to the GUI
            //1. Convert the output channels into bitmap
            var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(buffersOfFirstImage.RedChannel, buffersOfFirstImage.GreenChannel, buffersOfFirstImage.BlueChannel, width, height);
            this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            var buffersOfFirstImage = BuffersFirstImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;
            int paddedImageSize = (width + 2) * (height + 2);

            int[] outputImageRed = new int[imageSize];
            int[] outputImageGreen = new int[imageSize];
            int[] outputImageBlue = new int[imageSize];
            int[] paddedImageR = new int[paddedImageSize];
            int[] paddedImageG = new int[paddedImageSize];
            int[] paddedImageB = new int[paddedImageSize];
            int[] BlurKernel = new int[] { 1,2,1,2,4,2,1,2,1 };

            PadWithZero(buffersOfFirstImage.RedChannel, paddedImageR, height, width);
            PadWithZero(buffersOfFirstImage.GreenChannel, paddedImageG, height, width);
            PadWithZero(buffersOfFirstImage.BlueChannel, paddedImageB, height, width);

            Conv(paddedImageR, outputImageRed, BlurKernel, height, width);
            Conv(paddedImageG, outputImageGreen, BlurKernel, height, width);
            Conv(paddedImageB, outputImageBlue, BlurKernel, height, width);

            DDiv(outputImageRed, imageSize);
            DDiv(outputImageGreen, imageSize);
            DDiv(outputImageBlue, imageSize);

            Scale(outputImageRed, imageSize);
            Scale(outputImageGreen, imageSize);
            Scale(outputImageBlue, imageSize);
            //Refelct the result to the GUI
            //1. Convert the output channels into bitmap
            var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(outputImageRed, outputImageGreen, outputImageBlue, width, height);
            this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BuffersFirstImage == null)
            {
                MessageBox.Show("First image is not available");
                return;
            }
            var buffersOfFirstImage = BuffersFirstImage;

            int width = buffersOfFirstImage.Width;
            int height = buffersOfFirstImage.Height;
            int imageSize = width * height;
            int paddedImageSize = (width + 2) * (height + 2);

            int[] outputImage = new int[imageSize];
            
            int[] paddedImage = new int[paddedImageSize];
            
            int[] EmbossKernel = new int[] { -2, -1, 0, -1, 1, 1, 0, 1, 2 };

            ToGray(buffersOfFirstImage.RedChannel, buffersOfFirstImage.GreenChannel, buffersOfFirstImage.BlueChannel, outputImage, imageSize);

            PadWithZero(outputImage, paddedImage, height, width);

            Conv(paddedImage, outputImage, EmbossKernel, height, width);
            

            Scale(outputImage, imageSize);

            var outputBuffersObject = ImageHelper.CreateNewImageBuffersObject(outputImage, outputImage, outputImage, width, height);
            this.outputImage_pictureBox.Image = (Bitmap)ImageHelper.GetImageFromBuffers(outputBuffersObject).BitmapObject;
        }
    }
}
