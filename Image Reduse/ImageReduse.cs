using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace PamikPhoto.Image_Reduse
{
    public static class ImageReduse
    {

      public static void compress(Image img, string path)
        {
            try
            {
                EncoderParameter qualityParam =
              new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 60);
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;

                img.Save(path, jpegCodec, encoderParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }


    }
}
