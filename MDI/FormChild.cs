using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class FormChild : Form
    {
        private int _width, _height;
        private bool _drawImage = false;
        private Image _image;
        private Graphics _graphics;
        public bool Saved { get; set; } = false;
        

        public FormChild()
        {
            InitializeComponent();
            _width = 640;
            _height = 480;
            Width = 656;
            Height = 520;
        }

        public FormChild(int width, int height)
        {
            InitializeComponent();
            this._width = width;
            this._height = height;
            Width = width + 16;
            Height = height + 40;
        }

        public FormChild(Image image)
        {
            InitializeComponent();
            Width = image.Width + 16;
            Height = image.Height + 40;
            _drawImage = true;
            _image = image;
        }

        public void SaveImage(String path)
        {
            if (_drawImage)
            {
                _image.Save(path, ImageFormat.Png);
            }
            else
            {
                Bitmap b1 = new Bitmap(Width, Height);
                Graphics graphics = Graphics.FromImage(b1);
                graphics.FillRectangle(Brushes.Blue, 0, 0, _width, _height);             
                b1.Save(path);
            }
        } 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _graphics = e.Graphics;
            if (_drawImage)
            {
                _graphics.DrawImage(_image, 0, 0, _image.Width, _image.Height);
            }
            else
            {
                _graphics.FillRectangle(Brushes.Blue, 0, 0, _width, _height);
            }
        }
    }
}
