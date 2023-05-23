using System.Data.SqlClient;

namespace BabyFoot_app
{
    public partial class MatchForm : Form
    {
        // Etat de jeu
        int? idMatch;
        int? idJ1;
        int? idJ2;
        int score1 = 0;
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
        Color colorDef1 = Color.DarkBlue;
        Color colorAtt1 = Color.Blue;

        Color colorDef1S = Color.RoyalBlue;
        Color colorAtt1S = Color.DodgerBlue;

        /// <summary>
        /// ////////
        /// </summary>

        Color colorDef2 = Color.DarkRed;
        Color colorAtt2 = Color.Firebrick;

        Color colorDef2S = Color.Red;
        Color colorAtt2S = Color.LightCoral;

        Color colorJoueurSelect;


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
        int BallXCoordinate = 10;
        int BallYCoordinate = 10;
        bool BallDirecHaut = false;
        bool BallDirecBas = false;
        bool BallDirecGauche = false;
        bool BallDirecDroite = false;
        int poss = 0;

        // Restriction de mouvement
        int zoneDefGauche;
        int milieuDeTerrain;
        int zoneDefDroite;

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

            milieuDeTerrain = xMidPoint;
            zoneDefDroite = pictureBox_zoneDefDdroite.Left;
            zoneDefGauche = pictureBox_zoneDefGauche.Left;

            label_nomJ1.Text = nomJ1;
            label_nomJ2.Text = nomJ2;
            label_scoreJ1.Text = "" + score1;
            label_scoreJ2.Text = "" + score2;

        }

        private void changeColor(PictureBox pictureBox)
        {
            if (pictureBox.BackColor == colorDef1)
            {
                pictureBox.BackColor = colorDef1S;
            }

            else if (pictureBox.BackColor == colorDef1S)
            {
                pictureBox.BackColor = colorDef1;
            }






            else if (pictureBox.BackColor == colorAtt1)
            {
                pictureBox.BackColor = colorAtt1S;
            }

            else if (pictureBox.BackColor == colorAtt1S)
            {
                pictureBox.BackColor = colorAtt1;
            }





            else if (pictureBox.BackColor == colorDef2)
            {
                pictureBox.BackColor = colorDef2S;
            }

            else if (pictureBox.BackColor == colorAtt2)
            {
                pictureBox.BackColor = colorAtt2S;
            }





            else if (pictureBox.BackColor == colorDef2S)
            {
                pictureBox.BackColor = colorDef2;
            }

            else if (pictureBox.BackColor == colorAtt2S)
            {
                pictureBox.BackColor = colorAtt2;
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
            else
            {
                PictureBox joueur = (PictureBox)sender;
                changeColor(joueur);
                colorJoueurSelect = joueur.BackColor;
                JoueurSelect = joueur;
            }
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
            boolSelect.Text = (JoueurSelect != null).ToString();

            if (pictureBox_ball.Bounds.IntersectsWith(pictureBox_but1.Bounds))
            {

                pictureBox_ball.Location = new Point(xMidPoint, yMidPoint);

                timer_ball.Stop();
                score2++;
                label_scoreJ1.Text = "" + score1;
                label_scoreJ2.Text = "" + score2;

                poss = 1;
            }



            if (pictureBox_ball.Bounds.IntersectsWith(pictureBox_but2.Bounds))
            {

                pictureBox_ball.Location = new Point(xMidPoint, yMidPoint);
                timer_ball.Stop();
                score1++;
                label_scoreJ1.Text = "" + score1;
                label_scoreJ2.Text = "" + score2;
                poss = 1;
            }



            // Mvt Joueur

            if (JoueurSelect != null)
            {
                if (JoueurSelect.Bounds.IntersectsWith(pictureBox_ball.Bounds))
                {
                    timer_ball.Stop();
                    BallDirecHaut = false;
                    BallDirecBas = false;
                    BallDirecGauche = false;
                    BallDirecDroite = false;

                    poss = 0;

                    isBallPoss = true;
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
                // Restriction distance
                // DEF
                if (colorJoueurSelect == colorDef1S)
                {

                    yTerrainMin = 10;
                    xTerrainMin = 10;
                    xTerrainMax = ClientSize.Width - 10;


                    xTerrainMax = milieuDeTerrain;


                }

                if (colorJoueurSelect == colorDef2S)
                {

                    yTerrainMin = 10;
                    yTerrainMax = ClientSize.Height - panel_score.Height - 10;
                    xTerrainMax = ClientSize.Width - 10;


                    xTerrainMin = milieuDeTerrain;


                }


                // ATT
                if (colorJoueurSelect == colorAtt1S)
                {

                    yTerrainMin = 10;
                    yTerrainMax = ClientSize.Height - panel_score.Height - 10;
                    xTerrainMax = ClientSize.Width - 10;



                    xTerrainMin = zoneDefGauche;


                }

                if (colorJoueurSelect == colorAtt2S)
                {

                    yTerrainMin = 10;
                    yTerrainMax = ClientSize.Height - panel_score.Height - 10;
                    xTerrainMin = 10;


                    xTerrainMax = zoneDefDroite;


                }






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

                if (isBallPoss && poss == 0)
                {
                    timer_ball.Stop();
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
                    //MessageBox.Show("La balle monte");
                    BallDirecHaut = true;
                    BallDirecBas = false;
                    BallDirecGauche = false;
                    BallDirecDroite = false;
                    isBallPoss = false;
                    poss = 1;

                    pictureBox_ball.Location = new Point(pictureBox_ball.Location.X, pictureBox_ball.Location.Y - 2 * pictureBox_ball.Height);

                    timer_ball.Start();
                }

                // KeyDown -> Ball descend
                if (e.KeyCode == Keys.X)
                {
                    BallDirecHaut = false;
                    BallDirecBas = true;
                    BallDirecGauche = false;
                    BallDirecDroite = false;
                    poss = 1;


                    pictureBox_ball.Location = new Point(pictureBox_ball.Location.X, pictureBox_ball.Location.Y + 2 * pictureBox_ball.Height);

                    isBallPoss = false;
                    timer_ball.Start();
                }

                // KeyRight -> Ball va à droite
                if (e.KeyCode == Keys.F)
                {
                    BallDirecHaut = false;
                    BallDirecBas = false;
                    BallDirecGauche = false;
                    BallDirecDroite = true;
                    poss = 1;


                    pictureBox_ball.Location = new Point(pictureBox_ball.Location.X + 2 * pictureBox_ball.Width, pictureBox_ball.Location.Y);


                    timer_ball.Start();
                }

                // KeyLeft -> Ball va à gauche
                if (e.KeyCode == Keys.S)
                {
                    BallDirecHaut = false;
                    BallDirecBas = false;
                    BallDirecGauche = true;
                    BallDirecDroite = false;
                    poss = 1;


                    pictureBox_ball.Location = new Point(pictureBox_ball.Location.X - 2 * pictureBox_ball.Width, pictureBox_ball.Location.Y);


                    timer_ball.Start();
                    isBallPoss = false;
                }
                //JoueurSelect = null;
                //poss = 1;
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

        private void timer_ball_Tick(object sender, EventArgs e)
        {

            boolSelect.Text = (JoueurSelect != null).ToString();

            // HAUT
            if (BallDirecHaut && pictureBox_ball.Top > yTerrainMin)
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


        }
    }
}