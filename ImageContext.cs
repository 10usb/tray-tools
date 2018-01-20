using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace TrayTools {
  class ImageContext {
    Bitmap bitmap;
    int width, height;
    BitmapData bmData;
    IntPtr ptr;
    byte[] data;

    public ImageContext(int width, int height, Bitmap bitmap=null) {
      this.width = width;
      this.height = height;
      this.bitmap = bitmap!=null ? bitmap : new Bitmap(width, height, PixelFormat.Format32bppArgb);
      data = null;
    }

    public void Lock() {
      Rectangle rect = new Rectangle(0, 0, width, height);
      bmData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
      ptr = bmData.Scan0;
      if(data == null) {
        data = new byte[Math.Abs(bmData.Stride) * height];
      }
      Marshal.Copy(ptr, data, 0, data.Length);
    }

    public void Unlock() {
      Marshal.Copy(data, 0, ptr, data.Length);
      bitmap.UnlockBits(bmData);
    }

    public void SetPixel(int x, int y, Color color) {
      x = Math.Max(0, Math.Min(width, x));
      y = Math.Max(0, Math.Min(height, y));
      int index = (y * width + x) * 4;
      data[index + 0] = color.B;
      data[index + 1] = color.G;
      data[index + 2] = color.R;
      data[index + 3] = color.A;
    }

    public Color GetPixel(int x, int y) {
      x = Math.Max(0, Math.Min(width, x));
      y = Math.Max(0, Math.Min(height, y));
      int index = (y * width + x) * 4;
      return Color.FromArgb(data[index + 3], data[index + 2], data[index + 1], data[index + 0]);
    }

    public Image Image {
      get {
        return bitmap;
      }
    }
  }
}
