namespace BabyFoot_app
{
    partial class ResultatsMatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Résumé_rencontre = new Label();
            SuspendLayout();
            // 
            // Résumé_rencontre
            // 
            Résumé_rencontre.AutoSize = true;
            Résumé_rencontre.Location = new Point(191, 84);
            Résumé_rencontre.Name = "Résumé_rencontre";
            Résumé_rencontre.Size = new Size(128, 20);
            Résumé_rencontre.TabIndex = 0;
            Résumé_rencontre.Text = "Résumé rencontre";
            Résumé_rencontre.Click += label1_Click;
            // 
            // ResulatsMatch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Résumé_rencontre);
            Name = "ResulatsMatch";
            Text = "Résultats match";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Résumé_rencontre;
    }
}