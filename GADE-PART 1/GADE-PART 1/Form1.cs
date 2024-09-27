using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_PART_1
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
            int gameLvls = 10;

            GameEngine gameEngine = new GameEngine(gameLvls);
        }

        public void UpdateDisplay()
        {
            //Set the label to a string message
            lblDisplay.Text = engine.ToString();
        }
    }
}
