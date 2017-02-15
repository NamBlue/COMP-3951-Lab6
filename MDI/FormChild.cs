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
    /// <summary>
    /// Class for creating a FormChild which is the child window created inside the FormMain. 
    /// It displays an image of the user's choice inside itself.  
    /// </summary>
    public partial class FormChild : Form
    {
        /// <summary>
        /// Height and Width of the image that's selected.  
        /// </summary>
        private int _width, _height;
        /// <summary>
        /// Boolean for determining if an image could be drawn on the child window.  
        /// </summary>
        private bool _drawImage = false;
        /// <summary>
        /// Image object for displaying an image from the user's computer or the internet.  
        /// </summary>
        private Image _image;
        private Graphics _graphics;
        /// <summary>
        /// Boolean for checking if the image was saved successfully.  
        /// </summary>
        public bool Saved { get; set; } = false;
        public String Path { get; set; }
        
        /// <summary>
        /// Constructor for the child window with default height and width for the
        /// image size and the window size. 
        /// </summary>
        public FormChild()
        {
            InitializeComponent();
            this._width = 640;
            this._height = 480;
            this.Width = 656;
            this.Height = 520;
        }
        /// <summary>
        /// Constructor for the child window with specified height and width for the
        /// image size and the window size.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public FormChild(int width, int height)
        {
            InitializeComponent();
            this._width = width;
            this._height = height;
            this.Width = width + 16;
            this.Height = height + 40;
        }

        /// Constructor for the child window with a specified image that fits inside the
        /// specified height and width for the window.  
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="image"></param>
        public FormChild(String path)
        {
            InitializeComponent();
            try
            {
                Image image = Image.FromFile(path);
                this.Width = image.Width + 16;
                this.Height = image.Height + 40;
                this._drawImage = true;
                this._image = image;
                this.Path = path;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }   
        }


        //For web images
        public FormChild(Image image)
        {
            InitializeComponent();
            try
            {
                this.Width = image.Width + 16;
                this.Height = image.Height + 40;
                this._drawImage = true;
                this._image = image;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public void SaveImage(String path)
        {
            if (_drawImage)
            {
                _image.Save(path, ImageFormat.Jpeg);
            }
            else
            {
                Bitmap b1 = new Bitmap(Width, Height);
                Graphics graphics = Graphics.FromImage(b1);
                graphics.FillRectangle(Brushes.Blue, 0, 0, _width, _height);             
                b1.Save(path);
            }
            Saved = true;
            this.Path = path;
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
