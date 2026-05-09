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
        private readonly ControladorJuego _controlador;
        public event Action SolicitarSalida;

        public bool PartidaGuardada { get; private set; } = false;

        public FrmPausa(ControladorJuego controlador)
        {
            _controlador = controlador;
            InitializeComponent();
            ConfigurarVista();
        }

        private void ConfigurarVista()
        {
            var estado = _controlador.Estado;
            lblPuntaje.Text = $"Puntos de Lógica: {estado.Puntaje}";
            lblHabitacion.Text = $"Ubicación: {estado.HabitacionActual}";
            lblInventarioResumen.Text = estado.Inventario.Count == 0
                ? "Sin pistas u objetos."
                : "Objetos: " + string.Join(" | ", estado.Inventario);
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
                _controlador.GuardarPartida();
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