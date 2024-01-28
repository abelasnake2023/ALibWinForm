using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace ALibWinForms.Ui;



public static class ScreenProp
{
    private static float HoriScreenDpi()
    {
        float ppiX = 0;

        using (Graphics graphics = Graphics.FromHwnd(nint.Zero))  // IntPtr.Zero represents the primary screen
        {
            ppiX = graphics.DpiX;
        }

        return ppiX;
    }
    private static float VertScreenDpi()
    {
        float ppiY = 0;

        using (Graphics graphics = Graphics.FromHwnd(nint.Zero))  // IntPtr.Zero represents the primary screen
        {
            ppiY = graphics.DpiY;
        }

        return ppiY;
    }
    public static float HorAmountOfPixelPerCenti()
    {
        float horiPixelPerCenti = 0;

        horiPixelPerCenti = HoriScreenDpi() / 2.54f;

        return horiPixelPerCenti;
    }
    public static float VerAmountOfPixelPerCenti()
    {
        float vertPixelPerCenti = 0;

        vertPixelPerCenti = VertScreenDpi() / 2.54f;

        return vertPixelPerCenti;
    }
    public static float HoriCenti(float horPixel)
    {
        float horPixelPerCenti = HorAmountOfPixelPerCenti();

        return horPixel / horPixelPerCenti;
    }
    public static float VertCenti(float verPixel)
    {
        float verPixelPerCenti = VerAmountOfPixelPerCenti();

        return verPixel / verPixelPerCenti;
    }
}