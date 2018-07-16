using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MnistModleLibrary;

namespace Imageprocess
{
    class ImageProcess
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
            const int MnistImageSize = 227, corr = 20;
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

                    Bitmap temp = img.Clone(new Rectangle(x - corr, y - corr, width + 2*corr, height + 2*corr),
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
            img = (Bitmap)img.GetThumbnailImage(MnistImageSize, MnistImageSize, null, new System.IntPtr());

            var image = new float[MnistImageSize * MnistImageSize * 3];
            for (var x = 0; x < MnistImageSize; x++)
            {
                for (var y = 0; y < MnistImageSize; y++)
                {
                    var color = img.GetPixel(y, x);

                    image[x * MnistImageSize + y] = color.B;
                    image[x * MnistImageSize + y + 1 * MnistImageSize * MnistImageSize] = color.G;
                    image[x * MnistImageSize + y + 2 * MnistImageSize * MnistImageSize] = color.R;
                }
            }
            DispText.Add((model.Infer(new List<IEnumerable<float>> { image })).First().First());

        }

    }
}
