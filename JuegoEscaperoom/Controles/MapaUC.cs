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
        private List<Zona> _zonaActual = BancoZonas.ObtenerTodasLasZonas();

        public MapaUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }

        private void pbxHiyoko_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                Zona zona = _zonaActual.FirstOrDefault(z => z.Id == "hiyoko");
                if (zona != null)
                {
                    _form.MostrarControl(new ZonaUC(_form, zona));
                }
            }
        }

        private void pbxGundham_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                Zona zona = _zonaActual.FirstOrDefault(z => z.Id == "gundham");
                if (zona != null)
                {
                    _form.MostrarControl(new ZonaUC(_form, zona));
                }
            }
        }

        private void pbxNagito_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                Zona zona = _zonaActual.FirstOrDefault(z => z.Id == "nagito");
                if (zona != null)
                {
                    _form.MostrarControl(new ZonaUC(_form, zona));
                }
            }
        }

        private void pbxChiaki_Click(object sender, EventArgs e)
        {
            if (_form != null)
            {
                Zona zona = _zonaActual.FirstOrDefault(z => z.Id == "chiaki");
                if (zona != null)
                {
                    _form.MostrarControl(new ZonaUC(_form, zona));
                }
            }
        }

    }
}
