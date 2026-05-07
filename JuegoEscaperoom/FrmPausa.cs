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

    public partial class FrmPausa : Form
    {
        private readonly EstadoJuego _estado;
        public event Action SolicitarSalida;

        public bool PartidaGuardada { get; private set; } = false;

        public FrmPausa(EstadoJuego estado)
        {
            _estado = estado;
            InitializeComponent();
            ConfigurarVista();
        }

        private void ConfigurarVista()
        {
            lblPuntaje.Text = $"Puntos de Lógica: {_estado.Puntaje}";
            lblHabitacion.Text = $"Ubicación: {_estado.HabitacionActual}";
            lblInventarioResumen.Text = _estado.Inventario.Count == 0
                ? "Sin pistas u objetos."
                : "Objetos: " + string.Join(" | ", _estado.Inventario);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PersistenciaPartida.GuardarPartida(_estado);
                PartidaGuardada = true;
                MessageBox.Show("Progreso guardado.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirMenu_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "¿Seguro que quieres volver al menú? Se perderá el progreso no guardado.",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
                SolicitarSalida?.Invoke(); // El padre decide cómo cerrarse.
        }
    }
}