using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
//using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Properties;

namespace Space_Invaders
{

    public partial class gameWindow : Form
    {
        int arrowSpeed = 20;
        int invaderSpeed = 5;
        List<PictureBox> arrowList;
        PictureBox[,] invaderArray = new PictureBox[5,5];
        bool endGameBool = true;
        bool shooting = false;
        int invadersDown = 0;
        sbyte invaderMoveDirection = 1;

        public gameWindow()
        {
            InitializeComponent();
        }

        private void initializeInvaders()
        {
            for (int i = 0; i < invaderArray.GetLength(0); i++)
            {
                for (int j = 0; j < invaderArray.GetLength(1); j++)
                {
                    invaderArray[i, j] = makeInvader(i,j);
                    this.Controls.Add(this.invaderArray[i, j]);
                }
            }
        }
        
        private void startGame()
        {
            arrowSpeed = 20;
            invaderSpeed = 5;
            initializeInvaders();
            endGameBool = false;
            ship.Left = (ClientRectangle.Width / 2) - (ship.Width / 2);
            gameTimer.Start();

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (ship.Left > 25)
                {
                    ship.Left -= 25;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if(ship.Left+25<ClientRectangle.Width-ship.Width)
                ship.Left += 25;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (endGameBool == true) {
                    startGame();
                } else {
                    if (shooting == false) {
                        PictureBox newArrow = makeArrow(ship.Left + ship.Width / 2, ship.Top);
                        if(arrowList is null) {
                            arrowList = new List<PictureBox>();
                        }
                        arrowList.Add(newArrow);
                        this.Controls.Add(this.arrowList.Last());
                    }
                }
            }
        }


        private void gameTimerTick(object sender, EventArgs e)
        {
            if (arrowList is null) { }
            else
            {
                foreach (PictureBox ar in arrowList)
                {
                    ar.Top -= arrowSpeed;
                    for (int x = 0; x < invaderArray.GetLength(0); x++)
                    {
                        for (int y = 0; y < invaderArray.GetLength(1); y++)
                        {
                            if (invaderArray[x, y].Visible == true && ar.Visible == true)
                            {
                                if (ar.Bounds.IntersectsWith(invaderArray[x, y].Bounds))
                                {
                                    invaderArray[x, y].Visible = false;
                                    ar.Visible = false;
                                    invadersDown++;
                                }

                            }
                        }

                    }
                }
            }
            if (invadersDown == invaderArray.Length)
            {
                endGame("win");
            }
            bool horizontalMovementAllowed = canLastMove(invaderMoveDirection);
            foreach (PictureBox invader in invaderArray)
            {
                if (invader.Visible == true) {
                    if (invader.Top +invader.Height >= ship.Top) {
                        endGame("Lose");
                    }
                    if (horizontalMovementAllowed == true) {
                        invader.Left += invaderSpeed * invaderMoveDirection;
                    } else {
                        invader.Top += invaderSpeed;
                    }
                }
            }
            invaderMoveDirection *= horizontalMovementAllowed ? (sbyte)1 : (sbyte)-1;
            if (invadersDown > 5) {
                invaderSpeed = 7;
            } else if (invadersDown > 10) {
                invaderSpeed = 11;
            } else if (invadersDown > 15) {
                invaderSpeed = 15;
            }
            
        }

        private void endGame(string state)
        {
            gameTimer.Stop();
            endGameBool = true;
            invadersDown = 0;
            foreach(PictureBox ar in arrowList) {
                ar.Visible = false;
            }
            foreach(PictureBox invader in invaderArray)
            {
                invader.Visible = false;
            }
            arrowList.Clear();

        if(state == "win") {
                MessageBox.Show("Congrats, you win!");
            } else {
                MessageBox.Show("Boooooooooo! Try again!");
            }
        }

        private PictureBox makeInvader(int x, int y)
        {
            PictureBox newInvader = new PictureBox();
            newInvader.Left = 12 + 175 * x;
            newInvader.Top = 12 + 85 * y;
            newInvader.Image = Resources.invader;
            newInvader.Width = 100;
            newInvader.Height = 70;
            newInvader.SizeMode = PictureBoxSizeMode.StretchImage;
            newInvader.Visible = true;
            newInvader.Enabled = true;
            newInvader.BringToFront();
            return newInvader;

        }

        private PictureBox makeArrow(int x, int y)
        {
            PictureBox newArrow = new PictureBox();
            newArrow.Left = x - 8;
            newArrow.Top = y;
            newArrow.Image = Resources.arrow_black_background;
            newArrow.Width = 16;
            newArrow.Height = 30;
            newArrow.SizeMode = PictureBoxSizeMode.StretchImage;
            newArrow.Visible = true;
            newArrow.Enabled = true;
            return newArrow;
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                shooting = false;
            }
        }
        
        private bool canLastMove(sbyte direction)
        {
            //finding the first and last column that still has invaders
            int minX = 99, maxX =0, minY=0, maxY=0;
            for(int x = 0; x< invaderArray.GetLength(0); x++) {
                for(int y = 0; y < invaderArray.GetLength(1); y++) {
                    if (invaderArray[x, y].Visible == true) {
                        if (minX > x) {
                            minX = x;
                            minY = y;
                        }
                        if (maxX < x)
                        {
                            maxX = x;
                            maxY = y;
                        }
                    }
                }
            }
            if (direction > 0) {
                //check if there's space to move to the right -> Left + direction
                return invaderArray[maxX,maxY].Left < (ClientRectangle.Width - invaderArray[maxX, maxY].Width)-invaderSpeed;
            } else { 
                //check if there's space to move to the left -> Left - direction
                return invaderArray[minX, minY].Left > invaderSpeed+5;
            }
        }
    
    }

    
    

}
