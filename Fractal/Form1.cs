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
        Bitmap bitmap = new Bitmap(640, 480);

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
            public HSBColor(int a, float h, float s, float b)
            {
                this.a = a;
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
        private static bool action, rectangle, finished, press, test;
        private Cursor c1, c2;
        private static float xy;





        public Fractal()
        {
            InitializeComponent();
            init();


        }
        public void init()
        {
            //HSBcol = new HSB();
            finished = false;
            c1 = Cursors.WaitCursor;
            c2 = Cursors.Cross;
            x1 = this.Width - 16;
            y1 = this.Height - 40;
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
            action = false;
            rectangle = false;

            initvalues();

            xzoom = (xende - xstart) / (double)x1;
            yzoom = (yende - ystart) / (double)y1;
            mandelbrot();
        }

        public void stop()
        {
        }

        public void paint(Graphics g)
        {
            update(g);
        }

        public void update(Graphics g)
        {
            if (test)
            {

                if (rectangle)
                {

                    if (xs < xe)
                    {
                        Pen p = new Pen(Color.White);
                        if (ys < ye) g.DrawRectangle(p, xs, ys, (xe - xs), (ye - ys));
                        else g.DrawRectangle(p, xs, ye, (xe - xs), (ys - ye));
                    }
                    else
                    {
                        Pen p = new Pen(Color.White);
                        if (ys < ye) g.DrawRectangle(p, xe, ys, (xs - xe), (ye - ys));
                        else g.DrawRectangle(p, xe, ye, (xs - xe), (ys - ye));
                    }
                }

                g.DrawImage(bitmap, 0, 0);
            }
        }
        private void mandelbrot() // calculate all points
        {
            int x, y;
            float h, b, alt = 0.0f;
            test = true;
            action = false;
            this.Cursor = c1;
            for (x = 0; x < x1; x += 2)
                for (y = 0; y < y1; y++)
                {
                    h = pointcolour(xstart + xzoom * (double)x, ystart + yzoom * (double)y);
                    // color value
                    Color color = new Color();
                    using (g1 = Graphics.FromImage(bitmap))
                    {
                        if (h != alt)
                        {
                            b = 1.0f - h * h; // brightnes

                            ///djm added

                            ///HSBcol.fromHSB(h,0.8f,b); 
                            ///
                            //convert hsb to rgb then make a Java Color

                            color = HSBColor.FromHSB(new HSBColor(h * 255, 0.8f * 255, b * 255));

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
                            float wid = (float)-1;
                            Pen p = new Pen(color, wid);
                            g1.DrawLine(p, x, y, x + 1, y);


                        }
                        else
                        {
                            b = 1.0f - h * h; // brightnes
                            color = HSBColor.FromHSB(new HSBColor(h * 255, 0.8f * 255, b * 255));
                            Pen p = new Pen(color);
                            g1.DrawLine(p, x, y, x + 1, y);

                        }
                    }


                }
            //showStatus("Mandelbrot-Set ready - please select zoom area with pressed mouse.");
            this.Cursor = c2;
            action = true;
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                if (action)
                {
                    xe = e.X;
                    ye = e.Y;
                    rectangle = true;
                    Invalidate();
                }
                press = false;
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int z, w;
            if (action)
            {
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
                rectangle = false;
                test = true;
                Invalidate();
            }

        }

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

            if (action)
            {
                press = true;
                xs = e.X;
                ys = e.Y;
            }
            else
            {
                press = false;
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g1 = g;
            if (test)
            {
                update(g1);
            }
            else
            {
                start();
            }
            pictureBox1.Image = bitmap;
            g.DrawImageUnscaled(pictureBox1.Image, 0, 0);


        }
    }
}
