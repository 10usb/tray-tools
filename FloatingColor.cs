using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TrayTools {
  public class FloatingColor {
    double r, g, b;
    double h, s, v;
    bool hsv, rgb;

    public delegate void OnChangeEvent();

    public event OnChangeEvent OnChange;

    private FloatingColor() { hsv = false; rgb = false; }

    #region Properties

    /// <summary>
    /// Red color
    /// </summary>
    public double R {
      get {
        if(!rgb) __makeRGB();
        return r;
      }
      set {
        if(!rgb) __makeRGB();
        hsv = false;
        r = Math.Max(0.0, Math.Min(1.0, value));
        if(OnChange != null) OnChange();
      }
    }

    /// <summary>
    /// Green color
    /// </summary>
    public double G {
      get {
        if(!rgb) __makeRGB();
        return g;
      }
      set {
        if(!rgb) __makeRGB();
        hsv = false;
        g = Math.Max(0.0, Math.Min(1.0, value));
        if(OnChange != null) OnChange();
      }
    }

    /// <summary>
    /// Blue color
    /// </summary>
    public double B {
      get {
        if(!rgb) __makeRGB();
        return b;
      }
      set {
        if(!rgb) __makeRGB();
        hsv = false;
        b = Math.Max(0.0, Math.Min(1.0, value));
        if(OnChange != null) OnChange();
      }
    }

    /// <summary>
    /// Hud
    /// </summary>
    public double H {
      get {
        if(!hsv) __makeHSV();
        return h;
      }
      set {
        if(!hsv) __makeHSV();
        rgb = false;
        h = value;
        while(h < 0.0) h += 360.0;
        while(h > 360.0) h -= 360.0;
        if(OnChange != null) OnChange();
      }
    }

    /// <summary>
    /// Saturation
    /// </summary>
    public double S {
      get {
        if(!hsv) __makeHSV();
        return s;
      }
      set {
        if(!hsv) __makeHSV();
        rgb = false;
        s = Math.Max(0.0, Math.Min(1.0, value));
        if(OnChange != null) OnChange();
      }
    }

    /// <summary>
    /// Value
    /// </summary>
    public double V {
      get {
        if(!hsv) __makeHSV();
        return v;
      }
      set {
        if(!hsv) __makeHSV();
        rgb = false;
        v = Math.Max(0.0, Math.Min(1.0, value));
        if(OnChange != null) OnChange();
      }
    }

    #endregion

    #region Conversion

    public Color ToColor() {
      return System.Drawing.Color.FromArgb((int)Math.Round(R * 255), (int)Math.Round(G * 255), (int)Math.Round(B * 255));
    }

    public override string ToString() {
      return string.Format("{0:X2}{1:X2}{2:X2}", (int)Math.Round(R * 255), (int)Math.Round(G * 255), (int)Math.Round(B * 255));
    }

    public static FloatingColor FromString(string text) {
      Match match = Regex.Match(text.ToLower(), "^(\\#|0x)?(([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2}))|(([0-9a-f]{1})([0-9a-f]{1})([0-9a-f]{1}))$");

      if(match.Success) {
        int r, g, b;
        if(match.Groups[2].Length > 0) {
          r = int.Parse(match.Groups[3].Value, NumberStyles.AllowHexSpecifier);
          g = int.Parse(match.Groups[4].Value, NumberStyles.AllowHexSpecifier);
          b = int.Parse(match.Groups[5].Value, NumberStyles.AllowHexSpecifier);
        } else {
          r = int.Parse(match.Groups[7].Value + match.Groups[7].Value, NumberStyles.AllowHexSpecifier);
          g = int.Parse(match.Groups[8].Value + match.Groups[8].Value, NumberStyles.AllowHexSpecifier);
          b = int.Parse(match.Groups[9].Value + match.Groups[9].Value, NumberStyles.AllowHexSpecifier);
        }
        return Rgb(r, g, b);
      } else {
        Color color = System.Drawing.Color.FromName(text);
        if(color.A > 0) {
          return Rgb((int)color.R, (int)color.G, (int)color.B);
        }
      }

      return null;
    }

    #endregion

    #region Constructors

    public static FloatingColor Hsv(double h, double s, double v) {
      FloatingColor color = new FloatingColor();
      color.h = Math.Max(0.0, Math.Min(360.0, h));
      color.s = Math.Max(0.0, Math.Min(1.0, s));
      color.v = Math.Max(0.0, Math.Min(1.0, v));
      color.hsv = true;
      return color;
    }

    public static FloatingColor Rgb(int r, int g, int b) {
      return Rgb(r / 255.0, g / 255.0, b / 255.0);
    }

    public static FloatingColor Rgb(double r, double g, double b) {
      FloatingColor color = new FloatingColor();
      color.r = Math.Max(0.0, Math.Min(1.0, r));
      color.g = Math.Max(0.0, Math.Min(1.0, g));
      color.b = Math.Max(0.0, Math.Min(1.0, b));
      color.rgb = true;
      return color;
    }

    public static FloatingColor Color(Color c) {
      return Rgb(c.R / 255.0, c.G / 255.0, c.B / 255.0);
    }

    public FloatingColor Clone() {
      FloatingColor color = new FloatingColor();
      color.r = r;
      color.g = g;
      color.b = b;
      color.h = h;
      color.s = s;
      color.v = v;
      color.rgb = rgb;
      color.hsv = hsv;
      return color;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates the RGB values from the HSV
    /// </summary>
    void __makeRGB() {
      int region = (int)Math.Floor(h / 60.0);

      double f = Math.Abs(((region * 60.0) % 120.0) - (h % 60.0)) / 60.0;
      double l = v * (1 - s); // Lower value
      double q = v * f;
      double m = q + ((v - q) * (1 - s));

      switch(region) {
        case 0: r = v; g = m; b = l; break;
        case 1: r = m; g = v; b = l; break;
        case 2: r = l; g = v; b = m; break;
        case 3: r = l; g = m; b = v; break;
        case 4: r = m; g = l; b = v; break;
        case 5: r = v; g = l; b = m; break;
        case 6: r = v; g = m; b = l; break;
        default: throw new Exception(string.Format("Undefined color region: {0}", region));
      }
      rgb = true;
      if(OnChange != null) OnChange();
    }

    /// <summary>
    /// Creates the HSV values from the RGB
    /// </summary>
    void __makeHSV() {
      v = Math.Max(r, Math.Max(g, b));
      if(v <= 0) {
        s = 0;
        h = 0;
      } else {
        double l = Math.Min(r, Math.Min(g, b));
        double sf = l / v;
        s = 1.0 - sf;

        if(v == r) {
          if(l == g) {
            double ho = b / (1 + sf);
            h = Math.Round(360.0 - 60.0 * ho);
          } else { // l==b
            double ho = g / (1 + sf);
            h = Math.Round(0.0 + 60.0 * ho);
          }
        } else if(v == g) {
          if(l == r) {
            double ho = b / (1 + sf);
            h = Math.Round(120.0 + 60.0 * ho);
          } else { // l==b
            double ho = r / (1 + sf);
            h = Math.Round(120.0 - 60.0 * ho);
          }
        } else {// v==b
          if(l == g) {
            double ho = r / (1 + sf);
            h = Math.Round(240.0 + 60.0 * ho);
          } else { // l==g
            double ho = g / (1 + sf);
            h = Math.Round(240.0 - 60.0 * ho);
          }
        }
      }
      hsv = true;
      if(OnChange != null) OnChange();
    }

    #endregion
  }
}
