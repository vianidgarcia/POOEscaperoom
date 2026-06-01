using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoEscaperoom.Interfaces;

namespace JuegoEscaperoom.Clases
{
    public abstract class Acertijo : IResoluble
    {
        public bool Resuelto { get; protected set; } = false;
        public int Intentos { get; private set; } = 0;

        public abstract bool ValidarRespuesta(string respuesta);

        public bool Resolver(string respuesta)
        {
            Intentos++;
            if (!ValidarRespuesta(respuesta)) return false;
            return true;
        }

        public virtual int CalcularPuntos()
        {
            if (!Resuelto) return 0;
            int descuento = (Intentos - 1) * ConfigJuego.DescuentoPorFallo;
            return Math.Max(ConfigJuego.PuntosBase - descuento, 0);
        }
    }
}
