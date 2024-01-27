using ALibWinForms.Ui.Video;

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
            videoaLib1 = new VideoALib();
            videoPanel1 = new VideoPanel();
            newVideoView1 = new NewVideoView();
            ((System.ComponentModel.ISupportInitialize)pBoxImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoaLib1).BeginInit();
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
            btnAddPhotoFilePath.Location = new Point(672, 12);
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
            // videoaLib1
            // 
            videoaLib1.AllowDrop = true;
            videoaLib1.BackColor = Color.Black;
            videoaLib1.BackgroundImage = Properties.Resources.Github_profile1;
            videoaLib1.Location = new Point(153, 382);
            videoaLib1.MediaPlayer = null;
            videoaLib1.Name = "videoaLib1";
            videoaLib1.Size = new Size(515, 335);
            videoaLib1.TabIndex = 3;
            videoaLib1.Text = "videoaLib1";
            videoaLib1.VideoFilePath = null;
            videoaLib1.Click += videoaLib1_Click;
            videoaLib1.Paint += VideoView_Paint;
            videoaLib1.Enter += On_mouseEntered;
            videoaLib1.MouseDown += videoaLib1_MouseDown;
            videoaLib1.MouseEnter += On_mouseOnVideo;
            videoaLib1.MouseMove += videoaLib1_MouseMove;
            // 
            // videoPanel1
            // 
            videoPanel1.BackColor = SystemColors.ActiveCaption;
            videoPanel1.Location = new Point(672, 64);
            videoPanel1.Name = "videoPanel1";
            videoPanel1.Size = new Size(506, 350);
            videoPanel1.TabIndex = 4;
            videoPanel1.VideoBackGroundImage = Properties.Resources.Github_profile2;
            // 
            // newVideoView1
            // 
            newVideoView1.Location = new Point(693, 420);
            newVideoView1.Name = "newVideoView1";
            newVideoView1.Size = new Size(514, 351);
            newVideoView1.TabIndex = 5;
            newVideoView1.VideoFilePath = null;
            newVideoView1.VideoViewImage = Properties.Resources.Github_profile5;
            // 
            // Form1
            // 
            AcceptButton = btnAddPhotoFilePath;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1260, 811);
            Controls.Add(newVideoView1);
            Controls.Add(videoPanel1);
            Controls.Add(videoaLib1);
            Controls.Add(txtBoxFilePath);
            Controls.Add(btnAddPhotoFilePath);
            Controls.Add(pBoxImage);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoaLib1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pBoxImage;
        private Button btnAddPhotoFilePath;
        private TextBox txtBoxFilePath;
        private VideoALib videoaLib1;
        private VideoPanel videoPanel1;
        private NewVideoView newVideoView1;
    }
}