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
            btnVolver = new Button();
            btnCargar = new Button();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lvPartidas
            // 
            lvPartidas.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lvPartidas.Location = new Point(54, 47);
            lvPartidas.Name = "lvPartidas";
            lvPartidas.Size = new Size(1261, 573);
            lvPartidas.TabIndex = 0;
            lvPartidas.UseCompatibleStateImageBehavior = false;
            lvPartidas.View = View.List;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(68, 671);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 1;
            btnVolver.Text = "vol";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(525, 671);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 2;
            btnCargar.Text = "carg";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(796, 671);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "elim";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // CargarPartidaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEliminar);
            Controls.Add(btnCargar);
            Controls.Add(btnVolver);
            Controls.Add(lvPartidas);
            Name = "CargarPartidaUC";
            Size = new Size(1368, 788);
            Load += CargarPartidaUC_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvPartidas;
        private Button btnVolver;
        private Button btnCargar;
        private Button btnEliminar;
    }
}
