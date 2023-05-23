using System.Data.SqlClient;

namespace BabyFoot_app
{
    public partial class MatchForm : Form
    {
        // Etat de jeu
        int? idMatch;
        int? idJ1;
        int? idJ2;
        int score1 = 1;
        int score2 = 0;

        // Gameplay
        // Size variables
        int yTerrainMax;
        int yTerrainMin;
        int xTerrainMax;
        int xTerrainMin;

        int centerPoint;
        int xMidPoint;
        int yMidPoint;

        // Equipes
        Color colorJ1_1 = Color.BlueViolet;
        Color colorJ1_2 = Color.Blue;

        Color colorJ2_1 = Color.Firebrick;
        Color colorJ2_2 = Color.Orange;

        // Joueur sélectionné
        PictureBox? JoueurSelect;
        int JoueurXCoordinate = 5;
        int JoueurYCoordinate = 5;

        bool JoueurDirecHaut = false;
        bool JoueurDirecBas = false;
        bool JoueurDirecGauche = false;
        bool JoueurDirecDroite = false;

        // Conduite de balle
        bool isBallPoss = false;
        int positionInitBall;

        // Envoi balle
        int BallXCoordinate = 5;
        int BallYCoordinate = 5;
        bool BallDirecHaut = false;
        bool BallDirecBas = false;
        bool BallDirecGauche = false;
        bool BallDirecDroite = false;


        public MatchForm(int? idMatch, int? idJ1, int? idJ2, string? nomJ1, string? nomJ2)
        {
            this.idMatch = idMatch;
            this.idJ1 = idJ1;
            this.idJ2 = idJ2;

            InitializeComponent();

            positionInitBall = pictureBox_ball.Left;

            // Permettre l'écoute des touches même si le focus n'est pas sur la fenêtre
            KeyPreview = true;


            yTerrainMin = 10;
            yTerrainMax = ClientSize.Height - panel_score.Height - 10;
            xTerrainMin = 10;
            xTerrainMax = ClientSize.Width - 10;

            xMidPoint = xTerrainMax / 2;
            yMidPoint = yTerrainMax / 2;

            label_nomJ1.Text = nomJ1;
            label_nomJ2.Text = nomJ2;
            label_scoreJ1.Text = "" + score1;
            label_scoreJ2.Text = "" + score2;

        }

        private void btnFin_match_Click(object sender, EventArgs e)
        {

            // Insertion du score en un seul coup
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("insert into ActionFoot(idM, idJ, typeAction, valeur ,dateAction) values (@idM, @idJ1, default, @nbrBut1, default), (@idM, @idJ2, default, @nbrBut2, default)", connection))
                {

                    sqlCommand.Parameters.AddWithValue("@idM", idMatch);
                    sqlCommand.Parameters.AddWithValue("@idJ1", idJ1);
                    sqlCommand.Parameters.AddWithValue("@idJ2", idJ2);
                    sqlCommand.Parameters.AddWithValue("@nbrBut1", score1);
                    sqlCommand.Parameters.AddWithValue("@nbrBut2", score2);
                    sqlCommand.ExecuteNonQuery();

                }

                connection.Close();
            }

            MessageBox.Show("Match terminé !");

            ResultForm res = new();
            res.Show();
            Hide();
        }

        private void timer_fifa_Tick(object sender, EventArgs e)
        {

                // HAUT
                if (BallDirecHaut)
                {
                    pictureBox_ball.Top -= BallYCoordinate;

                }

                // BAS
                if (BallDirecBas && pictureBox_ball.Top + pictureBox_ball.Height < yTerrainMax)
                {
                    pictureBox_ball.Top += BallYCoordinate;

                }

                // GAUCHE
                if (BallDirecGauche && pictureBox_ball.Left > xTerrainMin)
                {
                    pictureBox_ball.Left -= BallXCoordinate;

                }
                // DROITE
                if (BallDirecDroite && pictureBox_ball.Left + pictureBox_ball.Width < xTerrainMax)
                {
                    pictureBox_ball.Left += BallXCoordinate;

                }

        



            // Mvt Joueur
            if (JoueurSelect != null)
            {
                if (JoueurSelect.Bounds.IntersectsWith(pictureBox_ball.Bounds))
                {
                    isBallPoss = true;
                     BallDirecHaut = false;
                     BallDirecBas = false;
                     BallDirecGauche = false;
                     BallDirecDroite = false;
                }

                // HAUT
                if (JoueurDirecHaut && JoueurSelect.Top > yTerrainMin)
                {
                    JoueurSelect.Top -= JoueurYCoordinate;
                }

                // BAS
                if (JoueurDirecBas && JoueurSelect.Top + JoueurSelect.Height < yTerrainMax)
                {
                    JoueurSelect.Top += JoueurYCoordinate;
                }

                // GAUCHE
                if (JoueurDirecGauche && JoueurSelect.Left > xTerrainMin)
                {
                    JoueurSelect.Left -= JoueurXCoordinate;
                }

                // DROITE
                if (JoueurDirecDroite && JoueurSelect.Left + JoueurSelect.Width < xTerrainMax)
                {
                    JoueurSelect.Left += JoueurXCoordinate;
                }

                // Mvt ballon

                if (isBallPoss)
                {

                    // Conduite de balle
                    if (positionInitBall >= JoueurSelect.Left && pictureBox_ball.Width < xTerrainMax && pictureBox_ball.Height < yTerrainMax)
                    {
                        pictureBox_ball.Top = JoueurSelect.Top - 10;
                        pictureBox_ball.Left = JoueurSelect.Left - 15;
                    }
                    if (positionInitBall < JoueurSelect.Left && pictureBox_ball.Width < xTerrainMax && pictureBox_ball.Height < yTerrainMax)
                    {
                        pictureBox_ball.Top = JoueurSelect.Top + pictureBox_ball.Height + 10;
                        pictureBox_ball.Left = JoueurSelect.Left + pictureBox_ball.Width - 15;
                    }
                }

            }
        }



        private void changeColor(PictureBox pictureBox)
        {
            if (pictureBox.BackColor == colorJ1_1)
            {
                pictureBox.BackColor = colorJ1_2;
            }
            else if (pictureBox.BackColor == colorJ1_2)
            {
                pictureBox.BackColor = colorJ1_1;
            }
            else if (pictureBox.BackColor == colorJ2_1)
            {
                pictureBox.BackColor = colorJ2_2;
            }
            else
            {
                pictureBox.BackColor = colorJ2_1;
            }
        }

        // Click sur un joueur
        private void pictureBox_J_Click(object sender, EventArgs e)
        {
            if (JoueurSelect != null)
            {
                changeColor(JoueurSelect);
                JoueurSelect = null;
            }

            PictureBox joueur = (PictureBox)sender;
            changeColor(joueur);
            JoueurSelect = joueur;
        }

        private void MatchForm_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show($"KeyUp code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + "\r\n");

            //JOUEUR
            // KeyUp -> JoueurSelect monte
            if (e.KeyCode == Keys.U)
            {
                //  MessageBox.Show($"KeyUp code: {e.KeyCode}");
                JoueurDirecHaut = true;
            }

            // KeyDown -> JoueurSelect descend
            if (e.KeyCode == Keys.N)
            {
                JoueurDirecBas = true;
            }

            // KeyRight -> JoueurSelect va à droite
            if (e.KeyCode == Keys.K)
            {
                JoueurDirecDroite = true;
            }

            // KeyLeft -> JoueurSelect va à gauche
            if (e.KeyCode == Keys.H)
            {
                JoueurDirecGauche = true;
            }

            if (isBallPoss)
            {
                // BALLON
                // KeyUp -> Ball monte
                if (e.KeyCode == Keys.E)
                {
                    BallDirecHaut = true;
                    BallDirecBas = false;
                    BallDirecGauche = false;
                    BallDirecDroite = false;
                }

                // KeyDown -> Ball descend
                if (e.KeyCode == Keys.X)
                {
                    BallDirecHaut = false;
                    BallDirecBas = true;
                    BallDirecGauche = false;
                    BallDirecDroite = false;
                }

                // KeyRight -> Ball va à droite
                if (e.KeyCode == Keys.F)
                {
                    BallDirecHaut = false;
                    BallDirecBas = false;
                    BallDirecGauche = false;
                    BallDirecDroite = true;

                }

                // KeyLeft -> Ball va à gauche
                if (e.KeyCode == Keys.S)
                {
                    BallDirecHaut = false;
                    BallDirecBas = false;
                    BallDirecGauche = true;
                    BallDirecDroite = false;

                }
                isBallPoss = false;

            }

        }

        private void MatchForm_KeyUp(object sender, KeyEventArgs e)
        {
            // JOUEUR
            // KeyUp -> JoueurSelect monte
            if (e.KeyCode == Keys.U)
            {
                JoueurDirecHaut = false;
            }

            // KeyDown -> JoueurSelect descend
            if (e.KeyCode == Keys.N)
            {
                JoueurDirecBas = false;
            }

            // KeyRight -> JoueurSelect va à droite
            if (e.KeyCode == Keys.K)
            {
                JoueurDirecDroite = false;
            }

            // KeyLeft -> JoueurSelect va à gauche
            if (e.KeyCode == Keys.H)
            {
                JoueurDirecGauche = false;
            }
        }
    }
}