using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BabyFoot_app
{
    public partial class ConfigMatch : Form
    {

        decimal? valeurMise1;
        decimal? valeurMise2;
        decimal? valeurJeton;
        DateTime dateDebutMatch; 
        int? idJ1;
        int? idJ2;
        string? nomJ1;
        string? nomJ2;

        public ConfigMatch()
        {
            InitializeComponent();
        }

        private void BindComboBox()
        {

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from joueur", con))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    sda.Fill(dt1);
                    DataTable dt2 = new DataTable();
                    sda.Fill(dt2);

                    comboBox_J1.ValueMember = "id";
                    comboBox_J1.DisplayMember = "nom";
                    comboBox_J1.DataSource = dt1;
                    comboBox_J1.DropDownStyle = ComboBoxStyle.DropDownList;

                    comboBox_J2.ValueMember = "id";
                    comboBox_J2.DisplayMember = "nom";
                    comboBox_J2.DataSource = dt2;
                    comboBox_J2.DropDownStyle = ComboBoxStyle.DropDownList;

                }
                con.Close();
            }

        }

        private void ConfigMatch_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }


        private bool IsValeursValid()
        {

            if (numericUpDown_valeurJeton.Value < 1 || numericUpDown_valeurMise1.Value < 1 || numericUpDown_valeurMise2.Value < 1)
            {
                MessageBox.Show("Valeurs invalides");
                return false;
            }

            if (comboBox_J1.SelectedItem == comboBox_J2.SelectedItem)
            {
                MessageBox.Show("Même joueur");
                return false;
            }


            else
            {

                int fid, fid2;

                Int32.TryParse(comboBox_J1.SelectedValue.ToString(), out fid);
                Int32.TryParse(comboBox_J2.SelectedValue.ToString(), out fid2);

                nomJ1 = comboBox_J1.Text;
                nomJ2 = comboBox_J2.Text;

                idJ1 = fid;
                idJ2 = fid2;
                valeurJeton = numericUpDown_valeurJeton.Value;
                valeurMise1 = numericUpDown_valeurMise1.Value;
                valeurMise2 = numericUpDown_valeurMise2.Value;

                return true;
            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            // Contrôle des valeurs
            if (!IsValeursValid())
            {
                return;
            }

            int idMatch=0;


            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                connection.Open();

                // Insertion du match dans la base 
                using (SqlCommand sqlCommand = new SqlCommand("insert into matchbabyfoot(idJ1, idJ2, valeurJeton ,dateMatch) values (@j1, @j2, @valJet, default);", connection))
                {
                    sqlCommand.Parameters.AddWithValue("@j1", idJ1);
                    sqlCommand.Parameters.AddWithValue("@j2", idJ2);
                    sqlCommand.Parameters.AddWithValue("@valJet", valeurJeton);
                    sqlCommand.ExecuteNonQuery();

                }



                // Selection id dernier match
                using (SqlCommand sqlCommand = new SqlCommand("select * from v_lastMatch", connection))
                {

                    sqlCommand.ExecuteNonQuery();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        idMatch = (int)reader["idLastMatch"];
                    }
                    reader.Close();

                }


                // Insertion des mises des joueurs
                using (SqlCommand sqlCommand = new SqlCommand("insert into Mise(idM, idJ, valeurMise) values (@idM, @idJ1, @valeurMise1), (@idM, @idJ2, @valeurMise2);", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@idJ1", idJ1);
                    sqlCommand.Parameters.AddWithValue("@idJ2", idJ2);
                    sqlCommand.Parameters.AddWithValue("@idM", idMatch);
                    sqlCommand.Parameters.AddWithValue("@valeurMise1", valeurMise1);
                    sqlCommand.Parameters.AddWithValue("@valeurMise2", valeurMise2);
                    sqlCommand.ExecuteNonQuery();

                }

                connection.Close();
            }


            MatchForm res = new(idMatch, idJ1, idJ2, nomJ1, nomJ2);
            res.Show();
           // Hide();

        }

    }
}
