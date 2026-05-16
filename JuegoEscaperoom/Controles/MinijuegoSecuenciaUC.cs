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
    public partial class MinijuegoSecuenciaUC : UserControl
    {
        private readonly FormPrincipal _form;
        private readonly Zona _zona;
        private readonly AcertijoSecuencia _acertijo;
        private readonly ServicioAudio _audio;

        // Secuencia actual y progreso del jugador
        private List<Direccion> _secuenciaActual = new();
        private int _indiceMostrar = 0;
        private int _indiceJugador = 0;
        private bool _mostrandoSecuencia = false;

        private static readonly Random _rng = new();

        // Mapeo tecla → dirección
        private static readonly Dictionary<Keys, Direccion> _mapaTeclas = new()
        {
            { Keys.Up,    Direccion.Arriba    },
            { Keys.Down,  Direccion.Abajo     },
            { Keys.Left,  Direccion.Izquierda },
            { Keys.Right, Direccion.Derecha   }
        };

        // Mapeo dirección → PictureBox correspondiente
        private Dictionary<Direccion, PictureBox> _mapaBotones;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoSecuenciaUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;
            _acertijo = (AcertijoSecuencia)zona.Acertijo;
            _audio = form.Audio;
            this.Dock = DockStyle.Fill;
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Mapear cada PictureBox a su dirección
            _mapaBotones = new()
            {
                { Direccion.Arriba,    pbxArriba    },
                { Direccion.Abajo,     pbxAbajo     },
                { Direccion.Izquierda, pbxIzquierda },
                { Direccion.Derecha,   pbxDerecha   }
            };

            CargarImagenesBotones();

            btnEmpezar.Click += (s, ev) => IniciarRonda();
            btnSalir.Click += (s, ev) => SalirSinCompletar();

            tmrSecuencia.Interval = 600;
            tmrSecuencia.Tick += MostrarSiguienteDireccion;

            MostrarEstado($"Ronda 0 / {_acertijo.RondasParaGanar} — Presiona Empezar");

            this.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_mapaTeclas.ContainsKey(keyData))
            {
                OnTeclaPresionada(this, new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Imágenes
        private void CargarImagenesBotones()
        {
            pbxArriba.Image = Properties.Resources.btn_arriba_normal;
            pbxAbajo.Image = Properties.Resources.btn_abajo_normal;
            pbxIzquierda.Image = Properties.Resources.btn_izquierda_normal;
            pbxDerecha.Image = Properties.Resources.btn_derecha_normal;

            foreach (var pbx in _mapaBotones.Values)
                pbx.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void IluminarBoton(Direccion dir, bool iluminado)
        {
            var pbx = _mapaBotones[dir];
            pbx.Image = dir switch
            {
                Direccion.Arriba => iluminado ? Properties.Resources.btn_arriba_on : Properties.Resources.btn_arriba_normal,
                Direccion.Abajo => iluminado ? Properties.Resources.btn_abajo_on : Properties.Resources.btn_abajo_normal,
                Direccion.Izquierda => iluminado ? Properties.Resources.btn_izquierda_on : Properties.Resources.btn_izquierda_normal,
                Direccion.Derecha => iluminado ? Properties.Resources.btn_derecha_on : Properties.Resources.btn_derecha_normal,
                _ => pbx.Image
            };
        }

        // Lógica de ronda 
        private void IniciarRonda()
        {
            btnEmpezar.Enabled = false;
            _indiceJugador = 0;
            _indiceMostrar = 0;
            _mostrandoSecuencia = true;
            _secuenciaActual = GenerarSecuencia(4);
            MostrarEstado("Memoriza la secuencia...");
            tmrSecuencia.Start();
        }

        private List<Direccion> GenerarSecuencia(int longitud)
        {
            var valores = Enum.GetValues<Direccion>();
            var secuencia = new List<Direccion>();
            for (int i = 0; i < longitud; i++)
                secuencia.Add(valores[_rng.Next(valores.Length)]);
            return secuencia;
        }

        private void MostrarSiguienteDireccion(object? sender, EventArgs e)
        {
            // Apagar el botón anterior
            if (_indiceMostrar > 0)
                IluminarBoton(_secuenciaActual[_indiceMostrar - 1], false);

            if (_indiceMostrar < _secuenciaActual.Count)
            {
                IluminarBoton(_secuenciaActual[_indiceMostrar], true);
                _audio.ReproducirEfecto("Audios/efecto_correcto.wav");
                _indiceMostrar++;
            }
            else
            {
                // Termina la demostración
                tmrSecuencia.Stop();
                _mostrandoSecuencia = false;
                MostrarEstado("¡Tu turno! Repite la secuencia.");
                this.Focus();
                CargarImagenesBotones();
            }
        }

        // Input del jugador 
        private void OnTeclaPresionada(object? sender, KeyEventArgs e)
        {
            if (_mostrandoSecuencia) return;
            if (!_mapaTeclas.TryGetValue(e.KeyCode, out var direccion)) return;

            IluminarBoton(direccion, true);
            tmrApagar.Start();

            if (direccion == _secuenciaActual[_indiceJugador])
            {
                _indiceJugador++;
                _audio.ReproducirEfecto("Audios/efecto_correcto.wav");

                if (_indiceJugador >= _secuenciaActual.Count)
                    RondaCompletada();
            }
            else
            {
                _audio.ReproducirEfecto("Audios/efecto_triste.wav");
                RondaFallada();
            }
        }

        private void tmrApagar_Tick(object sender, EventArgs e)
        {
            tmrApagar.Stop();
            foreach (var dir in _mapaBotones.Keys)
                IluminarBoton(dir, false);
        }

        private void RondaCompletada()
        {
            
            _acertijo.RegistrarAcierto();
            MostrarEstado($"Ronda {_acertijo.Aciertos} / {_acertijo.RondasParaGanar}");

            if (_acertijo.Resolver(""))
            {
                _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                MinijuegoCompletado?.Invoke(_zona);
               _form.Controlador.ProcesarVictoriaZona(_zona);
                MostrarEstado("Ganaste hermano, dele pa otra zona");
                
                return;
            }

            btnEmpezar.Enabled = true;
            MostrarEstado($"¡Correcto! Ronda {_acertijo.Aciertos} / {_acertijo.RondasParaGanar} — Siguiente ronda");
            CargarImagenesBotones();
        }

        private void RondaFallada()
        {
            _indiceJugador = 0;
            btnEmpezar.Enabled = true;
            MostrarEstado("Secuencia incorrecta. Intenta de nuevo.");
            CargarImagenesBotones();
        }

        private void SalirSinCompletar()
        {
            var res = MessageBox.Show(
                "Si sales perderás el progreso de este minijuego. ¿Seguro?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
                _form.MostrarControl(new ZonaUC(_form, _zona));
        }

        private void MostrarEstado(string texto) => lblEstado.Text = texto;
    }
}