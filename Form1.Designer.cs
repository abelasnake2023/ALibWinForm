using ALibWinForms.Ui.Video;

namespace ALibWinForms
{
    internal partial class Form1
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
            components = new System.ComponentModel.Container();
            pBoxImage = new PictureBox();
            btnAddPhotoFilePath = new Button();
            txtBoxFilePath = new TextBox();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            ((System.ComponentModel.ISupportInitialize)pBoxImage).BeginInit();
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
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // Form1
            // 
            AcceptButton = btnAddPhotoFilePath;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1260, 811);
            Controls.Add(txtBoxFilePath);
            Controls.Add(btnAddPhotoFilePath);
            Controls.Add(pBoxImage);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pBoxImage;
        private Button btnAddPhotoFilePath;
        private TextBox txtBoxFilePath;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}