namespace ALibWinForms.Ui.Video;



using System;
using System.Diagnostics;



public class VideoConverter
{
    public static string ConvertByteArrayToVideoFile(byte[] videoBytes)
    {
        string filePath = "";

        try
        {
            filePath = Path.GetTempFileName();
            File.WriteAllBytes(filePath, videoBytes);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error converting video from byte array to Video File(temp file)!");
            return null;
        }

        return filePath.Trim();
    }
    public static byte[] ConvertVideoToByteArray(string filePath)
    {
        filePath = filePath.Trim();

        try
        {
            byte[] videoBytes = File.ReadAllBytes(filePath);
            return videoBytes;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting video to byte array!");
            return null;
        }
    }
}