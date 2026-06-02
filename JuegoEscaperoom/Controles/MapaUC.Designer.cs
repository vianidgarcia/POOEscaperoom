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
            pbxGundham = new PictureBox();
            pbxNagito = new PictureBox();
            pbxHiyoko = new PictureBox();
            pbxChiaki = new PictureBox();
            lblContadorFragmentos = new Label();
            lblExpresion = new Label();
            btnPausa = new BotonJuego();
            pbxMonokuma = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxGundham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxNagito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHiyoko).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxChiaki).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxMonokuma).BeginInit();
            SuspendLayout();
            // 
            // pbxGundham
            // 
            pbxGundham.BackColor = Color.Transparent;
            pbxGundham.Cursor = Cursors.Hand;
            pbxGundham.Image = Properties.Resources.gundham_icon;
            pbxGundham.Location = new Point(314, 413);
            pbxGundham.Name = "pbxGundham";
            pbxGundham.Size = new Size(45, 67);
            pbxGundham.SizeMode = PictureBoxSizeMode.Zoom;
            pbxGundham.TabIndex = 1;
            pbxGundham.TabStop = false;
            pbxGundham.Click += pbxGundham_Click;
            // 
            // pbxNagito
            // 
            pbxNagito.BackColor = Color.Transparent;
            pbxNagito.Cursor = Cursors.Hand;
            pbxNagito.Image = Properties.Resources.nagito_icon;
            pbxNagito.Location = new Point(581, 137);
            pbxNagito.Name = "pbxNagito";
            pbxNagito.Size = new Size(51, 73);
            pbxNagito.SizeMode = PictureBoxSizeMode.Zoom;
            pbxNagito.TabIndex = 2;
            pbxNagito.TabStop = false;
            pbxNagito.Click += pbxNagito_Click;
            // 
            // pbxHiyoko
            // 
            pbxHiyoko.BackColor = Color.Transparent;
            pbxHiyoko.Cursor = Cursors.Hand;
            pbxHiyoko.Image = Properties.Resources.hiyoko_icon;
            pbxHiyoko.Location = new Point(880, 168);
            pbxHiyoko.Name = "pbxHiyoko";
            pbxHiyoko.Size = new Size(51, 73);
            pbxHiyoko.SizeMode = PictureBoxSizeMode.Zoom;
            pbxHiyoko.TabIndex = 3;
            pbxHiyoko.TabStop = false;
            pbxHiyoko.Click += pbxHiyoko_Click;
            // 
            // pbxChiaki
            // 
            pbxChiaki.BackColor = Color.Transparent;
            pbxChiaki.Cursor = Cursors.Hand;
            pbxChiaki.Image = Properties.Resources.chiaki_icon;
            pbxChiaki.Location = new Point(880, 427);
            pbxChiaki.Name = "pbxChiaki";
            pbxChiaki.Size = new Size(51, 73);
            pbxChiaki.SizeMode = PictureBoxSizeMode.Zoom;
            pbxChiaki.TabIndex = 4;
            pbxChiaki.TabStop = false;
            pbxChiaki.Click += pbxChiaki_Click;
            // 
            // lblContadorFragmentos
            // 
            lblContadorFragmentos.AutoSize = true;
            lblContadorFragmentos.BackColor = Color.Transparent;
            lblContadorFragmentos.Font = new Font("FOT-Rodin Pro B", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContadorFragmentos.Location = new Point(67, 76);
            lblContadorFragmentos.Name = "lblContadorFragmentos";
            lblContadorFragmentos.Size = new Size(74, 30);
            lblContadorFragmentos.TabIndex = 5;
            lblContadorFragmentos.Text = "frags";
            // 
            // lblExpresion
            // 
            lblExpresion.AutoSize = true;
            lblExpresion.BackColor = Color.Transparent;
            lblExpresion.Font = new Font("Dogica", 16F, FontStyle.Bold);
            lblExpresion.Location = new Point(67, 46);
            lblExpresion.Name = "lblExpresion";
            lblExpresion.Size = new Size(890, 22);
            lblExpresion.TabIndex = 6;
            lblExpresion.Text = "Selecciona en el mapa la zona a realizar";
            // 
            // btnPausa
            // 
            btnPausa.B = 116;
            btnPausa.BackColor = Color.FromArgb(5, 50, 116);
            btnPausa.FlatStyle = FlatStyle.Popup;
            btnPausa.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            btnPausa.ForeColor = Color.White;
            btnPausa.G = 50;
            btnPausa.Location = new Point(1151, 46);
            btnPausa.Name = "btnPausa";
            btnPausa.R = 5;
            btnPausa.Size = new Size(160, 90);
            btnPausa.TabIndex = 8;
            btnPausa.Text = "pause";
            btnPausa.UseVisualStyleBackColor = true;
            btnPausa.Click += btnPausa_Click;
            // 
            // pbxMonokuma
            // 
            pbxMonokuma.BackColor = Color.Transparent;
            pbxMonokuma.Cursor = Cursors.Hand;
            pbxMonokuma.Image = Properties.Resources.monokuma_icon;
            pbxMonokuma.Location = new Point(681, 488);
            pbxMonokuma.Name = "pbxMonokuma";
            pbxMonokuma.Size = new Size(83, 67);
            pbxMonokuma.SizeMode = PictureBoxSizeMode.Zoom;
            pbxMonokuma.TabIndex = 9;
            pbxMonokuma.TabStop = false;
            pbxMonokuma.Click += pbxMonokuma_Click;
            // 
            // MapaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.mapafoto;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pbxMonokuma);
            Controls.Add(btnPausa);
            Controls.Add(lblExpresion);
            Controls.Add(lblContadorFragmentos);
            Controls.Add(pbxChiaki);
            Controls.Add(pbxHiyoko);
            Controls.Add(pbxNagito);
            Controls.Add(pbxGundham);
            DoubleBuffered = true;
            Name = "MapaUC";
            Size = new Size(1368, 788);
            ((System.ComponentModel.ISupportInitialize)pbxGundham).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxNagito).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHiyoko).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxChiaki).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxMonokuma).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbxGundham;
        private PictureBox pbxNagito;
        private PictureBox pbxHiyoko;
        private PictureBox pbxChiaki;
        private Label lblContadorFragmentos;
        private Label lblExpresion;
        private BotonJuego btnPausa;
        private PictureBox pbxMonokuma;
    }
}
