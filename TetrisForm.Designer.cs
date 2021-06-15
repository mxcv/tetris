
namespace Tetris
{
	partial class TetrisForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainPictureBox = new System.Windows.Forms.PictureBox();
			this.restartButton = new System.Windows.Forms.Button();
			this.scoreTextLabel = new System.Windows.Forms.Label();
			this.highScoreTextLabel = new System.Windows.Forms.Label();
			this.nextLabel = new System.Windows.Forms.Label();
			this.scoreLabel = new System.Windows.Forms.Label();
			this.highScoreLabel = new System.Windows.Forms.Label();
			this.previewPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPictureBox
			// 
			this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPictureBox.Location = new System.Drawing.Point(12, 12);
			this.mainPictureBox.Name = "mainPictureBox";
			this.mainPictureBox.Size = new System.Drawing.Size(300, 600);
			this.mainPictureBox.TabIndex = 0;
			this.mainPictureBox.TabStop = false;
			// 
			// restartButton
			// 
			this.restartButton.Location = new System.Drawing.Point(437, 12);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(75, 23);
			this.restartButton.TabIndex = 1;
			this.restartButton.TabStop = false;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			// 
			// scoreTextLabel
			// 
			this.scoreTextLabel.AutoSize = true;
			this.scoreTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.scoreTextLabel.Location = new System.Drawing.Point(398, 59);
			this.scoreTextLabel.Name = "scoreTextLabel";
			this.scoreTextLabel.Size = new System.Drawing.Size(65, 24);
			this.scoreTextLabel.TabIndex = 2;
			this.scoreTextLabel.Text = "Score:";
			// 
			// highScoreTextLabel
			// 
			this.highScoreTextLabel.AutoSize = true;
			this.highScoreTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.highScoreTextLabel.Location = new System.Drawing.Point(356, 94);
			this.highScoreTextLabel.Name = "highScoreTextLabel";
			this.highScoreTextLabel.Size = new System.Drawing.Size(107, 24);
			this.highScoreTextLabel.TabIndex = 3;
			this.highScoreTextLabel.Text = "High score:";
			// 
			// nextLabel
			// 
			this.nextLabel.AutoSize = true;
			this.nextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nextLabel.Location = new System.Drawing.Point(356, 158);
			this.nextLabel.Name = "nextLabel";
			this.nextLabel.Size = new System.Drawing.Size(54, 24);
			this.nextLabel.TabIndex = 4;
			this.nextLabel.Text = "Next:";
			// 
			// scoreLabel
			// 
			this.scoreLabel.AutoSize = true;
			this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.scoreLabel.Location = new System.Drawing.Point(469, 59);
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(20, 24);
			this.scoreLabel.TabIndex = 5;
			this.scoreLabel.Text = "0";
			// 
			// highScoreLabel
			// 
			this.highScoreLabel.AutoSize = true;
			this.highScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.highScoreLabel.Location = new System.Drawing.Point(469, 94);
			this.highScoreLabel.Name = "highScoreLabel";
			this.highScoreLabel.Size = new System.Drawing.Size(20, 24);
			this.highScoreLabel.TabIndex = 6;
			this.highScoreLabel.Text = "0";
			// 
			// previewPictureBox
			// 
			this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.previewPictureBox.Location = new System.Drawing.Point(360, 185);
			this.previewPictureBox.Name = "previewPictureBox";
			this.previewPictureBox.Size = new System.Drawing.Size(120, 180);
			this.previewPictureBox.TabIndex = 7;
			this.previewPictureBox.TabStop = false;
			// 
			// TetrisForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 624);
			this.Controls.Add(this.previewPictureBox);
			this.Controls.Add(this.highScoreLabel);
			this.Controls.Add(this.scoreLabel);
			this.Controls.Add(this.nextLabel);
			this.Controls.Add(this.highScoreTextLabel);
			this.Controls.Add(this.scoreTextLabel);
			this.Controls.Add(this.restartButton);
			this.Controls.Add(this.mainPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "TetrisForm";
			this.Text = "Tetris";
			((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox mainPictureBox;
		private System.Windows.Forms.Button restartButton;
		private System.Windows.Forms.Label scoreTextLabel;
		private System.Windows.Forms.Label highScoreTextLabel;
		private System.Windows.Forms.Label nextLabel;
		private System.Windows.Forms.Label scoreLabel;
		private System.Windows.Forms.Label highScoreLabel;
		private System.Windows.Forms.PictureBox previewPictureBox;
	}
}

