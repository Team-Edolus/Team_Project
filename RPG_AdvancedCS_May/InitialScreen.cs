using System;
using System.Windows.Forms;


namespace RPG_AdvancedCS_May
{
    public partial class InitialScreen : Form 
    {
        //deni code
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        
        //end deni code
        public InitialScreen()
        {
            InitializeComponent();
            //deni
            player.SoundLocation = "../../Resources/bgMusic.wav";
        }

        private void InitialScreen_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.FormClosed += new FormClosedEventHandler(gameWindow_FormClosed);
            this.Hide();
            gameWindow.Show();

            //deni
            player.Play();
        }

        void gameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Options_Click(object sender, EventArgs e)
        {
            FormOptions formOptions = new FormOptions();
            formOptions.Show();
        }

        private void BTN_Credits_Click(object sender, EventArgs e)
        {
            FormCredits formCredits = new FormCredits();
            formCredits.Show();
        }
    }
}
