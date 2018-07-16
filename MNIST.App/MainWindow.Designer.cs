namespace MNIST.App
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.writeArea = new System.Windows.Forms.PictureBox();
            this.outputText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Equal = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).BeginInit();
            this.SuspendLayout();
            // 
            // writeArea
            // 
            resources.ApplyResources(this.writeArea, "writeArea");
            this.writeArea.Name = "writeArea";
            this.writeArea.TabStop = false;
            this.writeArea.Click += new System.EventHandler(this.writeArea_Click);
            this.writeArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseDown);
            this.writeArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseMove);
            this.writeArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.writeArea_MouseUp);
            // 
            // outputText
            // 
            resources.ApplyResources(this.outputText, "outputText");
            this.outputText.Name = "outputText";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clean_click);
            // 
            // Equal
            // 
            resources.ApplyResources(this.Equal, "Equal");
            this.Equal.Name = "Equal";
            this.Equal.UseVisualStyleBackColor = true;
            this.Equal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Equal_MouseClick);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Equal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.writeArea);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.writeArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox writeArea;
        private System.Windows.Forms.Label outputText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Equal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
