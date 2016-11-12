using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Lab6
{
    class BitmapEditor : IDisposable
    {
        private Bitmap bitmap;
        private BitmapData bitmapData;

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;

            Rectangle rectangle = new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height);

            bitmapData = this.bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    bitmap.UnlockBits(bitmapData);
                }

                disposedValue = true;
            }
        }

        ~BitmapEditor()
        {
            Dispose(false);
        }

        public void Dispose()
        {   
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void SetPixel(int x, int y, byte red, byte green, byte blue)
        {
            int offset = 3 * x + y * bitmapData.Stride;
            IntPtr ptr = IntPtr.Add(bitmapData.Scan0, offset);

            Marshal.Copy(new[] { blue, green, red }, 0, ptr, 3);
        }

        public Color GetPixel(int x, int y)
        {
            int offset = 3 * x + y * bitmapData.Stride;
            IntPtr ptr = IntPtr.Add(bitmapData.Scan0, offset);

            byte[] buffer = new byte[3];

            Marshal.Copy(ptr, buffer, 0, 3);

            return Color.FromArgb(buffer[2], buffer[1], buffer[0]);
        }
    }
}
