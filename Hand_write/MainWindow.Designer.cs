namespace classifybear
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.writeArea = new System.Windows.Forms.PictureBox();
            this.Equal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.Label();
            this.Rubber = new System.Windows.Forms.Button();
            this.Pen = new System.Windows.Forms.Button();
            this.Hint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(626, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 37);
            this.label1.TabIndex = 2;
            // 
            // writeArea
            // 
            this.writeArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.writeArea.Location = new System.Drawing.Point(11, 11);
            this.writeArea.Margin = new System.Windows.Forms.Padding(2);
            this.writeArea.Name = "writeArea";
            this.writeArea.Size = new System.Drawing.Size(1196, 443);
            this.writeArea.TabIndex = 4;
            this.writeArea.TabStop = false;
            this.writeArea.Click += new System.EventHandler(this.writeArea_Click);
            this.writeArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseDown);
            this.writeArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseMove);
            this.writeArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseUp);
            // 
            // Equal
            // 
            this.Equal.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.Equal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Equal.Location = new System.Drawing.Point(893, 607);
            this.Equal.Name = "Equal";
            this.Equal.Size = new System.Drawing.Size(140, 60);
            this.Equal.TabIndex = 5;
            this.Equal.Text = "=";
            this.Equal.UseVisualStyleBackColor = true;
            this.Equal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Equal_MouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(1055, 607);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "归零";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clean_click);
            // 
            // outputText
            // 
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.outputText.Location = new System.Drawing.Point(11, 466);
            this.outputText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(858, 163);
            this.outputText.TabIndex = 7;
            this.outputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rubber
            // 
            this.Rubber.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rubber.Location = new System.Drawing.Point(1046, 523);
            this.Rubber.Name = "Rubber";
            this.Rubber.Size = new System.Drawing.Size(140, 60);
            this.Rubber.TabIndex = 8;
            this.Rubber.Text = "橡皮擦";
            this.Rubber.UseVisualStyleBackColor = true;
            this.Rubber.Click += new System.EventHandler(this.Rubber_Click);
            // 
            // Pen
            // 
            this.Pen.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pen.Location = new System.Drawing.Point(893, 523);
            this.Pen.Name = "Pen";
            this.Pen.Size = new System.Drawing.Size(140, 60);
            this.Pen.TabIndex = 9;
            this.Pen.Text = "笔触";
            this.Pen.UseVisualStyleBackColor = true;
            this.Pen.Click += new System.EventHandler(this.Pen_Click);
            // 
            // Hint
            // 
            this.Hint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Hint.Location = new System.Drawing.Point(11, 629);
            this.Hint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(815, 54);
            this.Hint.TabIndex = 10;
            this.Hint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 703);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.Pen);
            this.Controls.Add(this.Rubber);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Equal);
            this.Controls.Add(this.writeArea);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "Hand_write Caculator";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox writeArea;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label outputText;
        private System.Windows.Forms.Button Rubber;
        private System.Windows.Forms.Button Pen;
        private System.Windows.Forms.Label Hint;
    }
}

