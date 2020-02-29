using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NS.Percepton
{
    public class ShowPercepton
    {
        public PictureBox _pictureBox;

        public ShowPercepton(PictureBox PicBox) { _pictureBox = PicBox; }
        public Point start;
        public double[] max { get; set; }
        public double[] min { get; set; }

        public List<List<double>> _points { get; set; }
        public List<double>_expectedPoint { get; set; }

        public Percepton percepton { get; set; }

        public int Width;
        public int Height;
        public void Draw()
        {
            if (max == null || max.Length < 2 )
                return;
            Width = _pictureBox.Width ;
            Height= _pictureBox.Height ;

            Bitmap bm = new Bitmap(Width, Height);
           
            Graphics formGraphics = Graphics.FromImage(bm);
            Pen blackPen = new Pen(Color.Black);

            double d = (max[0] <= 1) ? 0.1 : 1;
            for(double  m = min[0]; m <= max[0]; m+=d)
            {             
                double X = ConverMaxMin(m,min[0],max[0],0,Width);
               
                formGraphics.DrawString(""+m, SystemFonts.DefaultFont, Brushes.Black,(int)X, start.Y);

                if(m == 0)
                {
                    formGraphics.DrawLine(blackPen, (int)X, 0, (int)X, Width);
                    start.X = (int)X;
                }
            }

            for (double m = min[1]; m <= max[1]; m+=d)
            {
                double Y = ConverMaxMin(m, min[1], max[1], 0, Width);

                formGraphics.DrawString("" + m, SystemFonts.DefaultFont, Brushes.Black, start.X, (int)Y);

                if (m == 0)
                {
                    formGraphics.DrawLine(blackPen, 0, (int)Y, Width, (int)Y);
                    start.Y = (int)Y;
                }
            }

            if(_points != null && _expectedPoint != null)
            {
               for(int n = 0; n < _points.Count;n++)
                {
                    double X = ConverMaxMin(_points[n][0], min[0], max[0], 0, Width);
                    double Y = ConverMaxMin(_points[n][1], min[1], max[1], 0, Width);

                    formGraphics.FillRectangle((_expectedPoint[n] > 0)?Brushes.Red : Brushes.Green, new Rectangle((int)X-5, (int)Y-5, 5, 5));
                }
            }

            if(percepton != null)
            {
                double w0 = percepton.bias;
                double w1 = percepton.weights[0];
                double w2 = percepton.weights[1];

                for (double x = min[0]; x < max[0]; x+=0.01) {
                    double y = (-(w0 / w2) / (w0 / w1)) * x + (-w0 / w2);

                    double X = ConverMaxMin(x, min[0], max[0], 0, Width);
                    double Y = ConverMaxMin(y, min[1], max[1], 0, Width);

                    formGraphics.FillRectangle(Brushes.Aqua, new Rectangle((int)X, (int)Y, 5, 5));
                }
            }


            _pictureBox.Image = bm;
            blackPen.Dispose();
            formGraphics.Dispose();
        }
        
        public static double ConverMaxMin(double Input,double InputLow, double InputHigh,double OutputLow,double OutputHigh) {
        
            return ((Input - InputLow) / (InputHigh - InputLow)) * (OutputHigh - OutputLow) + OutputLow;
        }
    }
}
