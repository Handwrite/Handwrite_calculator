using System;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Imageprocess;
using Caculate;

namespace classifybear
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const int MnistImageSize = 227;// the input image size of MnistModel
        private Graphics graphics;
        private Point startPoint;// coordinate of the start point of the line to be draw
        private bool isErase;

        private void MainWindow_Load(object sender, EventArgs e)
        {
            writeArea.Image = new Bitmap(writeArea.Width, writeArea.Height);
            graphics = Graphics.FromImage(writeArea.Image);
            graphics.Clear(Color.White);
        }

        private void clean_click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            writeArea.Invalidate();
            outputText.Text = "";
            Hint.Text = "";
        }

        private void writeArea_Click(object sender, EventArgs e)
        {

        }

        private void writeArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                int corr = 25;
                Rectangle Region = new Rectangle(0 + corr, 0 + corr,
                        writeArea.Width - 2 * corr, writeArea.Height - 2 * corr);

                Pen penStyle;

                if (!isErase)
                {
                    penStyle = new Pen(Color.Black, 10) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                }
                else
                {
                    penStyle = new Pen(Color.White, 40)
                    {
                        StartCap = LineCap.Round,
                        EndCap = LineCap.Round
                    };
                }
                graphics.SetClip(Region);
                graphics.DrawLine(penStyle, startPoint, e.Location);
                writeArea.Invalidate();
                startPoint = e.Location;
            }
        }

        private void writeArea_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = (e.Button == MouseButtons.Left) ? e.Location : startPoint;
        }

        private void writeArea_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Equal_MouseClick(object sender, MouseEventArgs e)
        {
            ImageProcess temp = new ImageProcess();
            if (e.Button == MouseButtons.Left)
            {
                // begin to normalize data
                temp.ImageSet((Bitmap)writeArea.Image.Clone());
                temp.ImageCut();
                //process the DispText
                
                string expression="";
                for (int i = 0; i < temp.DispText.Count; ++i)
                {
                    expression += temp.DispText.ElementAt(i);
                }

                Caculation cal = new Caculation();
                if (cal.Match(expression) == false)
                {
                    Hint.Text = "Can't understand:  " + expression;
                    outputText.Text = "Check your brackects or try again!";
                }
                else
                {//check the error
                    try
                    {
                        Hint.Text = "";
                        outputText.Text = expression;
                        var result = cal.StrCalc(0, ref expression);
                        while (expression.Length != 0)
                        {
                            result = cal.StrCalc(result, ref expression);
                        }

                        outputText.Text += "=" + result.ToString();
                    }
                    catch
                    {
                        outputText.Text = "Try again! ";
                    }
                }

            }
        }
        private void Rubber_Click(object sender, EventArgs e)
        {
            isErase = true;
        }

        private void Pen_Click(object sender, EventArgs e)
        {
            isErase = false;
        }
    }
}
