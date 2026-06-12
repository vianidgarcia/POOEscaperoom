using JuegoEscaperoom.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom.Controles
{
    public partial class MinijuegoSecuenciaUC : UserControl
    {
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
        private readonly FormPrincipal _form;
        private readonly Zona _zona;
        private readonly AcertijoSecuencia _acertijo;
        private readonly ServicioAudio _audio;

        // Secuencia actual y progreso del jugador
        private List<Direccion> _secuenciaActual = new();
        private int _indiceMostrar = 0;
        private int _indiceJugador = 0;
        private bool _mostrandoSecuencia = false;
        private bool _faseApagar = false;

        private static readonly Random _rng = new();

        // Mapeo tecla → dirección
        private static readonly Dictionary<Keys, Direccion> _mapaTeclas = new()
        {
            { Keys.Up,    Direccion.Arriba    },
            { Keys.Down,  Direccion.Abajo     },
            { Keys.Left,  Direccion.Izquierda },
            { Keys.Right, Direccion.Derecha   },
            { Keys.W,     Direccion.Arriba    },
            { Keys.S,     Direccion.Abajo     },
            { Keys.A,     Direccion.Izquierda },
            { Keys.D,     Direccion.Derecha   }
        };

        // Mapeo dirección → PictureBox correspondiente
        private Dictionary<Direccion, PictureBox> _mapaBotones;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoSecuenciaUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;
            _acertijo = zona.Acertijo as AcertijoSecuencia
                ?? throw new ArgumentException("La zona no tiene un acertijo de tipo Secuencia.");
            _audio = form.Audio;
            this.Dock = DockStyle.Fill;

            _mapaBotones = new()
            {
                { Direccion.Arriba,    pbxArriba    },
                { Direccion.Abajo,     pbxAbajo     },
                { Direccion.Izquierda, pbxIzquierda },
                { Direccion.Derecha,   pbxDerecha   }
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            CargarImagenesBotones();
            btnEmpezar.Click += (s, ev) => IniciarRonda();
            btnSalir.Click += (s, ev) => Salir();
            tmrSecuencia.Interval = 300;

            // Textos localizados y textos de botones
            MostrarEstado(L.Formato("ui.secuencia.estadoInicial", 0, _acertijo.RondasParaGanar));
            btnEmpezar.Text = L.Obtener("ui.minijuego.empezar");
            btnSalir.Text = L.Obtener("ui.minijuego.salir");

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
            MostrarEstado(L.Obtener("ui.secuencia.memorizando"));
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

            if (_indiceJugador >= _secuenciaActual.Count)
                RondaCompletada();

            if (_acertijo.Resolver(""))
            {
                _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
            }
        }

        private void RondaCompletada()
        {

            _acertijo.RegistrarAcierto();
            MostrarEstado(L.Formato("ui.secuencia.rondasGanadas", _acertijo.Aciertos, _acertijo.RondasParaGanar));

            if (_acertijo.Resolver(""))
            {
                MinijuegoCompletado?.Invoke(_zona);
                _form.Controlador.ProcesarVictoriaZona(_zona, _acertijo.CalcularPuntos());
                MostrarEstado(L.Obtener("ui.secuencia.ganaste"));

                return;
            }

            btnEmpezar.Enabled = true;
            MostrarEstado(L.Formato("ui.secuencia.correcto", _acertijo.Aciertos, _acertijo.RondasParaGanar));
            CargarImagenesBotones();
        }

        private void RondaFallada()
        {
            _indiceJugador = 0;
            btnEmpezar.Enabled = true;
            MostrarEstado(L.Obtener("ui.secuencia.incorrecto"));
            CargarImagenesBotones();
        }

        private void Salir()
        {
            if (_zona.Completada)
            {
                _form.MostrarControl(new ZonaUC(_form, _zona));
                return;
            }

            var res = MessageBox.Show(
                L.Obtener("ui.minijuego.confirmarSalida"),
                L.Obtener("ui.minijuego.tituloSalida"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
                _form.MostrarControl(new ZonaUC(_form, _zona));
        }

        private void MostrarEstado(string texto) => lblEstado.Text = texto;

        private void tmrSecuencia_Tick(object sender, EventArgs e)
        {
            if (_faseApagar)
            {
                if (_indiceMostrar > 0)
                    IluminarBoton(_secuenciaActual[_indiceMostrar - 1], false);
            }
            else
            {
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
                    MostrarEstado(L.Obtener("ui.secuencia.turnoJugador"));
                    this.Focus();
                    CargarImagenesBotones();
                    return;
                }
            }
                _faseApagar = !_faseApagar;
        }
    }
}