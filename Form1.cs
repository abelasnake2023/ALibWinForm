using ALibWinForms.BusinessLogic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using ALib.Database.ALibSqlServer;
using System;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;


namespace ALibWinForms;


public partial class Form1 : Form
{
    private string photoPath = @"C:\Users\user\Videos\Captures\Messi fa on Liverpool (2).mp4";
    private Button play;




    public Form1()
    {
        InitializeComponent();
        videoaLib1.VideoFilePath = photoPath;
        videoaLib1.DoAllThing();

        play = new Button();
        play.Location = new Point(50, 50);
        play.Size = new Size(50, 30);
        play.BringToFront();
        play.Text = "play";
        play.Visible = true;
        videoaLib1.Controls.Add(play);
    }

    private static Image ByteArrayToImage(byte[] byteArray)
    {
        if (byteArray == null || byteArray.Length == 0)
        {
            Console.WriteLine("error!");
            return null;
        }

        using (MemoryStream stream = new MemoryStream(byteArray))
        {
            Console.WriteLine("error!");
            return Image.FromStream(stream);
        }
    }

    private void btnAddPhotoFilePath_Click(object sender, EventArgs e)
    {
        /*        object[,] param = new object[1, 3]
                {
                    { "@photo", "int",  9 }
                };


                ALibDataReader reader = new ALibDataReader();
                object o = reader.ExecuteScalarFunction("dbo.GetPhoto", param);


                if (o is byte[])
                {
                    byte[] byteArray = (byte[])o;
                    // Do something with the byte array...
                    Debug.WriteLine(BitConverter.ToString(byteArray));
                    pBoxImage.Image = PhotoConverter.ConvertByteArrayToImage(byteArray);
                }*/

        videoaLib1.OpenVideo();
        videoPanel1.VideoFile("C:\\Users\\user\\Videos\\Captures\\Messi fa on Liverpool (2).mp4");
        videoPanel1.PlayVideo();

        //progressBar1.Increment(10);

        newVideoView1.VideoFilePath = "C:\\Users\\user\\Videos\\Captures\\Messi fa on Liverpool (2).mp4";
        newVideoView1.OpenVideo();
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

    private void Form1_Load(object sender, EventArgs e)
    {
        pBoxImage.AllowDrop = true;
        newVideoView1.VideoFilePath = "C:\\Users\\user\\Videos\\Captures\\Messi fa on Liverpool (2).mp4";
        newVideoView1.OpenVideo();
    }

    private void On_imageEntered(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }

    private void On_mouseOnVideo(object sender, EventArgs e)
    {
        play.Visible = true;
        Debug.WriteLine("On_mouseOnVideo");
    }

    private void videoaLib1_MouseDown(object sender, MouseEventArgs e)
    {
        // play.Visible = true;
    }

    private void videoaLib1_MouseMove(object sender, MouseEventArgs e)
    {
        play.Visible = true;
        Debug.WriteLine("videoaLib1_MouseMove");
    }

    private void videoaLib1_Click(object sender, EventArgs e)
    {
        play.Visible = true;
        Debug.WriteLine("videoaLib1_MouseMove");
    }


    private void VideoView_Paint(object sender, PaintEventArgs e)
    {


    }

    private void On_mouseEntered(object sender, EventArgs e)
    {
        Debug.WriteLine("VideoView object mouse entred");
    }

    private void videoView1_Click(object sender, EventArgs e)
    {
        Debug.WriteLine("VideoView object mouse entred");
    }
}