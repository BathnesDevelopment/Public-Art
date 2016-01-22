using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging;

namespace PublicArt.Util
{
    public static class Thumbnailer
    {
        public static Task<byte[]> CreateThumbAsync(byte[] imageBytes, int maxWidth)
        {
            const int quality = 70;
            var size = new System.Drawing.Size(maxWidth, 0);

            var task = Task<byte[]>.Factory.StartNew(() =>
            {
                using (var inStream = new MemoryStream(imageBytes))
                using (var outStream = new MemoryStream())
                using (var imageFactory = new ImageFactory())
                {
                    imageFactory.Load(inStream)
                        .Resize(new ResizeLayer(size, ResizeMode.Max, upscale: false))
                        .Quality(quality)
                        .Save(outStream);

                    return outStream.ToArray();
                }
            });

            return task;
        }

    }
}
