namespace TrayTools {
    partial class ImageSelection {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSelection));
            this.SuspendLayout();
            // 
            // ImageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.Name = "ImageSelection";
            this.Text = "ImageSelection";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.ImageSelection_Shown);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ImageSelection_Scroll);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageSelection_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImageSelection_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageSelection_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageSelection_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageSelection_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}