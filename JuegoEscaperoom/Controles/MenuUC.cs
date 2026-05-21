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
        int r;
        int g;
        int b;

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
            SuscribirControles();
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

        private void SuscribirControles()
        {
            btnCargar.MouseEnter += MouseEnterButton;
            btnJugarNueva.MouseEnter += MouseEnterButton;
            btnSalir.MouseEnter += MouseEnterButton;
            btnCargar.MouseLeave += MouseLeaveButton;
            btnJugarNueva.MouseLeave += MouseLeaveButton;
            btnSalir.MouseLeave += MouseLeaveButton;
        }

        private void btnJugarNueva_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new IntroUC(_formPrincipal));
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new CargarPartidaUC(_formPrincipal));
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
           _formPrincipal.Close();
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
