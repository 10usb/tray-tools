namespace TrayTools {
  partial class ImageViewer {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageViewer));
      this.SuspendLayout();
      // 
      // ImageViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(380, 250);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ImageViewer";
      this.Text = "Eyedropper";
      this.TopMost = true;
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.ImageViewer_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Eyedropper_Paint);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Eyedropper_KeyDown);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Eyedropper_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Eyedropper_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Eyedropper_MouseUp);
      this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Eyedropper_MouseWheel);
      this.ResumeLayout(false);

    }

    #endregion
  }
}