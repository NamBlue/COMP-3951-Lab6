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
        /// <summary>
        /// String variable for specifiying where to save the images on the user's local computer.
        /// </summary>
        public String Path { get; set; }
        /// <summary>
        /// ImageFormate variable for referencing the image object if the user decides to import 
        /// an image to the main form.  
        /// </summary>
        public ImageFormat ImageFormat { get; set; } = ImageFormat.Jpeg;

        /// <summary>
        /// Constructor for the child window with default height and width for the
        /// image size and the window size.
        /// </summary>
        public FormChild()
        {
            InitializeComponent();
            this._width = 640;
            this._height = 480;
            this.AutoScrollMinSize = new Size(640, 480);
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
            this.AutoScrollMinSize = new Size(width, height);
        }

        /// <summary>
        /// Constructor for the child window with an image that is taken 
        /// from a specified address.  
        /// </summary>
        /// <param name="path">Specifies where the image can be taken from.</param>
        public FormChild(String path)
        {
            InitializeComponent();
            try
            {
                Image image = Image.FromFile(path);
                this._drawImage = true;
                this._image = image;
                this.Path = path;
                this.AutoScrollMinSize = image.Size;
                this.Text = path;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Constructor for the child window with a specified image object that the user 
        /// can import.  
        /// </summary>
        /// <param name="image"></param>
        public FormChild(Image image)
        {
            InitializeComponent();
            try
            {
                this._drawImage = true;
                this._image = image;
                this.AutoScrollMinSize = image.Size;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        /// <summary>
        /// Method for saving an image.  It requires that the path where the user
        /// wishes to save the image on their computer to be specified.  If the user
        /// has already specified the pathway, then the image is simply saved over the
        /// previous saved file.  
        /// </summary>
        /// <param name="path"></param>
        public void SaveImage(String path)
        {
            try
            {
                if (_drawImage)
                {
                    _image.Save(path, ImageFormat);
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        /// <summary>
        /// Paint method for painting the default image which is a blue rectangle of the
        /// following sizes: 640 x 480, 800 x 600 and 1024 x 768.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _graphics = e.Graphics;
            if (_drawImage)
            {
                Point autoScrollPosition = this.AutoScrollPosition;
                _graphics.DrawImage(_image, autoScrollPosition.X, autoScrollPosition.Y, _image.Width, _image.Height);
            }
            else
            {
                _graphics.FillRectangle(Brushes.Blue, 0, 0, _width, _height);
            }
        }
    }
}