using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Fractal : Form
    {
        Bitmap bitmap = new Bitmap(640,480);
        Graphics g1;
        public struct HSBColor
        {
            float h;
            float s;
            float b;
            int a;
            public HSBColor(float h, float s, float b)
            {
                this.a = 0xff;
                this.h = Math.Min(Math.Max(h, 0f), 255);
                this.s = Math.Min(Math.Max(s, 0f), 255);
                this.b = Math.Min(Math.Max(b, 0f), 255);

            }

            public float H
            {
                get { return h; }
            }
            public float S
            {
                get { return s; }
            }
            public float B
            {
                get { return b; }
            }
            public int A
            {
                get { return a; }
            }
            public Color Color
            {
                get
                {
                    return FromHSB(this);
                }
            }
            public static Color FromHSB(HSBColor hsbColor)
            {
                float r = hsbColor.b;
                float g = hsbColor.b;
                float b = hsbColor.b;
                if (hsbColor.s != 0)
                {
                    float max = hsbColor.b;
                    float dif = hsbColor.b * hsbColor.s / 255f;
                    float min = hsbColor.b - dif;
                    float h = hsbColor.h * 360f / 255f;





                    if (h < 60f)
                    {
                        r = max;
                        g = h * dif / 60f + min;
                        b = min;
                    }
                    else if (h < 120f)
                    {
                        r = -(h - 120f) * dif / 60f + min;
                        g = max;
                        b = min;
                    }
                    else if (h < 180f)
                    {
                        r = min;
                        g = max;
                        b = (h - 120f) * dif / 60f + min;
                    }
                    else if (h < 240f)
                    {
                        r = min;
                        g = -(h - 240f) * dif / 60f + min;
                        b = max;
                    }
                    else if (h < 300f)
                    {
                        r = (h - 240f) * dif / 60f + min;
                        g = min;
                        b = max;
                    }
                    else if (h <= 360f)
                    {
                        r = max;
                        g = min;
                        b = -(h - 360f) * dif / 60 + min;
                    }
                    else
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                }
                return Color.FromArgb
                    (
                        hsbColor.a,
                        (int)Math.Round(Math.Min(Math.Max(r, 0), 255)),
                        (int)Math.Round(Math.Min(Math.Max(g, 0), 255)),
                        (int)Math.Round(Math.Min(Math.Max(b, 0), 255))
                        );
            }
        }





        private int MAX = 256;      // max iterations
        private double SX = -2.025; // start value real
        private double SY = -1.125; // start value imaginary
        private double EX = 0.6;    // end value real
        private double EY = 1.125;  // end value imaginary
        private static int x1, y1, xs, ys, xe, ye;
        private static double xstart, ystart, xende, yende, xzoom, yzoom;
        private static bool  rectangle=false, finished, test,track_scoll=false;
        private Cursor c1, c2;
        private static float xy;
        private Color color2;
        float h, b, alt = 0.0f,hue = 255,saturation = 0.8f * 255, brightness=255,bg=255;

        private void reset_Click(object sender, EventArgs e)
        {
            track_scoll = false;
            hue = 255;
            saturation = 0.8f * 255;
            brightness = 255;
            bg = 255;
            start();
            pictureBox1.Image = bitmap;
        }

        private void colorPicker_Scroll(object sender, EventArgs e)
        {
            track_scoll = true;
            hue = trackBar1.Value;
            saturation = trackBar2.Value;
            brightness = trackBar3.Value;
            bg = trackBar4.Value;


            start();
            pictureBox1.Image = bitmap;
        }

        public Fractal()
        {
            InitializeComponent();
            init();

        }


        
        //Save image
        private void btn_save_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to btn_save.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.pictureBox1.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.pictureBox1.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        

        public void init()
        {
            //HSBcol = new HSB();
            finished = false;
            c1 = Cursors.WaitCursor;
            c2 = Cursors.Cross;
            x1 = this.Width -150;
            y1 = this.Height - 38;
            pictureBox1.Width = x1;
            pictureBox1.Height = y1;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            xy = (float)x1 / (float)y1;
            finished = true;
        }

        

        public void destroy() // delete all instances 
        {
            if (finished)
            {
                //removeMouseListener(this);
                //removeMouseMotionListener(this);
                //bitmap = null;

                g1 = null;
                c1 = null;
                c2 = null;

                //System.gc(); // garbage collection
                GC.Collect();
            }
        }


        public void start()
        {

            initvalues();

            xzoom = (xende - xstart) / (double)x1;
            yzoom = (yende - ystart) / (double)y1;
           
                mandelbrot();
            
            
        }

        private void mandelbrot() // calculate all points
        {
            if (!track_scoll)
            {
                trackBar1.Value = 255;
                trackBar2.Value = 255;
                trackBar3.Value = 255;
                
            }
            int x, y;
            test = true;
            this.Cursor = c1;
            for (x = 0; x < x1; x ++)
                for (y = 0; y < y1; y++)
                {
                    h = pointcolour(xstart + xzoom * (double)x, ystart + yzoom * (double)y);
                    // color value
                    
                        if (h != alt)
                        {
                        // brightnes

                        ///djm added

                        ///HSBcol.fromHSB(h,0.8f,b); 

                        //convert hsb to rgb then make a Java Color
                        
                            b = 1.0f - h * h;
                            if (!track_scoll)
                            {
                                hue = h * 255;
                            }

                            color2 = HSBColor.FromHSB(new HSBColor(hue,saturation,b*brightness));

                        ///g1.setColor(col);
                        //djm end
                        //djm added to convert to RGB from HSB

                        //g1.setColor(Color.getHSBColor(h, 0.8f, b));
                        //djm test

                        //  Color col = Color.FromArgb(0, 0, 0, 0);

                        //red = Color.Red;
                        // green = Color.Green;
                        // blue = Color.Blue;

                        //djm 
                        alt = h;





                        }
                        else
                        {
                        b = 1.0f - h * h;
                        if (!track_scoll)
                        {
                           bg = h * 255;
                        }
                        color2 = HSBColor.FromHSB(new HSBColor(bg, 0.8f * 255,b * 255));
                        }
                    bitmap.SetPixel(x, y, color2);


                }
            //showStatus("Mandelbrot-Set ready - please select zoom area with pressed mouse.");
            pictureBox1.Image = bitmap;
            this.Cursor = c2;
        }

        private float pointcolour(double xwert, double ywert)
        // color value from 0.0 to 1.0 by iterations
        {
            double r = 0.0, i = 0.0, m = 0.0;
            int j = 0;

            while ((j < MAX) && (m < 4.0))
            {
                j++;
                m = r * r - i * i;
                i = 2.0 * r * i + ywert;
                r = m + xwert;
            }
            return (float)j / (float)MAX;
        }
        private void initvalues() // reset start values
        {
            xstart = SX;
            ystart = SY;
            xende = EX;
            yende = EY;
            if ((float)((xende - xstart) / (yende - ystart)) != xy)
                xstart = xende - (yende - ystart) * (double)xy;
        }
       
        //Save Button
        private void btn_save_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        //Color Choose
        
        //Picture Box
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            rectangle = true;
           
                
                xs = e.X;
                ys = e.Y;
            

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if (rectangle)
            {
                xe = e.X;
                ye = e.Y;

                Bitmap bm = new Bitmap(bitmap);

                // Draw the rectangle.
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.DrawRectangle(Pens.White,
                        Math.Min(xs, xe), Math.Min(ys, xe),
                        Math.Abs(xe-xs), Math.Abs(ye-ys));
                }
                pictureBox1.Image = bm;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            rectangle = false;
               
                int z, w;
                xe = e.X;
                ye = e.Y;

                if (xs > xe)
                {
                    z = xs;
                    xs = xe;
                    xe = z;
                }
                if (ys > ye)
                {
                    z = ys;
                    ys = ye;
                    ye = z;
                }
                w = (xe - xs);
                z = (ye - ys);
                if ((w < 2) && (z < 2)) initvalues();
                else
                {
                    if (((float)w > (float)z * xy)) ye = (int)((float)ys + (float)w / xy);
                    else xe = (int)((float)xs + (float)z * xy);
                    xende = xstart + xzoom * (double)xe;
                    yende = ystart + yzoom * (double)ye;
                    xstart += xzoom * (double)xs;
                    ystart += yzoom * (double)ys;
                }
                xzoom = (xende - xstart) / (double)x1;
                yzoom = (yende - ystart) / (double)y1;
           
          
                mandelbrot();
           
                test = true;
                Invalidate();

            

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        
            if (!test)
            {
           
                start();

            }
            


        }
    }
}
