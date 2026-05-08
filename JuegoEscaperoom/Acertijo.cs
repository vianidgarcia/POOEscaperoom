using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    using JuegoEscaperoom.JuegoEscaperoomS;
    using System.Drawing;

    namespace EscapeRoomPOO
    {
        public abstract class Acertijo : IResoluble
        {

            // Propiedades públicas (Lectura)
            public string Pregunta { get; protected set; } = "";
            public string Pista { get; protected set; } = "";
            public string NombreObjeto { get; protected set; } = "";
            public string ItemRequerido { get; protected set; } = "";
            public string ItemRecompensa { get; protected set; } = "";
            public Rectangle Area { get; set; }
            public bool Resuelto { get; private set; } = false;
            public int Intentos { get; private set; } = 0;
            public Habitacion? HabitacionDestino { get; protected set; }
            public bool EsVictoriaFinal { get; set; } = false;
            public abstract bool ValidarRespuesta(string respuesta);

            public bool Resolver(string respuesta)
            {
                Intentos++;
                Resuelto = ValidarRespuesta(respuesta);
                return Resuelto;
            }

            public void MarcarComoResuelto()
            { 
                Resuelto = true; 
            }

            protected string Normalizar(string texto) =>
                texto?.Trim().ToLowerInvariant().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u") ?? "";
        }
    }
}
