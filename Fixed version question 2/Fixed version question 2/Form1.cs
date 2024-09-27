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
            GameEngine engine = new GameEngine(gameLvls);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int userXValue = 0;
            int userYValue = 0;
            int positionParameter = 0;
            Position position = new Position(userXValue, userYValue);
            position.X_Coordinate();
            position.Y_Coordinate();
            EmptyTile emptyTile = new EmptyTile(positionParameter);
            //emptyTile.Display();

            //int gameLvls = 0;
            //GameEngine gameEngine = new GameEngine(gameLvls);
            //gameEngine.ToString();
        }
        public void UpdateDisplay()
        {
            //engine = ToString(lblDisplay);

        }
    }


}

