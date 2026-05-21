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
            btnIrMenuPrincipal = new Button();
            SuspendLayout();
            // 
            // btnIrMenuPrincipal
            // 
            btnIrMenuPrincipal.BackColor = Color.FromArgb(5, 50, 116);
            btnIrMenuPrincipal.FlatStyle = FlatStyle.Popup;
            btnIrMenuPrincipal.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnIrMenuPrincipal.ForeColor = SystemColors.ButtonHighlight;
            btnIrMenuPrincipal.Location = new Point(489, 356);
            btnIrMenuPrincipal.Margin = new Padding(0);
            btnIrMenuPrincipal.Name = "btnIrMenuPrincipal";
            btnIrMenuPrincipal.Size = new Size(391, 77);
            btnIrMenuPrincipal.TabIndex = 0;
            btnIrMenuPrincipal.Text = "Menu";
            btnIrMenuPrincipal.UseVisualStyleBackColor = false;
            btnIrMenuPrincipal.Click += btnIrMenuPrincipal_Click;
            // 
            // CreditosUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnIrMenuPrincipal);
            Name = "CreditosUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
        }

        #endregion

        private Button btnIrMenuPrincipal;
    }
}
