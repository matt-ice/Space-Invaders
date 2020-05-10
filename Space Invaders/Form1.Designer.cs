namespace Space_Invaders
{
    partial class gameWindow
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
            this.components = new System.ComponentModel.Container();
            this.ship = new System.Windows.Forms.PictureBox();
            this.invaderTemplate = new System.Windows.Forms.PictureBox();
            this.arrow = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).BeginInit();
            this.SuspendLayout();
            // 
            // ship
            // 
            this.ship.Image = global::Space_Invaders.Properties.Resources.bow_ship;
            this.ship.Location = new System.Drawing.Point(481, 599);
            this.ship.Name = "ship";
            this.ship.Size = new System.Drawing.Size(100, 50);
            this.ship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ship.TabIndex = 0;
            this.ship.TabStop = false;
            // 
            // invaderTemplate
            // 
            this.invaderTemplate.Image = global::Space_Invaders.Properties.Resources.invader;
            this.invaderTemplate.Location = new System.Drawing.Point(12, 12);
            this.invaderTemplate.Name = "invaderTemplate";
            this.invaderTemplate.Size = new System.Drawing.Size(100, 70);
            this.invaderTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.invaderTemplate.TabIndex = 1;
            this.invaderTemplate.TabStop = false;
            this.invaderTemplate.Visible = false;
            // 
            // arrow
            // 
            this.arrow.Image = global::Space_Invaders.Properties.Resources.arrow_black_background;
            this.arrow.Location = new System.Drawing.Point(522, 563);
            this.arrow.Name = "arrow";
            this.arrow.Size = new System.Drawing.Size(16, 30);
            this.arrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrow.TabIndex = 2;
            this.arrow.TabStop = false;
            this.arrow.Visible = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerTick);
            // 
            // gameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.arrow);
            this.Controls.Add(this.invaderTemplate);
            this.Controls.Add(this.ship);
            this.Name = "gameWindow";
            this.Text = "Hawkeye vs Space Invaders!";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameKeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameKeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.ship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invaderTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ship;
        private System.Windows.Forms.PictureBox invaderTemplate;
        private System.Windows.Forms.PictureBox arrow;
        private System.Windows.Forms.Timer gameTimer;
    }
}

