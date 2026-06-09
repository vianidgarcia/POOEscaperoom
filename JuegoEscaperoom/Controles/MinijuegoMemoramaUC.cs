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
    public partial class MinijuegoMemoramaUC : UserControl
    {
        private FormPrincipal _form;
        private Zona _zona;
        private AcertijoMemorama _acertijo;
        private ServicioAudio _audio;
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
        private List<PictureBox> _cartasAnimando = new();
        private int _anchoOriginal;
        private bool _cerrando = true;
        private bool _esPrimeraCarta;
        private bool _esVuelta;

        List<int> paresNumeros = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        string? primerSeleccion = null;
        string? segundaSeleccion = null;

        int TiempoTotal = ConfigJuego.TiempoMemorama;
        List<PictureBox> _cartas = new List<PictureBox>();
        PictureBox? _carta1;
        PictureBox? _carta2;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoMemoramaUC(FormPrincipal formPrincipal, Zona zona)
        {
            _form = formPrincipal;
            _zona = zona;
            _acertijo = zona.Acertijo as AcertijoMemorama ?? throw new ArgumentException("La zona no tiene un acertijo de tipo memorama.");
            _audio = formPrincipal.Audio;
            this.BackgroundImage = _zona.ImagenFondo;
            InitializeComponent();
            this.Dock = DockStyle.Fill;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblEstado.Text = L.Obtener("ui.memorama.estadoInicial");
            btnEmpezar.Text = L.Obtener("ui.minijuego.empezar");
            btnRegresar.Text = L.Obtener("ui.minijuego.salir");
            lblTiempo.Text = L.Formato("ui.memorama.tiempoRestante", TiempoTotal);
            _cartas = new List<PictureBox>
            {
                pbxCarta1, pbxCarta2, pbxCarta3, pbxCarta4,
                pbxCarta5, pbxCarta6, pbxCarta7, pbxCarta8,
                pbxCarta9, pbxCarta10, pbxCarta11, pbxCarta12
            };
            CargarFoto();
            _anchoOriginal = pbxCarta1.Width-15;
        }

        private void CargarFoto()
        {
            foreach (PictureBox pbx in _cartas)
            {
                pbx.BackgroundImage = Properties.Resources.cartaVolteada;
                pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                pbx.Click += Carta_Click;
            }

            PrepararJuego();
        }

        private void PrepararJuego()
        {
            var rndLista = paresNumeros.OrderBy(x => Guid.NewGuid()).ToList();

            paresNumeros = rndLista;

            primerSeleccion = null;
            segundaSeleccion = null;
            _carta1 = null;
            _carta2 = null;

            for (int i = 0; i < _cartas.Count; i++)
            {
                _cartas[i].Image = null;
                _cartas[i].BackgroundImage = Properties.Resources.cartaVolteada;
                _cartas[i].BackColor = Color.Transparent;
                _cartas[i].Tag = paresNumeros[i].ToString();
            }
        }

        private void Carta_Click(object? sender, EventArgs e)
        {
            if (!tmrJuego.Enabled)
                return;

            if (_acertijo.Resuelto)
                return;

            PictureBox? cartaSeleccionada = sender as PictureBox;

            if (cartaSeleccionada == null)
                return;

            if (cartaSeleccionada.Tag == null)
                return;

            if (cartaSeleccionada.Image != null)
                return;

            if (primerSeleccion == null)
            {
                _carta1 = cartaSeleccionada;

                _cartasAnimando = new List<PictureBox>
        {
            _carta1
        };

                _esPrimeraCarta = true;
                tmrFlip.Start();

                return;
            }

            if (segundaSeleccion == null)
            {
                if (_carta1 == cartaSeleccionada)
                    return;

                _carta2 = cartaSeleccionada;

                _cartasAnimando = new List<PictureBox>
        {
            _carta2
        };

                _esPrimeraCarta = false;
                tmrFlip.Start();

                return;
            }

            RevisarCartas(_carta1!, _carta2!);
        }

        private void RevisarCartas(PictureBox A, PictureBox B)
        {
            if (A.Tag == null || B.Tag == null)
                return;

            if (primerSeleccion == segundaSeleccion)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                lblEstado.Text = L.Obtener("ui.memorama.sigueIntentando");

                A.Image = null;
                A.BackgroundImage = Properties.Resources.cartaVolteada;
                A.BackColor = Color.Transparent;

                B.Image = null;
                B.BackgroundImage = Properties.Resources.cartaVolteada;
                B.BackColor = Color.Transparent;
            }

            primerSeleccion = null;
            segundaSeleccion = null;

            _carta1 = null;
            _carta2 = null;

            if (_cartas.All(o => o.Tag == null))
            {
                _acertijo.RegistrarRondaGanada();
                _acertijo.RegistrarTiempo(ConfigJuego.TiempoMemorama - TiempoTotal);

                tmrJuego.Stop();

                lblEstado.Text = L.Obtener("ui.memorama.felicitacionesRonda");

                if (_acertijo.Resolver(""))
                {
                    _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");

                    MinijuegoCompletado?.Invoke(_zona);

                    _form.Controlador.ProcesarVictoriaZona(
                        _zona,
                        _acertijo.CalcularPuntos());

                    lblEstado.Text = L.Obtener("ui.memorama.ganaste");

                    return;
                }

                btnEmpezar.Enabled = true;

                lblEstado.Text = L.Formato(
                    "ui.memorama.rondasGanadas",
                    _acertijo.RondasGanadas,
                    _acertijo.RondasParaGanar);
            }
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            btnEmpezar.Enabled = false;
            lblEstado.Text = L.Obtener("ui.memorama.empezando");
            lblTiempo.Text = L.Formato("ui.memorama.tiempoRestante", TiempoTotal);
            TiempoTotal = ConfigJuego.TiempoMemorama;
            PrepararJuego();
            _acertijo.RegistrarRonda();
            tmrJuego.Start();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
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

        private void tmrJuego_Tick(object sender, EventArgs e)
        {
            TiempoTotal--;
            lblTiempo.Text = L.Formato("ui.memorama.tiempoRestante", TiempoTotal);
            if (TiempoTotal == 0)
            {
                tmrJuego.Stop();
                MessageBox.Show(L.Obtener("ui.memorama.tiempoAgotado"), L.Obtener("ui.memorama.tituloTiempo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEmpezar.Enabled = true;
            }
        }

        private void tmrFlip_Tick(object sender, EventArgs e)
        {
            if (_cerrando)
            {
                if (_cartasAnimando.Count > 0 &&
                    _cartasAnimando[0].Width > 0)
                {
                    foreach (var carta in _cartasAnimando)
                    {
                        carta.Width -= 20;
                    }
                }
                else
                {
                    tmrFlip.Stop();

                    if (_esPrimeraCarta)
                    {
                        primerSeleccion = (string)_cartasAnimando[0].Tag;
                    }
                    else
                    {
                        segundaSeleccion = (string)_cartasAnimando[0].Tag;
                    }

                    foreach (var carta in _cartasAnimando)
                    {
                        carta.BackgroundImage = null;
                        carta.BackColor = Color.SeaShell;

                        carta.Image =
                            Properties.Resources.ResourceManager.GetObject(
                                (string)carta.Tag) as Image;
                    }

                    _cerrando = false;

                    tmrFlip.Start();
                }
            }
            else
            {
                if (_cartasAnimando.Count > 0 &&
                    _cartasAnimando[0].Width < _anchoOriginal)
                {
                    foreach (var carta in _cartasAnimando)
                    {
                        carta.Width += 20;
                    }
                }
                else
                {
                    tmrFlip.Stop();

                    _cerrando = true;

                    if (primerSeleccion != null &&
                        segundaSeleccion != null &&
                        _carta1 != null &&
                        _carta2 != null)
                    {
                        RevisarCartas(_carta1, _carta2);
                    }
                }
            }
        }

    }
}
