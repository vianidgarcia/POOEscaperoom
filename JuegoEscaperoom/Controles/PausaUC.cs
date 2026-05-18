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
    public partial class PausaUC : UserControl
    {
        private FormPrincipal _form;
        public PausaUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _form.Controlador.GuardarPartida();
                MessageBox.Show("Partida guardada exitosamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
               "¿Seguro que quieres regresar al menú principal?",
               "Regresar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
                _form.MostrarControl(new MenuUC(_form));
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
                        _form.MostrarControl(new MapaUC(_form));
        }
    }
}
