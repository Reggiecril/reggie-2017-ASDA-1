﻿namespace Fractal
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
            this.SuspendLayout();
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 424);
            this.Name = "Fractal";
            this.Text = "Fractal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Fractal_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Fractal_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Fractal_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Fractal_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

