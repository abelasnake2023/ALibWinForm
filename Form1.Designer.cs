namespace ALibWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pBoxImage = new PictureBox();
            btnAddPhotoFilePath = new Button();
            txtBoxFilePath = new TextBox();
            videoDemo = new LibVLCSharp.WinForms.VideoView();
            btnPlayOrPause = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoDemo).BeginInit();
            SuspendLayout();
            // 
            // pBoxImage
            // 
            pBoxImage.BackColor = SystemColors.ButtonFace;
            pBoxImage.Location = new Point(153, 12);
            pBoxImage.Name = "pBoxImage";
            pBoxImage.Size = new Size(488, 273);
            pBoxImage.TabIndex = 0;
            pBoxImage.TabStop = false;
            pBoxImage.DragDrop += On_imageDropped;
            pBoxImage.DragEnter += On_imageEntered;
            // 
            // btnAddPhotoFilePath
            // 
            btnAddPhotoFilePath.Location = new Point(153, 291);
            btnAddPhotoFilePath.Name = "btnAddPhotoFilePath";
            btnAddPhotoFilePath.Size = new Size(190, 37);
            btnAddPhotoFilePath.TabIndex = 1;
            btnAddPhotoFilePath.Text = "Add Photo Path";
            btnAddPhotoFilePath.UseVisualStyleBackColor = true;
            btnAddPhotoFilePath.Click += btnAddPhotoFilePath_Click;
            // 
            // txtBoxFilePath
            // 
            txtBoxFilePath.Location = new Point(349, 299);
            txtBoxFilePath.Name = "txtBoxFilePath";
            txtBoxFilePath.Size = new Size(292, 23);
            txtBoxFilePath.TabIndex = 2;
            // 
            // videoDemo
            // 
            videoDemo.BackColor = Color.Black;
            videoDemo.BackgroundImage = Properties.Resources.Github_profile;
            videoDemo.Location = new Point(153, 343);
            videoDemo.MediaPlayer = null;
            videoDemo.Name = "videoDemo";
            videoDemo.Size = new Size(906, 456);
            videoDemo.TabIndex = 3;
            videoDemo.Text = "videoView1";
            videoDemo.Click += videoDemo_Click;
            // 
            // btnPlayOrPause
            // 
            btnPlayOrPause.Location = new Point(1081, 343);
            btnPlayOrPause.Name = "btnPlayOrPause";
            btnPlayOrPause.Size = new Size(112, 33);
            btnPlayOrPause.TabIndex = 4;
            btnPlayOrPause.Text = "Play";
            btnPlayOrPause.UseVisualStyleBackColor = true;
            btnPlayOrPause.Click += btnPlayOrPause_Click;
            // 
            // Form1
            // 
            AcceptButton = btnAddPhotoFilePath;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1260, 811);
            Controls.Add(btnPlayOrPause);
            Controls.Add(videoDemo);
            Controls.Add(txtBoxFilePath);
            Controls.Add(btnAddPhotoFilePath);
            Controls.Add(pBoxImage);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoDemo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pBoxImage;
        private Button btnAddPhotoFilePath;
        private TextBox txtBoxFilePath;
        private LibVLCSharp.WinForms.VideoView videoDemo;
        private Button btnPlayOrPause;
    }
}