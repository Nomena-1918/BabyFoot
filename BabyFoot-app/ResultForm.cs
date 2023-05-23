

using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BabyFoot_app
{
    public partial class ResultForm : Form
    {
        DateTime? dateMatch;
        string? nomJ1, nomJ2, vainqueur;
        decimal? mise1, mise2, valeurJeton, recompenseGagnant;
        int? score1, score2;


        public ResultForm()
        {
            InitializeComponent();
        }

        public void RetrieveData()
        {

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                connection.Open();


                // Selection date, valeurJeton du dernier match
                using (SqlCommand sqlCommand = new SqlCommand("select * from v_lastMatchComp", connection))
                {

                    sqlCommand.ExecuteNonQuery();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        valeurJeton = (int)reader["valeurJeton"];
                        dateMatch = (DateTime)reader["dateMatch"];
                    }
                    reader.Close();

                }

                // Selection mises des joueurs du dernier match
                using (SqlCommand sqlCommand = new SqlCommand("select * from v_miseJoueurDernierMatch", connection))
                {
                    sqlCommand.ExecuteNonQuery();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        mise1 = (int)reader["miseJoueur"];
                    }

                    if (reader.Read())
                    {
                        mise2 = (int)reader["miseJoueur"];
                    }
                    reader.Close();

                }

                // Selection score des joueurs du dernier match
                using (SqlCommand sqlCommand = new SqlCommand("select * from v_score", connection))
                {
                    sqlCommand.ExecuteNonQuery();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        score1 = (int)reader["nbButs"];
                        nomJ1 = (string)reader["nom"];
                    }

                    if (reader.Read())
                    {
                        score2 = (int)reader["nbButs"];
                        nomJ2 = (string)reader["nom"];
                    }
                    reader.Close();
                }

                recompenseGagnant = mise1 + mise2 - valeurJeton;

                if (score1 > score2)
                {
                    vainqueur = nomJ1;
                }
                else if (score1 < score2)
                {
                    vainqueur = nomJ2;
                }
                else
                {
                    vainqueur = "aucun";
                }

                connection.Close();
            }
        }

        public void BindLabel()
        {
            label_dateMatch.Text = dateMatch.ToString();
            label_scoreJ1.Text = score1.ToString();
            label_scoreJ2.Text = score2.ToString();
            label_nomJ1.Text = nomJ1;
            label_nomJ2.Text = nomJ2;
            label_mise1.Text = mise1.ToString();
            label_mise2.Text = mise2.ToString();
            label_valJeton.Text = valeurJeton.ToString();
            label_valVainqueur.Text = vainqueur;
            label_recompGagnant.Text = recompenseGagnant.ToString();

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            RetrieveData();
            BindLabel();
        }
    }
}
