namespace JuegoEscaperoom.Controles
{
    partial class MinijuegoSecuenciaUC
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
            pbxArriba = new PictureBox();
            pbxAbajo = new PictureBox();
            pbxIzquierda = new PictureBox();
            pbxDerecha = new PictureBox();
            lblEstado = new Label();
            btnEmpezar = new Button();
            btnSalir = new Button();
            tmrSecuencia = new System.Windows.Forms.Timer(components);
            tmrApagar = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxArriba).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxAbajo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxIzquierda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxDerecha).BeginInit();
            SuspendLayout();
            // 
            // pbxArriba
            // 
            pbxArriba.Location = new Point(285, 236);
            pbxArriba.Name = "pbxArriba";
            pbxArriba.Size = new Size(100, 100);
            pbxArriba.TabIndex = 0;
            pbxArriba.TabStop = false;
            // 
            // pbxAbajo
            // 
            pbxAbajo.Location = new Point(425, 236);
            pbxAbajo.Name = "pbxAbajo";
            pbxAbajo.Size = new Size(100, 100);
            pbxAbajo.TabIndex = 1;
            pbxAbajo.TabStop = false;
            // 
            // pbxIzquierda
            // 
            pbxIzquierda.Location = new Point(139, 236);
            pbxIzquierda.Name = "pbxIzquierda";
            pbxIzquierda.Size = new Size(100, 100);
            pbxIzquierda.TabIndex = 2;
            pbxIzquierda.TabStop = false;
            // 
            // pbxDerecha
            // 
            pbxDerecha.Location = new Point(568, 236);
            pbxDerecha.Name = "pbxDerecha";
            pbxDerecha.Size = new Size(100, 100);
            pbxDerecha.TabIndex = 3;
            pbxDerecha.TabStop = false;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(16, 47);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(55, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "lblEstado";
            // 
            // btnEmpezar
            // 
            btnEmpezar.Location = new Point(16, 12);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(75, 23);
            btnEmpezar.TabIndex = 5;
            btnEmpezar.Text = "butEmp";
            btnEmpezar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(699, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "butSal";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // tmrSecuencia
            // 
            tmrSecuencia.Interval = 200;
            // 
            // tmrApagar
            // 
            tmrApagar.Tick += tmrApagar_Tick;
            // 
            // MinijuegoSecuenciaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSalir);
            Controls.Add(btnEmpezar);
            Controls.Add(lblEstado);
            Controls.Add(pbxDerecha);
            Controls.Add(pbxIzquierda);
            Controls.Add(pbxAbajo);
            Controls.Add(pbxArriba);
            Name = "MinijuegoSecuenciaUC";
            Size = new Size(790, 433);
            ((System.ComponentModel.ISupportInitialize)pbxArriba).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxAbajo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxIzquierda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxDerecha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxArriba;
        private PictureBox pbxAbajo;
        private PictureBox pbxIzquierda;
        private PictureBox pbxDerecha;
        private Label lblEstado;
        private Button btnEmpezar;
        private Button btnSalir;
        private System.Windows.Forms.Timer tmrSecuencia;
        private System.Windows.Forms.Timer tmrApagar;
    }
}
