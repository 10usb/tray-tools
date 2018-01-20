using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
  public partial class ImageViewer : Form {
    Timer timer;
    Image background;
    Bitmap image;
    Rectangle rect;
    Rectangle screen;
    double zoom;
    Point offset;

    State state;
    Point originalMouse;
    Point originaloffset;
    Point picker;


    Font font;
    Brush shadow;
    Pen line;

    bool busy;
    ImageCreator source;
    ImageCreator imagePixelated;

    public ImageViewer(Bitmap image, Image background = null) {
      InitializeComponent();
      this.image = image;
      this.background = background;

      this.state = State.Idle;
      this.zoom = 1.0;


      font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
      shadow = new SolidBrush(Color.FromArgb(128, Color.Black));
      line = new Pen(new SolidBrush(Color.Red), 1);

      timer = new Timer();
      timer.Interval = 40;
      timer.Tick += new EventHandler(timer_Tick);
      timer.Enabled = true;

      this.busy = false;
      this.imagePixelated = null;
      this.source = null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ImageViewer_Load(object sender, EventArgs e) {
      new System.Threading.Thread(new System.Threading.ThreadStart(delegate() {
        ImageContext ic = new ImageContext(image.Width, image.Height, image);
        ImageCreator source = new ImageCreator(image.Width, image.Height);
        ic.Lock();
        for(int y=0; y < image.Height; y++) {
          for(int x=0; x < image.Width; x++) {
            source.SetPixel(x, y, ic.GetPixel(x, y));
          }
        }
        ic.Unlock();
        lock(this) {
          this.source = source;
        }
      })).Start();
    }

    /// <summary>
    /// 
    /// </summary>
    void buildImage() {
      if(busy) return;
      if(imagePixelated!=null && (imagePixelated.Width == rect.Width && imagePixelated.Height == rect.Height)) return;

      imagePixelated = null;
      this.Invalidate();

      new System.Threading.Thread(new System.Threading.ThreadStart(delegate() {
        ImageCreator newImage = new ImageCreator(rect.Width, rect.Height);
        for(int y=0; y < newImage.Height; y++) {
          for(int x=0; x < newImage.Width; x++) {
            double sx = x / (double)newImage.Width;
            double sy = y / (double)newImage.Height;

            sx *= source.Width;
            sy *= source.Height;

            sx = Math.Max(0, sx);
            sy = Math.Max(0, sy);

            sx = Math.Min(sx, source.Width - 1);
            sy = Math.Min(sy, source.Height - 1);

            newImage.SetPixel(x, y, source.GetPixel((int)sx, (int)sy));
          }
        }
        if(newImage.Width==rect.Width && newImage.Height==rect.Height){
          // Create image
          Image tmp = newImage.Image;

          lock(this) {
            imagePixelated = newImage;
          }
          this.Invalidate();
        }else{
          busy = false;
          buildImage();
        }
      })).Start();

    }

    /// <summary>
    /// 
    /// </summary>
    void makeRect() {
      bool imageReady = false;
      lock(this) {
        if(source != null) {
          imageReady = true;
        }
      }
      if(imageReady && !screen.IsEmpty) {
        int width  = (int)Math.Round(image.Width * zoom);
        int height = (int)Math.Round(image.Height * zoom);
        int x = screen.Width / 2;
        int y = screen.Height / 2;
        x += offset.X;
        y += offset.Y;

        rect = new Rectangle(x - width / 2, y - height / 2, width, height);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void timer_Tick(object sender, EventArgs e) {
      bool imageReady = false;
      lock(this) {
        if(source != null) {
          imageReady = true;
        }
      }
      if(imageReady) {
        makeRect();
        this.Invalidate();
        timer.Enabled = false;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_Paint(object sender, PaintEventArgs e) {
      if(screen.IsEmpty) {
        screen = e.ClipRectangle;
        makeRect();
      }

      e.Graphics.DrawImage(background, screen);
      e.Graphics.FillRectangle(shadow, screen);

      bool imageReady = false;
      bool pixelatedReady = false;
      lock(this) {
        if(source != null) {
          imageReady = true;
        }
        if(imagePixelated != null) {
          pixelatedReady = true;
        }
      }
      if(pixelatedReady) {
        e.Graphics.DrawImage(imagePixelated.Image, rect);
      } else if(imageReady) {
        e.Graphics.DrawImage(image, rect);
      }


      double x = Math.Floor(picker.X / zoom);
      double y = Math.Floor(picker.Y / zoom);

      Rectangle lineR = new Rectangle();
      lineR.X = (int)Math.Floor(x * zoom);
      lineR.Y = (int)Math.Floor(y * zoom);
      lineR.Width = (int)Math.Round(zoom);
      lineR.Height = (int)Math.Round(zoom);

      lineR.X+= rect.X;
      lineR.Y += rect.Y;

      e.Graphics.DrawRectangle(line, lineR);


      string message = string.Format("{0}%", (int)(zoom * 100));

      SizeF size = e.Graphics.MeasureString(message, font, new PointF(), StringFormat.GenericTypographic);

      e.Graphics.FillRectangle(shadow, new Rectangle(0, 0, (int)(size.Width + 24), (int)(size.Height + 18)));
      e.Graphics.DrawString(message, font, new SolidBrush(Color.Black), new Point(11, 9));
      e.Graphics.DrawString(message, font, new SolidBrush(Color.Red), new Point(10, 8));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e) {
      double direction = Math.Round(e.Delta / 120.0);

      if(direction < 0 ? zoom <= 1 : zoom < 1) {
        zoom = Math.Round(Math.Max(0.1, Math.Min(1, zoom + (zoom * 0.15 * direction))), 2);
      } else {
        zoom = Math.Round(Math.Max(1, Math.Min(32, zoom + (zoom * 0.15 * direction))), 2);
      }

      timer.Enabled = true;
      buildImage();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_MouseDown(object sender, MouseEventArgs e) {
      state = State.Picking;
      originalMouse = e.Location;
      originaloffset = offset;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_MouseMove(object sender, MouseEventArgs e) {
      if(state == State.Picking) state = State.Moving;
      if(state == State.Moving) {
        offset.X = originaloffset.X + (e.X - originalMouse.X);
        offset.Y = originaloffset.Y + (e.Y - originalMouse.Y);
        timer.Enabled = true;
      }
      picker.X = e.X - rect.X;
      picker.Y = e.Y - rect.Y;
      timer.Enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_MouseUp(object sender, MouseEventArgs e) {
      if(state == State.Moving) {
        offset.X = originaloffset.X + (e.X - originalMouse.X);
        offset.Y = originaloffset.Y + (e.Y - originalMouse.Y);
        state = State.Idle;
        timer.Enabled = true;
      } else if(state == State.Picking) {
        Color color = imagePixelated.GetPixel(e.X - rect.X, e.Y - rect.Y);

        ColorPicker cp = new ColorPicker();
        cp.Color = color;
        cp.Show();
        cp.Focus();

        this.Close();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Eyedropper_KeyDown(object sender, KeyEventArgs e) {
      switch(e.KeyData) {
        case Keys.X: {
          this.Close();
        } break;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum State {
      Idle,
      Picking,
      Moving,
    }
  }
}
