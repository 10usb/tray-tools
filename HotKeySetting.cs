using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
  public partial class HotKeySetting : UserControl {
    Timer check;
    Hotkey hothey;

    public HotKeySetting() {
      InitializeComponent();

      hothey = null;
      check = new Timer();
      check.Interval = 1000;
      check.Tick += new EventHandler(check_Tick);
      check.Enabled = true;
    }

    public Hotkey Hotkey {
      get {
        return hothey;
      }
      set {
        hothey = value;
        updateInterface();
      }
    }

    void check_Tick(object sender, EventArgs e) {
      updateInterface();
    }

    void updateInterface() {
      if(hothey != null) {
        AltCheckBox.Checked = hothey.Alt;
        ControlCheckBox.Checked = hothey.Control;
        ShiftCheckBox.Checked = hothey.Shift;
        WindowsCheckBox.Checked = hothey.Windows;
        KeyCodeComboBox.SelectedIndex = KeyCodeComboBox.Items.IndexOf(hothey.KeyCode.ToString());
        RegisteredCheckBox.Checked = hothey.Registered;
      }
    }

    private void AltCheckBox_CheckedChanged(object sender, EventArgs e) {
      if(AltCheckBox.Checked != hothey.Alt) {
        hothey.Alt = AltCheckBox.Checked;
      }
    }

    private void ControlCheckBox_CheckedChanged(object sender, EventArgs e) {
      if(ControlCheckBox.Checked != hothey.Control) {
        hothey.Control = ControlCheckBox.Checked;
      }
    }

    private void ShiftCheckBox_CheckedChanged(object sender, EventArgs e) {
      if(ShiftCheckBox.Checked != hothey.Shift) {
        hothey.Shift = ShiftCheckBox.Checked;
      }
    }

    private void WindowsCheckBox_CheckedChanged(object sender, EventArgs e) {
      if(WindowsCheckBox.Checked != hothey.Windows) {
        hothey.Windows = WindowsCheckBox.Checked;
      }
    }

    private void KeyCodeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      Keys key = keys[KeyCodeComboBox.SelectedIndex];

      if(hothey.KeyCode != key) {
        hothey.KeyCode = key;
      }
    }

    private void RegisteredCheckBox_CheckedChanged(object sender, EventArgs e) {
      if(RegisteredCheckBox.Checked != hothey.Registered) {
        if(RegisteredCheckBox.Checked) {
          hothey.Register(this);
        } else {
          hothey.Unregister();
        }
      }
    }

    static Keys[] keys = {
      Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F,
      Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L,
      Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R,
      Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X,
      Keys.Y, Keys.Z,
    };
  }
}
