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
            btnJugarNueva = new Button();
            btnCargar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnJugarNueva
            // 
            btnJugarNueva.Location = new Point(158, 344);
            btnJugarNueva.Name = "btnJugarNueva";
            btnJugarNueva.Size = new Size(75, 23);
            btnJugarNueva.TabIndex = 0;
            btnJugarNueva.Text = "N Partida";
            btnJugarNueva.UseVisualStyleBackColor = true;
            btnJugarNueva.Click += btnJugarNueva_Click;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(158, 387);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(75, 23);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "C partid";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(161, 437);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSalir);
            Controls.Add(btnCargar);
            Controls.Add(btnJugarNueva);
            Name = "MenuUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
        }

        #endregion

        private Button btnJugarNueva;
        private Button btnCargar;
        private Button btnSalir;
    }
}
