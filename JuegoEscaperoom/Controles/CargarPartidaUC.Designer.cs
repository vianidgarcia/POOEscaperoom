namespace JuegoEscaperoom.Controles
{
    partial class CargarPartidaUC
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
            lvPartidas = new ListView();
            btnVolver = new BotonJuego();
            btnCargar = new BotonJuego();
            btnEliminar = new BotonJuego();
            SuspendLayout();
            // 
            // lvPartidas
            // 
            lvPartidas.BackColor = SystemColors.InactiveCaption;
            lvPartidas.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvPartidas.Location = new Point(67, 47);
            lvPartidas.Name = "lvPartidas";
            lvPartidas.Size = new Size(1219, 573);
            lvPartidas.TabIndex = 0;
            lvPartidas.UseCompatibleStateImageBehavior = false;
            lvPartidas.View = View.List;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(5, 50, 116);
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ControlLightLight;
            btnVolver.Location = new Point(62, 641);
            btnVolver.Margin = new Padding(0);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(171, 100);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "vol";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.FromArgb(5, 50, 116);
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnCargar.ForeColor = SystemColors.ControlLightLight;
            btnCargar.Location = new Point(629, 641);
            btnCargar.Margin = new Padding(0);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(171, 100);
            btnCargar.TabIndex = 2;
            btnCargar.Text = "carg";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(5, 50, 116);
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnEliminar.ForeColor = SystemColors.ControlLightLight;
            btnEliminar.Location = new Point(1115, 641);
            btnEliminar.Margin = new Padding(0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(171, 100);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "elim";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // CargarPartidaUC
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondomenu2;
            Controls.Add(btnEliminar);
            Controls.Add(btnCargar);
            Controls.Add(btnVolver);
            Controls.Add(lvPartidas);
            DoubleBuffered = true;
            Font = new Font("FOT-Rodin Pro B", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "CargarPartidaUC";
            Size = new Size(1363, 788);
            Load += CargarPartidaUC_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvPartidas;
        private BotonJuego btnVolver;
        private BotonJuego btnCargar;
        private BotonJuego btnEliminar;
    }
}
