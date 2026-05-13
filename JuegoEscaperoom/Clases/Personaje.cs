using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class Personaje
    {
        public string Nombre { get; }
        public string RutaVoz { get; }

        private readonly Dictionary<string, Image> _expresiones = new();
        public IReadOnlyDictionary<string, Image> Expresiones => _expresiones;

        public Personaje(string nombre, string rutaVoz)
        {
            Nombre = nombre;
            RutaVoz = rutaVoz;
        }

        public void AgregarExpresion(string clave, Image imagen)
        {
            if (!string.IsNullOrEmpty(clave) && imagen != null)
                _expresiones[clave] = imagen;
        }

        public Image? ObtenerExpresion(string clave) =>
            _expresiones.TryGetValue(clave, out var img) ? img : null;
    }
}
