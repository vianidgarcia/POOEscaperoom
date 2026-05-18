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
            btnGuardar = new Button();
            btnMenuPrincipal = new Button();
            btnContinuar = new Button();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(119, 43);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(200, 120);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guarda";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnMenuPrincipal
            // 
            btnMenuPrincipal.Location = new Point(117, 189);
            btnMenuPrincipal.Name = "btnMenuPrincipal";
            btnMenuPrincipal.Size = new Size(186, 95);
            btnMenuPrincipal.TabIndex = 1;
            btnMenuPrincipal.Text = "Menuprin";
            btnMenuPrincipal.UseVisualStyleBackColor = true;
            btnMenuPrincipal.Click += btnMenuPrincipal_Click;
            // 
            // btnContinuar
            // 
            btnContinuar.Location = new Point(119, 321);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(186, 95);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continua";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // PausaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnContinuar);
            Controls.Add(btnMenuPrincipal);
            Controls.Add(btnGuardar);
            Name = "PausaUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
        }

        #endregion

        private Button btnGuardar;
        private Button btnMenuPrincipal;
        private Button btnContinuar;
    }
}
