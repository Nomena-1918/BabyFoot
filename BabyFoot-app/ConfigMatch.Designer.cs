namespace BabyFoot_app
{
    partial class ConfigMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigMatch));
            label_valPerdant = new Label();
            label_perdant = new Label();
            label_valJeton = new Label();
            label_valMise = new Label();
            label_valVainqueur = new Label();
            label_jeton = new Label();
            label_mise1 = new Label();
            label_vainqueur = new Label();
            lbl_ResulMatch = new Label();
            button1 = new Button();
            numericUpDown_valeurMise1 = new NumericUpDown();
            numericUpDown_valeurJeton = new NumericUpDown();
            comboBox_J1 = new ComboBox();
            comboBox_J2 = new ComboBox();
            numericUpDown_valeurMise2 = new NumericUpDown();
            label1 = new Label();
            label_mise2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurMise1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurJeton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurMise2).BeginInit();
            SuspendLayout();
            // 
            // label_valPerdant
            // 
            label_valPerdant.AutoSize = true;
            label_valPerdant.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_valPerdant.Location = new Point(367, 168);
            label_valPerdant.Name = "label_valPerdant";
            label_valPerdant.Size = new Size(0, 28);
            label_valPerdant.TabIndex = 25;
            // 
            // label_perdant
            // 
            label_perdant.AutoSize = true;
            label_perdant.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label_perdant.Location = new Point(44, 168);
            label_perdant.Name = "label_perdant";
            label_perdant.Size = new Size(44, 30);
            label_perdant.TabIndex = 24;
            label_perdant.Text = "J2 :";
            // 
            // label_valJeton
            // 
            label_valJeton.AutoSize = true;
            label_valJeton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_valJeton.Location = new Point(367, 371);
            label_valJeton.Name = "label_valJeton";
            label_valJeton.Size = new Size(0, 28);
            label_valJeton.TabIndex = 20;
            // 
            // label_valMise
            // 
            label_valMise.AutoSize = true;
            label_valMise.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_valMise.Location = new Point(367, 241);
            label_valMise.Name = "label_valMise";
            label_valMise.Size = new Size(0, 28);
            label_valMise.TabIndex = 19;
            // 
            // label_valVainqueur
            // 
            label_valVainqueur.AutoSize = true;
            label_valVainqueur.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_valVainqueur.Location = new Point(367, 99);
            label_valVainqueur.Name = "label_valVainqueur";
            label_valVainqueur.Size = new Size(0, 28);
            label_valVainqueur.TabIndex = 18;
            // 
            // label_jeton
            // 
            label_jeton.AutoSize = true;
            label_jeton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label_jeton.Location = new Point(44, 371);
            label_jeton.Name = "label_jeton";
            label_jeton.Size = new Size(139, 30);
            label_jeton.TabIndex = 16;
            label_jeton.Text = "Valeur jeton :";
            // 
            // label_mise1
            // 
            label_mise1.AutoSize = true;
            label_mise1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label_mise1.Location = new Point(44, 241);
            label_mise1.Name = "label_mise1";
            label_mise1.Size = new Size(153, 30);
            label_mise1.TabIndex = 15;
            label_mise1.Text = "Valeur mise 1 :";
            // 
            // label_vainqueur
            // 
            label_vainqueur.AutoSize = true;
            label_vainqueur.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label_vainqueur.Location = new Point(44, 99);
            label_vainqueur.Name = "label_vainqueur";
            label_vainqueur.Size = new Size(44, 30);
            label_vainqueur.TabIndex = 14;
            label_vainqueur.Text = "J1 :";
            // 
            // lbl_ResulMatch
            // 
            lbl_ResulMatch.AutoSize = true;
            lbl_ResulMatch.Font = new Font("Arial", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ResulMatch.Location = new Point(112, 25);
            lbl_ResulMatch.Name = "lbl_ResulMatch";
            lbl_ResulMatch.Size = new Size(305, 30);
            lbl_ResulMatch.TabIndex = 13;
            lbl_ResulMatch.Text = "Configurations du match";
            // 
            // button1
            // 
            button1.Location = new Point(293, 444);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 30;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnValider_Click;
            // 
            // numericUpDown_valeurMise1
            // 
            numericUpDown_valeurMise1.Location = new Point(267, 247);
            numericUpDown_valeurMise1.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDown_valeurMise1.Name = "numericUpDown_valeurMise1";
            numericUpDown_valeurMise1.Size = new Size(150, 27);
            numericUpDown_valeurMise1.TabIndex = 31;
            // 
            // numericUpDown_valeurJeton
            // 
            numericUpDown_valeurJeton.Location = new Point(267, 377);
            numericUpDown_valeurJeton.Maximum = new decimal(new int[] { -1530494976, 232830, 0, 0 });
            numericUpDown_valeurJeton.Name = "numericUpDown_valeurJeton";
            numericUpDown_valeurJeton.Size = new Size(150, 27);
            numericUpDown_valeurJeton.TabIndex = 32;
            // 
            // comboBox_J1
            // 
            comboBox_J1.AllowDrop = true;
            comboBox_J1.FormattingEnabled = true;
            comboBox_J1.Location = new Point(267, 99);
            comboBox_J1.Name = "comboBox_J1";
            comboBox_J1.Size = new Size(151, 28);
            comboBox_J1.TabIndex = 33;
            // 
            // comboBox_J2
            // 
            comboBox_J2.FormattingEnabled = true;
            comboBox_J2.Location = new Point(267, 173);
            comboBox_J2.Name = "comboBox_J2";
            comboBox_J2.Size = new Size(151, 28);
            comboBox_J2.TabIndex = 34;
            // 
            // numericUpDown_valeurMise2
            // 
            numericUpDown_valeurMise2.Location = new Point(267, 311);
            numericUpDown_valeurMise2.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            numericUpDown_valeurMise2.Name = "numericUpDown_valeurMise2";
            numericUpDown_valeurMise2.Size = new Size(150, 27);
            numericUpDown_valeurMise2.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(367, 305);
            label1.Name = "label1";
            label1.Size = new Size(0, 28);
            label1.TabIndex = 36;
            // 
            // label_mise2
            // 
            label_mise2.AutoSize = true;
            label_mise2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label_mise2.Location = new Point(44, 305);
            label_mise2.Name = "label_mise2";
            label_mise2.Size = new Size(153, 30);
            label_mise2.TabIndex = 35;
            label_mise2.Text = "Valeur mise  2:";
            // 
            // ConfigMatch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 504);
            Controls.Add(numericUpDown_valeurMise2);
            Controls.Add(label1);
            Controls.Add(label_mise2);
            Controls.Add(comboBox_J2);
            Controls.Add(comboBox_J1);
            Controls.Add(numericUpDown_valeurJeton);
            Controls.Add(numericUpDown_valeurMise1);
            Controls.Add(button1);
            Controls.Add(label_valPerdant);
            Controls.Add(label_perdant);
            Controls.Add(label_valJeton);
            Controls.Add(label_valMise);
            Controls.Add(label_valVainqueur);
            Controls.Add(label_jeton);
            Controls.Add(label_mise1);
            Controls.Add(label_vainqueur);
            Controls.Add(lbl_ResulMatch);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigMatch";
            Text = "Configuration";
            Load += ConfigMatch_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurMise1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurJeton).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_valeurMise2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_valPerdant;
        private Label label_perdant;
        private Label label_valJeton;
        private Label label_valMise;
        private Label label_valVainqueur;
        private Label label_jeton;
        private Label label_mise1;
        private Label label_vainqueur;
        private Label lbl_ResulMatch;
        private Button button1;
        private NumericUpDown numericUpDown_valeurMise1;
        private NumericUpDown numericUpDown_valeurJeton;
        private ComboBox comboBox_J1;
        private ComboBox comboBox_J2;
        private NumericUpDown numericUpDown_valeurMise2;
        private Label label1;
        private Label label_mise2;
    }
}