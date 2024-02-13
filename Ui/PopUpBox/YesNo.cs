﻿namespace ALibWinForms.Ui.PopUpBox;



using Guna.UI2.WinForms;
using System.Windows.Forms;



public delegate void ActionYesNo(object? sender, EventArgs e);
public class YesNo : Form
{
    private int width;
    private int height;
    private PictureBox logoPBox;
    private Panel pnlTop;
    private Panel pnlBottom;
    private Label lblMainMessage;
    private Label lblTitleMessage;
    private Guna2Button btnClose;
    private Guna2Button btnYes;
    private Guna2Button btnNo;


    public YesNo(int width, int height, int x, int y, int titleHeight,
        string title, string mainMessage, Image cancelBtnImage, Image logoImage, Image topImage, 
        Image bottomImage, Image btnYesImage, Image btnNoImage,
        ActionYesNo actionYes, ActionYesNo actionNo)
    {
        // the form property
        this.Visible = true;
        this.FormBorderStyle = FormBorderStyle.None;
        this.width = width;
        this.height = height;
        this.Size = new Size(width, height);
        this.StartPosition = FormStartPosition.Manual;
        this.Location = new Point(x, y);

        // The bottom panel
        this.pnlBottom = new Panel();
        this.pnlBottom.Size = new Size(width, height - titleHeight);
        this.pnlBottom.Dock = DockStyle.Fill;
        this.pnlBottom.BackgroundImage = bottomImage;
        this.Controls.Add(this.pnlBottom);

        // The top panel
        this.pnlTop = new Panel();
        this.pnlTop.Size = new Size(width, titleHeight);
        this.pnlTop.Dock = DockStyle.Top;
        this.pnlTop.BackgroundImage = topImage;
        this.Controls.Add(this.pnlTop);

        // the main label
        this.lblMainMessage = new Label();
        this.lblMainMessage.BackColor = Color.Transparent;
        this.lblMainMessage.Text = mainMessage;
        this.lblMainMessage.Size = new Size(30, 30); // default size
        this.lblMainMessage.Location = new Point
            ((width / 2) - 30, (height - titleHeight) / 2); // default location
        this.pnlBottom.Controls.Add(this.lblMainMessage);

        // the top Label
        this.lblTitleMessage = new Label();
        this.lblTitleMessage.BackColor = Color.Transparent;
        this.lblTitleMessage.Size = new Size(20, 20); // default size
        this.lblTitleMessage.Text = title;
        this.lblTitleMessage.Location = new Point
            ((width / 2) - 20, titleHeight / 2); // default location
        this.pnlTop.Controls.Add(this.lblTitleMessage);

        // the logo
        logoPBox = new PictureBox();
        logoPBox.BackColor = Color.Transparent;
        logoPBox.SizeMode = PictureBoxSizeMode.Zoom;
        logoPBox.Size = new Size(30, 30); // default size
        logoPBox.Image = logoImage;
        logoPBox.Location = new Point(0 + 7, 0 + 7); // default position
        this.pnlTop.Controls.Add(logoPBox);

        // Close button
        this.btnClose = new Guna2Button();
        this.btnClose.FillColor = Color.Transparent;
        this.btnClose.BackColor = Color.Transparent;
        this.btnClose.Size = new Size(cancelBtnImage.Width, cancelBtnImage.Height);
        this.btnClose.BackgroundImage = cancelBtnImage;
        this.btnClose.Location = new Point
            (width - cancelBtnImage.Width, 0);
        this.pnlTop.Controls.Add(this.btnClose);
        this.btnClose.Click += On_exit;

        // yes button
        this.btnYes = new Guna2Button();
        this.btnYes.FillColor = Color.Transparent;
        this.btnYes.BackColor = Color.Transparent;
        this.btnYes.Size = new Size(btnYesImage.Width, btnYesImage.Height);
        this.btnYes.BackgroundImage = btnYesImage;
        this.btnYes.BackgroundImageLayout = ImageLayout.Zoom;
        this.btnYes.Text = "Yes";
        this.btnYes.Location = new Point
            (height - 30, (1/4) * width); // default location
        this.pnlBottom.Controls.Add(this.btnYes);
        this.btnYes.Click += (sender, e) => actionYes(sender, e);

        // No button
        this.btnNo = new Guna2Button();
        this.btnNo.FillColor = Color.Transparent;
        this.btnNo.BackColor = Color.Transparent;
        this.btnNo.Size = new Size(btnNoImage.Width, btnNoImage.Height);
        this.btnNo.BackgroundImage = btnNoImage;
        this.btnNo.BackgroundImageLayout = ImageLayout.Zoom;
        this.btnNo.Text = "No";
        this.btnNo.Location = new Point
            (height - 30, (3/4) * width); // default location
        this.pnlBottom.Controls.Add(this.btnNo);
        this.btnNo.Click += (sender, e) => actionNo(sender, e);
    }


    public Guna2Button BtnClose
    {
        get { return this.btnClose; }
    }



    public void TitlePosition(int x, int y)
    {
        this.lblTitleMessage.Location = new Point(x, y);
    }
    public void TitleSize(int width, int height)
    {
        this.lblTitleMessage.Size = new Size(width, height);
    }
    public void MainMessagePosition(int x, int y)
    {
        this.lblMainMessage.Location = new Point(x, y);
    }
    public void MainMessageSize(int width, int height)
    {
        this.lblMainMessage.Size = new Size(width, height);
    }
    public void LogoPosition(int x, int y)
    {
        this.logoPBox.Location = new Point(x, y);
    }
    public void LogoSize(int width, int height)
    {
        this.logoPBox.Size = new Size(width, height);
    }
    public void BtnYesLocation(int x, int y)
    {
        this.btnYes.Location = new Point(x, y);
    }
    public void BtnNoLocation(int x, int y)
    {
        this.btnNo.Location = new Point(x, y);
    }
    public void BtnYesSize(int width, int height)
    {
        this.btnYes.Size = new Size(width, height);
    }
    public void BtnNoSize(int width, int height)
    {
        this.btnNo.Size = new Size(width, height);
    }



    public void TitleFont(Font font, Color fontColor)
    {
        this.lblTitleMessage.Font = font;
        this.lblTitleMessage.ForeColor = fontColor;
    }
    public void MainMessageFont(Font font, Color fontColor)
    {
        this.lblMainMessage.Font = font;
        this.lblMainMessage.ForeColor = fontColor;
    }
    public void YesNoFont(Font font, Color fontColor)
    {
        this.btnYes.Font = font;
        this.btnYes.ForeColor = fontColor;

        this.btnNo.ForeColor = fontColor;
        this.btnNo.Font = font;
    }



    private void On_exit(object? sender, EventArgs e)
    {
        this.Visible = false;
        this.Dispose();
        this.Close();
    }
}