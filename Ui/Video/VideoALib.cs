namespace ALibWinForms.Ui.Video;

using LibVLCSharp.WinForms;
using LibVLCSharp.Shared;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;



public class VideoALib : VideoView
{
    private string videoFilePath;
    private LibVLC libVLC;
    private MediaPlayer mediaPlayer;
    private Media media;
    private Panel overlayPanel;


    public string VideoFilePath
    {
        get { return this.videoFilePath; }
        set { this.videoFilePath = value; }
    }


    public VideoALib()
    {

    }



    public void DoAllThing()
    {
        libVLC = new LibVLC();
        this.mediaPlayer = new MediaPlayer(libVLC);
        base.MediaPlayer = mediaPlayer;
        base.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlayer.AspectRatio = $"{x}:{y}";
        });




        overlayPanel = new Panel();
        overlayPanel.Dock = DockStyle.Fill;
        overlayPanel.BackColor = Color.Transparent;
        this.Controls.Add(overlayPanel);
    }
    public void OpenVideo()
    {
        media = new Media(this.libVLC, this.videoFilePath, FromType.FromPath);

        this.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlayer.AspectRatio = $"{x}:{y}";
        });

        this.mediaPlayer.Play(media);
    }


    //MAKE THE VIDEO VIEW CONTAINER TO HAVE ROUND CORNER
    protected override void OnPaint(PaintEventArgs e) //Polymorphism
    {
        base.OnPaint(e);
        Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = new GraphicsPath();
        GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90);
        GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90);
        GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y + Rect.Height - 50, 50, 50, 0, 90);
        GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - 50, 50, 50, 90, 90);
        this.Region = new Region(GraphPath);

        base.OnPaint(e);
    }
}