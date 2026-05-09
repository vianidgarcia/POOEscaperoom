using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
            VerificarBotonCargar();
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            if (PersistenciaPartida.ExistePartida())
            {
                var res = MessageBox.Show(
                    "Ya existe una partida guardada.\n" +
                    "¿Deseas iniciar desde cero y perder ese progreso?",
                    "Confirmar nueva partida",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes) return;
            }

            IniciarJuego(cargarPartida: false);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            IniciarJuego(cargarPartida: true);
        }

        private void IniciarJuego(bool cargarPartida)
        {
            Hide();
            if (!cargarPartida)
            {
                using var intro = new FrmIntro();
                intro.ShowDialog();
            }

            using var juego = new FrmEscaperoom(cargarPartida);
            juego.ShowDialog();

            Show();
           VerificarBotonCargar();
        }

        private void VerificarBotonCargar()
        {
            var btnCargar = Controls.OfType<Button>()
                .FirstOrDefault(b => b.Text.Contains("Cargar"));
            if (btnCargar != null)
                btnCargar.Enabled = PersistenciaPartida.ExistePartida();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
