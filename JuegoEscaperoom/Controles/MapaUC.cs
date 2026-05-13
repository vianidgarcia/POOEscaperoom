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
    public partial class MapaUC : UserControl
    {
        private FormPrincipal _form;
        private Zona _zonaActual = BancoZonas.ObtenerZonaHiyoko();

        public MapaUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                _form.MostrarControl(new MinijuegoSecuenciaUC(_form, _zonaActual));
            }
        }
    }
}
