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
            btnEmpezar = new BotonJuego();
            btnSalir = new BotonJuego();
            btnOpcion1 = new BotonJuego();
            btnOpcion2 = new BotonJuego();
            btnOpcion3 = new BotonJuego();
            btnOpcion4 = new BotonJuego();
            lblPregunta = new Label();
            lblEstado = new Label();
            pbxOpcion1 = new PictureBox();
            pbxOpcion2 = new PictureBox();
            pbxOpcion3 = new PictureBox();
            pbxOpcion4 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion4).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnEmpezar
            // 
            btnEmpezar.BackColor = Color.FromArgb(5, 50, 116);
            btnEmpezar.FlatStyle = FlatStyle.Popup;
            btnEmpezar.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnEmpezar.ForeColor = Color.White;
            btnEmpezar.Location = new Point(274, 179);
            btnEmpezar.Name = "btnEmpezar";
            btnEmpezar.Size = new Size(216, 23);
            btnEmpezar.TabIndex = 0;
            btnEmpezar.Text = "emp";
            btnEmpezar.UseVisualStyleBackColor = true;
            btnEmpezar.Click += btnEmpezar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(5, 50, 116);
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(773, 170);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(216, 23);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "sal";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnOpcion1
            // 
            btnOpcion1.BackColor = Color.FromArgb(5, 50, 116);
            btnOpcion1.FlatStyle = FlatStyle.Popup;
            btnOpcion1.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnOpcion1.ForeColor = Color.White;
            btnOpcion1.Location = new Point(55, 427);
            btnOpcion1.Name = "btnOpcion1";
            btnOpcion1.Size = new Size(300, 50);
            btnOpcion1.TabIndex = 2;
            btnOpcion1.Text = "Op1";
            btnOpcion1.UseVisualStyleBackColor = true;
            // 
            // btnOpcion2
            // 
            btnOpcion2.BackColor = Color.FromArgb(5, 50, 116);
            btnOpcion2.FlatStyle = FlatStyle.Popup;
            btnOpcion2.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnOpcion2.ForeColor = Color.White;
            btnOpcion2.Location = new Point(361, 427);
            btnOpcion2.Name = "btnOpcion2";
            btnOpcion2.Size = new Size(300, 50);
            btnOpcion2.TabIndex = 3;
            btnOpcion2.Text = "Op2";
            btnOpcion2.UseVisualStyleBackColor = true;
            // 
            // btnOpcion3
            // 
            btnOpcion3.BackColor = Color.FromArgb(5, 50, 116);
            btnOpcion3.FlatStyle = FlatStyle.Popup;
            btnOpcion3.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnOpcion3.ForeColor = Color.White;
            btnOpcion3.Location = new Point(667, 427);
            btnOpcion3.Name = "btnOpcion3";
            btnOpcion3.Size = new Size(300, 50);
            btnOpcion3.TabIndex = 4;
            btnOpcion3.Text = "Op3";
            btnOpcion3.UseVisualStyleBackColor = true;
            // 
            // btnOpcion4
            // 
            btnOpcion4.BackColor = Color.FromArgb(5, 50, 116);
            btnOpcion4.FlatStyle = FlatStyle.Popup;
            btnOpcion4.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnOpcion4.ForeColor = Color.White;
            btnOpcion4.Location = new Point(973, 427);
            btnOpcion4.Name = "btnOpcion4";
            btnOpcion4.Size = new Size(300, 50);
            btnOpcion4.TabIndex = 5;
            btnOpcion4.Text = "Op4";
            btnOpcion4.UseVisualStyleBackColor = true;
            // 
            // lblPregunta
            // 
            lblPregunta.BackColor = Color.Transparent;
            lblPregunta.Font = new Font("FOT-Rodin Pro B", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPregunta.ForeColor = SystemColors.ButtonHighlight;
            lblPregunta.Location = new Point(16, 59);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(1185, 78);
            lblPregunta.TabIndex = 6;
            lblPregunta.Text = "preguntya";
            lblPregunta.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.BackColor = Color.Transparent;
            lblEstado.Font = new Font("FOT-Rodin Pro B", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = SystemColors.ButtonHighlight;
            lblEstado.Location = new Point(612, 15);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(34, 20);
            lblEstado.TabIndex = 7;
            lblEstado.Text = "est";
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbxOpcion1
            // 
            pbxOpcion1.BackColor = Color.Transparent;
            pbxOpcion1.Location = new Point(104, 499);
            pbxOpcion1.Name = "pbxOpcion1";
            pbxOpcion1.Size = new Size(200, 200);
            pbxOpcion1.TabIndex = 8;
            pbxOpcion1.TabStop = false;
            // 
            // pbxOpcion2
            // 
            pbxOpcion2.BackColor = Color.Transparent;
            pbxOpcion2.Location = new Point(414, 499);
            pbxOpcion2.Name = "pbxOpcion2";
            pbxOpcion2.Size = new Size(200, 200);
            pbxOpcion2.TabIndex = 9;
            pbxOpcion2.TabStop = false;
            // 
            // pbxOpcion3
            // 
            pbxOpcion3.BackColor = Color.Transparent;
            pbxOpcion3.Location = new Point(713, 499);
            pbxOpcion3.Name = "pbxOpcion3";
            pbxOpcion3.Size = new Size(200, 200);
            pbxOpcion3.TabIndex = 10;
            pbxOpcion3.TabStop = false;
            // 
            // pbxOpcion4
            // 
            pbxOpcion4.BackColor = Color.Transparent;
            pbxOpcion4.Location = new Point(1022, 499);
            pbxOpcion4.Name = "pbxOpcion4";
            pbxOpcion4.Size = new Size(200, 200);
            pbxOpcion4.TabIndex = 11;
            pbxOpcion4.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(lblEstado);
            panel1.Controls.Add(lblPregunta);
            panel1.Location = new Point(55, 231);
            panel1.Name = "panel1";
            panel1.Size = new Size(1218, 158);
            panel1.TabIndex = 12;
            // 
            // MinijuegoPreguntasUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbxOpcion4);
            Controls.Add(pbxOpcion3);
            Controls.Add(pbxOpcion2);
            Controls.Add(pbxOpcion1);
            Controls.Add(btnOpcion4);
            Controls.Add(btnOpcion3);
            Controls.Add(btnOpcion2);
            Controls.Add(btnOpcion1);
            Controls.Add(btnSalir);
            Controls.Add(btnEmpezar);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Name = "MinijuegoPreguntasUC";
            Size = new Size(1368, 788);
            ((System.ComponentModel.ISupportInitialize)pbxOpcion1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxOpcion4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private BotonJuego btnEmpezar;
        private BotonJuego btnSalir;
        private BotonJuego btnOpcion1;
        private BotonJuego btnOpcion2;
        private BotonJuego btnOpcion3;
        private BotonJuego btnOpcion4;
        private Label lblPregunta;
        private Label lblEstado;
        private PictureBox pbxOpcion1;
        private PictureBox pbxOpcion2;
        private PictureBox pbxOpcion3;
        private PictureBox pbxOpcion4;
        private Panel panel1;
    }
}
