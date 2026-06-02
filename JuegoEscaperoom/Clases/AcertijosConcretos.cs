using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public enum Direccion { Arriba, Abajo, Izquierda, Derecha }

    public class AcertijoSecuencia : Acertijo
    {
        public int RondasParaGanar { get; }
        public int Aciertos { get; private set; } = 0;

        public int RondasTotales { get; private set; } = 0;

        public AcertijoSecuencia(int rondasParaGanar = ConfigJuego.RondasSecuencia)
        {
            RondasParaGanar = rondasParaGanar;
        }

        public void RegistrarAcierto()
        {
            if (!Resuelto) Aciertos++;
        }

        public void RegistrarRonda()
        {
            if (!Resuelto) RondasTotales++;
        }
        public override bool ValidarRespuesta(string _)
        {
            if (Aciertos >= RondasParaGanar)
            {
                Resuelto = true;
                return true;
            }
            return false;
        }

        public override int CalcularPuntos()
        {
            if (!Resuelto) return 0;
            int fallos = RondasTotales - Aciertos;
            int descuento = fallos * ConfigJuego.DescuentoPorFallo;
            return Math.Max(ConfigJuego.PuntosBase - descuento, 0);
        }
    }

    public class AcertijoOpcionMultiple : Acertijo
    {
        public string Pregunta { get; } = string.Empty;
        public List<string> Opciones { get; }
        public List<Image?> ImagenesOpciones { get; }
        private readonly int _indiceCorrecto;

        public AcertijoOpcionMultiple(string pregunta, List<string> opciones, int indiceCorrecto, List<Image?>? imagenesOpciones = null)
        {
            Pregunta = pregunta;
            Opciones = opciones;
            _indiceCorrecto = indiceCorrecto;
            ImagenesOpciones = imagenesOpciones ?? new List<Image?>(new Image?[opciones.Count]);
        }

        public override bool ValidarRespuesta(string respuesta)
        {
            if (int.TryParse(respuesta, out int indice) && indice == _indiceCorrecto)
            {
                Resuelto = true;
                return true;
            }
            return false;
        }
    }

    public class AcertijoCuestionario : Acertijo
    {
        public IReadOnlyList<AcertijoOpcionMultiple> Preguntas { get; }
        public int PreguntaActual { get; private set; } = 0;
        public AcertijoCuestionario(List<AcertijoOpcionMultiple> preguntas)
        {
            Preguntas = preguntas.OrderBy(_ => Random.Shared.Next()).ToList().AsReadOnly();
        }
        public AcertijoOpcionMultiple? ObtenerPreguntaActual() =>
            PreguntaActual < Preguntas.Count ? Preguntas[PreguntaActual] : null;
        public override bool ValidarRespuesta(string respuesta)
        {
            var pregunta = ObtenerPreguntaActual();
            if (pregunta == null) return false;
            else
        if (pregunta.Resolver(respuesta))
            {
                PreguntaActual++;
                if (PreguntaActual >= Preguntas.Count)
                {
                    Resuelto = true;
                    return true;
                }
                return true;
            }
            else
            {
                if (pregunta.Intentos >= ConfigJuego.IntentosMaximosCuestionario)
                    return false; // falla completo, Resuelto nunca se marca
                return false;
            }
        }

        public override int CalcularPuntos()
        {
            int puntosTotales = 0;
            if (!Resuelto) return 0;
            foreach (var pregunta in Preguntas)
            {
                puntosTotales += pregunta.CalcularPuntos();
            }
            return puntosTotales;
        }

    }
        public class AcertijoMemorama : Acertijo
        {
            public int RondasParaGanar { get; private set; } = 0;
            public int RondasGanadas { get; private set; } = 0;
            public int TiempoRestante { get; private set; } = 0;
            public int RondasTotales { get; private set; } = 0;

            public AcertijoMemorama(int rondasParaGanar = ConfigJuego.RondasMemorama)
            {
                RondasParaGanar = rondasParaGanar;
            }

            public void RegistrarTiempo(int segundos)
            {
                TiempoRestante += segundos;
            }
            public void RegistrarRondaGanada()
            { 
                if (!Resuelto) RondasGanadas++;
            }
            public void RegistrarRonda()
            { 
                if (!Resuelto) RondasTotales++;
            }
            public override bool ValidarRespuesta(string respuesta)
            {
                if (RondasGanadas >= RondasParaGanar)
                {
                    Resuelto = true;
                    return true;
                }
                return false;
            }

            public override int CalcularPuntos()
            {
                if (!Resuelto) return 0;
                int puntosBase = ConfigJuego.PuntosBaseMemorama;
                int bonusTiempo = TiempoRestante * ConfigJuego.PuntosPorSegundoRestante;
                int fallos = RondasTotales - RondasGanadas;
                return puntosBase + bonusTiempo - (fallos * ConfigJuego.DescuentoPorFallo);
            }
        }

        public class AcertijoCodigo : Acertijo
        {
            private readonly string _codigoCorrecto;

            public AcertijoCodigo(string codigo)
            {
                _codigoCorrecto = codigo.Trim();
            }

            public override bool ValidarRespuesta(string respuesta)
            {
                if (respuesta.Trim() == _codigoCorrecto)
                {
                    Resuelto = true;
                    return true;
                }
                return false;
            }
        }
    }



