namespace JuegoEscaperoom.Controles
{
    partial class ZonaUC
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
            pbxSprite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxSprite).BeginInit();
            SuspendLayout();
            // 
            // pbxPersonaje
            // 
            pbxSprite.Location = new Point(316, 189);
            pbxSprite.Name = "pbxPersonaje";
            pbxSprite.Size = new Size(378, 756);
            pbxSprite.TabIndex = 0;
            pbxSprite.TabStop = false;
            // 
            // ZonaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbxSprite);
            Name = "ZonaUC";
            Size = new Size(1920, 1080);
            ((System.ComponentModel.ISupportInitialize)pbxSprite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxSprite;
    }
}
