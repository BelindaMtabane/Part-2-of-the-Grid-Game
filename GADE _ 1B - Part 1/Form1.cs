namespace GADE___1B___Part_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int userXValue;
            int userYValue;
            Position position = new Position(userXValue, userYValue);
            position.X_Coordinate();
            position.Y_Coordinate();


        }
    }
}
