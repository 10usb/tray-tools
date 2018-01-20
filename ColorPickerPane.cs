using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
  public partial class ColorPickerPane : UserControl {
    ImageContext image;
    Pen borderPen;
    RenderType type;
    FloatingColor color;
    Timer timer;
    int xValue, yValue;
    State state;

    public ColorPickerPane() {
      InitializeComponent();
      image = new ImageContext(256, 256);
      borderPen = new Pen(System.Drawing.Color.FromArgb(113, 122, 138));

      type = RenderType.Hud;
      color = null;

      xValue = 0;
      yValue = 0;

      timer = new Timer();
      timer.Interval = 40;
      timer.Tick += new EventHandler(timer_Tick);
    }

    public FloatingColor Color {
      get {
        return color;
      }
      set {
        color = value;
        UpdateImage();

        if(color != null) {
          color.OnChange += new FloatingColor.OnChangeEvent(color_OnChange);
        }
      }
    }

    void color_OnChange() {
      timer.Enabled = true;
    }

    void timer_Tick(object sender, EventArgs e) {
      UpdateImage();
      timer.Enabled = false;
    }

    public RenderType Type {
      get {
        return type;
      }
      set {
        type = value;
        UpdateImage();
      }
    }

    void ColorPickerPane_Paint(object sender, PaintEventArgs e) {
      Rectangle drawRect = e.ClipRectangle;
      drawRect.X++;
      drawRect.Y++;
      drawRect.Width -= 2;
      drawRect.Height -= 2;
      e.Graphics.DrawImage(image.Image, drawRect);

      Rectangle point = new Rectangle(0, 0, 15, 15);
      point.X = (int)Math.Round((xValue / 255.0) * (e.ClipRectangle.Width - 2)) - 7;
      point.Y = (int)Math.Round((yValue / 255.0) * (e.ClipRectangle.Height - 2)) - 7;
      e.Graphics.DrawImage(Properties.Resources.Pointer, point);

      Rectangle borderRect = e.ClipRectangle;
      borderRect.Width--;
      borderRect.Height--;
      e.Graphics.DrawRectangle(borderPen, borderRect);
    }

    void ColorPickerPane_Load(object sender, EventArgs e) {
      UpdateImage();
    }

    void UpdateImage() {
      if(color != null) {
        switch(type) {
          case RenderType.Red: {
            SetValue((int)Math.Round(color.B * 255.0), (int)Math.Round(255.0 - color.G * 255.0));
          } break;
          case RenderType.Green: {
            SetValue((int)Math.Round(color.B * 255.0), (int)Math.Round(255.0 - color.R * 255.0));
          } break;
          case RenderType.Blue: {
            SetValue((int)Math.Round(color.R * 255.0), (int)Math.Round(255.0 - color.G * 255.0));
          } break;
          case RenderType.Hud: {
            SetValue((int)Math.Round(color.S * 255.0), (int)Math.Round(255.0 - color.V * 255.0));
          } break;
          case RenderType.Saturation: {
            SetValue((int)Math.Round(color.H * 255.0 / 360.0), (int)Math.Round(255.0 - color.V * 255.0));
          } break;
          case RenderType.Value: {
            SetValue((int)Math.Round(color.H * 255.0 / 360.0), (int)Math.Round(255.0 - color.S * 255.0));
          } break;
        }

        image.Lock();
        switch(type) {
          case RenderType.Red: MakeRed(); break;
          case RenderType.Green: MakeGreen(); break;
          case RenderType.Blue: MakeBlue(); break;
          case RenderType.Hud: MakeHud(); break;
          case RenderType.Saturation: MakeSat(); break;
          case RenderType.Value: MakeValue(); break;
        }
        image.Unlock();
      }
      this.Invalidate();
    }

    #region Image Creation

    void MakeRed() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          image.SetPixel(x, y, System.Drawing.Color.FromArgb((int)Math.Round(color.R * 255), 255 - y, x));
        }
      }
    }

    void MakeGreen() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          image.SetPixel(x, y, System.Drawing.Color.FromArgb(255 - y, (int)Math.Round(color.G * 255), x));
        }
      }
    }

    void MakeBlue() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          image.SetPixel(x, y, System.Drawing.Color.FromArgb(x, 255 - y, (int)Math.Round(color.B * 255)));
        }
      }
    }

    void MakeHud() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          FloatingColor c = FloatingColor.Hsv(color.H, x / 255.0, 1.0 - y / 255.0);
          image.SetPixel(x, y, c.ToColor());
        }
      }
    }

    void MakeSat() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          FloatingColor c = FloatingColor.Hsv(Math.Floor(x / 255.0 * 360.0), color.S, 1.0 - y / 255.0);
          image.SetPixel(x, y, c.ToColor());
        }
      }
    }

    void MakeValue() {
      for(int y=0; y < 256; y++) {
        for(int x=0; x < 256; x++) {
          FloatingColor c = FloatingColor.Hsv(Math.Floor(x / 255.0 * 360.0), 1.0 - y / 255.0, color.V);
          image.SetPixel(x, y, c.ToColor());
        }
      }
    }

    #endregion

    void SetValue(int x, int y, bool mutate = false) {
      this.xValue = Math.Max(0, Math.Min(255, x));
      this.yValue = Math.Max(0, Math.Min(255, y));

      if(mutate) {
        switch(type) {
          case RenderType.Red: {
            color.B = this.xValue / 255.0;
            color.G = 1.0 - this.yValue / 255.0;
          } break;
          case RenderType.Green: {
            color.B = this.xValue / 255.0;
            color.R = 1.0 - this.yValue / 255.0;
          } break;
          case RenderType.Blue: {
            color.R = this.xValue / 255.0;
            color.G = 1.0 - this.yValue / 255.0;
          } break;
          case RenderType.Hud: {
            color.S = this.xValue / 255.0;
            color.V = 1.0 - this.yValue / 255.0;
          } break;
          case RenderType.Saturation: {
            color.H = this.xValue / 255.0 * 360;
            color.V = 1.0 - this.yValue / 255.0;
          } break;
          case RenderType.Value: {
            color.H = this.xValue / 255.0 * 360;
            color.S = 1.0 - this.yValue / 255.0;
          } break;
        }
      }

      this.Invalidate();
    }

    enum State {
      Idle,
      Draging,
    }

    void ColorPickerPane_MouseDown(object sender, MouseEventArgs e) {
      state = State.Draging;
    }

    void ColorPickerPane_MouseMove(object sender, MouseEventArgs e) {
      if(state == State.Draging) {
        SetValue((int)Math.Round((((double)e.X - 1) / (this.Width - (2) - 1)) * 255), (int)Math.Round((((double)e.Y - 1) / (this.Height - (2) - 1)) * 255), true);
      }
    }

    void ColorPickerPane_MouseUp(object sender, MouseEventArgs e) {
      if(state == State.Draging) {
        SetValue((int)Math.Round((((double)e.X - 1) / (this.Width - (2) - 1)) * 255), (int)Math.Round((((double)e.Y - 1) / (this.Height - (2) - 1)) * 255), true);
      }
      state = State.Idle;
    }
  }
}
