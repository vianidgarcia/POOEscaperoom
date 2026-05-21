namespace JuegoEscaperoom.Controles
{
    partial class DialogoUC
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblDialogo = new Label();
            pnlDialogo = new Panel();
            pbxHudBarra = new PictureBox();
            pbxHudDatos = new PictureBox();
            pbxSprite = new PictureBox();
            pnlDialogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxHudBarra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHudDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxSprite).BeginInit();
            SuspendLayout();
            // 
            // lblDialogo
            // 
            lblDialogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDialogo.BackColor = SystemColors.ActiveCaptionText;
            lblDialogo.Font = new Font("FOT-Rodin Pro B", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblDialogo.ForeColor = SystemColors.ButtonHighlight;
            lblDialogo.Location = new Point(16, 15);
            lblDialogo.Name = "lblDialogo";
            lblDialogo.Size = new Size(1206, 142);
            lblDialogo.TabIndex = 1;
            lblDialogo.Text = "Dialog";
            // 
            // pnlDialogo
            // 
            pnlDialogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDialogo.AutoSize = true;
            pnlDialogo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlDialogo.BackColor = SystemColors.ActiveCaptionText;
            pnlDialogo.Controls.Add(lblDialogo);
            pnlDialogo.Cursor = Cursors.Hand;
            pnlDialogo.Location = new Point(122, 613);
            pnlDialogo.Name = "pnlDialogo";
            pnlDialogo.Size = new Size(1244, 175);
            pnlDialogo.TabIndex = 2;
            // 
            // pbxHudBarra
            // 
            pbxHudBarra.Image = Properties.Resources.HUDbarra;
            pbxHudBarra.Location = new Point(0, 0);
            pbxHudBarra.Name = "pbxHudBarra";
            pbxHudBarra.Size = new Size(255, 788);
            pbxHudBarra.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxHudBarra.TabIndex = 3;
            pbxHudBarra.TabStop = false;
            // 
            // pbxHudDatos
            // 
            pbxHudDatos.Image = Properties.Resources.HUDdatos;
            pbxHudDatos.Location = new Point(957, 0);
            pbxHudDatos.Name = "pbxHudDatos";
            pbxHudDatos.Size = new Size(409, 145);
            pbxHudDatos.SizeMode = PictureBoxSizeMode.Zoom;
            pbxHudDatos.TabIndex = 4;
            pbxHudDatos.TabStop = false;
            // 
            // pbxSprite
            // 
            pbxSprite.Location = new Point(0, 0);
            pbxSprite.Name = "pbxSprite";
            pbxSprite.Size = new Size(1366, 788);
            pbxSprite.SizeMode = PictureBoxSizeMode.Zoom;
            pbxSprite.TabIndex = 5;
            pbxSprite.TabStop = false;
            // 
            // DialogoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(pnlDialogo);
            Controls.Add(pbxHudDatos);
            Controls.Add(pbxHudBarra);
            Controls.Add(pbxSprite);
            DoubleBuffered = true;
            Name = "DialogoUC";
            Size = new Size(1366, 788);
            pnlDialogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxHudBarra).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHudDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxSprite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDialogo;
        private Panel pnlDialogo;
        private PictureBox pbxHudBarra;
        private PictureBox pbxHudDatos;
        private PictureBox pbxSprite;
    }
}
