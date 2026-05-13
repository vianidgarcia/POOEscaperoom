using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoEscaperoom.Interfaces;

namespace JuegoEscaperoom.Clases
{
    public class Dialogo
    {
        public Personaje Hablante { get; init; } = null!;
        public string Texto { get; init; } = "";
        public string ExpresionAUsar { get; init; } = "";
        public Action<IEscenaGrafica>? EfectoEspecial { get; init; }
    }
}
 

