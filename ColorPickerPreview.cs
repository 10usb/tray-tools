using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrayTools {
  public partial class ColorPickerPreview : UserControl {
    Pen borderPen;
    Brush original;
    Brush current;
    FloatingColor color;

    public ColorPickerPreview() {
      InitializeComponent();
      borderPen = new Pen(System.Drawing.Color.FromArgb(113, 122, 138));
      original = new SolidBrush(System.Drawing.Color.Red);
      current = new SolidBrush(System.Drawing.Color.Blue);
    }

    public FloatingColor Color {
      get {
        return color;
      }
      set {
        color = value;
        if(color != null) {
          current = new SolidBrush(color.ToColor());
          original = new SolidBrush(color.ToColor());
          color.OnChange += new FloatingColor.OnChangeEvent(color_OnChange);
        }
      }
    }

    void color_OnChange() {
      current = new SolidBrush(color.ToColor());
      this.Invalidate();
    }

    void ColorPickerPreview_Paint(object sender, PaintEventArgs e) {
      Rectangle borderRect = e.ClipRectangle;
      borderRect.Width--;
      borderRect.Height--;
      e.Graphics.DrawRectangle(borderPen, borderRect);

      Rectangle rect = e.ClipRectangle;
      rect.X++;
      rect.Y++;
      rect.Width -= 2;
      rect.Height -= 2;
      rect.Height /= 2;
      e.Graphics.FillRectangle(current, rect);

      rect.Y += rect.Height;
      rect.Height = e.ClipRectangle.Height - 2 - rect.Height;
      e.Graphics.FillRectangle(original, rect);
    }
  }
}
