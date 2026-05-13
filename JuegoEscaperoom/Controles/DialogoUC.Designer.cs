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
            pbxSprite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxSprite).BeginInit();
            SuspendLayout();
            // 
            // lblDialogo
            // 
            lblDialogo.Anchor = AnchorStyles.Bottom;
            lblDialogo.AutoSize = true;
            lblDialogo.Font = new Font("FOT-Rodin Pro B", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblDialogo.ForeColor = SystemColors.ButtonHighlight;
            lblDialogo.Location = new Point(91, 434);
            lblDialogo.Name = "lblDialogo";
            lblDialogo.Size = new Size(89, 29);
            lblDialogo.TabIndex = 1;
            lblDialogo.Text = "Dialog";
            // 
            // pbxSprite
            // 
            pbxSprite.Dock = DockStyle.Fill;
            pbxSprite.Location = new Point(0, 0);
            pbxSprite.Name = "pbxSprite";
            pbxSprite.Size = new Size(960, 540);
            pbxSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxSprite.TabIndex = 2;
            pbxSprite.TabStop = false;
            // 
            // DialogoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblDialogo);
            Controls.Add(pbxSprite);
            Name = "DialogoUC";
            Size = new Size(960, 540);
            ((System.ComponentModel.ISupportInitialize)pbxSprite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDialogo;
        private PictureBox pbxSprite;
    }
}
