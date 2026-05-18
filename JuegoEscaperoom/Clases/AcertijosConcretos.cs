
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

        public AcertijoSecuencia(string pregunta, string pista, int rondasParaGanar = 3)
        {
            Pregunta = pregunta;
            Pista = pista;
            RondasParaGanar = rondasParaGanar;
        }

        public void RegistrarAcierto() => Aciertos++;

        public override bool ValidarRespuesta(string _) => Aciertos >= RondasParaGanar;
    }

    namespace JuegoEscaperoom.Clases
    {
        public class AcertijoOpcionMultiple : Acertijo
        {
            public List<string> Opciones { get; }
            public List<Image?> ImagenesOpciones { get; }
            private readonly int _indiceCorrecto;

            public AcertijoOpcionMultiple(
                string pregunta,
                List<string> opciones,
                int indiceCorrecto,
                string pista = "",
                List<Image?>? imagenesOpciones = null)
            {
                Pregunta = pregunta;
                Opciones = opciones;
                Pista = pista;
                _indiceCorrecto = indiceCorrecto;
                ImagenesOpciones = imagenesOpciones ?? new List<Image?>(new Image?[opciones.Count]);
            }

            public override bool ValidarRespuesta(string respuesta) =>
                int.TryParse(respuesta, out int indice) && indice == _indiceCorrecto;
        }
    }

}

