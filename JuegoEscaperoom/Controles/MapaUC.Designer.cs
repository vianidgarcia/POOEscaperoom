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
            ((System.ComponentModel.ISupportInitialize)pbxGundham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxNagito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxHiyoko).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxChiaki).BeginInit();
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
            lblExpresion.Font = new Font("FOT-Rodin Pro B", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpresion.Location = new Point(67, 46);
            lblExpresion.Name = "lblExpresion";
            lblExpresion.Size = new Size(507, 30);
            lblExpresion.TabIndex = 6;
            lblExpresion.Text = "Selecciona en el mapa la zona a realizar";
            // 
            // MapaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.mapafoto;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(lblExpresion);
            Controls.Add(lblContadorFragmentos);
            Controls.Add(pbxChiaki);
            Controls.Add(pbxHiyoko);
            Controls.Add(pbxNagito);
            Controls.Add(pbxGundham);
            Name = "MapaUC";
            Size = new Size(1368, 788);
            ((System.ComponentModel.ISupportInitialize)pbxGundham).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxNagito).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxHiyoko).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxChiaki).EndInit();
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
    }
}
