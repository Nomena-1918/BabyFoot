namespace BabyFoot_app
{
    partial class Terrain
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
            Fin_match = new Button();
            SuspendLayout();
            // 
            // Fin_match
            // 
            Fin_match.Location = new Point(694, 12);
            Fin_match.Name = "Fin_match";
            Fin_match.Size = new Size(94, 29);
            Fin_match.TabIndex = 0;
            Fin_match.Text = "Fin match";
            Fin_match.UseVisualStyleBackColor = true;
            Fin_match.Click += Fin_match_Click;
            // 
            // Terrain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Fin_match);
            Name = "Terrain";
            Text = "Terrain";
            ResumeLayout(false);
        }

        #endregion

        private Button Fin_match;
    }
}