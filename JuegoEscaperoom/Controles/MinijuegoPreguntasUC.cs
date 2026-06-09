using JuegoEscaperoom.Clases;
using JuegoEscaperoom.Properties;
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
    public partial class MinijuegoPreguntasUC : UserControl
    {
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
        private readonly FormPrincipal _form;
        private readonly Zona _zona;
        private readonly ServicioAudio _audio;
        private readonly AcertijoCuestionario _acertijo;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoPreguntasUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;
            _audio = form.Audio;
            _acertijo = zona.Acertijo as AcertijoCuestionario
                ?? throw new ArgumentException("La zona no tiene un acertijo de tipo cuestionario.");
            this.Dock = DockStyle.Fill;
            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            btnEmpezar.Text = L.Formato("ui.minijuego.empezar");
            btnSalir.Text = L.Formato("ui.minijuego.salir");

            MostrarEstado(L.Formato("ui.preguntas.estadoInicial", 1, _acertijo.Preguntas.Count));
            OcultarPregunta();

            btnOpcion1.Click += (s, ev) => ValidarOpcion(0);
            btnOpcion2.Click += (s, ev) => ValidarOpcion(1);
            btnOpcion3.Click += (s, ev) => ValidarOpcion(2);
            btnOpcion4.Click += (s, ev) => ValidarOpcion(3);

        }

        private void btnEmpezar_Click(object? sender, EventArgs e)
        {
            btnEmpezar.Enabled = false;
            MostrarPreguntaActual();
        }

        private void MostrarPreguntaActual()
        {
            var pregunta = _acertijo.ObtenerPreguntaActual();
            if (pregunta == null) return;

            lblPregunta.Text = pregunta.Pregunta;
            btnOpcion1.Text = pregunta.Opciones[0];
            btnOpcion2.Text = pregunta.Opciones[1];
            btnOpcion3.Text = pregunta.Opciones[2];
            btnOpcion4.Text = pregunta.Opciones[3];

            CargarImagenesPregunta(pregunta);
            MostrarEstado(L.Formato("ui.preguntas.intentos",
                _acertijo.PreguntaActual + 1, _acertijo.Preguntas.Count, ConfigJuego.RondasCuestionario));
            MostrarPregunta();
        }
        private void CargarImagenesPregunta(AcertijoOpcionMultiple pregunta)
        {
            pbxOpcion1.Image = pregunta.ImagenesOpciones[0];
            pbxOpcion2.Image = pregunta.ImagenesOpciones[1];
            pbxOpcion3.Image = pregunta.ImagenesOpciones[2];
            pbxOpcion4.Image = pregunta.ImagenesOpciones[3];

            pbxOpcion1.Visible = pregunta.ImagenesOpciones[0] != null;
            pbxOpcion2.Visible = pregunta.ImagenesOpciones[1] != null;
            pbxOpcion3.Visible = pregunta.ImagenesOpciones[2] != null;
            pbxOpcion4.Visible = pregunta.ImagenesOpciones[3] != null;
        }

        private void ValidarOpcion(int indiceSeleccionado)
        {
           
            if (_acertijo.Resolver(indiceSeleccionado.ToString()))
            {
                if (_acertijo.Resuelto)
                {
                    _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                    OcultarPregunta();
                    MostrarEstado(L.Formato("ui.preguntas.ganaste", _acertijo.CalcularPuntos()));
                    MinijuegoCompletado?.Invoke(_zona);
                    _form.Controlador.ProcesarVictoriaZona(_zona, _acertijo.CalcularPuntos());
                    return;
                }
                _audio.ReproducirEfecto("Audios/efecto_correcto.wav");
                MostrarEstado(L.Formato("ui.preguntas.correcto", _acertijo.Preguntas[_acertijo.PreguntaActual - 1].CalcularPuntos()));
                MostrarPreguntaActual();


            }
            else
            {
                PreguntaIncorrecta();
                _audio.ReproducirEfecto("Audios/efecto_triste.wav");
               
            }
        }

        private void PreguntaIncorrecta()
        {
            if (_acertijo.ObtenerPreguntaActual() != null) { }
            int intentosRestantes = ConfigJuego.IntentosMaximosCuestionario
                - _acertijo.ObtenerPreguntaActual().Intentos;
            if (intentosRestantes > 0)
                MostrarEstado(L.Formato("ui.preguntas.incorrecto", intentosRestantes));
            else if (intentosRestantes == 0)
            {
                MessageBox.Show("Horrible,perdiste", "xd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _form.MostrarControl(new ZonaUC(_form, _zona));
                return;
            }
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            if (_zona.Completada)
            {
                _form.MostrarControl(new ZonaUC(_form, _zona));
                return;
            }
            var resultado = MessageBox.Show(
                L.Obtener("ui.minijuego.confirmarSalida"),
                L.Obtener("ui.minijuego.tituloSalida"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
                _form.MostrarControl(new ZonaUC(_form, _zona));
        }

        private void MostrarPregunta()
        {
            lblPregunta.Visible = true;
            btnOpcion1.Visible = true;
            btnOpcion2.Visible = true;
            btnOpcion3.Visible = true;
            btnOpcion4.Visible = true;
        }

        private void OcultarPregunta()
        {
            lblPregunta.Visible = false;
            btnOpcion1.Visible = false;
            btnOpcion2.Visible = false;
            btnOpcion3.Visible = false;
            btnOpcion4.Visible = false;
        }

        private void MostrarEstado(string texto) => lblEstado.Text = texto;
    }
}