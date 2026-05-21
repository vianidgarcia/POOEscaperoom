namespace JuegoEscaperoom.Controles
{
    partial class MinijuegoPreguntasUC
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
            btnEmpezar = new Button();
            btnSalir = new Button();
            btnOpcion1 = new Button();
            btnOpcion2 = new Button();
            btnOpcion3 = new Button();
            btnOpcion4 = new Button();
            lblPregunta = new Label();
            lblEstado = new Label();
            pbxOpcion1 = new PictureBox();
            pbxOpcion2 = new PictureBox();
            pbxOpcion3 = new PictureBox();
            pbxOpcion4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion4).BeginInit();
            SuspendLayout();
            // 
            // btnEmpezar
            // 
            btnEmpezar.Location = new Point(490, 169);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(75, 23);
            btnEmpezar.TabIndex = 0;
            btnEmpezar.Text = "emp";
            btnEmpezar.UseVisualStyleBackColor = true;
            btnEmpezar.Click += btnEmpezar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(793, 170);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "sal";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnOpcion1
            // 
            btnOpcion1.Location = new Point(67, 444);
            btnOpcion1.Name = "btnOpcion1";
            btnOpcion1.Size = new Size(270, 23);
            btnOpcion1.TabIndex = 2;
            btnOpcion1.Text = "Op1";
            btnOpcion1.UseVisualStyleBackColor = true;
            // 
            // btnOpcion2
            // 
            btnOpcion2.Location = new Point(361, 444);
            btnOpcion2.Name = "btnOpcion2";
            btnOpcion2.Size = new Size(276, 23);
            btnOpcion2.TabIndex = 3;
            btnOpcion2.Text = "Op2";
            btnOpcion2.UseVisualStyleBackColor = true;
            // 
            // btnOpcion3
            // 
            btnOpcion3.Location = new Point(659, 444);
            btnOpcion3.Name = "btnOpcion3";
            btnOpcion3.Size = new Size(300, 23);
            btnOpcion3.TabIndex = 4;
            btnOpcion3.Text = "Op3";
            btnOpcion3.UseVisualStyleBackColor = true;
            // 
            // btnOpcion4
            // 
            btnOpcion4.Location = new Point(981, 444);
            btnOpcion4.Name = "btnOpcion4";
            btnOpcion4.Size = new Size(322, 23);
            btnOpcion4.TabIndex = 5;
            btnOpcion4.Text = "Op4";
            btnOpcion4.UseVisualStyleBackColor = true;
            // 
            // lblPregunta
            // 
            lblPregunta.AutoSize = true;
            lblPregunta.Location = new Point(659, 377);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(61, 15);
            lblPregunta.TabIndex = 6;
            lblPregunta.Text = "preguntya";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(686, 208);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(22, 15);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "est";
            // 
            // pbxOpcion1
            // 
            pbxOpcion1.BackColor = Color.Transparent;
            pbxOpcion1.Location = new Point(68, 481);
            pbxOpcion1.Name = "pbxOpcion1";
            pbxOpcion1.Size = new Size(269, 247);
            pbxOpcion1.TabIndex = 8;
            pbxOpcion1.TabStop = false;
            // 
            // pbxOpcion2
            // 
            pbxOpcion2.BackColor = Color.Transparent;
            pbxOpcion2.Location = new Point(359, 483);
            pbxOpcion2.Name = "pbxOpcion2";
            pbxOpcion2.Size = new Size(278, 245);
            pbxOpcion2.TabIndex = 9;
            pbxOpcion2.TabStop = false;
            // 
            // pbxOpcion3
            // 
            pbxOpcion3.BackColor = Color.Transparent;
            pbxOpcion3.Location = new Point(655, 480);
            pbxOpcion3.Name = "pbxOpcion3";
            pbxOpcion3.Size = new Size(304, 257);
            pbxOpcion3.TabIndex = 10;
            pbxOpcion3.TabStop = false;
            // 
            // pbxOpcion4
            // 
            pbxOpcion4.BackColor = Color.Transparent;
            pbxOpcion4.Location = new Point(983, 481);
            pbxOpcion4.Name = "pbxOpcion4";
            pbxOpcion4.Size = new Size(306, 247);
            pbxOpcion4.TabIndex = 11;
            pbxOpcion4.TabStop = false;
            // 
            // MinijuegoPreguntasUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbxOpcion4);
            Controls.Add(pbxOpcion3);
            Controls.Add(pbxOpcion2);
            Controls.Add(pbxOpcion1);
            Controls.Add(lblEstado);
            Controls.Add(lblPregunta);
            Controls.Add(btnOpcion4);
            Controls.Add(btnOpcion3);
            Controls.Add(btnOpcion2);
            Controls.Add(btnOpcion1);
            Controls.Add(btnSalir);
            Controls.Add(btnEmpezar);
            DoubleBuffered = true;
            Name = "MinijuegoPreguntasUC";
            Size = new Size(1368, 788);
            ((System.ComponentModel.ISupportInitialize)pbxOpcion1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEmpezar;
        private Button btnSalir;
        private Button btnOpcion1;
        private Button btnOpcion2;
        private Button btnOpcion3;
        private Button btnOpcion4;
        private Label lblPregunta;
        private Label lblEstado;
        private PictureBox pbxOpcion1;
        private PictureBox pbxOpcion2;
        private PictureBox pbxOpcion3;
        private PictureBox pbxOpcion4;
    }
}
