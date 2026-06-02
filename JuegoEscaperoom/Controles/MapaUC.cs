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
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
        private readonly FormPrincipal _form;
        private readonly List<Zona> _zonas;

        public MapaUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
            _zonas = form.Controlador.Zonas.ToList();
            pbxMonokuma.Visible = false;
            pbxMonokuma.Enabled = false;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pbxMonokuma.Visible = _form.Controlador.Estado.PuedeIrAZonaFinal;
            pbxMonokuma.Enabled = _form.Controlador.Estado.PuedeIrAZonaFinal;

            _form.Controlador.ZonaFinalDesbloqueada += () =>
            {
                pbxMonokuma.Visible = true;
                pbxMonokuma.Enabled = true;
                _form.Controlador.GuardarPartida();
            };
            ActualizarEstadoZonas();
            lblExpresion.Text = L.Obtener("ui.mapa.instruccion");
            btnPausa.Text = L.Obtener("ui.mapa.pausa");

        }

        private void ActualizarEstadoZonas()
        {
            lblContadorFragmentos.Text = L.Formato("ui.mapa.fragmentos",
                _form.Controlador.Estado.FragmentosObtenidos);
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
            PausaUC pausa = new PausaUC(_form);

            this.Controls.Add(pausa);
            pausa.Location = new Point(
                (this.ClientSize.Width - pausa.Width) / 2,
                (this.ClientSize.Height - pausa.Height) / 2);
            pausa.BringToFront();
            pausa.Focus();

        }

        private void pbxMonokuma_Click(object sender, EventArgs e)
        {
            var zona = _zonas.FirstOrDefault(z => z.Id == "monokuma");
            if (zona != null) _form.MostrarControl(new ZonaUC(_form, zona));
        }
    }
}
