using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public static class BancoZonas
    {
        public static List<Zona> ObtenerTodasLasZonas() => new()
        {
            CrearZonaHiyoko(),
            CrearZonaGundham(),
            CrearZonaChiaki(),
            CrearZonaNagito()
        };

        public static Zona ObtenerZonaHiyoko() => CrearZonaHiyoko();

        public static Zona CrearZonaIntro(Action<string> talentoCallback, Func<string> obtenerTalento, Action onRegistrar)
        {
            var monokuma = new Personaje("Monokuma", "");
            monokuma.AgregarExpresion("neutral", Properties.Resources.kuma_neutral);
            monokuma.AgregarExpresion("riendo", Properties.Resources.kuma_riendo);
            monokuma.AgregarExpresion("feliz", Properties.Resources.kuma_feliz);
            monokuma.AgregarExpresion("serio", Properties.Resources.kuma_serio);
            monokuma.AgregarExpresion("curioso", Properties.Resources.kuma_curioso);
            monokuma.AgregarExpresion("despreocupado", Properties.Resources.kuma_despreocupado);

            var dialogos = new List<Dialogo>
            {
                new() { Hablante = monokuma, Texto = "...", ExpresionAUsar = "neutral" },
                new() { Hablante = monokuma, Texto = "Vaya, vaya. Parece que tenemos un nuevo participante.", ExpresionAUsar = "riendo" },
                new() { Hablante = monokuma, Texto = "Permíteme presentarme. Soy Monokuma, tu adorable anfitrión en esta hermosa isla.", ExpresionAUsar = "feliz" },
                new() { Hablante = monokuma, Texto = "Bienvenido a la Isla Jabberwock. Preciosa, verdad? Lástima que no puedas irte.", ExpresionAUsar = "serio" },
                new() { Hablante = monokuma, Texto = "Aquí encontrarás a algunos estudiantes muy interesantes. Cada uno tiene algo para ti.", ExpresionAUsar = "despreocupado" },
                new() { Hablante = monokuma, Texto = "Pero antes de empezar, necesito registrarte oficialmente en el e-Handbook.", ExpresionAUsar = "curioso"},
                new() { Hablante = monokuma, Texto = "Dime... cual es tu talento, Super Estudiante?", ExpresionAUsar = "riendo", EfectoEspecial = uc => uc.MostrarInputTalento(talentoCallback)},
                new() { Hablante = monokuma, ExpresionAUsar = "feliz", EfectoEspecial = (escena) =>
                    {
                        string talento = obtenerTalento();
                        bool duplicado = PersistenciaPartida.TalentoYaExiste(talento);
                        string reaccion = duplicado
                            ? $"Espera... ¿otro Súper {talento}? Esto se pone interesante. ¡Upupupu!"
                            : $"¡Súper {talento}! Qué título tan... peculiar. ¡Upupupu!";
                        escena.CambiarTextoDialogo(reaccion);
                    }},
                new() { Hablante = monokuma, Texto = "Perfecto. Queda registrado en el e-Handbook. Que empiece el show!",ExpresionAUsar = "serio", EfectoEspecial= (escena) => onRegistrar()} 
            };

            return new Zona("intro", "Introduccion",
                Properties.Resources.zona_intro,
                Properties.Resources.kuma_neutral,
                monokuma, dialogos);
        }

        private static Zona CrearZonaHiyoko()
        {
            var personaje = new Personaje("Hiyoko Saionji", "");
            personaje.AgregarExpresion("normal", Properties.Resources.hiyoko_pretenciosa);
            personaje.AgregarExpresion("burlona", Properties.Resources.hiyoko_burlona);
            personaje.AgregarExpresion("seria", Properties.Resources.hiyoko_despreocupada);
            personaje.AgregarExpresion("curiosa", Properties.Resources.hiyoko_curiosa);

            var dialogos = new List<Dialogo>
            {
                new() { Hablante = personaje, Texto = "Que haces aqui, torpe?",                                          ExpresionAUsar = "burlona" },
                new() { Hablante = personaje, Texto = "Si quieres pasar, demuestra que tienes algo de ritmo.",           ExpresionAUsar = "seria"   },
                new() { Hablante = personaje, Texto = "El bon odori tiene un orden sagrado. Cada paso en su momento.",   ExpresionAUsar = "pretenciosa"  },
                new() { Hablante = personaje, Texto = "Listo para intentarlo?",                                           ExpresionAUsar = "curiosa" },
            };

            var acertijo = new AcertijoSecuencia(
                "Repite la secuencia de pasos que marca Hiyoko.",
                "Observa el orden de los botones."
                );

            return new Zona("hiyoko", "Escenario de danza",
                Properties.Resources.zona_hiyoko,
                Properties.Resources.hiyoko_fullbody,
                personaje, dialogos, acertijo, "Fragmento de Esperanza");
        }

        private static Zona CrearZonaGundham()
        {
            var personaje = new Personaje("Gundham Tanaka", "");
            personaje.AgregarExpresion("dramatico", Properties.Resources.gundham_dramatico);
            personaje.AgregarExpresion("serio", Properties.Resources.gundham_serio);
            personaje.AgregarExpresion("relajado", Properties.Resources.gundham_relajado);
            personaje.AgregarExpresion("confundido", Properties.Resources.gundham_confundido);

            var dialogos = new List<Dialogo>
            {
                new() { Hablante = personaje, Texto = "Mortal! Has osado entrar al dominio de los Cuatro Jinetes Oscuros.",    ExpresionAUsar = "dramatico" },
                new() { Hablante = personaje, Texto = "Mis cuatro guardianes obedecen un orden cosmico inamovible.",           ExpresionAUsar = "serio"     },
                new() { Hablante = personaje, Texto = "Eh? Que quieres entender de lo que hablo?",           ExpresionAUsar = "confundido"     },
                new() { Hablante = personaje, Texto = "Si los invocas en el orden correcto... considerare dejarte pasar.",     ExpresionAUsar = "relajado"  },
            };

            var acertijo = new AcertijoSecuencia(
                "Invoca a los hamsteres en el orden ritual correcto.",
                "El orden: Cham-P, San-D, Maga-Z, Jum-P.");

            return new Zona("gundham", "Establos del fin del mundo",
                Properties.Resources.zona_gundham,
                Properties.Resources.gundham_fullbody,
                personaje, dialogos, acertijo, "Fragmento de Esperanza");
        }

        
        private static Zona CrearZonaChiaki()
        {
            var personaje = new Personaje("Chiaki Nanami", "");
            personaje.AgregarExpresion("tranquila", Properties.Resources.chiaki_tranquila);
            personaje.AgregarExpresion("curiosa", Properties.Resources.chiaki_curiosa);
            personaje.AgregarExpresion("pensando", Properties.Resources.chiaki_pensando);
            personaje.AgregarExpresion("sorprendida", Properties.Resources.chiaki_sorprendida);

            var dialogos = new List<Dialogo>
            {
                new() { Hablante = personaje, Texto = "...Ah, hola.",                                                         ExpresionAUsar = "tranquila" },
                new() { Hablante = personaje, Texto = "Todo juego tiene un patron. Si lo memorizas, siempre puedes ganar.",   ExpresionAUsar = "curiosa"   },
                new() { Hablante = personaje, Texto = "Te voy a mostrar algo. Solo tienes que recordarlo exactamente.",        ExpresionAUsar = "pensando"  },
                new() { Hablante = personaje, Texto = "¿Listo para intentarlo?",                                                   ExpresionAUsar = "sorprendida" },
            };

            var acertijo = new AcertijoSecuencia(
                "Memoriza el patron y luego recrealo.",
                "Tienes 3 segundos para observarlo.");

            return new Zona("chiaki", "Sala de arcade",
                Properties.Resources.zona_chiaki,
                Properties.Resources.chiaki_fullbody,
                personaje, dialogos, acertijo, "Fragmento de Esperanza");
        }

        private static Zona CrearZonaNagito()
        {
            var personaje = new Personaje("Nagito Komaeda", "");
            personaje.AgregarExpresion("sonriente", Properties.Resources.nagito_feliz);
            personaje.AgregarExpresion("pensativo", Properties.Resources.nagito_pensando);
            personaje.AgregarExpresion("intenso", Properties.Resources.nagito_intenso);

            var dialogos = new List<Dialogo>
            {
                new() { Hablante = personaje, Texto = "Oh... no esperaba visita. Aunque la suerte siempre encuentra su camino.",       ExpresionAUsar = "sonriente" },
                new() { Hablante = personaje, Texto = "La logica es la unica esperanza verdadera, no crees?",                          ExpresionAUsar = "pensativo" },
                new() { Hablante = personaje, Texto = "Permiteme hacerte unas preguntas. Para alguien con esperanza, no seran problema.", ExpresionAUsar = "intenso" },
            };

            var acertijo = new AcertijoSecuencia(
                "Responde las tres preguntas correctamente.",
                "La logica es suficiente.",
               3);

            return new Zona("nagito", "Biblioteca de la isla",
                Properties.Resources.zona_nagito,
                Properties.Resources.nagito_fullbody,
                personaje, dialogos, acertijo, "Fragmento de Esperanza");
        }
        
    }
}
