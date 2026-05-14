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
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxSprite).BeginInit();
            SuspendLayout();
            // 
            // pbxSprite
            // 
            pbxSprite.BackColor = Color.Transparent;
            pbxSprite.Location = new Point(653, 72);
            pbxSprite.Name = "pbxSprite";
            pbxSprite.Size = new Size(345, 626);
            pbxSprite.TabIndex = 0;
            pbxSprite.TabStop = false;
            pbxSprite.Click += pbxSprite_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(20, 21);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(103, 61);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "Volv";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // ZonaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnVolver);
            Controls.Add(pbxSprite);
            Name = "ZonaUC";
            Size = new Size(1368, 788);
            ((System.ComponentModel.ISupportInitialize)pbxSprite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxSprite;
        private Button btnVolver;
    }
}
