using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System.Drawing.Drawing2D;
namespace ALibWinForms.Ui.Video;



using System;
using System.Diagnostics;
using System.Windows.Forms;

public class NewVideoView : Panel
{
    private VideoViewAbel v = new VideoViewAbel();
    private string videoFilePath;
    private LibVLC libVLC;
    private MediaPlayer mediaPlayer;
    private Media media;
    private Image videoViewImage;
    private System.Windows.Forms.Timer timer;
    private Point compPosRelScreen;
    private Point mousePosition;


    //Progress bar
    private ProgressBar progressBar = new ProgressBar();


    public NewVideoView()
    {

    }


    public Image VideoViewImage
    {
        set
        {
            this.videoViewImage = value;
            v.BackgroundImage = this.videoViewImage;
            v.Dock = DockStyle.Top;
            v.Size = new Size(this.Width, this.Height - 20);
            this.Controls.Add(v);
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += On_timer;
            timer.Start();

            //Progress bar
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
           // progressBar.Size = new Size(, 10);
            progressBar.Dock = DockStyle.Bottom;
           // restPanel.Controls.Add(progressBar);


            v.MouseEnter += On_mouseEnters;
            v.MouseLeave += On_mouseLeave;
            v.MouseHover += On_mouseHovers;
            this.mediaPlayer.EndReached += On_videoEnd;
            this.MouseEnter += On_panelEnter;
        }
        get
        {
            return this.videoViewImage;
        }
    }

    private void On_panelEnter(object? sender, EventArgs e)
    {
        
    }

    private void On_timer(object? sender, EventArgs e)
    {

        try
        {
            this.compPosRelScreen = this.PointToScreen(new Point(0, 0));
            this.mousePosition = Cursor.Position;


            if (this.mousePosition.X >= this.compPosRelScreen.X && this.mousePosition.X <= this.compPosRelScreen.X + this.Width
                && this.mousePosition.Y >= this.compPosRelScreen.Y && this.mousePosition.Y <= this.compPosRelScreen.Y + this.Height)
            {
                if (!this.mediaPlayer.IsPlaying)
                {
                    this.mediaPlayer.Play();
                }
            }
            else
            {
                this.mediaPlayer.Stop();
            }
        }
        catch
        {

        }
    }

    private void On_videoEnd(object? sender, EventArgs e)
    {
        this.mediaPlayer.Play(this.media);
        Debug.WriteLine("video end");
    }

    private void On_mouseHovers(object? sender, EventArgs e)
    {
        this.mediaPlayer.Play(this.media);
    }

    private void On_mouseLeave(object? sender, EventArgs e)
    {
        this.mediaPlayer.Pause();
    }

    private void On_mouseEnters(object? sender, EventArgs e)
    {
        this.mediaPlayer.Play(this.media);
    }

    public string VideoFilePath
    {
        get { return this.videoFilePath; }
        set
        {
            this.videoFilePath = value;
            this.DoAllThing();
        }
    }


    public void DoAllThing()
    {
        libVLC = new LibVLC();
        this.mediaPlayer = new MediaPlayer(libVLC);
        v.MediaPlayer = mediaPlayer;
    }
    public void OpenVideo()
    {
        this.media = new Media(this.libVLC, this.videoFilePath, FromType.FromPath);

        this.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlayer.AspectRatio = $"{x}:{y}";
        });
    }






    protected override void OnPaint(PaintEventArgs e) //Polymorphism
    {
        Debug.WriteLine("hello");
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


public class VideoViewAbel : VideoView
{
    public VideoViewAbel()
    {
        
    }

    protected override void OnPaint(PaintEventArgs e) //Polymorphism
    {
        base.OnPaint(e);
        Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = new GraphicsPath();
        GraphPath.AddArc(Rect.X, Rect.Y, 50, 50, 180, 90); // Top-left corner
        GraphPath.AddArc(Rect.X + Rect.Width - 50, Rect.Y, 50, 50, 270, 90); // Top-right corner
        GraphPath.AddLine(Rect.X + Rect.Width, Rect.Y + 50, Rect.X + Rect.Width, Rect.Y + Rect.Height);
        GraphPath.AddLine(Rect.X + Rect.Width, Rect.Y + Rect.Height, Rect.X, Rect.Y + Rect.Height);
        GraphPath.AddLine(Rect.X, Rect.Y + Rect.Height, Rect.X, Rect.Y + 50);
        GraphPath.CloseFigure();

        this.Region = new Region(GraphPath);
    }
}