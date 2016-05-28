using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MemoryHandling
{
    public class BitmapEditor : IDisposable
    {
        private bool _isDisposed;

        private readonly Bitmap _bitmap;

        public BitmapEditor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            var bitmapData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.ReadWrite, _bitmap.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;

            int bytes = Math.Abs(bitmapData.Stride) * _bitmap.Height;

            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            SetPixelColor(x, y, r, g, b, rgbValues);

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            _bitmap.UnlockBits(bitmapData);
        }

        private void SetPixelColor(int x, int y, byte r, byte g, byte b, byte[] rgbValues)
        {
            var pixelIndex = 3 * (_bitmap.Width * x + y);

            rgbValues[pixelIndex] = r;
            rgbValues[pixelIndex + 1] = g;
            rgbValues[pixelIndex + 2] = b;
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

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (_isDisposed)
            {
                return;
            }

            if (fromDisposeMethod)
            {
                _bitmap.Dispose();
            }

            _isDisposed = true;
        }
    }
}