namespace JuegoEscaperoom.Controles
{
    partial class MenuUC
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
            btnJugarNueva = new BotonJuego();
            btnCargar = new BotonJuego();
            btnSalir = new BotonJuego();
            cmbIdioma = new ComboBox();
            lblIdioma = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // btnJugarNueva
            // 
            btnJugarNueva.BackColor = Color.FromArgb(5, 50, 116);
            btnJugarNueva.FlatStyle = FlatStyle.Popup;
            btnJugarNueva.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnJugarNueva.ForeColor = SystemColors.ButtonHighlight;
            btnJugarNueva.Location = new Point(505, 270);
            btnJugarNueva.Margin = new Padding(0);
            btnJugarNueva.Name = "btnJugarNueva";
            btnJugarNueva.Size = new Size(391, 77);
            btnJugarNueva.TabIndex = 0;
            btnJugarNueva.Text = "N Partida";
            btnJugarNueva.UseVisualStyleBackColor = false;
            btnJugarNueva.Click += btnJugarNueva_Click;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.FromArgb(5, 50, 116);
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnCargar.ForeColor = SystemColors.ButtonHighlight;
            btnCargar.Location = new Point(505, 363);
            btnCargar.Margin = new Padding(0);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(391, 77);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "C partid";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(5, 50, 116);
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.Location = new Point(505, 457);
            btnSalir.Margin = new Padding(0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(391, 77);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbIdioma
            // 
            cmbIdioma.FormattingEnabled = true;
            cmbIdioma.Location = new Point(549, 554);
            cmbIdioma.Name = "cmbIdioma";
            cmbIdioma.Size = new Size(121, 23);
            cmbIdioma.TabIndex = 3;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.BackColor = Color.Transparent;
            lblIdioma.Location = new Point(505, 557);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(38, 15);
            lblIdioma.TabIndex = 4;
            lblIdioma.Text = "label1";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Dogica Pixel", 44F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.ForeColor = Color.FromArgb(254, 200, 2);
            lblTitulo.Location = new Point(397, 175);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(623, 59);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Escaperoom";
            // 
            // MenuUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.fondomenu2;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(lblTitulo);
            Controls.Add(lblIdioma);
            Controls.Add(cmbIdioma);
            Controls.Add(btnSalir);
            Controls.Add(btnCargar);
            Controls.Add(btnJugarNueva);
            DoubleBuffered = true;
            Name = "MenuUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BotonJuego btnJugarNueva;
        private BotonJuego btnCargar;
        private BotonJuego btnSalir;
        private ComboBox cmbIdioma;
        private Label lblIdioma;
        private Label lblTitulo;
    }
}
