using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public static class ConfigJuego
    {
        // Puntuación
        public const int PuntosBase = 100;
        public const int DescuentoPorFallo = 25;
        public const int PuntosBaseMemorama = 200;

        // Rondas
        public const int RondasSecuencia = 3;
        public const int RondasMemorama = 1;
        public const int RondasCuestionario = 3;

        // Tiempo
        public const int TiempoMemorama = 60;
        public const int PuntosPorSegundoRestante = 5;

        public const int IntentosMaximosCuestionario = 3;
    }
}
