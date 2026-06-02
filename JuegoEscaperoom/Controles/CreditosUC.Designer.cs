namespace JuegoEscaperoom.Controles
{
    partial class CreditosUC
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
            btnIrMenuPrincipal = new BotonJuego();
            lblGanaste = new Label();
            lblPuntuacion = new Label();
            SuspendLayout();
            // 
            // btnIrMenuPrincipal
            // 
            btnIrMenuPrincipal.B = 116;
            btnIrMenuPrincipal.BackColor = Color.FromArgb(5, 50, 116);
            btnIrMenuPrincipal.FlatStyle = FlatStyle.Popup;
            btnIrMenuPrincipal.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnIrMenuPrincipal.ForeColor = SystemColors.ButtonHighlight;
            btnIrMenuPrincipal.G = 50;
            btnIrMenuPrincipal.Location = new Point(570, 369);
            btnIrMenuPrincipal.Margin = new Padding(0);
            btnIrMenuPrincipal.Name = "btnIrMenuPrincipal";
            btnIrMenuPrincipal.R = 5;
            btnIrMenuPrincipal.Size = new Size(391, 77);
            btnIrMenuPrincipal.TabIndex = 0;
            btnIrMenuPrincipal.Text = "Menu";
            btnIrMenuPrincipal.UseVisualStyleBackColor = false;
            btnIrMenuPrincipal.Click += btnIrMenuPrincipal_Click;
            // 
            // lblGanaste
            // 
            lblGanaste.AutoSize = true;
            lblGanaste.BackColor = Color.Transparent;
            lblGanaste.Font = new Font("Dogica", 16F, FontStyle.Bold);
            lblGanaste.ForeColor = SystemColors.ButtonHighlight;
            lblGanaste.Location = new Point(268, 196);
            lblGanaste.Name = "lblGanaste";
            lblGanaste.Size = new Size(890, 22);
            lblGanaste.TabIndex = 8;
            lblGanaste.Text = "Selecciona en el mapa la zona a realizar";
            // 
            // lblPuntuacion
            // 
            lblPuntuacion.AutoSize = true;
            lblPuntuacion.BackColor = Color.Transparent;
            lblPuntuacion.Font = new Font("FOT-Rodin Pro B", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPuntuacion.ForeColor = SystemColors.ButtonHighlight;
            lblPuntuacion.Location = new Point(567, 244);
            lblPuntuacion.Name = "lblPuntuacion";
            lblPuntuacion.Size = new Size(74, 30);
            lblPuntuacion.TabIndex = 7;
            lblPuntuacion.Text = "frags";
            // 
            // CreditosUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = Properties.Resources.fondomenu2;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(lblGanaste);
            Controls.Add(lblPuntuacion);
            Controls.Add(btnIrMenuPrincipal);
            DoubleBuffered = true;
            Name = "CreditosUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BotonJuego btnIrMenuPrincipal;
        private Label lblGanaste;
        private Label lblPuntuacion;
    }
}
