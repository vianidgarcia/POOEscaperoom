using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;

namespace JuegoEscaperoom
{
    public partial class FrmEscaperoom : Form
    {
       
        private readonly ControladorJuego _controlador = new();
        private EscenaHabitacion _escenaActual;
        private string _textoDialogoCompleto = "";
        private int _charDialogo = 0;


        public FrmEscaperoom(bool cargarPartida)
        {
            InitializeComponent();
            SuscribirEventosControlador();
            CargarImagenPersonaje();

            if (cargarPartida)
            {
                try
                {
                    _controlador.IniciarPartidaGuardada();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo cargar la partida: {ex.Message}\n\nIniciando partida nueva.",
                        "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _controlador.IniciarPartidaNueva();
                }
            }
            else
                _controlador.IniciarPartidaNueva();
        }

        private void SuscribirEventosControlador()
        {
            _controlador.EscenaCargada += OnEscenaCargada;
            _controlador.DialogoSolicitado += MostrarDialogoAnimado;
            _controlador.UIActualizada += ActualizarUI;
            _controlador.JuegoTerminado += OnJuegoTerminado;
        }
       
        private void OnEscenaCargada(EscenaHabitacion escena)
        {
            _escenaActual = escena;
            pbxEscena.Image = escena.Fondo;
            ActualizarUI();
        }

        private void OnJuegoTerminado()
        {
            PersistenciaPartida.BorrarPartida();
            MessageBox.Show("¡La puerta de salida se ha desbloqueado! ¡He escapado!", "¡Felicidades!");
            ReiniciarJuego();
        }

        private void pbxEscena_MouseClick(object sender, MouseEventArgs e)
        {
            var acertijo = _escenaActual?.GetAcertijoEnPunto(
                e.Location, pbxEscena.Size, pbxEscena.Image);

            if (acertijo == null) return;

            switch (_controlador.EvaluarClick(acertijo))
            {
                case AcertijoResultado.YaResuelto:
                    MostrarDialogoAnimado($"Ya revisé {acertijo.NombreObjeto}. No hay nada más aquí.");
                    break;

                case AcertijoResultado.Bloqueado:
                    MostrarDialogoAnimado($"Parece bloqueado... Necesito [{acertijo.ItemRequerido}] para esto.");
                    break;

                case AcertijoResultado.Disponible:
                    using (var frm = new FrmPregunta(acertijo))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                            _controlador.ProcesarVictoria(acertijo);
                    }
                    break;
            }
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            using var frmPausa = new FrmPausa(_controlador.Estado);
            frmPausa.SolicitarSalida += () =>
            {
                frmPausa.Close();
                this.Close();
            };
            frmPausa.ShowDialog();
            ActualizarUI();
        }

        private void FrmEscaperoom_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!_controlador.CambiosSinGuardar) return;

            var resultado = MessageBox.Show(
                "Vas a cerrar el Escape Room sin haber guardado.\n\n¿Quieres guardar el progreso?",
                "¿Guardar partida?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _controlador.GuardarPartida();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else if (resultado == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

      
        private void ActualizarUI()
        {
            var estado = _controlador.Estado;
            lblPuntaje.Text = $"Puntaje: {estado.Puntaje}";
            lblInventario.Text = "Inventario: " + string.Join(", ", estado.Inventario);
            InterfazHelper.ActualizarInventario(flpInventario, estado.Inventario);
        }

        public void MostrarDialogoAnimado(string texto)
        {
            tmrDialogo.Stop();
            _textoDialogoCompleto = texto;
            _charDialogo = 0;
            lblDialogo.Text = "";
            tmrDialogo.Start();
        }

        private void tmrDialogo_Tick(object sender, EventArgs e)
        {
            if (_charDialogo < _textoDialogoCompleto.Length)
            {
                lblDialogo.Text += _textoDialogoCompleto[_charDialogo];
                _charDialogo++;
            }
            else
            {
                tmrDialogo.Stop();
            }
        }

        // Helpers de inicialización
        private void CargarImagenPersonaje()
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Resources", "personaje_icon.png");
            if (!File.Exists(ruta)) return;

            pbxIconoPersonaje.Image = Image.FromFile(ruta);
            pbxIconoPersonaje.BackColor = Color.Transparent;
            pbxIconoPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void ReiniciarJuego()
        {
            var respuesta = MessageBox.Show("¿Deseas jugar de nuevo?", "Reinicio",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                _controlador.IniciarPartidaNueva();
            else
            {
                _controlador.LimpiarCambios(); // pone CambiosSinGuardar = false
                this.Close();
            }
        }
    }
}