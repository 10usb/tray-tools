using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace TrayTools {
  public class ImageCreator {
    int width, height;
    byte[] data;
    bool changed;
    Image cache;

    public ImageCreator(int width, int height){
      this.width = width;
      this.height = height;
      MemoryStream ms = new MemoryStream();
      new Bitmap(width, height, PixelFormat.Format32bppArgb).Save(ms, ImageFormat.Bmp);
      data = ms.GetBuffer();
    }

    public void SetPixel(int x, int y, Color color) {
      x = Math.Max(0, Math.Min(width-1, x));
      y = (height-1)-Math.Max(0, Math.Min(height-1, y));
      int index = 54 + ((y * width + x) * 4);
      data[index + 0] = color.B;
      data[index + 1] = color.G;
      data[index + 2] = color.R;
      data[index + 3] = color.A;
      changed = true;
    }

    public Color GetPixel(int x, int y) {
      x = Math.Max(0, Math.Min(width - 1, x));
      y = (height - 1) - Math.Max(0, Math.Min(height - 1, y));
      int index = 54 + ((y * width + x) * 4);
      return Color.FromArgb(data[index + 3], data[index + 2], data[index + 1], data[index + 0]);
    }

    public Image Image {
      get {
        if(changed){
          MemoryStream ms = new MemoryStream(data);
          cache = new Bitmap(ms);
          changed = false;
        }
        return cache;
      }
    }

    public int Width {
      get {
        return width;
      }
    }

    public int Height {
      get {
        return height;
      }
    }
  }
}
