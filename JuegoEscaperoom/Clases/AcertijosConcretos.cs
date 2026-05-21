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


    public class AcertijoMemorama : Acertijo
    {
        public int RondasParaGanar { get; private set; } = 0;

        public int RondasGanadas { get; private set; } = 0;

        public AcertijoMemorama(string pregunta, string pista = "", int rondasParaGanar = 3)
        {
            Pregunta = pregunta;
            Pista = pista;
            RondasParaGanar = rondasParaGanar;
        }

        public void RegistrarRondaGanada() => RondasGanadas++;

        public override bool ValidarRespuesta(string respuesta)
        {
            // La validación real se haría en el control del memorama, aquí solo se simula
            return RondasGanadas == RondasParaGanar;
        }
    }

    public class AcertijoCodigo : Acertijo
    {
        private readonly string _codigoCorrecto;

        public AcertijoCodigo(string pregunta, string codigo, string pista = "")
        {
            Pregunta = pregunta;
            Pista = pista;
            _codigoCorrecto = codigo.Trim();
        }

        public override bool ValidarRespuesta(string respuesta) =>
            respuesta.Trim() == _codigoCorrecto;
    }
}


