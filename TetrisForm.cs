﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
	public partial class TetrisForm : Form
	{
		private PlayableField mainField;
		private Field previewField;
		public TetrisForm()
		{
			InitializeComponent();
			Icon = Properties.Resources.Icon;
			PreviewKeyDown += Form_PreviewKeyDown;			// accept arrow keys
			restartButton.GotFocus += (s, e) => Focus();	// prevent the button from focusing
			restartButton.Click += (s, e) => {
				previewField.Clear();
				mainField.Clear();
			};

			previewField = new Field(previewPictureBox, new Size(Tetromino.MaxSize.Width + 2, Tetromino.MaxSize.Height + 2));
			mainField = new PlayableField(mainPictureBox, new Size(10, 20), this, new Random());
			mainField.PropertyChanged += Field_PropertyChanged;
			mainField.Start();
		}

		private void Field_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(PlayableField.NextTetromino):
					previewField.Clear();
					mainField.NextTetromino.Display(previewField, new Point(1, 1));
					break;
				case nameof(PlayableField.Score):
					scoreLabel.Text = mainField.Score.ToString();
					if (mainField.Score > int.Parse(highScoreLabel.Text))
						highScoreLabel.Text = mainField.Score.ToString();
					break;
			}
		}

		private void Form_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Right:
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
					e.IsInputKey = true;
					break;
			}
		}
	}
}
