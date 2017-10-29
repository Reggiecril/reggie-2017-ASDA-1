namespace Fractal
{
    partial class Fractal
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fractal));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.colorCycle = new System.Windows.Forms.Button();
            this.t = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 425);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(790, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(173, 120);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            this.btn_save.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_save_MouseMove);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(606, 268);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(154, 69);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.colorPicker_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar2.LargeChange = 2;
            this.trackBar2.Location = new System.Drawing.Point(606, 343);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(154, 69);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.colorPicker_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar3.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar3.LargeChange = 2;
            this.trackBar3.Location = new System.Drawing.Point(790, 268);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(154, 69);
            this.trackBar3.TabIndex = 5;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.Scroll += new System.EventHandler(this.colorPicker_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(762, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(762, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(946, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "B";
            // 
            // trackBar4
            // 
            this.trackBar4.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar4.LargeChange = 10;
            this.trackBar4.Location = new System.Drawing.Point(790, 343);
            this.trackBar4.Maximum = 255;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(154, 69);
            this.trackBar4.TabIndex = 9;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar4.Scroll += new System.EventHandler(this.colorPicker_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(949, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "BG";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(606, 12);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(173, 120);
            this.reset.TabIndex = 11;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // colorCycle
            // 
            this.colorCycle.BackColor = System.Drawing.Color.White;
            this.colorCycle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorCycle.BackgroundImage")));
            this.colorCycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorCycle.Location = new System.Drawing.Point(606, 138);
            this.colorCycle.Name = "colorCycle";
            this.colorCycle.Size = new System.Drawing.Size(357, 130);
            this.colorCycle.TabIndex = 12;
            this.colorCycle.Text = "Color Cycle";
            this.colorCycle.UseVisualStyleBackColor = false;
            this.colorCycle.Click += new System.EventHandler(this.colorCycle_Click);
            // 
            // t
            // 
            this.t.Tick += new System.EventHandler(this.t_Tick);
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 424);
            this.Controls.Add(this.colorCycle);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Fractal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Fractal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button colorCycle;
        private System.Windows.Forms.Timer t;
    }
}

