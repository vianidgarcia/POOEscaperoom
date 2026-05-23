using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoEscaperoom.Clases;

namespace JuegoEscaperoom.Controles
{
    public partial class CargarPartidaUC : UserControl
    {
        private FormPrincipal _formPrincipal;
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
        
        public CargarPartidaUC(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
                this.Dock = DockStyle.Fill;
                AplicarTextos();
            this.DoubleBuffered = true;
        }

        private void AplicarTextos()
        {
            btnVolver.Text = L.Obtener("ui.cargarPartida.volver");
            btnCargar.Text = L.Obtener("ui.cargarPartida.cargar");
            btnEliminar.Text = L.Obtener("ui.cargarPartida.eliminar");
        }

        private void CargarPartidaUC_Load(object sender, EventArgs e)
        {
            lvPartidas.Items.Clear();
            foreach (var partida in PersistenciaPartida.ListarPartidasGuardadas())
            {
                string display = $"{partida.TalentoJugador} - {partida.FechaGuardado:dd/MM/yyyy HH:mm:ss}";
                lvPartidas.Items.Add(new ListViewItem(display) { Tag = partida.SlotId });
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new MenuUC(_formPrincipal));
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (lvPartidas.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    L.Obtener("ui.cargarPartida.sinSeleccion"),
                    L.Obtener("ui.cargarPartida.tituloSinSeleccion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string slotId = lvPartidas.SelectedItems[0].Tag?.ToString() ?? "";
            var estado = PersistenciaPartida.CargarPartida(slotId);

            if (estado == null)
            {
                MessageBox.Show(
                    L.Obtener("ui.cargarPartida.errorCargar"),
                    L.Obtener("ui.cargarPartida.tituloError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fecha = estado.FechaGuardado.ToString("dd/MM/yyyy HH:mm:ss");
            var result = MessageBox.Show(
                L.Formato("ui.cargarPartida.confirmarCarga", estado.TalentoJugador, fecha),
                L.Obtener("ui.cargarPartida.tituloConfirmarCarga"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                _formPrincipal.IniciarConEstadoCargado(estado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lvPartidas.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    L.Obtener("ui.cargarPartida.sinSeleccion"),
                    L.Obtener("ui.cargarPartida.tituloSinSeleccion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string slotId = lvPartidas.SelectedItems[0].Tag?.ToString() ?? "";
            var estado = PersistenciaPartida.CargarPartida(slotId);

            if (estado == null)
            {
                MessageBox.Show(
                    L.Obtener("ui.cargarPartida.errorEliminar"),
                    L.Obtener("ui.cargarPartida.tituloError"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fecha = estado.FechaGuardado.ToString("dd/MM/yyyy HH:mm:ss");
            var result = MessageBox.Show(
                L.Formato("ui.cargarPartida.confirmarEliminacion", estado.TalentoJugador, fecha),
                L.Obtener("ui.cargarPartida.tituloConfirmarEliminacion"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                PersistenciaPartida.EliminarPartida(slotId);
                lvPartidas.Items.Remove(lvPartidas.SelectedItems[0]);
                MessageBox.Show(
                    L.Obtener("ui.cargarPartida.eliminadaExitosa"),
                    L.Obtener("ui.cargarPartida.tituloEliminada"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
