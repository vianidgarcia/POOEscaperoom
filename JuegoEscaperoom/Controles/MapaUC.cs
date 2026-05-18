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
        private readonly FormPrincipal _form;
        private readonly List<Zona> _zonas;

        public MapaUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
            _zonas = form.Controlador.Zonas.ToList();
            this.Dock = DockStyle.Fill;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActualizarEstadoZonas();
        }

        private void ActualizarEstadoZonas()
        {

            lblContadorFragmentos.Text = $"Fragmentos: {_form.Controlador.Estado.FragmentosEsperanza.Count} / 4";
        }

        private void pbxHiyoko_Click(object sender, EventArgs e)
        {
            var zona = _zonas.FirstOrDefault(z => z.Id == "hiyoko");
            if (zona != null) _form.MostrarControl(new ZonaUC(_form, zona));
        }

        private void pbxGundham_Click(object sender, EventArgs e)
        {
            var zona = _zonas.FirstOrDefault(z => z.Id == "gundham");
            if (zona != null) _form.MostrarControl(new ZonaUC(_form, zona));
        }

        private void pbxChiaki_Click(object sender, EventArgs e)
        {
            var zona = _zonas.FirstOrDefault(z => z.Id == "chiaki");
            if (zona != null) _form.MostrarControl(new ZonaUC(_form, zona));
        }

        private void pbxNagito_Click(object sender, EventArgs e)
        {
            var zona = _zonas.FirstOrDefault(z => z.Id == "nagito");
            if (zona != null) _form.MostrarControl(new ZonaUC(_form, zona));
        }


        private void btnPausa_Click(object sender, EventArgs e)
        {
            _form.MostrarControl(new PausaUC(_form));
        }
    }
}
