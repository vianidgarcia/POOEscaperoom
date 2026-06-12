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
            lbxScores = new ListBox();
            lblScores = new Label();
            SuspendLayout();
            // 
            // btnJugarNueva
            // 
            btnJugarNueva.B = 116;
            btnJugarNueva.BackColor = Color.FromArgb(5, 50, 116);
            btnJugarNueva.FlatStyle = FlatStyle.Popup;
            btnJugarNueva.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnJugarNueva.ForeColor = SystemColors.ButtonHighlight;
            btnJugarNueva.G = 50;
            btnJugarNueva.Location = new Point(731, 246);
            btnJugarNueva.Margin = new Padding(0);
            btnJugarNueva.Name = "btnJugarNueva";
            btnJugarNueva.R = 5;
            btnJugarNueva.Size = new Size(559, 103);
            btnJugarNueva.TabIndex = 0;
            btnJugarNueva.Text = "N Partida";
            btnJugarNueva.UseVisualStyleBackColor = false;
            btnJugarNueva.Click += btnJugarNueva_Click;
            // 
            // btnCargar
            // 
            btnCargar.B = 116;
            btnCargar.BackColor = Color.FromArgb(5, 50, 116);
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnCargar.ForeColor = SystemColors.ButtonHighlight;
            btnCargar.G = 50;
            btnCargar.Location = new Point(731, 370);
            btnCargar.Margin = new Padding(0);
            btnCargar.Name = "btnCargar";
            btnCargar.R = 5;
            btnCargar.Size = new Size(559, 103);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "C partid";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnSalir
            // 
            btnSalir.B = 116;
            btnSalir.BackColor = Color.FromArgb(5, 50, 116);
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.G = 50;
            btnSalir.Location = new Point(731, 495);
            btnSalir.Margin = new Padding(0);
            btnSalir.Name = "btnSalir";
            btnSalir.R = 5;
            btnSalir.Size = new Size(559, 103);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // cmbIdioma
            // 
            cmbIdioma.FormattingEnabled = true;
            cmbIdioma.Location = new Point(32, 99);
            cmbIdioma.Margin = new Padding(4);
            cmbIdioma.Name = "cmbIdioma";
            cmbIdioma.Size = new Size(171, 28);
            cmbIdioma.TabIndex = 3;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.BackColor = Color.Transparent;
            lblIdioma.Location = new Point(32, 66);
            lblIdioma.Margin = new Padding(4, 0, 4, 0);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(53, 20);
            lblIdioma.TabIndex = 4;
            lblIdioma.Text = "idiom";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Font = new Font("Dogica Pixel", 44F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.ForeColor = Color.FromArgb(254, 200, 2);
            lblTitulo.Location = new Point(685, 176);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(623, 59);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Escaperoom";
            // 
            // lbxScores
            // 
            lbxScores.Enabled = false;
            lbxScores.FormattingEnabled = true;
            lbxScores.ItemHeight = 20;
            lbxScores.Location = new Point(32, 331);
            lbxScores.Name = "lbxScores";
            lbxScores.Size = new Size(240, 344);
            lbxScores.TabIndex = 6;
            // 
            // lblScores
            // 
            lblScores.AutoSize = true;
            lblScores.BackColor = Color.Transparent;
            lblScores.Location = new Point(32, 300);
            lblScores.Margin = new Padding(4, 0, 4, 0);
            lblScores.Name = "lblScores";
            lblScores.Size = new Size(85, 20);
            lblScores.TabIndex = 7;
            lblScores.Text = "lblScores";
            // 
            // MenuUC
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.fondomenu2;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(lblScores);
            Controls.Add(lbxScores);
            Controls.Add(lblTitulo);
            Controls.Add(lblIdioma);
            Controls.Add(cmbIdioma);
            Controls.Add(btnSalir);
            Controls.Add(btnCargar);
            Controls.Add(btnJugarNueva);
            DoubleBuffered = true;
            Font = new Font("FOT-Rodin Pro B", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ButtonHighlight;
            Margin = new Padding(4);
            Name = "MenuUC";
            Size = new Size(1366, 768);
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
        private ListBox lbxScores;
        private Label lblScores;
    }
}
