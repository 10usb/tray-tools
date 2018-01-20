using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
    public partial class MainForm : Form {
        Hotkey printScreen;
        Hotkey colorPicker;
        Hotkey screenPicker;
        NotifyIcon TrayIcon;
        ContextMenu TrayMenu;

        public MainForm() {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e) {
            printScreen = new Hotkey();
            printScreen.Control = true;
            printScreen.Alt = true;
            printScreen.KeyCode = Keys.P;
            printScreen.Pressed += new HandledEventHandler(printScreen_Pressed);
            printScreen.Register(this);
            HotKeySettingPrintScreen.Hotkey = printScreen;

            colorPicker = new Hotkey();
            colorPicker.Control = true;
            colorPicker.Alt = true;
            colorPicker.KeyCode = Keys.O;
            colorPicker.Pressed += new HandledEventHandler(colorPicker_Pressed);
            colorPicker.Register(this);
            HotKeySettingColorPicker.Hotkey = colorPicker;

            TrayMenu = new ContextMenu();
            TrayMenu.MenuItems.Add(0, new MenuItem("Exit", new System.EventHandler(Exit_Click)));
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = "Coffee give me!!!";
            TrayIcon.Icon = Properties.Resources.coffee;
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;
            TrayIcon.DoubleClick += new System.EventHandler(this.TrayDoubleClick);
            Hide();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void printScreen_Pressed(object sender, HandledEventArgs e) {
            for (int index = 0; index < Screen.AllScreens.Length; index++) {
                ImageSelection imageSelection = new ImageSelection(index);
                imageSelection.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void colorPicker_Pressed(object sender, HandledEventArgs e) {
            ColorPicker cp = new ColorPicker();
            FloatingColor color = FloatingColor.FromString(Clipboard.GetText(TextDataFormat.Text));
            if (color != null) {
                cp.Color = color.ToColor();
            } else {
                Random r = new Random();
                cp.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }
            cp.Show();
            cp.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Exit_Click(Object sender, System.EventArgs e) {
            TrayIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        void TrayDoubleClick(object Sender, EventArgs e) {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            TrayIcon.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
        //protected override void ScaleControl(SizeF factor, BoundsSpecified specified) {}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Bitmap GetScreen() {
            //foreach (Screen screen in Screen.AllScreens) {

            //    uint dpiX = 0, dpiY = 0;
            //    screen.GetDpi(DpiType.Angular, out dpiX, out dpiY);
            //    string message = string.Format("DPI {0} x {1}", dpiX, dpiY);
            //    MessageBox.Show(message);

            //    screen.GetDpi(DpiType.Effective, out dpiX, out dpiY);
            //    message = string.Format("DPI {0} x {1}", dpiX, dpiY);
            //    MessageBox.Show(message);

            //    screen.GetDpi(DpiType.Raw, out dpiX, out dpiY);
            //    message = string.Format("DPI {0} x {1}", dpiX, dpiY);
            //    MessageBox.Show(message);
            //}

            Rectangle screenSize = Screen.GetBounds(Screen.GetBounds(Point.Empty));

            Bitmap bitmap = new Bitmap(screenSize.Width, screenSize.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), screenSize.Size);
            g.Dispose();
            return bitmap;
        }
    }
}
