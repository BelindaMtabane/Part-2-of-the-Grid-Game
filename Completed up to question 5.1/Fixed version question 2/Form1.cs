using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fixed_version_question_2
{
    public partial class Form1 : Form
    {
        private GameEngine engine;
        public Form1()
        {
            InitializeComponent();
            int gameLvls = 10;
            //Initialize the instance varivble 
            engine = new GameEngine(gameLvls);

            //Call the method to hold the function to display
            UpdateDisplay();

            // Enable keyboard input
            this.KeyPreview = true;

            btnUp.Click += btnUp_Click;
            btnDown.Click += btnDown_Click;
            btnLeft.Click += btnLeft_Click;
            btnRight.Click += btnRight_Click;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize the variables that would be used for the tile of the game
            int xValue = 12;
            int yValue = 8;
            //int positionParameter = 0;
            //int xCoordinate = 12;
            //int yCoordinate = 8;
            int gameLvls = 10;

            //Initialiaze the position object 
            //Position position = new(xValue, yValue);

            //Initialize the emptyTile object
            //EmptyTile emptyTile;

            //Initialize the object
            //WallTile wallTile = new(positionParameter, xCoordinate, yCoordinate);

            GameEngine gameEngine = new GameEngine(gameLvls);
        }
 
        public void UpdateDisplay()
        {
            //Set the label to a string message
            lblDisplay.Text = engine.ToString();

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveHero(Level.Direction.Up);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveHero(Level.Direction.Left);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveHero(Level.Direction.Down);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveHero(Level.Direction.Right);

        }
        private void MoveHero(Level.Direction direction)
        {
            engine.TriggerMovement(direction);
            UpdateDisplay();
        }
    }


}

 