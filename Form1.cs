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
    private LibVLC libVLC;
    private MediaPlayer mediaPlayer;

    public void InitializeLibVLC()
    {
        libVLC = new LibVLC();

        mediaPlayer = new MediaPlayer(libVLC);

        videoDemo.MediaPlayer = mediaPlayer;
    }
    private void OpenVideo(string filePath)
    {
        var media = new Media(libVLC, filePath, FromType.FromPath);
        mediaPlayer.Play(media);
    }


    public Form1()
    {
        InitializeComponent();
        InitializeLibVLC();
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

        OpenVideo(photoPath);
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
    }

    private void On_imageEntered(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }

    private void btnPlayOrPause_Click(object sender, EventArgs e)
    {
        if (mediaPlayer.IsPlaying)
        {
            mediaPlayer.Pause();
            btnPlayOrPause.Text = "Play";
        }
        else
        {
            mediaPlayer.Play();
            btnPlayOrPause.Text = "Pause";
        }
    }

    private void videoDemo_Click(object sender, EventArgs e)
    {

    }
}