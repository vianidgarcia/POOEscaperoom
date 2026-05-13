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
using JuegoEscaperoom.Controles;

namespace JuegoEscaperoom
{
    public partial class FormPrincipal : Form
    {
        public ServicioAudio Audio { get; } = new();
        public ControladorJuego Controlador { get; private set; }
        private UserControl? _controlActual;

        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarVentana();
            IniciarJuego();
        }

        private void ConfigurarVentana()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
        }

        private void IniciarJuego()
        {
            var estado = new EstadoJuego();
            var zonas = BancoZonas.ObtenerTodasLasZonas();
            Controlador = new ControladorJuego(estado, zonas);

            SuscribirEventosControlador();

            // Primera pantalla: introducción de Monokuma
            MostrarControl(new IntroUC(this));
        }

        private void SuscribirEventosControlador()
        {
            Controlador.JunkoDesbloqueada += () =>
            {
                // El mapa se encarga de mostrar a Junko disponible
                // No navegamos aquí — el jugador decide cuándo ir
            };

            Controlador.JuegoTerminado += () =>
            {
                MostrarControl(new CreditosUC(this));
            };
        }

        // ── Navegación 
        public void MostrarControl(UserControl nuevoControl)
        {
            _controlActual?.Dispose();

            nuevoControl.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(nuevoControl);
            _controlActual = nuevoControl;
            nuevoControl.BringToFront();
        }

        // ── Cierre limpio 
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Controlador.CambiosSinGuardar)
            {
                var res = MessageBox.Show(
                    "¿Guardar progreso antes de salir?",
                    "Guardar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    try { Controlador.GuardarPartida(); }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar: {ex.Message}");
                        e.Cancel = true;
                        return;
                    }
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            Audio.Dispose();
            base.OnFormClosing(e);
        }
    }
}
