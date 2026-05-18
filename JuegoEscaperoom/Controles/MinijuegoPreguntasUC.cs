using JuegoEscaperoom.Clases;
using JuegoEscaperoom.Clases.JuegoEscaperoom.Clases;
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
        private readonly FormPrincipal _form;
        private readonly Zona _zona;
        private readonly ServicioAudio _audio;
        private readonly List<AcertijoOpcionMultiple> _preguntas;

        private int _indiceActual = 0;
        private int _intentos = 0;
        private int _puntosGanados = 0;

        private const int MaxIntentos = 3;
        private const int PuntosBase = 100;
        private const int DescuentoPorFallo = 25;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoPreguntasUC(FormPrincipal form, Zona zona, List<AcertijoOpcionMultiple> preguntas)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;
            _audio = form.Audio;
            _preguntas = preguntas;
            this.Dock = DockStyle.Fill;
            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            MostrarEstado($"Pregunta 1 de {_preguntas.Count} — Presiona Empezar");
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
            var pregunta = _preguntas[_indiceActual];
            _intentos = 0;

            lblPregunta.Text = pregunta.Pregunta;
            btnOpcion1.Text = pregunta.Opciones[0];
            btnOpcion2.Text = pregunta.Opciones[1];
            btnOpcion3.Text = pregunta.Opciones[2];
            btnOpcion4.Text = pregunta.Opciones[3];
           
            CargarImagenesPregunta(pregunta);
            MostrarEstado($"Pregunta {_indiceActual + 1} de {_preguntas.Count} — {MaxIntentos} intentos");
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
            var pregunta = _preguntas[_indiceActual];
            _intentos++;

            if (pregunta.ValidarRespuesta(indiceSeleccionado.ToString()))
            {
                int puntosObtenidos = Math.Max(PuntosBase - ((_intentos - 1) * DescuentoPorFallo), 0);
                _puntosGanados += puntosObtenidos;
                _audio.ReproducirEfecto("Audios/efecto_correcto.wav");
                PreguntaCorrecta(puntosObtenidos);
            }
            else
            {
                _audio.ReproducirEfecto("Audios/efecto_triste.wav");
                PreguntaIncorrecta();
            }
        }

        private void PreguntaCorrecta(int puntos)
        {
            _indiceActual++;

            if (_indiceActual >= _preguntas.Count)
            {
                _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                OcultarPregunta();
                MostrarEstado($"¡Correcto! Has respondido todo. Puntos obtenidos: {_puntosGanados}");
                MinijuegoCompletado?.Invoke(_zona);
                _form.Controlador.ProcesarVictoriaZona(_zona);
                return;
            }

            MostrarEstado($"¡Correcto! +{puntos} puntos — Siguiente pregunta");
            MostrarPreguntaActual();
        }

        private void PreguntaIncorrecta()
        {
            int intentosRestantes = MaxIntentos - _intentos;

            if (intentosRestantes <= 0)
            {
                MostrarEstado("Sin intentos. Pasando a la siguiente pregunta...");
                _indiceActual++;

                if (_indiceActual >= _preguntas.Count)
                {
                    OcultarPregunta();
                    MostrarEstado($"Minijuego terminado. Puntos obtenidos: {_puntosGanados}");
                    MinijuegoCompletado?.Invoke(_zona);
                    return;
                }

                MostrarPreguntaActual();
                return;
            }

            MostrarEstado($"Incorrecto. Te quedan {intentosRestantes} intentos.");
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            if (_zona.Completada)
            {
                _form.MostrarControl(new ZonaUC(_form, _zona));
                return;
            }
            var resultado = MessageBox.Show(
                "Si regresas perderás el progreso de este minijuego. ¿Seguro?",
                "Regresar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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