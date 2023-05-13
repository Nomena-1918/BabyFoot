namespace BabyFoot_app
{
    public partial class MatchForm : Form
    {
        public MatchForm()
        {
            InitializeComponent();
        }

        private void btnFin_match_Click(object sender, EventArgs e)
        {
            ResultForm res = new ResultForm();
            res.Show();
            Hide();
        }
    }
}