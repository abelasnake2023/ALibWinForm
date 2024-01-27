namespace ALibWinForms.Ui.Photo;



using System;
using System.Diagnostics;
using System.IO;



public class PhotoConverter
{
    public static byte[] ConvertImageFileToByteArray(string filePath)
    {
        try
        {
            byte[] fileBytes = File.ReadAllBytes(filePath.Trim());
            return fileBytes;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error converting photo to byte array: " + ex.Message);
            return null;
        }
    }
    public static Image ConvertByteArrayToImage(byte[] byteArray)
    {
        try
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                Image photo = Image.FromStream(stream);
                return photo;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting byte array to photo: " + ex.Message);
            return null;
        }
    }
    public static byte[] ConvertImageToByteArray(Image image)
    {
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error converting photo to byte array: " + ex.Message);
            return null;
        }
    }
}