using JuegoEscaperoom.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private FormPrincipal _form;
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;

        public CreditosUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblPuntuacion.Location= new Point((this.Width - lblPuntuacion.Width) / 2, lblPuntuacion.Location.Y);
            lblGanaste.Location = new Point((this.Width - lblGanaste.Width) / 2, lblGanaste.Location.Y);
            btnIrMenuPrincipal.Location = new Point((this.Width - btnIrMenuPrincipal.Width) / 2, btnIrMenuPrincipal.Location.Y);

            lblPuntuacion.Text = string.Concat(L.Obtener("ui.creditos.puntuacion"), _form.Controlador.Estado.Puntaje.ToString());
            lblGanaste.Text = L.Obtener("ui.creditos.mensaje");
            btnIrMenuPrincipal.Text = L.Obtener("ui.creditos.menu");
        }

        private void btnIrMenuPrincipal_Click(object sender, EventArgs e)
        {
            _form.MostrarControl(new MenuUC(_form));
        }

    }
}
