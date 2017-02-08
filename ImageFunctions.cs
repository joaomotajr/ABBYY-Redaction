using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Sample
{
    public static class ImageFunctions
    {
        public static Bitmap RotateImage(Image bmp, double angle)
        {
            var g = default(Graphics);
            var tmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppRgb);

            tmp.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            g = Graphics.FromImage(tmp);
            try
            {
                g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
                g.RotateTransform((float) angle);
                g.DrawImage(bmp, 0, 0);
            }
            finally
            {
                g.Dispose();
            }
            return tmp;
        }
    }


}
