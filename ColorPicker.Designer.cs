namespace TrayTools {
  partial class ColorPicker {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPicker));
      this.RadioHType = new System.Windows.Forms.RadioButton();
      this.TxtHud = new System.Windows.Forms.TextBox();
      this.TxtSaturation = new System.Windows.Forms.TextBox();
      this.RadioSType = new System.Windows.Forms.RadioButton();
      this.TxtValue = new System.Windows.Forms.TextBox();
      this.RadioVType = new System.Windows.Forms.RadioButton();
      this.TxtHex = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.TxtBlue = new System.Windows.Forms.TextBox();
      this.RadioRType = new System.Windows.Forms.RadioButton();
      this.TxtRed = new System.Windows.Forms.TextBox();
      this.RadioGType = new System.Windows.Forms.RadioButton();
      this.TxtGreen = new System.Windows.Forms.TextBox();
      this.RadioBType = new System.Windows.Forms.RadioButton();
      this.Preview = new TrayTools.ColorPickerPreview();
      this.Pane = new TrayTools.ColorPickerPane();
      this.Bar = new TrayTools.ColorPickerBar();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // RadioHType
      // 
      this.RadioHType.AutoSize = true;
      this.RadioHType.Checked = true;
      this.RadioHType.Location = new System.Drawing.Point(319, 85);
      this.RadioHType.Name = "RadioHType";
      this.RadioHType.Size = new System.Drawing.Size(36, 17);
      this.RadioHType.TabIndex = 9;
      this.RadioHType.TabStop = true;
      this.RadioHType.Text = "H:";
      this.RadioHType.UseVisualStyleBackColor = true;
      this.RadioHType.CheckedChanged += new System.EventHandler(this.RadioHType_CheckedChanged);
      // 
      // TxtHud
      // 
      this.TxtHud.Location = new System.Drawing.Point(362, 84);
      this.TxtHud.Name = "TxtHud";
      this.TxtHud.Size = new System.Drawing.Size(46, 20);
      this.TxtHud.TabIndex = 2;
      this.TxtHud.Text = "0";
      this.TxtHud.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtHud.TextChanged += new System.EventHandler(this.TxtHud_TextChanged);
      this.TxtHud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtHud_KeyDown);
      // 
      // TxtSaturation
      // 
      this.TxtSaturation.Location = new System.Drawing.Point(362, 106);
      this.TxtSaturation.Name = "TxtSaturation";
      this.TxtSaturation.Size = new System.Drawing.Size(46, 20);
      this.TxtSaturation.TabIndex = 3;
      this.TxtSaturation.Text = "0";
      this.TxtSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtSaturation.TextChanged += new System.EventHandler(this.TxtSaturation_TextChanged);
      this.TxtSaturation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSaturation_KeyDown);
      // 
      // RadioSType
      // 
      this.RadioSType.AutoSize = true;
      this.RadioSType.Location = new System.Drawing.Point(319, 107);
      this.RadioSType.Name = "RadioSType";
      this.RadioSType.Size = new System.Drawing.Size(35, 17);
      this.RadioSType.TabIndex = 10;
      this.RadioSType.Text = "S:";
      this.RadioSType.UseVisualStyleBackColor = true;
      this.RadioSType.CheckedChanged += new System.EventHandler(this.RadioSType_CheckedChanged);
      // 
      // TxtValue
      // 
      this.TxtValue.Location = new System.Drawing.Point(362, 128);
      this.TxtValue.Name = "TxtValue";
      this.TxtValue.Size = new System.Drawing.Size(46, 20);
      this.TxtValue.TabIndex = 4;
      this.TxtValue.Text = "0";
      this.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtValue.TextChanged += new System.EventHandler(this.TxtValue_TextChanged);
      this.TxtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValue_KeyDown);
      // 
      // RadioVType
      // 
      this.RadioVType.AutoSize = true;
      this.RadioVType.Location = new System.Drawing.Point(319, 129);
      this.RadioVType.Name = "RadioVType";
      this.RadioVType.Size = new System.Drawing.Size(35, 17);
      this.RadioVType.TabIndex = 11;
      this.RadioVType.Text = "V:";
      this.RadioVType.UseVisualStyleBackColor = true;
      this.RadioVType.CheckedChanged += new System.EventHandler(this.RadioVType_CheckedChanged);
      // 
      // TxtHex
      // 
      this.TxtHex.Location = new System.Drawing.Point(349, 226);
      this.TxtHex.Name = "TxtHex";
      this.TxtHex.Size = new System.Drawing.Size(59, 20);
      this.TxtHex.TabIndex = 8;
      this.TxtHex.Text = "2e2e2e";
      this.TxtHex.TextChanged += new System.EventHandler(this.TxtHex_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(332, 229);
      this.label1.Margin = new System.Windows.Forms.Padding(0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(14, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "#";
      // 
      // TxtBlue
      // 
      this.TxtBlue.Location = new System.Drawing.Point(362, 198);
      this.TxtBlue.Name = "TxtBlue";
      this.TxtBlue.Size = new System.Drawing.Size(46, 20);
      this.TxtBlue.TabIndex = 7;
      this.TxtBlue.Text = "0";
      this.TxtBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtBlue.TextChanged += new System.EventHandler(this.TxtBlue_TextChanged);
      this.TxtBlue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBlue_KeyDown);
      // 
      // RadioRType
      // 
      this.RadioRType.AutoSize = true;
      this.RadioRType.Location = new System.Drawing.Point(319, 155);
      this.RadioRType.Name = "RadioRType";
      this.RadioRType.Size = new System.Drawing.Size(36, 17);
      this.RadioRType.TabIndex = 12;
      this.RadioRType.Text = "R:";
      this.RadioRType.UseVisualStyleBackColor = true;
      this.RadioRType.CheckedChanged += new System.EventHandler(this.RadioRType_CheckedChanged);
      // 
      // TxtRed
      // 
      this.TxtRed.Location = new System.Drawing.Point(362, 154);
      this.TxtRed.Name = "TxtRed";
      this.TxtRed.Size = new System.Drawing.Size(46, 20);
      this.TxtRed.TabIndex = 5;
      this.TxtRed.Text = "0";
      this.TxtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtRed.TextChanged += new System.EventHandler(this.TxtRed_TextChanged);
      this.TxtRed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRed_KeyDown);
      // 
      // RadioGType
      // 
      this.RadioGType.AutoSize = true;
      this.RadioGType.Location = new System.Drawing.Point(319, 177);
      this.RadioGType.Name = "RadioGType";
      this.RadioGType.Size = new System.Drawing.Size(36, 17);
      this.RadioGType.TabIndex = 13;
      this.RadioGType.Text = "G:";
      this.RadioGType.UseVisualStyleBackColor = true;
      this.RadioGType.CheckedChanged += new System.EventHandler(this.RadioGType_CheckedChanged);
      // 
      // TxtGreen
      // 
      this.TxtGreen.Location = new System.Drawing.Point(362, 176);
      this.TxtGreen.Name = "TxtGreen";
      this.TxtGreen.Size = new System.Drawing.Size(46, 20);
      this.TxtGreen.TabIndex = 6;
      this.TxtGreen.Text = "0";
      this.TxtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.TxtGreen.TextChanged += new System.EventHandler(this.TxtGreen_TextChanged);
      this.TxtGreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtGreen_KeyDown);
      // 
      // RadioBType
      // 
      this.RadioBType.AutoSize = true;
      this.RadioBType.Location = new System.Drawing.Point(319, 199);
      this.RadioBType.Name = "RadioBType";
      this.RadioBType.Size = new System.Drawing.Size(35, 17);
      this.RadioBType.TabIndex = 14;
      this.RadioBType.Text = "B:";
      this.RadioBType.UseVisualStyleBackColor = true;
      this.RadioBType.CheckedChanged += new System.EventHandler(this.RadioBType_CheckedChanged);
      // 
      // Preview
      // 
      this.Preview.Color = null;
      this.Preview.Location = new System.Drawing.Point(326, 11);
      this.Preview.Name = "Preview";
      this.Preview.Size = new System.Drawing.Size(66, 66);
      this.Preview.TabIndex = 23;
      // 
      // Pane
      // 
      this.Pane.BackColor = System.Drawing.Color.Black;
      this.Pane.Color = null;
      this.Pane.Location = new System.Drawing.Point(11, 11);
      this.Pane.Name = "Pane";
      this.Pane.Size = new System.Drawing.Size(258, 258);
      this.Pane.TabIndex = 22;
      this.Pane.Type = TrayTools.RenderType.Hud;
      // 
      // Bar
      // 
      this.Bar.Color = null;
      this.Bar.Location = new System.Drawing.Point(273, 8);
      this.Bar.Name = "Bar";
      this.Bar.Size = new System.Drawing.Size(40, 264);
      this.Bar.TabIndex = 21;
      this.Bar.Type = TrayTools.RenderType.Hud;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(326, 249);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 24;
      this.button1.Text = "Clipboard";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // ColorPicker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(419, 279);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.Preview);
      this.Controls.Add(this.TxtHex);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TxtBlue);
      this.Controls.Add(this.RadioRType);
      this.Controls.Add(this.TxtValue);
      this.Controls.Add(this.TxtRed);
      this.Controls.Add(this.RadioHType);
      this.Controls.Add(this.RadioGType);
      this.Controls.Add(this.Pane);
      this.Controls.Add(this.TxtGreen);
      this.Controls.Add(this.TxtHud);
      this.Controls.Add(this.RadioBType);
      this.Controls.Add(this.Bar);
      this.Controls.Add(this.RadioSType);
      this.Controls.Add(this.TxtSaturation);
      this.Controls.Add(this.RadioVType);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ColorPicker";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Color Picker";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton RadioHType;
    private System.Windows.Forms.TextBox TxtHud;
    private System.Windows.Forms.TextBox TxtSaturation;
    private System.Windows.Forms.RadioButton RadioSType;
    private System.Windows.Forms.TextBox TxtValue;
    private System.Windows.Forms.RadioButton RadioVType;
    private System.Windows.Forms.TextBox TxtHex;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TxtBlue;
    private System.Windows.Forms.RadioButton RadioRType;
    private System.Windows.Forms.TextBox TxtRed;
    private System.Windows.Forms.RadioButton RadioGType;
    private System.Windows.Forms.TextBox TxtGreen;
    private System.Windows.Forms.RadioButton RadioBType;
    private ColorPickerBar Bar;
    private ColorPickerPane Pane;
    private ColorPickerPreview Preview;
    private System.Windows.Forms.Button button1;
  }
}