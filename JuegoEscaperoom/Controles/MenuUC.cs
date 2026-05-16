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
        public MenuUC(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
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
    }
}
