using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// Represents the screen and its drawing
    /// </summary>
    sealed public class Screen
    {
        #region Constants

        public const int Width = 224;
        public const int Height = 256;
        private const ushort Offset = 0x2400;

        #endregion

        #region Instance variables

        readonly private Memory memory;
        readonly private Timer clock;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Screen"/>
        /// </summary>
        internal Screen(Memory memory)
        {
            this.memory = memory ?? throw new ArgumentNullException(nameof(memory));
            this.clock = new Timer(state => Refresh(), new AutoResetEvent(false), 100, 167); // Draws screen at 60Hz
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the screen
        /// </summary>
        public void Refresh()
        {
            // Inspired by https://stackoverflow.com/a/33652557

            using (Graphics g = Graphics.FromHwnd(Process.GetCurrentProcess().MainWindowHandle))
            {
                using (Image image = GetImageFromMemory())
                {
                    Size fontSize = new Size(2, 2);

                    // translating the character positions to pixels
                    Rectangle imageRect = new Rectangle(0, 0, image.Size.Width * fontSize.Width, image.Size.Height * fontSize.Height);
                    g.DrawImage(image, imageRect);
                }
            }
        }

        private Image GetImageFromMemory()
        {
            var picture = new Bitmap(Width, Height);

            ushort totalNumber = 57344;
            for (ushort i = 0; i < totalNumber; i += 8)
            {
                byte pixel = this.memory[i];
                int x = i / Height;

                for (int p = 0; p < 8; ++p)
                {
                    Color color;
                    if ((p & (1 << p)) != 0)
                        color = Color.Black;
                    else
                        color = Color.White;

                    int y = (i % Width) + p;
                    
                    picture.SetPixel(x, y, color);
                }
            }

            return picture;
        }

        #endregion
    }
}
