namespace GADE___1B___Part_1
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

        }
        public void UpdateDisplay()
        {
            //Set the label to a string message
            lblDisplay.Text = engine.ToString();
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            
        }
    }
}
