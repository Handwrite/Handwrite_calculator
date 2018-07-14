using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using MNISTModelLibrary;// reference MNISTModelLibrary

namespace Imageprocess
{
    class  ImageProcess
    {
        private List<int> x_coord = new List<int>();
        private List<int> y_coord = new List<int>();
        private Bitmap img;
        public List<string> DispText = new List<string>();

        private const int MnistImageSize = 28;// the input image size of MnistModel
        private Mnist model;// MNIST model
        private int corr = 25;

        public void ImageSet(Bitmap imageset)
        {
            img = imageset;
        }

        public void ImageCut()
        {
            model = new Mnist();
            int index = 0;
            char c = '0';
            CutY();

            if (x_coord.Count > 1)
            {
                int x_start = x_coord[0];
                int x_end = x_coord[x_coord.Count - 1];
                int x_index = 0;
                while (x_start != x_end)
                {
                    int Region_Width = x_start;
                    while (x_coord.Contains(Region_Width) && x_index < x_coord.Count)
                    {
                        Region_Width++;
                        x_index++;
                    }
                    int x = x_start;
                    int y = 0;

                    int width = Region_Width - x_start;
                    int height = img.Height;

                    CutX(img.Clone(new Rectangle(x, y, width, height), img.PixelFormat));
                    if (y_coord.Count > 1 && y_coord.Count != img.Height)
                    {
                        int y1 = y_coord[0];
                        int y2 = y_coord[y_coord.Count - 1];
                        if (y1 != 1)
                        {
                            y = y1 - 1;
                        }
                        height = y2 - y1 + 1;
                    }
                    
                    Bitmap temp = img.Clone(new Rectangle(x - corr, y - corr, width + 2 * corr, height + 2 * corr),
                                                img.PixelFormat);
                    //temp.Save("D:\\" + c + ".png");
                    //++ c;
                    TextInfer(temp);
                    temp.Dispose();

                    if (x_index < x_coord.Count)
                    {
                        x_start = x_coord[x_index];
                    }
                    else
                    {
                        x_start = x_end;
                    }
                }
            }
        }

        private void CutY()
        {
            x_coord.Clear();
            bool isWhiteLine = true;
            for (int x = 0; x < img.Width; x++)
            {
                isWhiteLine = false;
                for (int y = 0; y < img.Height; y++)
                {
                    Color __c = img.GetPixel(x, y);
                    if (__c.R == 255)
                    {
                        isWhiteLine = true;
                    }
                    else
                    {
                        isWhiteLine = false;
                        break;
                    }
                }
                if (!isWhiteLine)
                {
                    x_coord.Add(x);
                }
            }
        }

        private void CutX(Bitmap tempImg)
        {
            y_coord.Clear();
            bool isWhiteLine = true;
            for (int x = 0; x < tempImg.Height; x++)
            {
                isWhiteLine = false;
                for (int y = 0; y < tempImg.Width; y++)
                {
                    var __c = tempImg.GetPixel(y, x);
                    if (__c.R == 255)
                    {
                        isWhiteLine = true;
                    }
                    else
                    {
                        isWhiteLine = false;
                        break;
                    }
                }
                if (!isWhiteLine)
                {
                    y_coord.Add(x);
                }
            }
            tempImg.Dispose();
        }

        private void TextInfer(Bitmap img)
        {
            Graphics gNormalized = Graphics.FromImage(img);
            gNormalized.DrawImage(img, 0, 0, MnistImageSize, MnistImageSize);

            var image = new List<float>(MnistImageSize * MnistImageSize);
            for (var x = 0; x < MnistImageSize; x++)
            {
                for (var y = 0; y < MnistImageSize; y++)
                {
                    var color = img.GetPixel(y, x);
                    image.Add((float)(0.5 - (color.R + color.G + color.B) / (3.0 * 255)));
                }
            }
            //string temp = (model.Infer(new List<IEnumerable<float>> { image })).First().First().ToString();
            //DispText.Add(temp);
            DispText.Add((model.Infer(new List<IEnumerable<float>> { image })).First().First().ToString());

        }

    }
}
