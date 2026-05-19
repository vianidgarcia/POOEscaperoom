namespace JuegoEscaperoom.Controles
{
    partial class MinijuegoMemoramaUC
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
            components = new System.ComponentModel.Container();
            btnEmpezar = new Button();
            btnRegresar = new Button();
            lblEstado = new Label();
            lblTiempo = new Label();
            tmrJuego = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnEmpezar
            // 
            btnEmpezar.Location = new Point(60, 59);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(148, 78);
            btnEmpezar.TabIndex = 0;
            btnEmpezar.Text = "btnEmpe";
            btnEmpezar.UseVisualStyleBackColor = true;
            btnEmpezar.Click += btnEmpezar_Click;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(241, 59);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(148, 78);
            btnRegresar.TabIndex = 1;
            btnRegresar.Text = "Regre";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(66, 168);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(62, 15);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "textEstado";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(66, 210);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(67, 15);
            lblTiempo.TabIndex = 3;
            lblTiempo.Text = "textTiempo";
            // 
            // tmrJuego
            // 
            tmrJuego.Interval = 1000;
            tmrJuego.Tick += tmrJuego_Tick;
            // 
            // MinijuegoMemoramaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTiempo);
            Controls.Add(lblEstado);
            Controls.Add(btnRegresar);
            Controls.Add(btnEmpezar);
            Name = "MinijuegoMemoramaUC";
            Size = new Size(1368, 788);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmpezar;
        private Button btnRegresar;
        private Label lblEstado;
        private Label lblTiempo;
        private System.Windows.Forms.Timer tmrJuego;
    }
}
