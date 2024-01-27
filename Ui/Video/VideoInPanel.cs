namespace ALibWinForms.Ui.Video;



using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System.Drawing.Drawing2D;
using System.Threading;



public class VideoInPanel : Panel
{
    //object related with VideoView container
    private VideoViewInPanel v = new VideoViewInPanel();
    private Image videoBackGroundImage;
    private string videoFile;
    private MediaPlayer medPlay;
    //the panel rest of the VideoView container
    private Panel restPanel;
    //the progress bar
    private ProgressBar progressBar;
    private System.Threading.Timer timer; // in order to move the progress bar
    private long movieCurrentTime = 0;
    private int initializeTimer = 0;
    private bool videoPlaying = true;
    //related to start and end the video when the mouse hovers
    private System.Windows.Forms.Timer timerGui;
    private Point compPosRelScreen;
    private Point mousePosition;
    private bool guiTimerEqNonGuiTimer = false;
    private bool delayProgressBar = false;



    public VideoInPanel()
    {
        
    }



    public Image VideoBackGroundImage
    {
        set
        {
            this.videoBackGroundImage = value;
            v.Size = new Size(this.Width, this.Height - 5);
            v.Dock = DockStyle.Top;
            this.Controls.Add(v);
            v.VideoBackGroundImage = this.videoBackGroundImage;
            this.MedPlay = v.MediaPlay;

            //Gui Timer -> in order to start and stop the video
            timerGui = new System.Windows.Forms.Timer();
            timerGui.Interval = 500;
            timerGui.Tick += On_GuiTimer;
            timerGui.Start();

            //the part rest from the Video
            this.restPanel = new Panel();
            this.restPanel.Size = new Size(300, 30);
            this.restPanel.BackColor = Color.Green;
            this.restPanel.Dock = DockStyle.Fill;
            this.Controls.Add(restPanel);

            //Progress bar -> video progress bar
            progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.BackColor = Color.White;
            progressBar.ForeColor = Color.Red;
            progressBar.Size = new Size(this.restPanel.Width, 10);
            progressBar.Dock = DockStyle.Bottom;
            restPanel.Controls.Add(progressBar);
        }
        get
        {
            return this.videoBackGroundImage;
        }
    }
    private MediaPlayer MedPlay
    {
        set 
        { 
            this.medPlay = v.MediaPlay;
            this.medPlay.TimeChanged += On_videoTime;
        }
    }



    //normal methods
    public void VideoByte(byte[] b)
    {

    }
    public void VideoMemoryStream(MemoryStream memoryStream)
    {

    }
    public void VideoFile(string videoFile)
    {
        videoFile = videoFile.Trim();
        this.videoFile = videoFile;
        v.VideoFilePath = this.videoFile;
    }
    public void InitiateVideo()
    {
        v.OpenVideo();
    }
    public string Help()
    {
        string s = "\n        * Step to be followed with example\n" +
            "        Image i = Image.FromFile(@\"C:\\Users\\user\\Desktop\\Github profile.jpg\");\r\n" +
            "        VideoInPanel videoInPanel = new VideoInPanel();\r\n" +
            "        videoInPanel.Location = new Point(500, 400);\r\n" +
            "        videoInPanel.Size = new Size(500, 300);\r\n" +
            "        videoInPanel.VideoBackGroundImage = i;\r\n" +
            "        videoInPanel.VideoFile(@\"C:\\Users\\user\\Videos\\Captures\\Messi fa on Liverpool (2).mp4\");\r\n" +
            "        videoInPanel.InitiateVideo();\r\n" +
            "        this.Controls.Add(videoInPanel);\n";

        return s;
    }



    //Events
    private async void On_GuiTimer(object? sender, EventArgs e)
    {
        try
        {
            this.compPosRelScreen = this.PointToScreen(new Point(0, 0));
            this.mousePosition = Cursor.Position;


            if (this.mousePosition.X >= this.compPosRelScreen.X && this.mousePosition.X <= this.compPosRelScreen.X + this.Width
                && this.mousePosition.Y >= this.compPosRelScreen.Y && this.mousePosition.Y <= this.compPosRelScreen.Y + this.Height)
            {
                guiTimerEqNonGuiTimer = true;

                v.Dock = DockStyle.Top;
                v.Size = new Size(this.Width, this.Height - 5);

                if (!this.medPlay.IsPlaying)
                {
                    await Task.Run(() => v.Play());

                    if(this.delayProgressBar)
                    {
                        movieCurrentTime = 0;
                    }

                    progressBar.Value = 0;
                    delayProgressBar = true;
                }
            }
            else
            {
                this.delayProgressBar = false;
                this.guiTimerEqNonGuiTimer = false;
                await Task.Run(() => v.Stop());
                this.progressBar.Value = 0;
                movieCurrentTime = 0;

                v.Dock = DockStyle.Fill;
            }
        }
        catch
        {

        }
    }
    public async void On_nonGuiTimer(object sender)
    {
        await Task.Run(() =>
        {
            if (this.progressBar.InvokeRequired)
            {
                this.progressBar.BeginInvoke((MethodInvoker)(() =>
                {
                    if (this.progressBar.Value < 100 && guiTimerEqNonGuiTimer && this.medPlay.IsPlaying
                    && movieCurrentTime > 200)
                    {
                        progressBar.Value += 1;
                    }
                }));
            }
            else
            {
                if (this.progressBar.Value < 100 && guiTimerEqNonGuiTimer && this.medPlay.IsPlaying
                    && movieCurrentTime > 200)
                {
                    progressBar.Value += 1;
                }
            }
        });
    }
    private async void On_videoTime(object? sender, MediaPlayerTimeChangedEventArgs e)
    {
        await Task.Run(() =>
        {
            movieCurrentTime = e.Time;
            if (initializeTimer == 0)
            {
                timer = new System.Threading.Timer(On_nonGuiTimer, null, TimeSpan.Zero,
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
                if (!videoPlaying)
                {
                    timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(medPlay.Length / 100));
                    videoPlaying = true;
                }
            }
        });
    }



    //Painting
    protected async override void OnPaint(PaintEventArgs e) //Polymorphism
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
}



internal class VideoViewInPanel : VideoView
{
    private string videoFilePath;
    private Image videoBackGroundImage;
    private LibVLC libVLC;
    private MediaPlayer mediaPlay;
    private Media media;



    internal VideoViewInPanel()
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
    public Media Media
    {
        get
        {
            return this.media;
        }
    }



    public void InitializeObject()
    {
        libVLC = new LibVLC();
        this.mediaPlay = new MediaPlayer(libVLC);
        base.MediaPlayer = this.mediaPlay;
        base.Invoke((MethodInvoker)delegate
        {
            string x = Convert.ToString(this.Width);
            string y = Convert.ToString(this.Height);
            this.mediaPlay.AspectRatio = $"{x}:{y}";
        });
    }
    public async void OpenVideo()
    {
        await Task.Run(() =>
        {
            this.media = new Media(this.libVLC, this.videoFilePath, FromType.FromPath);

            this.Invoke((MethodInvoker)delegate
            {
                string x = Convert.ToString(this.Width);
                string y = Convert.ToString(this.Height);
                this.mediaPlay.AspectRatio = $"{x}:{y}";
            });
        });
    }
    public void Play()
    {
        this.mediaPlay.Play(this.media);
    }
    public void Stop()
    {
        this.mediaPlay.Stop();
    }



    //MAKE THE VIDEO VIEW CONTAINER TO HAVE ROUND CORNER ONLY ON THE TOP
    protected async override void OnPaint(PaintEventArgs e) //Polymorphism
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
        base.OnPaint(e);
    }
}