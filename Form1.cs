using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using ALib.Database.ALibSqlServer;
using System;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using ALibWinForms.Ui.Video;
using ALibWinForms.Ui.Photo;



namespace ALibWinForms;



internal partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private async void btnAddPhotoFilePath_Click(object sender, EventArgs e)
    {
        /*object[,] param = new object[1, 3]
               {
                            { "@photo", "int",  16 }
               };


        ALibDataReader reader = new ALibDataReader();

        object o = null;
        await Task.Run(() =>
        {
            try
            {
                o = reader.ExecuteScalarFunction("dbo.GetPhoto", param);
            }
            catch
            {
                Debug.WriteLine("I think timeout");
            }
        });



        if (o is byte[])
        {
            byte[] byteArray = (byte[])o;


            Debug.WriteLine(BitConverter.ToString(byteArray));


            Image i = Image.FromFile(@"C:\Users\user\Desktop\Github profile.jpg");
            VideoInPanel videoInPanel = new VideoInPanel();
            videoInPanel.Location = new Point(500, 400);
            videoInPanel.Size = new Size(500, 300);
            videoInPanel.VideoBackGroundImage = i;

            string filePath = VideoConverter.ConvertByteArrayToVideoFile(byteArray);
            Debug.WriteLine("my file path: " + filePath);

            videoInPanel.VideoFile(filePath);
            videoInPanel.InitiateVideo();
            this.Controls.Add(videoInPanel);
        }*/
    }

    private void On_imageDropped(object sender, DragEventArgs e)
    {
        var data = e.Data.GetData(DataFormats.FileDrop);
        if (data != null)
        {
            var fileNames = data as string[];
            if (fileNames.Length > 0)
            {
                pBoxImage.Image = Image.FromFile(fileNames[0]);
            }
        }
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        pBoxImage.AllowDrop = true;
    }

    private void On_imageEntered(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
}