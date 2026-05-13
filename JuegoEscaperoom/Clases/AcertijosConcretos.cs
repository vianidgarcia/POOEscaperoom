
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
}

