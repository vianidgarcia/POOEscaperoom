using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class EscenaHabitacion
    {
        private readonly Dictionary<Acertijo, Rectangle> _mapaInteractivo = new();

        public Image Fondo { get; private set; }

        public EscenaHabitacion(Image fondo)
        {
            Fondo = fondo;
        }

        public void RegistrarObjeto(Acertijo acertijo, Rectangle area)
        {
            if (acertijo == null) return;
            _mapaInteractivo[acertijo] = area;
        }

        public Acertijo GetAcertijoEnPunto(Point puntoClic, Size tamañoControl, Image imagenOriginal)
        {
            if (imagenOriginal == null || tamañoControl.Width == 0 || tamañoControl.Height == 0)
                return null;

            float factorX = (float)imagenOriginal.Width / tamañoControl.Width;
            float factorY = (float)imagenOriginal.Height / tamañoControl.Height;

            Point puntoReal = new Point((int)(puntoClic.X * factorX), (int)(puntoClic.Y * factorY));

            foreach (var kvp in _mapaInteractivo)
            {
                if (kvp.Value.Contains(puntoReal))
                    return kvp.Key;
            }
            return null;
        }

        public IEnumerable<Rectangle> ObtenerAreas() => _mapaInteractivo.Values;

    }
}
