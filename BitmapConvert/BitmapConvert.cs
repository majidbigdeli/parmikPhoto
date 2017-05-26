using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Parmik.CS.Core.Image
{
    public class BitmapConvert
    {
        public static Bitmap GetImage(string base64)
        {
            var bytes = System.Convert.FromBase64String(base64);
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap bitmap1 = (Bitmap)tc.ConvertFrom(bytes);
            return bitmap1;
        }
        public static string ToBase64(System.Drawing.Image bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            var bitmapData = ms.ToArray();
            var photobase64 = System.Convert.ToBase64String(bitmapData);

            return photobase64;
        }



        public static Stream ToStream(System.Drawing.Image bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            return ms;

        }


    }
}
