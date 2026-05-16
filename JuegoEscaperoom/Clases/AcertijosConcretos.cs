
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class AcertijoTexto : Acertijo
    {
        private readonly string _respuestaCorrecta;

        public AcertijoTexto(string pregunta, string respuesta, string pista = "")
        {
            Pregunta = pregunta;
            Pista = pista;
            _respuestaCorrecta = Normalizar(respuesta);
        }

        public override bool ValidarRespuesta(string respuesta) =>
            Normalizar(respuesta) == _respuestaCorrecta;
    }

    public class AcertijoNumerico : Acertijo
    {
        private readonly int _numeroCorrecto;

        public AcertijoNumerico(string pregunta, int respuesta, string pista = "")
        {
            Pregunta = pregunta;
            Pista = pista;
            _numeroCorrecto = respuesta;
        }

        public override bool ValidarRespuesta(string respuesta) =>
            int.TryParse(respuesta, out int n) && n == _numeroCorrecto;
    }

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
        private readonly int _indiceCorrecto;
        public AcertijoOpcionMultiple(string pregunta, List<string> opciones, int indiceCorrecto, string pista = "")
        {
            Pregunta = pregunta;
            Opciones = opciones;
            Pista = pista;
            _indiceCorrecto = indiceCorrecto;
        }
        public override bool ValidarRespuesta(string respuesta) =>
            int.TryParse(respuesta, out int indice) && indice == _indiceCorrecto;
    }

    public class AcertijoLogica : Acertijo
    {
        private readonly Func<string, bool> _validador;
        public AcertijoLogica(string pregunta, Func<string, bool> validador, string pista = "")
        {
            Pregunta = pregunta;
            Pista = pista;
            _validador = validador;
           
        }
        public override bool ValidarRespuesta(string respuesta) => _validador(respuesta);
    }
}

