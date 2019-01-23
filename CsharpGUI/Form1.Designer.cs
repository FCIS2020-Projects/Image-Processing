namespace CsharpGUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSecondImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subImage_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.inputImage2_pictureBox = new System.Windows.Forms.PictureBox();
            this.addImage_btn = new System.Windows.Forms.Button();
            this.sobel_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.equalize_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.outputImage_pictureBox = new System.Windows.Forms.PictureBox();
            this.inputImage_pictureBox = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage2_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1268, 27);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.loadSecondImageToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openImageToolStripMenuItem.Text = "Load First Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.LoadFirstImageToolStripMenuItem_Click);
            // 
            // loadSecondImageToolStripMenuItem
            // 
            this.loadSecondImageToolStripMenuItem.Name = "loadSecondImageToolStripMenuItem";
            this.loadSecondImageToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.loadSecondImageToolStripMenuItem.Text = "Load Second Image";
            this.loadSecondImageToolStripMenuItem.Click += new System.EventHandler(this.loadSecondImageToolStripMenuItem_Click);
            // 
            // subImage_btn
            // 
            this.subImage_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.subImage_btn.Location = new System.Drawing.Point(683, 552);
            this.subImage_btn.Margin = new System.Windows.Forms.Padding(2);
            this.subImage_btn.Name = "subImage_btn";
            this.subImage_btn.Size = new System.Drawing.Size(111, 22);
            this.subImage_btn.TabIndex = 26;
            this.subImage_btn.Text = "Sub Image";
            this.subImage_btn.UseVisualStyleBackColor = true;
            this.subImage_btn.Click += new System.EventHandler(this.subImage_btn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Input Image 2";
            // 
            // inputImage2_pictureBox
            // 
            this.inputImage2_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputImage2_pictureBox.Location = new System.Drawing.Point(428, 112);
            this.inputImage2_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputImage2_pictureBox.Name = "inputImage2_pictureBox";
            this.inputImage2_pictureBox.Size = new System.Drawing.Size(414, 423);
            this.inputImage2_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputImage2_pictureBox.TabIndex = 24;
            this.inputImage2_pictureBox.TabStop = false;
            // 
            // addImage_btn
            // 
            this.addImage_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addImage_btn.Location = new System.Drawing.Point(798, 552);
            this.addImage_btn.Margin = new System.Windows.Forms.Padding(2);
            this.addImage_btn.Name = "addImage_btn";
            this.addImage_btn.Size = new System.Drawing.Size(111, 22);
            this.addImage_btn.TabIndex = 23;
            this.addImage_btn.Text = "Add Image";
            this.addImage_btn.UseVisualStyleBackColor = true;
            this.addImage_btn.Click += new System.EventHandler(this.addImage_btn_Click);
            // 
            // sobel_button
            // 
            this.sobel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sobel_button.Location = new System.Drawing.Point(914, 552);
            this.sobel_button.Margin = new System.Windows.Forms.Padding(2);
            this.sobel_button.Name = "sobel_button";
            this.sobel_button.Size = new System.Drawing.Size(111, 22);
            this.sobel_button.TabIndex = 22;
            this.sobel_button.Text = "Detect Edges";
            this.sobel_button.UseVisualStyleBackColor = true;
            this.sobel_button.Click += new System.EventHandler(this.sobel_button_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1023, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Output Image";
            // 
            // equalize_button
            // 
            this.equalize_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.equalize_button.Location = new System.Drawing.Point(1352, 544);
            this.equalize_button.Margin = new System.Windows.Forms.Padding(2);
            this.equalize_button.Name = "equalize_button";
            this.equalize_button.Size = new System.Drawing.Size(111, 35);
            this.equalize_button.TabIndex = 20;
            this.equalize_button.Text = "Equalize Image";
            this.equalize_button.UseVisualStyleBackColor = true;
            this.equalize_button.Click += new System.EventHandler(this.equalize_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Input Image";
            // 
            // outputImage_pictureBox
            // 
            this.outputImage_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputImage_pictureBox.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.outputImage_pictureBox.Location = new System.Drawing.Point(845, 112);
            this.outputImage_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputImage_pictureBox.Name = "outputImage_pictureBox";
            this.outputImage_pictureBox.Size = new System.Drawing.Size(414, 423);
            this.outputImage_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputImage_pictureBox.TabIndex = 18;
            this.outputImage_pictureBox.TabStop = false;
            // 
            // inputImage_pictureBox
            // 
            this.inputImage_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputImage_pictureBox.Location = new System.Drawing.Point(11, 112);
            this.inputImage_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputImage_pictureBox.Name = "inputImage_pictureBox";
            this.inputImage_pictureBox.Size = new System.Drawing.Size(414, 423);
            this.inputImage_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputImage_pictureBox.TabIndex = 17;
            this.inputImage_pictureBox.TabStop = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(568, 552);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 22);
            this.button3.TabIndex = 28;
            this.button3.Text = "Histogram ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 22);
            this.button1.TabIndex = 30;
            this.button1.Text = "Blur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 552);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 22);
            this.button2.TabIndex = 31;
            this.button2.Text = "Emboss";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 582);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.subImage_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputImage2_pictureBox);
            this.Controls.Add(this.addImage_btn);
            this.Controls.Add(this.sobel_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.equalize_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputImage_pictureBox);
            this.Controls.Add(this.inputImage_pictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage2_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputImage_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSecondImageToolStripMenuItem;
        private System.Windows.Forms.Button subImage_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox inputImage2_pictureBox;
        private System.Windows.Forms.Button addImage_btn;
        private System.Windows.Forms.Button sobel_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button equalize_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox outputImage_pictureBox;
        private System.Windows.Forms.PictureBox inputImage_pictureBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

