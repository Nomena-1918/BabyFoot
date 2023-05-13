using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyFoot_app
{
    public partial class Terrain : Form
    {
        public Terrain()
        {
            InitializeComponent();
        }

        private void Fin_match_Click(object sender, EventArgs e)
        {
            ResultatsMatch res = new ResultatsMatch();
            res.Show();
            Hide();
        }
    }
}
