namespace BabyFoot_app
{
    public partial class ConfigMatch : Form
    {
        public ConfigMatch()
        {
            InitializeComponent();
        }

        private void ConfigMatch_Load(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Terrain terrain = new Terrain();
            terrain.Show();
            Hide();
        }
    }
}