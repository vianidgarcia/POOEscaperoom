using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Controles
{
    public class BotonJuego : Button
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public BotonJuego()
        {
            R = 5;
            G = 50;
            B = 116;
            // Estilo base compartido
            this.FlatStyle = FlatStyle.Popup;
            this.BackColor = Color.FromArgb(R, G, B);
            this.ForeColor = Color.White;
            this.Font = new Font("Dogica Pixel", 12F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.FlatAppearance.BorderSize = 2;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = Color.FromArgb(254, 200, 2); // hover
            this.ForeColor = Color.Black;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.FromArgb(R, G, B); // normal
            this.ForeColor = Color.White;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.BackColor = Color.FromArgb(254, 200, 2); // hover
            this.ForeColor = Color.Black;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = Color.FromArgb(R, G, B); // normal
            this.ForeColor = Color.White;
        }
    }
}
