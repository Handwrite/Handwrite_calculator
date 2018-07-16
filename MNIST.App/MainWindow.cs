using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imageprocess;

namespace MNIST.App
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const int MnistImageSize = 28;// the input image size of MnistModel
        private Graphics graphics;
        private Point startPoint;// coordinate of the start point of the line to be draw
        private bool isErase;
        // Initialize the window, setup all things
        private void Form1_Load(object sender, EventArgs e)
        {
            writeArea.Image = new Bitmap(writeArea.Width, writeArea.Height);
            graphics = Graphics.FromImage(writeArea.Image);
            graphics.Clear(Color.White);

        }

        // Erase the content of the image and the text of label1 after erase button been clicked
        private void clean_click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            writeArea.Invalidate();
            outputText.Text = "";
        }

        // Record the start coordinate of the line  after left button been pressed
        private void writeArea_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = (e.Button == MouseButtons.Left) ? e.Location : startPoint;
        }

        // Draw the line according to the start coordinate and the current coordinate
        // Update the start coordinate of the next line when the mouse is moving
        private void writeArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
               
                int corr = 28;
                Rectangle Region = new Rectangle(0 + corr, 0 + corr,
                        writeArea.Width - 2 * corr, writeArea.Height - 2 * corr);

                Pen penStyle;

                if (!isErase)
                {
                    penStyle = new Pen(Color.Black, 10) { StartCap = LineCap.Round, EndCap = LineCap.Round };

                }else
                {
                     penStyle = new Pen(Color.White, 10)
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

        //Normalize the picture and send it for inference after left button been released
        private void writeArea_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void writeArea_Click(object sender, EventArgs e)
        {

        }

        private void Equal_MouseClick(object sender, MouseEventArgs e)
        {
            ImageProcess temp = new ImageProcess();
            if (e.Button == MouseButtons.Left)
            {
                // begin to normalize data   
                outputText.Text = "";
                temp.ImageSet((Bitmap)writeArea.Image.Clone());
                temp.ImageCut();
                //process the DispText
                try
                {
                    for (int i = 0; i < temp.DispText.Count; ++i)
                    {
                        outputText.Text += temp.DispText.ElementAt(i);
                    }

                    outputText.Text += "=" + new DataTable().Compute(outputText.Text, "");
                }
                catch
                {
                    outputText.Text = "Try Again!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isErase = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isErase = false;
        }
    }
}
