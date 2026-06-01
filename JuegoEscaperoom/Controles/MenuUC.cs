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

    public partial class MenuUC : UserControl
    {
        private FormPrincipal _formPrincipal;
    
        private static readonly Dictionary<string, string> Idiomas = new()
        {
            { "Español",    "es" },
            { "English",    "en" },
            { "Português",  "pt" }
        };


        public MenuUC(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            this.Dock = DockStyle.Fill;
            InicializarSelectorIdioma();
            AplicarTextos();
        }

        private void InicializarSelectorIdioma()
        {
            cmbIdioma.Items.Clear();
            foreach (var nombre in Idiomas.Keys)
                cmbIdioma.Items.Add(nombre);

            string codigoActual = ServicioLocalizacion.Instancia.IdiomaActual;
            foreach (var par in Idiomas)
            {
                if (par.Value == codigoActual)
                {
                    cmbIdioma.SelectedItem = par.Key;
                    break;
                }
            }

            cmbIdioma.SelectedIndexChanged += CmbIdioma_SelectedIndexChanged;
        }

        private void CmbIdioma_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbIdioma.SelectedItem is string nombreIdioma &&
                Idiomas.TryGetValue(nombreIdioma, out string? codigo))
            {
                ServicioLocalizacion.Instancia.CargarIdioma(codigo);
                AplicarTextos();
            }
        }

        private void AplicarTextos()
        {
            var L = ServicioLocalizacion.Instancia;
            btnJugarNueva.Text = L.Obtener("ui.menu.nuevaPartida");
            btnCargar.Text = L.Obtener("ui.menu.cargarPartida");
            btnSalir.Text = L.Obtener("ui.menu.salir");
            lblIdioma.Text = L.Obtener("ui.menu.seleccionarIdioma") + ":";
        }

        private void btnJugarNueva_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new IntroUC(_formPrincipal));
            _formPrincipal.IniciarJuego();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new CargarPartidaUC(_formPrincipal));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           _formPrincipal.Close();
        }

    }
}
