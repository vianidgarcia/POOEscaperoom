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
        public Acertijo Acertijo { get; }
        public string? FragmentoEsperanza { get; }

        public bool Completada { get; private set; } = false;

        public Zona(string id, string nombreVisible, Image imagenFondo,
                    Image spritePersonaje, Personaje personaje,
                    List<Dialogo> dialogos, Acertijo acertijo,
                    string? fragmentoEsperanza = null)
        {
            Id = id;
            NombreVisible = nombreVisible;
            ImagenFondo = imagenFondo;
            SpritePersonaje = spritePersonaje;
            Personaje = personaje;
            Dialogos = dialogos.AsReadOnly();
            Acertijo = acertijo;
            FragmentoEsperanza = fragmentoEsperanza;
        }

        // Constructor alternativo para zonas narrativas sin acertijo (ej. intro)
        public Zona(string id, string nombreVisible, Image imagenFondo,
                    Image spritePersonaje, Personaje personaje, List<Dialogo> dialogos)
            : this(id, nombreVisible, imagenFondo, spritePersonaje, personaje, dialogos, null!, null)
        { }


        public void MarcarComoCompletada() => Completada = true;
    }
}
 
