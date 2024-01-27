namespace ALibWinForms.Ui.Video;



using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Timers;

public class VideoPanel : Panel
{
    //object related with VideoView container
    private VideoViewInPanel v = new VideoViewInPanel();
    private Image videoBackGroundImage;
    private string videoFile;
    private MediaPlayer medPlay;

    //the panel rest of the VideoView container
    Panel restPanel;

    //the progress bar
    private ProgressBar progressBar;
    private System.Threading.Timer timer;
    private int initializeTimer = 0;
    private bool videoPlaying = true;

    //play/pause button
    private Button playAndPause = new Button();


    public Image VideoBackGroundImage
    {
        set
        {
            this.videoBackGroundImage = value;
            v.Size = new Size(this.Width, this.Height - 50);
            v.Dock = DockStyle.Top;
            this.Controls.Add(v);
            v.VideoBackGroundImage = this.videoBackGroundImage;
            this.MedPlay = v.MediaPlay;


            //New panel
            this.restPanel = new Panel();
            this.restPanel.Size = new Size(300, 30);
            this.restPanel.BackColor = Color.Red;
            this.restPanel.Dock = DockStyle.Fill;
            this.Controls.Add(restPanel);

            //Progress bar
            progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Size = new Size(this.restPanel.Width, 10);
            progressBar.Dock = DockStyle.Bottom;
            restPanel.Controls.Add(progressBar);

            //_____________________________________
            //play and pause button
            playAndPause.Text = "play";
            playAndPause.Size = new Size(30, 40);
            playAndPause.Location = new Point(0, 0);
            playAndPause.Dock = DockStyle.Bottom;
            restPanel.Controls.Add(playAndPause);
        }
        get
        {
            return this.videoBackGroundImage;
        }
    }

    public void OnTimerCallback(object sender)
    {
        if (this.progressBar.InvokeRequired)
        {
            this.progressBar.BeginInvoke((MethodInvoker)(() =>
            {
                if (this.progressBar.Value < 100)
                {
                    progressBar.Value += 1;
                }
            }));
        }
        else
        {
            if (this.progressBar.Value < 100)
            {
                progressBar.Value += 1;
            }
        }
    }

    public MediaPlayer MedPlay
    {
        set 
        { 
            this.medPlay = v.MediaPlay;
            this.medPlay.TimeChanged += On_videoTime;
        }
    }


    public VideoPanel()
    {
        
    }



    public void VideoFile(string videoFile)
    {
        videoFile = videoFile.Trim();
        this.videoFile = videoFile;
        v.VideoFilePath = this.videoFile;
    }
    public void PlayVideo()
    {
        v.OpenVideo();
    }

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
    }


    //Events
    private void On_videoTime(object? sender, MediaPlayerTimeChangedEventArgs e)
    {
        Debug.WriteLine(e.Time);
        if(initializeTimer == 0)
        {
            timer = new System.Threading.Timer(OnTimerCallback, null, TimeSpan.Zero,
              TimeSpan.FromMilliseconds(medPlay.Length / 100));
            ++initializeTimer;
        }


        if (!medPlay.IsPlaying)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            videoPlaying = false;
        }
        else
        {
            if(!videoPlaying)
            {
                timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(medPlay.Length / 100));
                videoPlaying = true;
            }
        }
    }
}


public class VideoViewInPanel : VideoView
{
    private string videoFilePath;
    private Image videoBackGroundImage;
    private LibVLC libVLC;
    private MediaPlayer mediaPlay;
    private Media media;



    public VideoViewInPanel()
    {
        
    }


    public Image VideoBackGroundImage
    {
        set
        {
            this.videoBackGroundImage = value;
            base.BackgroundImage = this.videoBackGroundImage;
            this.InitializeObject();
        }
        get
        {
            return this.videoBackGroundImage;
        }
    }
    public string VideoFilePath
    {
        set
        {
            this.videoFilePath = value;
        }
    }
    public MediaPlayer MediaPlay
    {
        get
        {
            return this.mediaPlay;
        }
    }



    public void InitializeObject()
    {
        libVLC = new LibVLC();
        this.mediaPlay = new MediaPlayer(libVLC);
        base.MediaPlayer = mediaPlay;
        base.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlay.AspectRatio = $"{x}:{y}";
        });
    }
    public void OpenVideo()
    {
        media = new Media(this.libVLC, this.videoFilePath, FromType.FromPath);

        this.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlay.AspectRatio = $"{x}:{y}";
        });

        this.mediaPlay.Play(media);
    }


    //MAKE THE VIDEO VIEW CONTAINER TO HAVE ROUND CORNER
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