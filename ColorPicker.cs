using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
  public partial class ColorPicker : Form {
    FloatingColor color;

    public ColorPicker() {
      InitializeComponent();

      color = FloatingColor.Rgb(0, 0, 0);
    }

    public Color Color {
      get {
        return color.ToColor();
      }
      set {
        color = FloatingColor.Color(value);
        color.OnChange += new FloatingColor.OnChangeEvent(color_OnChange);
        Preview.Color = color;
        Bar.Color = color;
        Pane.Color = color;
        UpdateFields();
      }
    }

    void color_OnChange() {
      UpdateFields();
    }

    #region Radio Buttons

    void RadioHType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Hud;
    }

    void RadioSType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Saturation;
    }

    void RadioVType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Value;
    }

    void RadioRType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Red;
    }

    void RadioGType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Green;
    }

    void RadioBType_CheckedChanged(object sender, EventArgs e) {
      Pane.Type = Bar.Type = RenderType.Blue;
    }

    #endregion

    void UpdateFields() {
      TxtHud.Text = Math.Round(color.H).ToString();
      TxtSaturation.Text = Math.Round(color.S * 100.0).ToString();
      TxtValue.Text = Math.Round(color.V * 100.0).ToString();
      TxtRed.Text = Math.Round(color.R * 255.0).ToString();
      TxtGreen.Text = Math.Round(color.G * 255.0).ToString();
      TxtBlue.Text = Math.Round(color.B * 255.0).ToString();
      TxtHex.Text = color.ToString();
    }

    void TxtHud_TextChanged(object sender, EventArgs e) {
      if(TxtHud.Focused) {
        try {
          if(Math.Round(color.H) != int.Parse(TxtHud.Text)) color.H = int.Parse(TxtHud.Text);
        } catch { }
      }
    }

    void TxtHud_KeyDown(object sender, KeyEventArgs e) {
      try {
        color.H = getValue(TxtHud.Text, e);
      } catch { }
    }

    void TxtSaturation_TextChanged(object sender, EventArgs e) {
      if(TxtSaturation.Focused) {
        try {
          if(Math.Round(color.S * 100.0) != int.Parse(TxtSaturation.Text)) {
            color.S = int.Parse(TxtSaturation.Text) / 100.0;
          }
        } catch { }
      }
    }

    void TxtSaturation_KeyDown(object sender, KeyEventArgs e) {

      try {
        color.S = getValue(TxtSaturation.Text, e) / 100.0;
      } catch { }
    }

    void TxtValue_TextChanged(object sender, EventArgs e) {
      if(TxtValue.Focused) {
        try {
          if(Math.Round(color.V * 100.0) != int.Parse(TxtValue.Text)) {
            color.V = int.Parse(TxtValue.Text) / 100.0;
          }
        } catch { }
      }
    }

    void TxtValue_KeyDown(object sender, KeyEventArgs e) {
      try {
        color.V = getValue(TxtValue.Text, e) / 100.0;
      } catch { }
    }

    void TxtRed_TextChanged(object sender, EventArgs e) {
      if(TxtRed.Focused) {
        try {
          if(Math.Round(color.R * 255.0) != int.Parse(TxtRed.Text)) {
            color.R = int.Parse(TxtRed.Text) / 255.0;
          }
        } catch { }
      }
    }

    void TxtRed_KeyDown(object sender, KeyEventArgs e) {
      try {
        color.R = getValue(TxtRed.Text, e) / 255.0;
      } catch { }
    }

    void TxtGreen_TextChanged(object sender, EventArgs e) {
      if(TxtGreen.Focused) {
        try {
          if(Math.Round(color.G * 255.0) != int.Parse(TxtGreen.Text)) {
            color.G = int.Parse(TxtGreen.Text) / 255.0;
          }
        } catch { }
      }
    }

    void TxtGreen_KeyDown(object sender, KeyEventArgs e) {
      try {
        color.G = getValue(TxtGreen.Text, e) / 255.0;
      } catch {
      }
    }

    void TxtBlue_TextChanged(object sender, EventArgs e) {
      if(TxtBlue.Focused) {
        try {
          if(Math.Round(color.B * 255.0) != int.Parse(TxtBlue.Text)) {
            color.B = int.Parse(TxtBlue.Text) / 255.0;
          }
        } catch { }
      }
    }

    void TxtBlue_KeyDown(object sender, KeyEventArgs e) {
      try {
        color.B = getValue(TxtBlue.Text, e) / 255.0;
      } catch { }
    }

    void TxtHex_TextChanged(object sender, EventArgs e) {
      if(TxtHex.Focused) {
        FloatingColor color = FloatingColor.FromString(TxtHex.Text);
        if(color != null) {
          this.color.R = color.R;
          this.color.G = color.G;
          this.color.B = color.B;
        }
      }
    }

    int getValue(string str, KeyEventArgs e) {
      int value = 0;
      switch(e.KeyCode) {
        case Keys.Up: {
          value = int.Parse(str) + 1;
        } break;
        case Keys.Down: {
          value = int.Parse(str) - 1;
        } break;
        default: throw new Exception();
      }
      return value;
    }

    void button1_Click(object sender, EventArgs e) {
      Clipboard.SetText(color.ToString());
      this.Close();
    }
  }
}
