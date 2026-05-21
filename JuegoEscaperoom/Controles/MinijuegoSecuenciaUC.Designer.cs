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
            pbxArriba.BackColor = Color.Transparent;
            pbxArriba.Location = new Point(389, 450);
            pbxArriba.Name = "pbxArriba";
            pbxArriba.Size = new Size(250, 250);
            pbxArriba.TabIndex = 0;
            pbxArriba.TabStop = false;
            // 
            // pbxAbajo
            // 
            pbxAbajo.BackColor = Color.Transparent;
            pbxAbajo.Location = new Point(658, 450);
            pbxAbajo.Name = "pbxAbajo";
            pbxAbajo.Size = new Size(250, 250);
            pbxAbajo.TabIndex = 1;
            pbxAbajo.TabStop = false;
            // 
            // pbxIzquierda
            // 
            pbxIzquierda.BackColor = Color.Transparent;
            pbxIzquierda.Location = new Point(116, 450);
            pbxIzquierda.Name = "pbxIzquierda";
            pbxIzquierda.Size = new Size(250, 250);
            pbxIzquierda.TabIndex = 2;
            pbxIzquierda.TabStop = false;
            // 
            // pbxDerecha
            // 
            pbxDerecha.BackColor = Color.Transparent;
            pbxDerecha.Location = new Point(930, 450);
            pbxDerecha.Name = "pbxDerecha";
            pbxDerecha.Size = new Size(250, 250);
            pbxDerecha.TabIndex = 3;
            pbxDerecha.TabStop = false;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(275, 68);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(55, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "lblEstado";
            // 
            // btnEmpezar
            // 
            btnEmpezar.Location = new Point(77, 64);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(167, 120);
            btnEmpezar.TabIndex = 5;
            btnEmpezar.Text = "butEmp";
            btnEmpezar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(1119, 68);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(167, 120);
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
            tmrApagar.Interval = 30;
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
            DoubleBuffered = true;
            Name = "MinijuegoSecuenciaUC";
            Size = new Size(1368, 788);
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
