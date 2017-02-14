using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public FormChild(int width, int height, Image image)
        {
            InitializeComponent();
            this._width = width;
            this._height = height;
            Width = width + 16;
            Height = height + 40;
            _drawImage = true;
            _image = image;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            if (_drawImage)
            {
                graphics.DrawImage(_image, 0, 0);
            }
            else
            {
                graphics.FillRectangle(Brushes.Blue, 0, 0, _width, _height);
            }
        }
    }
}
