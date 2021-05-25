using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
	/// <summary>
	/// Random figure of tiles.
	/// </summary>
	class Tetromino
	{
		public static Size MaxSize { get; } = new Size(2, 4);
		private static readonly int[,] Figures = {
			{ 5, 1, 3, 7 }, // I
			{ 5, 2, 4, 7 }, // Z
			{ 5, 3, 4, 6 }, // S
			{ 5, 3, 4, 7 }, // T
			{ 5, 2, 3, 7 }, // L
			{ 5, 3, 7, 6 }, // J
			{ 5, 4, 6, 7 }  // O
		};

		private int color, figure;
		private Field field;
		private Point[] tiles = new Point[Figures.GetLength(1)];
		private Point fieldOffset;
		public Tetromino(Random random)
		{
			color = random.Next(Field.BitmapTiles.Length) + 1;
			figure = random.Next(Figures.GetLength(0));

			for (int i = 0; i < tiles.Length; i++)
				tiles[i] = new Point(Figures[figure, i] % 2, Figures[figure, i] / 2);
		}

		/// <summary>Tries to move this tetromino on the field towards the specified direction (or rotate).</summary>
		/// <param name="direction">Up - rotates, Right/Down/Left - moves</param>
		/// <exception cref="OverflowException">Thrown when the direction is down, but movement is not possible and not all tiles have been placed on the field.</exception>
		/// <returns>whether there was a movement.</returns>
		/// <remarks>Requires <see cref="Display(Field, Point)"/> to be called before.</remarks>
		public bool Move(Keys direction)
		{
			bool isArrowKey = true;
			Point[] newTiles = new Point[tiles.Length];

			switch (direction)
			{
				case Keys.Up:
					newTiles[0] = new Point(tiles[0].X, tiles[0].Y);	// 0 is the center tile
					for (int i = 1; i < newTiles.Length; ++i)
					{
						newTiles[i] = new Point(tiles[0].X - tiles[i].X, tiles[0].Y - tiles[i].Y);          // take coordinates relative to the center tile
						newTiles[i] = new Point(newTiles[i].Y, -newTiles[i].X);								// rotate 90 degrees ('x = y, 'y = -x)
						newTiles[i] = new Point(newTiles[i].X + tiles[0].X, newTiles[i].Y + tiles[0].Y);    // add the coordinates of the center tile 
					}
					break;
				case Keys.Down:
					for (int i = 0; i < tiles.Length; ++i)
						newTiles[i] = new Point(tiles[i].X, tiles[i].Y + 1);
					break;
				case Keys.Left:
					for (int i = 0; i < tiles.Length; ++i)
						newTiles[i] = new Point(tiles[i].X - 1, tiles[i].Y);
					break;
				case Keys.Right:
					for (int i = 0; i < tiles.Length; ++i)
						newTiles[i] = new Point(tiles[i].X + 1, tiles[i].Y);
					break;
				default:
					isArrowKey = false;
					break;
			}

			FillTiles(0);
			if (isArrowKey && newTiles.All(t => t.X > -1 && t.X < field.Size.Width && t.Y < field.Size.Height && field[t.X, t.Y] == 0))
				tiles = newTiles;				// if a new figure can be placed, accept it
			else if (direction == Keys.Down && tiles.Any(t => t.Y < 0))
				throw new OverflowException();	// check overflow
			FillTiles(color);
			return tiles == newTiles;			// return true if its position was changed
		}

		/// <summary>Sets this tetramino on the field with the specified offset.</summary>
		/// <remarks>If you use it again, offset will be refreshed, but all <see cref="Move(Keys)">moves</see> will be saved.</remarks>
		public void Display(Field field, Point offset)
		{
			this.field = field;
			for (int i = 0; i < tiles.Length; ++i)
				tiles[i] = new Point(
					tiles[i].X + offset.X - fieldOffset.X,
					tiles[i].Y + offset.Y - fieldOffset.Y
				);
			fieldOffset = offset;
			FillTiles(color);
		}

		private void FillTiles(int color)
		{
			foreach (Point tile in tiles)
				field[tile.X, tile.Y] = color;
		}
	}
}
