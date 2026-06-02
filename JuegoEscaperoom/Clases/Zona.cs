using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class Zona
    {
        public string Id { get; }
        public Image ImagenFondo { get; }
        public Image SpritePersonaje { get; }
        public Personaje Personaje { get; }
        public IReadOnlyList<Dialogo> Dialogos { get; }
        public Acertijo? Acertijo { get; }
        public bool DaFragmento { get; }
        public bool Completada { get; private set; } = false;
        public IReadOnlyList<Dialogo>? DialogosPista { get; }

        public Zona(string id, Image imagenFondo,
                    Image spritePersonaje, Personaje personaje,
                    List<Dialogo> dialogos, Acertijo? acertijo = null,
                   bool daFragmento = false, List<Dialogo>? dialogosPista = null)
        {
            Id = id;
            ImagenFondo = imagenFondo;
            SpritePersonaje = spritePersonaje;
            Personaje = personaje;
            Dialogos = dialogos.AsReadOnly();
            Acertijo = acertijo;
            DaFragmento = daFragmento;
            DialogosPista = dialogosPista?.AsReadOnly();

        }
        public void MarcarComoCompletada() => Completada = true;
    }
}
 
