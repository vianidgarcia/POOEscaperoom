namespace JuegoEscaperoom.Controles
{
    partial class PausaUC
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
            btnGuardar = new BotonJuego();
            btnMenuPrincipal = new BotonJuego();
            btnContinuar = new BotonJuego();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(5, 50, 116);
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Dogica Pixel", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(35, 43);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 72);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guarda";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.BackColor = Color.FromArgb(5, 50, 116);
            btnMenuPrincipal.FlatStyle = FlatStyle.Popup;
            btnMenuPrincipal.Font = new Font("Dogica Pixel", 9F, FontStyle.Bold);
            btnMenuPrincipal.ForeColor = SystemColors.ControlLightLight;
            btnMenuPrincipal.Location = new Point(35, 143);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(200, 71);
            btnMenuPrincipal.TabIndex = 1;
            btnMenuPrincipal.Text = "Menuprin";
            btnMenuPrincipal.UseVisualStyleBackColor = false;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.FromArgb(5, 50, 116);
            btnContinuar.FlatStyle = FlatStyle.Popup;
            btnContinuar.Font = new Font("Dogica Pixel", 9F, FontStyle.Bold);
            btnContinuar.ForeColor = SystemColors.ControlLightLight;
            btnContinuar.Location = new Point(35, 246);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(200, 71);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continua";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // PausaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 54, 159);
            BackgroundImageLayout = ImageLayout.None;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(btnContinuar);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(btnGuardar);
            DoubleBuffered = true;
            Name = "PausaUC";
            Size = new Size(274, 356);
            ResumeLayout(false);
        }

        #endregion

        private BotonJuego btnGuardar;
        private BotonJuego btnMenuPrincipal;
        private BotonJuego btnContinuar;
    }
}
