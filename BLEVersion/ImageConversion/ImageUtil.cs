using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace com.gravicode.neospectralib.ImageConversion
{
    public class ImageUtil
    {
        public static Bitmap convert(string base64Str)
        {
            byte[] decodedBytes = Convert.FromBase64String(
                base64Str.Substring(base64Str.IndexOf(",") + 1));

            using (MemoryStream ms = new MemoryStream(decodedBytes))
            {
                return new Bitmap(ms);
            }
        }

        public static string convert(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                return "data:image/png;base64," + Convert.ToBase64String(imageBytes);
            }
        }
    }
}
