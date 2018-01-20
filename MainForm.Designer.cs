namespace TrayTools {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HotKeySettingPrintScreen = new TrayTools.HotKeySetting();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.HotKeySettingColorPicker = new TrayTools.HotKeySetting();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.HotKeySettingScreenPicker = new TrayTools.HotKeySetting();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HotKeySettingPrintScreen);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(606, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printscreen";
            // 
            // HotKeySettingPrintScreen
            // 
            this.HotKeySettingPrintScreen.Hotkey = null;
            this.HotKeySettingPrintScreen.Location = new System.Drawing.Point(10, 31);
            this.HotKeySettingPrintScreen.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.HotKeySettingPrintScreen.Name = "HotKeySettingPrintScreen";
            this.HotKeySettingPrintScreen.Size = new System.Drawing.Size(588, 48);
            this.HotKeySettingPrintScreen.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.HotKeySettingColorPicker);
            this.groupBox2.Location = new System.Drawing.Point(18, 120);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(606, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ColorPicker";
            // 
            // HotKeySettingColorPicker
            // 
            this.HotKeySettingColorPicker.Hotkey = null;
            this.HotKeySettingColorPicker.Location = new System.Drawing.Point(10, 31);
            this.HotKeySettingColorPicker.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.HotKeySettingColorPicker.Name = "HotKeySettingColorPicker";
            this.HotKeySettingColorPicker.Size = new System.Drawing.Size(588, 48);
            this.HotKeySettingColorPicker.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.HotKeySettingScreenPicker);
            this.groupBox3.Location = new System.Drawing.Point(18, 222);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(606, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ScreenPicker";
            // 
            // HotKeySettingScreenPicker
            // 
            this.HotKeySettingScreenPicker.Hotkey = null;
            this.HotKeySettingScreenPicker.Location = new System.Drawing.Point(10, 31);
            this.HotKeySettingScreenPicker.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.HotKeySettingScreenPicker.Name = "HotKeySettingScreenPicker";
            this.HotKeySettingScreenPicker.Size = new System.Drawing.Size(588, 48);
            this.HotKeySettingScreenPicker.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(645, 351);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrayTools";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private HotKeySetting HotKeySettingPrintScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private HotKeySetting HotKeySettingColorPicker;
        private System.Windows.Forms.GroupBox groupBox3;
        private HotKeySetting HotKeySettingScreenPicker;


    }
}

