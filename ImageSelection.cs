using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TrayTools {
    public partial class ImageSelection : Form {
        Image image;
        Rectangle selection;
        State state;
        Size size;
        Point start;
        Point end;
        Pen line;
        Rectangle top, left, right, bottom;
        Brush shadow;
        const int CORNER_RADIUS = 15;
        Screen screen;

        public ImageSelection(int index) {
            InitializeComponent();
            this.screen = Screen.AllScreens[index];

            Rectangle bounds = new Rectangle();
            foreach(Screen screen in Screen.AllScreens){
                bounds.Width = Math.Max(bounds.Width, screen.Bounds.Width);
                bounds.Height = Math.Max(bounds.Height, screen.Bounds.Height);
            }
            bounds.Location = new Point(bounds.Width * index, 0);

            image = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(bounds.Location, new Point(0, 0), bounds.Size);
            g.Dispose();

            selection = Rectangle.Empty;
            state = State.Idle;
            // Drawing stuff
            line = new Pen(new SolidBrush(Color.Red), 1);
            shadow = new SolidBrush(Color.FromArgb(128, Color.Black));
        }

        void ImageSelection_Shown(object sender, EventArgs e) {
            this.Bounds = this.screen.Bounds;
        }

        void ImageSelection_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawImage(image, 0, 0, this.Width, this.Height);

            if (!selection.IsEmpty) {
                Rectangle lineR = selection;
                lineR.Width--;
                lineR.Height--;
                e.Graphics.DrawRectangle(line, lineR);

                // Top
                e.Graphics.FillRectangle(shadow, top);

                // Bottom
                e.Graphics.FillRectangle(shadow, bottom);

                // Left
                e.Graphics.FillRectangle(shadow, left);

                // Right
                e.Graphics.FillRectangle(shadow, right);

                double factor = Math.Max(this.Width, this.Height) / 1920.0;
                Font font = new Font("Arial", (int)(30 * factor), FontStyle.Bold, GraphicsUnit.Pixel);
                Point pt = new Point(Math.Max((int)(font.Size * .30), selection.X + (int)(font.Size * .30)), Math.Max((int)(font.Size * .25), selection.Y - (int)(font.Size * 1.2)));
                string text = string.Format("{0} x {1}", selection.Width, selection.Height);
                
                e.Graphics.DrawString(text, font, new SolidBrush(Color.Red), pt);
            } else {
                Rectangle area = this.Bounds;
                area.Location = Point.Empty;
                e.Graphics.FillRectangle(shadow, area);
            }
        }

        void ImageSelection_Scroll(object sender, ScrollEventArgs e) {

        }

        void ImageSelection_MouseDown(object sender, MouseEventArgs e) {
            if (Distance2D(e.Location, new Point(selection.Right, selection.Bottom)) < CORNER_RADIUS) {
                size = selection.Size;
                end = e.Location;
                state = State.Resizing;
            } else {
                if (selection.Contains(e.Location)) {
                    start = selection.Location;
                    end = e.Location;
                    state = State.Moving;
                } else {
                    start = e.Location;
                    end = Point.Empty;
                    state = State.Selecting;
                }
            }
        }

        void ImageSelection_MouseUp(object sender, MouseEventArgs e) {
            state = State.Idle;
        }

        void ImageSelection_MouseMove(object sender, MouseEventArgs e) {
            switch (state) {
                case State.Selecting: {
                    end = e.Location;
                    selection = Rectangle.FromLTRB(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y), Math.Max(start.X, end.X), Math.Max(start.Y, end.Y));
                    UpdateSelection();
                }
                break;
                case State.Moving: {
                    selection.X = Math.Min(Math.Max(0, start.X + (e.X - end.X)), this.Width - selection.Width);
                    selection.Y = Math.Min(Math.Max(0, start.Y + (e.Y - end.Y)), this.Height - selection.Height);
                    UpdateSelection();
                }
                break;
                case State.Resizing: {
                    selection.Width = Math.Min(Math.Max(0, size.Width + (e.X - end.X)), this.Width - selection.X);
                    selection.Height = Math.Min(Math.Max(0, size.Height + (e.Y - end.Y)), this.Height - selection.Y);
                    UpdateSelection();
                }
                break;
                default: {
                    if (Distance2D(e.Location, new Point(selection.Right, selection.Bottom)) < CORNER_RADIUS) {
                        this.Cursor = Cursors.SizeNWSE;
                    } else {
                        if (selection.Contains(e.Location)) {
                            this.Cursor = Cursors.SizeAll;
                        } else {
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
                break;
            }
        }

        void ImageSelection_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Left: {
                    selection.X--;
                    UpdateSelection();
                }
                break;
                case Keys.Up: {
                    selection.Y--;
                    UpdateSelection();
                }
                break;
                case Keys.Right: {
                    selection.X++;
                    UpdateSelection();
                }
                break;
                case Keys.Down: {
                    selection.Y++;
                    UpdateSelection();
                }
                break;
                case Keys.Escape:
                case Keys.X: {
                    this.Close();
                }
                break;
                case Keys.S: {
                    // Save
                    this.Hide();
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.DefaultExt = "bmp";
                    sfd.Filter = "Image (*.png)|*.png";
                    sfd.Title = "Save screenshot to...";
                    if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                        GetImage().Save(sfd.FileName);
                    }
                    this.Close();
                }
                break;
                case Keys.C: {
                    // Clipboard
                    this.Close();
                    Clipboard.SetImage(GetImage());
                }
                break;
                case Keys.V: {
                    // ImageViewer
                    ImageViewer imageViewer = new ImageViewer(GetImage(), image);
                    imageViewer.Show();
                    imageViewer.Focus();
                    this.Close();
                }
                break;
            }
        }

        void UpdateSelection() {
            top = new Rectangle(0, 0, this.Width, selection.Y);
            bottom = new Rectangle(0, selection.Y + selection.Height, this.Width, this.Height - (selection.Y + selection.Height));
            left = new Rectangle(0, selection.Y, selection.X, selection.Height);
            right = new Rectangle(selection.X + selection.Width, selection.Y, this.Width - (selection.X + selection.Width), selection.Height);
            this.Invalidate();
        }

        //public Image GetImage() {
        public Bitmap GetImage() {
            Bitmap bitmap = new Bitmap(selection.Width, selection.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(image, -selection.X, -selection.Y);
            g.Dispose();
            return bitmap;
        }

        public enum State {
            Idle,
            Selecting,
            Moving,
            Resizing,
        }

        public double Distance2D(Point p1, Point p2) {
            return Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
        }
    }
}
