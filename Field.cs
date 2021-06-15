using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
	/// <summary>
	/// Field where the <see cref="Tetromino">tetrominoes</see> can be displayed.
	/// </summary>
	class Field
	{
		public static Bitmap[] BitmapTiles { get; set; }
		public PictureBox PictureBox { get; private set; }
		public Size Size { get; }
		public int this[int i, int j]
		{
			get => i > -1 && i < Size.Width && j > -1 && j < Size.Height ? tiles[i, j] : 0;
			set
			{
				if (i > -1 && i < Size.Width && j > -1 && j < Size.Height && tiles[i, j] != value)
				{
					Rectangle rectangle = new Rectangle(i * tileWidth, j * tileWidth, tileWidth, tileWidth);
					using (Graphics g = Graphics.FromImage(PictureBox.Image))
						if (value == 0) g.FillRectangle(new SolidBrush(PictureBox.BackColor), rectangle);
						else g.DrawImage(BitmapTiles[value - 1], i * tileWidth, j * tileWidth);
					PictureBox.Invalidate(rectangle);
					tiles[i, j] = value;
				}
			}
		}

		private int[,] tiles;   // contains the color of the tile or 0 if it's empty
		private int tileWidth;

		public Field(PictureBox pictureBox, Size size, int tileWidth)
		{
			Size = size;
			tiles = new int[size.Width, size.Height];
			this.tileWidth = tileWidth;

			if (BitmapTiles == null)
			{
				Bitmap bitmap = Properties.Resources.Tiles;
				bitmap = new Bitmap(bitmap, new Size(bitmap.Width / bitmap.Height * tileWidth, tileWidth));	// resize
				BitmapTiles = new Bitmap[bitmap.Width / bitmap.Height];
				for (int i = 0; i < BitmapTiles.Length; ++i)
					BitmapTiles[i] = bitmap.Clone(new Rectangle(i * tileWidth, 0, tileWidth, tileWidth), bitmap.PixelFormat);
			}

			PictureBox = pictureBox;
			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
		}
		/// <summary>Clears the entire field.</summary>
		public virtual void Clear()
		{
			for (int i = 0; i < Size.Width; ++i)
				for (int j = 0; j < Size.Height; ++j)
					tiles[i, j] = 0;
			using (Graphics g = Graphics.FromImage(PictureBox.Image))
				g.Clear(PictureBox.BackColor);
			PictureBox.Invalidate();
		}
	}
}
