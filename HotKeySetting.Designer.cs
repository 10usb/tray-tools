namespace TrayTools {
    partial class HotKeySetting {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.AltCheckBox = new System.Windows.Forms.CheckBox();
            this.ControlCheckBox = new System.Windows.Forms.CheckBox();
            this.ShiftCheckBox = new System.Windows.Forms.CheckBox();
            this.WindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.KeyCodeComboBox = new System.Windows.Forms.ComboBox();
            this.RegisteredCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AltCheckBox
            // 
            this.AltCheckBox.AutoSize = true;
            this.AltCheckBox.Location = new System.Drawing.Point(6, 9);
            this.AltCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AltCheckBox.Name = "AltCheckBox";
            this.AltCheckBox.Size = new System.Drawing.Size(54, 24);
            this.AltCheckBox.TabIndex = 0;
            this.AltCheckBox.Text = "Alt";
            this.AltCheckBox.UseVisualStyleBackColor = true;
            this.AltCheckBox.CheckedChanged += new System.EventHandler(this.AltCheckBox_CheckedChanged);
            // 
            // ControlCheckBox
            // 
            this.ControlCheckBox.AutoSize = true;
            this.ControlCheckBox.Location = new System.Drawing.Point(72, 9);
            this.ControlCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ControlCheckBox.Name = "ControlCheckBox";
            this.ControlCheckBox.Size = new System.Drawing.Size(86, 24);
            this.ControlCheckBox.TabIndex = 1;
            this.ControlCheckBox.Text = "Control";
            this.ControlCheckBox.UseVisualStyleBackColor = true;
            this.ControlCheckBox.CheckedChanged += new System.EventHandler(this.ControlCheckBox_CheckedChanged);
            // 
            // ShiftCheckBox
            // 
            this.ShiftCheckBox.AutoSize = true;
            this.ShiftCheckBox.Location = new System.Drawing.Point(170, 9);
            this.ShiftCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ShiftCheckBox.Name = "ShiftCheckBox";
            this.ShiftCheckBox.Size = new System.Drawing.Size(68, 24);
            this.ShiftCheckBox.TabIndex = 2;
            this.ShiftCheckBox.Text = "Shift";
            this.ShiftCheckBox.UseVisualStyleBackColor = true;
            this.ShiftCheckBox.CheckedChanged += new System.EventHandler(this.ShiftCheckBox_CheckedChanged);
            // 
            // WindowsCheckBox
            // 
            this.WindowsCheckBox.AutoSize = true;
            this.WindowsCheckBox.Location = new System.Drawing.Point(249, 9);
            this.WindowsCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WindowsCheckBox.Name = "WindowsCheckBox";
            this.WindowsCheckBox.Size = new System.Drawing.Size(99, 24);
            this.WindowsCheckBox.TabIndex = 3;
            this.WindowsCheckBox.Text = "Windows";
            this.WindowsCheckBox.UseVisualStyleBackColor = true;
            this.WindowsCheckBox.CheckedChanged += new System.EventHandler(this.WindowsCheckBox_CheckedChanged);
            // 
            // KeyCodeComboBox
            // 
            this.KeyCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyCodeComboBox.FormattingEnabled = true;
            this.KeyCodeComboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.KeyCodeComboBox.Location = new System.Drawing.Point(350, 6);
            this.KeyCodeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KeyCodeComboBox.Name = "KeyCodeComboBox";
            this.KeyCodeComboBox.Size = new System.Drawing.Size(104, 28);
            this.KeyCodeComboBox.TabIndex = 4;
            this.KeyCodeComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyCodeComboBox_SelectedIndexChanged);
            // 
            // RegisteredCheckBox
            // 
            this.RegisteredCheckBox.AutoSize = true;
            this.RegisteredCheckBox.Location = new System.Drawing.Point(466, 9);
            this.RegisteredCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RegisteredCheckBox.Name = "RegisteredCheckBox";
            this.RegisteredCheckBox.Size = new System.Drawing.Size(113, 24);
            this.RegisteredCheckBox.TabIndex = 5;
            this.RegisteredCheckBox.Text = "Registered";
            this.RegisteredCheckBox.UseVisualStyleBackColor = true;
            this.RegisteredCheckBox.CheckedChanged += new System.EventHandler(this.RegisteredCheckBox_CheckedChanged);
            // 
            // HotKeySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.RegisteredCheckBox);
            this.Controls.Add(this.KeyCodeComboBox);
            this.Controls.Add(this.WindowsCheckBox);
            this.Controls.Add(this.ShiftCheckBox);
            this.Controls.Add(this.ControlCheckBox);
            this.Controls.Add(this.AltCheckBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HotKeySetting";
            this.Size = new System.Drawing.Size(588, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AltCheckBox;
        private System.Windows.Forms.CheckBox ControlCheckBox;
        private System.Windows.Forms.CheckBox ShiftCheckBox;
        private System.Windows.Forms.CheckBox WindowsCheckBox;
        private System.Windows.Forms.ComboBox KeyCodeComboBox;
        private System.Windows.Forms.CheckBox RegisteredCheckBox;
    }
}
