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
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            CargarFoto();
        }

        private void CargarFoto()
        {
            int columnas = 4;
            int anchoTarjeta = 100;
            int altoTarjeta = 100;
            int espaciado = 10;
            int offsetLeft = 200;
            int offsetTop = 150;

            for (int i = 0; i < 12; i++)
            {
                int col = i % columnas;
                int fila = i / columnas;

                PictureBox nuevaCarta = new PictureBox();
                nuevaCarta.Width = anchoTarjeta;
                nuevaCarta.Height = altoTarjeta;
                nuevaCarta.Left = offsetLeft + col * (anchoTarjeta + espaciado);
                nuevaCarta.Top = offsetTop + fila * (altoTarjeta + espaciado);
                nuevaCarta.BackColor = Color.LightGray;
                nuevaCarta.SizeMode = PictureBoxSizeMode.StretchImage;
                nuevaCarta.Click += NuevaCarta_Click;
                _cartas.Add(nuevaCarta);
                this.Controls.Add(nuevaCarta);
            }

            PrepararJuego();
        }

        private void NuevaCarta_Click(object sender, EventArgs e)
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
                lblEstado.Text = "Sigue Intentando!";
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
                lblEstado.Text = "¡Felicidades, has ganado la ronda!";

                if (_acertijo.Resolver(""))
                {
                    _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                    MinijuegoCompletado?.Invoke(_zona);
                    _form.Controlador.ProcesarVictoriaZona(_zona);
                    lblEstado.Text = "Ganaste hermano, dele pa otra zona";

                    return;
                }

                btnEmpezar.Enabled = true;
                lblEstado.Text = $"Ronda {_acertijo.RondasGanadas} / {_acertijo.RondasParaGanar} — Siguiente ronda";
            }

        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            btnEmpezar.Enabled = false;
            lblEstado.Text = "Empieza el memorama!";
            lblTiempo.Text = $"Tiempo: {TiempoTotal}s";
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
                "Si sales perderás el progreso de este minijuego. ¿Seguro?",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
                _form.MostrarControl(new ZonaUC(_form, _zona));
        }

        private void tmrJuego_Tick(object sender, EventArgs e)
        {
            TiempoTotal--;
            lblTiempo.Text = $"Tiempo: {TiempoTotal}s";
            if (TiempoTotal == 0)
            {
                tmrJuego.Stop();
                MessageBox.Show("¡Se acabó el tiempo! Intenta de nuevo.", "Tiempo agotado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEmpezar.Enabled = true;
            }
        }
    }
}
