using System;
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
    }


}

