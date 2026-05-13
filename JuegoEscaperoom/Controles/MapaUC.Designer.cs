namespace JuegoEscaperoom.Controles
{
    partial class MapaUC
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
            btnPrueba = new Button();
            SuspendLayout();
            // 
            // btnPrueba
            // 
            btnPrueba.Location = new Point(220, 59);
            btnPrueba.Name = "btnPrueba";
            btnPrueba.Size = new Size(139, 101);
            btnPrueba.TabIndex = 0;
            btnPrueba.Text = "Ir al minijuego de Hiyoko";
            btnPrueba.UseVisualStyleBackColor = true;
            btnPrueba.Click += btnPrueba_Click;
            // 
            // MapaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPrueba);
            Name = "MapaUC";
            Size = new Size(594, 269);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrueba;
    }
}
