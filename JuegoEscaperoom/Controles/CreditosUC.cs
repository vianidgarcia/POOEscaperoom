using JuegoEscaperoom.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom.Controles
{
    public partial class CreditosUC : UserControl
    {
        int r;
        int g;
        int b;
        private FormPrincipal _form;
        public CreditosUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }

        private void btnIrMenuPrincipal_Click(object sender, EventArgs e)
        {
            _form.MostrarControl(new MenuUC(_form));
        }

        private void MouseEnterButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            r = btn.BackColor.R;
            g = btn.BackColor.G;
            b = btn.BackColor.B;
            btn.BackColor = Color.FromArgb(254, 200, 2);
            btn.ForeColor = Color.Black;
        }

        private void MouseLeaveButton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(r, g, b); // Restaura el color original
            btn.ForeColor = Color.White;
        }
    }
}
