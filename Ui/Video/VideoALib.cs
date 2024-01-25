namespace ALibWinForms.Ui.Video;

using LibVLCSharp.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;



public class VideoALib : VideoView
{
    private int cornerRadius = 10; // Adjust this value based on your preference

    public int CornerRadius
    {
        get { return cornerRadius; }
        set
        {
            cornerRadius = value;
            Invalidate(); // Trigger a redraw when the corner radius is changed
        }
    }

    protected override void OnPaint(PaintEventArgs e) //Polymorphism
    {
        GraphicsPath path = new GraphicsPath();
        Rectangle rect = new Rectangle(0, 0, Width, Height);

        // Add rounded rectangle to the graphics path
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90);
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90);
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90);
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90);
        path.CloseAllFigures();

        // Set the clipping region to the rounded rectangle
        e.Graphics.SetClip(path);

        base.OnPaint(e);

        // Reset the clipping region
        e.Graphics.ResetClip();
    }
}