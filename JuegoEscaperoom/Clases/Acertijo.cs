using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoEscaperoom.Interfaces;

namespace JuegoEscaperoom
{
    public abstract class Acertijo : IResoluble
    {
        public string Pregunta { get; protected set; } = "";
        public string Pista { get; protected set; } = "";
        public bool Resuelto { get; private set; } = false;
        public int Intentos { get; private set; } = 0;

        public abstract bool ValidarRespuesta(string respuesta);

        public bool Resolver(string respuesta)
        {
            Intentos++;
            if (!ValidarRespuesta(respuesta)) return false;
            Resuelto = true;
            return true;
        }
        protected static string Normalizar(string texto) =>
        texto?.Trim().ToLowerInvariant()
                .Replace("á", "a").Replace("é", "e")
                .Replace("í", "i").Replace("ó", "o")
                .Replace("ú", "u") ?? "";
    }
}
