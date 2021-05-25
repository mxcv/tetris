using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
	/// <summary>
	/// Field with movable <see cref="Tetromino">tetrominoes</see>.
	/// </summary>
	class PlayableField : Field, INotifyPropertyChanged
	{
		public int Score
		{
			get => score;
			private set
			{
				if (score != value)
				{
					score = value;
					OnPropertyChanged(nameof(Score));
				}
			}
		}
		public Tetromino NextTetromino
		{
			get => nextTetromino;
			private set
			{
				if (nextTetromino != value)
				{
					nextTetromino = value;
					OnPropertyChanged(nameof(NextTetromino));
				}
			}
		}

		private int score;
		private Form form;
		private Random random;
		private Timer timer;
		private Tetromino tetromino, nextTetromino;
		public PlayableField(PictureBox pictureBox, Size size, Form form, Random random) : base(pictureBox, size)
		{
			this.form = form;
			this.random = random;
			
			timer = new Timer();
			timer.Tick += (s, e) => MoveTetramino(Keys.Down);
		}

		/// <summary>Starts the timer and begins to listen to the input commands./summary>
		public void Start()
		{
			Clear();
			form.KeyDown += (s, e) => MoveTetramino(e.KeyCode);
			timer.Start();
		}

		/// <summary>Restarts the game.</summary>
		public override void Clear()
		{
			base.Clear();
			Score = 0;
			timer.Interval = 1000;
			tetromino = new Tetromino(random);
			NextTetromino = new Tetromino(random);
			tetromino.Display(this, new Point(Size.Width / 2 - Tetromino.MaxSize.Width / 2, -Tetromino.MaxSize.Height));
		}

		/// <summary>
		/// Moves the current tetromino.
		/// Adds a new tetromino and decrements the timer interval if the old one is dropped.
		/// Removes rows and increments the score if filled rows were found.
		/// </summary>
		private void MoveTetramino(Keys direction)
		{
			try
			{
				if (tetromino.Move(direction) == false && direction == Keys.Down)
				{
					int nRowsRemoved = 0;
					while (true)
					{
						int i, j;
						for (i = 0; i < Size.Height; ++i)           // for each row
						{
							for (j = 0; j < Size.Width; ++j)
								if (this[j, i] == 0) break;

							if (j == Size.Width)                    // if the row is filled
							{
								for (j = 0; j < Size.Width; ++j)    // clear it
									this[j, i] = 0;
								for (; i > 0; --i)                  // and move all upper rows down
									for (j = 0; j < Size.Width; ++j)
										this[j, i] = this[j, i - 1];
								break;
							}
						}

						if (i != Size.Height)
							++nRowsRemoved;
						else break;
					}
					switch (nRowsRemoved)
					{
						case 1: Score += 100; break;
						case 2: Score += 300; break;
						case 3: Score += 700; break;
						case 4: Score += 1500; break;
					}
					tetromino = NextTetromino;
					tetromino.Display(this, new Point(Size.Width / 2 - Tetromino.MaxSize.Width / 2, -Tetromino.MaxSize.Height));
					NextTetromino = new Tetromino(random);

					if (timer.Interval > 100)
						timer.Interval -= 10;
				}
			}
			catch (OverflowException)
			{
				timer.Stop();
				MessageBox.Show("Game over! Your score: " + Score);
				timer.Start();
				Clear();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
