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
        private Bitmap img;
        public List<string> DispText = new List<string>();

        public void ImageSet(Bitmap imageset)
        {
            img = imageset;
        }

        public void ImageCut()
        {
            Mnist model = new Mnist();
            List<int> x_coord = new List<int>();
            List<int> y_coord = new List<int>();
            int index = 0;
            const int MnistImageSize = 28, corr = 25;
            CutY(ref x_coord);

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

                    CutX(img.Clone(new Rectangle(x, y, width, height), img.PixelFormat), ref y_coord);

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
                    TextInfer(temp, model, MnistImageSize);
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

        private void CutY(ref List<int> x_coord)
        {
            x_coord.Clear();
            bool isWhiteCol = true;
            for (int x = 0; x < img.Width; x++)
            {
                isWhiteCol = true;
                for (int y = 0; y < img.Height; y++)
                {
                    Color col = img.GetPixel(x, y);
                    if (col.R == 255 && col.G == 255 && col.B == 255)
                    {
                        continue;
                    }
                    else
                    {
                        isWhiteCol = false;
                        break;
                    }
                }
                if (!isWhiteCol)
                {
                    x_coord.Add(x);
                }
            }
        }

        private void CutX(Bitmap tempImg, ref List<int> y_coord)
        {
            y_coord.Clear();
            bool isWhiteRow = true;
            for (int x = 0; x < tempImg.Height; x++)
            {
                isWhiteRow = false;
                for (int y = 0; y < tempImg.Width; y++)
                {
                    var col = tempImg.GetPixel(y, x);
                    if (col.R == 255 && col.G == 255 && col.B == 255)
                    {
                        isWhiteRow = true;
                    }
                    else
                    {
                        isWhiteRow = false;
                        break;
                    }
                }
                if (!isWhiteRow)
                {
                    y_coord.Add(x);
                }
            }
            tempImg.Dispose();
        }

        private void TextInfer(Bitmap img, Mnist model, int MnistImageSize)
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
            string str_temp = (model.Infer(new List<IEnumerable<float>> { image })).First().First().ToString();
            if (str_temp == "43")
            {
                str_temp = "+";
            }
            else if (str_temp == "42")
            {
                str_temp = "*";
            }
            else if (str_temp == "45")
            {
                str_temp = "-";
            }
            else if (str_temp == "47")
            {
                str_temp = "/";
            }
            DispText.Add(str_temp);
        }

    }
}
