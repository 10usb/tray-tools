using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TrayTools {
  public partial class ColorPickerBar : UserControl {
    ImageContext image;
    Pen borderPen;
    int value;
    State state;
    RenderType type;
    FloatingColor color;
    Timer timer;

    const int ARROW_SIZE = 10;
    const int IMAGE_SIZE = 32;
    const int PADDING_TOP = 4;
    const int PADDING_BOTTOM = 4;

    public ColorPickerBar() {
      InitializeComponent();
      image = new ImageContext(IMAGE_SIZE, 256);
      borderPen = new Pen(System.Drawing.Color.FromArgb(113, 122, 138));

      value = 0;
      type = RenderType.Hud;

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

    void ColorPickerBar_Paint(object sender, PaintEventArgs e) {
      Rectangle drawRect = e.ClipRectangle;
      drawRect.X += ARROW_SIZE;
      drawRect.Y += PADDING_TOP;
      drawRect.Width -= ARROW_SIZE * 2;
      drawRect.Height -= PADDING_TOP + PADDING_BOTTOM;
      e.Graphics.DrawImage(image.Image, drawRect);

      drawRect.X -= 1;
      drawRect.Y -= 1;
      drawRect.Width += 1;
      drawRect.Height += 1;
      e.Graphics.DrawRectangle(borderPen, drawRect);

      Rectangle point = new Rectangle(0, 0, 8, 9);
      point.Y = (int)Math.Round((1.0 - value / 255.0) * (e.ClipRectangle.Height - (PADDING_TOP + PADDING_BOTTOM) - 1)) - 4 + PADDING_TOP;

      e.Graphics.DrawImage(Properties.Resources.ArrowLeft, point);

      point.X = e.ClipRectangle.Width - 8;
      e.Graphics.DrawImage(Properties.Resources.ArrowRight, point);
    }

    void ColorPickerBar_Load(object sender, EventArgs e) {
      UpdateImage();
    }

    void ColorPickerBar_MouseDown(object sender, MouseEventArgs e) {
      state = State.Draging;
    }

    void ColorPickerBar_MouseMove(object sender, MouseEventArgs e) {
      if(state == State.Draging) {
        SetValue(255 - (int)Math.Round((((double)e.Y - PADDING_TOP) / (this.Height - (PADDING_TOP + PADDING_BOTTOM) - 1)) * 255), true);
      }
    }

    void ColorPickerBar_MouseUp(object sender, MouseEventArgs e) {
      if(state == State.Draging) {
        SetValue(255 - (int)Math.Round((((double)e.Y - PADDING_TOP) / (this.Height - (PADDING_TOP + PADDING_BOTTOM) - 1)) * 255), true);
      }
      state = State.Idle;
    }

    void SetValue(int value, bool mutate = false) {
      this.value = Math.Max(0, Math.Min(255, value));

      if(mutate) {
        switch(type) {
          case RenderType.Red: color.R = this.value / 255.0; break;
          case RenderType.Green: color.G = this.value / 255.0; break;
          case RenderType.Blue: color.B = this.value / 255.0; break;
          case RenderType.Hud: color.H = this.value / 255.0 * 360.0; break;
          case RenderType.Saturation: color.S = this.value / 255.0; break;
          case RenderType.Value: color.V = this.value / 255.0; break;
        }
      }

      this.Invalidate();
    }

    void SetPixel(int y, Color color) {
      for(int x=0; x < IMAGE_SIZE; x++) {
        image.SetPixel(x, y, color);
      }
    }

    void UpdateImage() {
      if(color != null) {
        image.Lock();
        switch(type) {
          case RenderType.Red: {
            SetValue((int)Math.Round(color.R * 255.0)); MakeRed();
          } break;
          case RenderType.Green: {
            SetValue((int)Math.Round(color.G * 255.0)); MakeGreen();
          } break;
          case RenderType.Blue: {
            SetValue((int)Math.Round(color.B * 255.0)); MakeBlue();
          } break;
          case RenderType.Hud: {
            SetValue((int)Math.Round(color.H / 360.0 * 255.0)); MakeHud();
          } break;
          case RenderType.Saturation: {
            SetValue((int)Math.Round(color.S * 255.0)); MakeSat();
          } break;
          case RenderType.Value: {
            SetValue((int)Math.Round(color.V * 255.0)); MakeValue();
          } break;
        }
        image.Unlock();
      }
      this.Invalidate();
    }

    #region Image Creation

    void MakeRed() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Rgb(1.0 - y / 255.0, color.G, color.B);
        SetPixel(y, c.ToColor());
      }
    }

    void MakeGreen() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Rgb(color.R, 1.0 - y / 255.0, color.B);
        SetPixel(y, c.ToColor());
      }
    }

    void MakeBlue() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Rgb(color.R, color.G, 1.0 - y / 255.0);
        SetPixel(y, c.ToColor());
      }
    }

    void MakeHud() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Hsv(Math.Round((1.0 - y / 255.0) * 360.0), 1.0, 1.0);
        SetPixel(y, c.ToColor());
      }
    }

    void MakeSat() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Hsv(color.H, 1.0 - y / 255.0, color.V);
        SetPixel(y, c.ToColor());
      }
    }

    void MakeValue() {
      for(int y=0; y < 256; y++) {
        FloatingColor c = FloatingColor.Hsv(color.H, color.S, 1.0 - y / 255.0);
        SetPixel(y, c.ToColor());
      }
    }

    #endregion

    enum State {
      Idle,
      Draging,
    }
  }
}
