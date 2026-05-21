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
        public string NombreVisible { get; }
        public Image ImagenFondo { get; }
        public Image SpritePersonaje { get; }
        public Personaje Personaje { get; }
        public IReadOnlyList<Dialogo> Dialogos { get; }
        public Acertijo? Acertijo { get; }
        public bool DaFragmento { get; }
        public bool Completada { get; private set; } = false;
        public IReadOnlyList<Dialogo>? DialogosPista { get; }

        public Zona(string id, string nombreVisible, Image imagenFondo,
                    Image spritePersonaje, Personaje personaje,
                    List<Dialogo> dialogos, Acertijo? acertijo = null,
                    string? fragmentoEsperanza = null, List<Dialogo> dialogosPista = null)
        {
            Id = id;
            NombreVisible = nombreVisible;
            ImagenFondo = imagenFondo;
            SpritePersonaje = spritePersonaje;
            Personaje = personaje;
            Dialogos = dialogos.AsReadOnly();
            Acertijo = acertijo;
            DaFragmento = fragmentoEsperanza != null;
            DialogosPista = dialogosPista?.AsReadOnly();

        }

        // Constructor alternativo para zonas narrativas sin acertijo (ej. intro)
        public Zona(string id, string nombreVisible, Image imagenFondo,
                    Image spritePersonaje, Personaje personaje, List<Dialogo> dialogos)
            : this(id, nombreVisible, imagenFondo, spritePersonaje, personaje, dialogos, null!, null)
        { 
        }

        public void MarcarComoCompletada() => Completada = true;
    }
}
 
