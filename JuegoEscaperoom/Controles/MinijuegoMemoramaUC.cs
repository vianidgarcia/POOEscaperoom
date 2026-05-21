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

        List<int> paresNumeros = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        string primerSeleccion = null;
        string segundaSeleccion = null;

        int TiempoTotal = 60;
        List<PictureBox> _cartas = new List<PictureBox>();
        PictureBox _carta1;
        PictureBox _carta2;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoMemoramaUC(FormPrincipal formPrincipal, Zona zona)
        {
            _form = formPrincipal;
            _zona = zona;
            _acertijo = (AcertijoMemorama)zona.Acertijo;
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
        }

        private void CargarFoto()
        {
            foreach (PictureBox pbx in _cartas) 
            { 
              pbx.BackColor = Color.LightGray;
                pbx.SizeMode = PictureBoxSizeMode.StretchImage;
                pbx.Click += Carta_Click;
            }

            PrepararJuego();
        }

        private void Carta_Click(object sender, EventArgs e)
        {
            if (!tmrJuego.Enabled) return;

            if (_acertijo.Resuelto)
            {
                return;
            }


            if (primerSeleccion == null)
            {
                _carta1 = sender as PictureBox;

                if (_carta1.Tag != null && _carta1.Image == null)
                {
                    _carta1.Image = Properties.Resources.ResourceManager.GetObject((string)_carta1.Tag) as Image;
                    primerSeleccion = (string)_carta1.Tag;
                }

            }
            else if (segundaSeleccion == null)
            {
                _carta2 = sender as PictureBox;

                if (_carta2.Tag != null && _carta2.Image == null)
                {
                    _carta2.Image = Properties.Resources.ResourceManager.GetObject((string)_carta2.Tag) as Image;
                    segundaSeleccion = (string)_carta2.Tag;

                }
            }
            else
            {
                RondaCompletada(_carta1, _carta2);
            }
        }

        private void PrepararJuego()
        {
            var randomList = paresNumeros.OrderBy(x => Guid.NewGuid()).ToList();

            // save the random list to the question numbers list again
            paresNumeros = randomList;

            for (int i = 0; i < _cartas.Count; i++)
            {
                _cartas[i].Image = null;
                _cartas[i].Tag = paresNumeros[i].ToString();
            }

        }

        private void RondaCompletada(PictureBox A, PictureBox B)
        {

            if (primerSeleccion == segundaSeleccion)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                lblEstado.Text = L.Obtener("ui.memorama.sigueIntentando");
            }

            primerSeleccion = null;
            segundaSeleccion = null;

            foreach (PictureBox x in _cartas.ToList())
            {
                if (x.Tag != null)
                {
                    x.Image = null;
                }
            }

            if (_cartas.All(o => o.Tag == null))
            {
                _acertijo.RegistrarRondaGanada();
                tmrJuego.Stop();
                lblEstado.Text = L.Obtener("ui.memorama.felicitacionesRonda");

                if (_acertijo.Resolver(""))
                {
                    _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                    MinijuegoCompletado?.Invoke(_zona);
                    _form.Controlador.ProcesarVictoriaZona(_zona);
                    lblEstado.Text = L.Obtener("ui.memorama.ganaste");

                    return;
                }

                btnEmpezar.Enabled = true;
                lblEstado.Text = L.Formato("ui.memorama.rondasGanadas", _acertijo.RondasGanadas, _acertijo.RondasParaGanar);
            }

        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            btnEmpezar.Enabled = false;
            lblEstado.Text = L.Obtener("ui.memorama.empezando");
            lblTiempo.Text = L.Formato("ui.memorama.tiempoRestante", TiempoTotal);
            TiempoTotal = 60;
            PrepararJuego();
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
    }
}
