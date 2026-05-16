using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoEscaperoom.Clases;

namespace JuegoEscaperoom.Controles
{
    public partial class CargarPartidaUC : UserControl
    {
        private FormPrincipal _formPrincipal;
        public CargarPartidaUC(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            
        }

        private void CargarPartidaUC_Load(object sender, EventArgs e)
        {
            foreach (var partida in PersistenciaPartida.ListarPartidasGuardadas())
            {
                string displayText = $"{partida.TalentoJugador} - {partida.FechaGuardado:dd/MM/yyyy HH:mm:ss}";
                lvPartidas.Items.Add(new ListViewItem(displayText) { Tag = partida.SlotId });
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _formPrincipal.MostrarControl(new MenuUC(_formPrincipal));
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (lvPartidas.SelectedItems.Count == 1)
            {
                string slotId = lvPartidas.SelectedItems[0].Tag.ToString() ?? "";
                var estado = PersistenciaPartida.CargarPartida(slotId);
                if (estado != null)
                {
                    var result = MessageBox.Show($"Estás a punto de cargar la partida de {estado.TalentoJugador} guardada el {estado.FechaGuardado:dd/MM/yyyy HH:mm:ss}. ¿Deseas continuar?", "Confirmar carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _formPrincipal.IniciarConEstadoCargado(estado);
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar la partida. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lvPartidas.SelectedItems.Count == 1)
            {
                string slotId = lvPartidas.SelectedItems[0].Tag.ToString() ?? "";
                var estado = PersistenciaPartida.CargarPartida(slotId);
                if (estado != null)
                {
                    var result = MessageBox.Show($"Estás a punto de eliminar la partida de {estado.TalentoJugador} guardada el {estado.FechaGuardado:dd/MM/yyyy HH:mm:ss}. ¿Deseas continuar?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        PersistenciaPartida.EliminarPartida(slotId);
                        lvPartidas.Items.Remove(lvPartidas.SelectedItems[0]);
                        MessageBox.Show("Partida eliminada exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Error al eliminar la partida. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
