using JuegoEscaperoom.Clases;
using JuegoEscaperoom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public static class BancoZonas
    {
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;

        public static List<Zona> ObtenerTodasLasZonas() => new()
        {
            CrearZonaHiyoko(),
            CrearZonaGundham(),
            CrearZonaChiaki(),
            CrearZonaNagito()
        };

        public static Zona ObtenerZonaHiyoko() => CrearZonaHiyoko();

        public static Zona CrearZonaIntro(
            Action<string> talentoCallback,
            Func<string> obtenerTalento,
            Action onRegistrar)
        {
            var monokuma = CrearPersonajeMonokuma();
            var dialogos = ConstruirDialogos("monokuma_intro", monokuma,
                efectos: new Dictionary<string, Action<IEscenaGrafica>>
                {
                    ["input_talento"] = uc => uc.MostrarInputTalento(talentoCallback),
                    ["reaccion_talento"] = escena =>
                    {
                        string talento = obtenerTalento();
                        bool duplicado = PersistenciaPartida.TalentoYaExiste(talento);
                        string reaccion = L.ObtenerReaccionTalento(talento, duplicado);
                        escena.CambiarTextoDialogo(reaccion);
                    },
                    ["registrar"] = _ => onRegistrar()
                });

            return new Zona("intro", "Introduccion",
                Properties.Resources.zona_intro,
                Properties.Resources.kuma_neutral,
                monokuma, dialogos);
        }

        private static Zona CrearZonaHiyoko()
        {
            var personaje = new Personaje("Hiyoko Saionji");
            personaje.AgregarExpresion("normal", Properties.Resources.hiyoko_pretenciosa);
            personaje.AgregarExpresion("burlona", Properties.Resources.hiyoko_burlona);
            personaje.AgregarExpresion("seria", Properties.Resources.hiyoko_despreocupada);
            personaje.AgregarExpresion("curiosa", Properties.Resources.hiyoko_curiosa);

            var dialogos = ConstruirDialogos("hiyoko", personaje);
            var acertijo = ConstruirAcertijoSecuencia("hiyoko");

            return new Zona("hiyoko", "Escenario de danza",
                Properties.Resources.zona_hiyoko,
                Properties.Resources.hiyoko_fullbody,
                personaje, dialogos, acertijo, L.Obtener("ui.fragmentoEsperanza"), ObtenerDialogosPistaHiyoko());
        }

        private static Zona CrearZonaGundham()
        {
            var personaje = new Personaje("Gundham Tanaka");
            personaje.AgregarExpresion("dramatico", Properties.Resources.gundham_dramatico);
            personaje.AgregarExpresion("serio", Properties.Resources.gundham_serio);
            personaje.AgregarExpresion("relajado", Properties.Resources.gundham_relajado);
            personaje.AgregarExpresion("confundido", Properties.Resources.gundham_confundido);

            var dialogos = ConstruirDialogos("gundham", personaje);

            return new Zona("gundham", "Establos del fin del mundo",
                Properties.Resources.zona_gundham,
                Properties.Resources.gundham_fullbody,
                personaje, dialogos, null, L.Obtener("ui.fragmentoEsperanza"), ObtenerDialogosPistaGundham());
        }

        private static Zona CrearZonaChiaki()
        {
            var personaje = new Personaje("Chiaki Nanami");
            personaje.AgregarExpresion("tranquila", Properties.Resources.chiaki_tranquila);
            personaje.AgregarExpresion("curiosa", Properties.Resources.chiaki_curiosa);
            personaje.AgregarExpresion("pensando", Properties.Resources.chiaki_pensando);
            personaje.AgregarExpresion("sorprendida", Properties.Resources.chiaki_sorprendida);

            var dialogos = ConstruirDialogos("chiaki", personaje);
            var acertijo = ConstruirAcertijoMemorama("chiaki");

            return new Zona("chiaki", "Sala de arcade",
                Properties.Resources.zona_chiaki,
                Properties.Resources.chiaki_fullbody,
                personaje, dialogos, acertijo, L.Obtener("ui.fragmentoEsperanza"), ObtenerDialogosPistaChiaki());
        }

        private static Zona CrearZonaNagito()
        {
            var personaje = new Personaje("Nagito Komaeda");
            personaje.AgregarExpresion("sonriente", Properties.Resources.nagito_feliz);
            personaje.AgregarExpresion("pensativo", Properties.Resources.nagito_pensando);
            personaje.AgregarExpresion("intenso", Properties.Resources.nagito_intenso);

            var dialogos = ConstruirDialogos("nagito", personaje);

            return new Zona("nagito", "Biblioteca de la isla",
                Properties.Resources.zona_nagito,
                Properties.Resources.nagito_fullbody,
                personaje, dialogos, null, L.Obtener("ui.fragmentoEsperanza"), ObtenerDialogosPistaNagito());
        }

        public static List<AcertijoOpcionMultiple> ObtenerPreguntasGundham() =>
            ConstruirPreguntasOpcionMultiple("gundham");

        public static List<AcertijoOpcionMultiple> ObtenerPreguntasNagito() =>
            ConstruirPreguntasOpcionMultiple("nagito");


        private static List<Dialogo> ConstruirDialogos(
            string zonaId,
            Personaje hablante,
            Dictionary<string, Action<IEscenaGrafica>>? efectos = null)
        {
            var resultado = new List<Dialogo>();
            var array = L.ObtenerDialogos(zonaId);

            foreach (var nodo in array)
            {
                string texto = nodo?["texto"]?.GetValue<string>() ?? "";
                string expresion = nodo?["expresion"]?.GetValue<string>() ?? "";
                string? claveEfecto = nodo?["efecto"]?.GetValue<string>();

                Action<IEscenaGrafica>? efecto = null;
                if (claveEfecto != null && efectos != null)
                    efectos.TryGetValue(claveEfecto, out efecto);

                resultado.Add(new Dialogo
                {
                    Hablante = hablante,
                    Texto = texto,
                    ExpresionAUsar = expresion,
                    EfectoEspecial = efecto
                });
            }
            return resultado;
        }

        private static AcertijoSecuencia ConstruirAcertijoSecuencia(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            string pregunta = nodo?["pregunta"]?.GetValue<string>() ?? "";
            string pista = nodo?["pista"]?.GetValue<string>() ?? "";
            int rondas = nodo?["rondasParaGanar"]?.GetValue<int>() ?? 3;
            return new AcertijoSecuencia(pregunta, pista, rondas);
        }

        private static AcertijoMemorama ConstruirAcertijoMemorama(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            string pregunta = nodo?["pregunta"]?.GetValue<string>() ?? "";
            string pista = nodo?["pista"]?.GetValue<string>() ?? "";
            int rondas = nodo?["rondasParaGanar"]?.GetValue<int>() ?? 3;
            return new AcertijoMemorama(pregunta, pista, rondas);
        }

        private static List<AcertijoOpcionMultiple> ConstruirPreguntasOpcionMultiple(string zonaId)
        {
            var nodoZona = L.ObtenerAcertijo(zonaId);
            var arrayPregs = nodoZona?["preguntas"]?.AsArray() ?? new JsonArray();
            var resultado = new List<AcertijoOpcionMultiple>();

            foreach (var p in arrayPregs)
            {
                string pregunta = p?["pregunta"]?.GetValue<string>() ?? "";
                string pista = p?["pista"]?.GetValue<string>() ?? "";
                int correcto = p?["indiceCorrecto"]?.GetValue<int>() ?? 0;

                var opciones = new List<string>();
                foreach (var op in p?["opciones"]?.AsArray() ?? new JsonArray())
                    opciones.Add(op?.GetValue<string>() ?? "");

                // Imágenes: se resuelven por nombre de recurso igual que antes
                List<Image?>? imagenes = null;
                var imgArray = p?["imagenesOpciones"]?.AsArray();
                if (imgArray != null)
                {
                    imagenes = new List<Image?>();
                    foreach (var img in imgArray)
                    {
                        string? key = img?.GetValue<string>();
                        imagenes.Add(key != null
                            ? Properties.Resources.ResourceManager.GetObject(key) as Image
                            : null);
                    }
                }

                resultado.Add(new AcertijoOpcionMultiple(pregunta, opciones, correcto, pista, imagenes));
            }

            return resultado.OrderBy(_ => Random.Shared.Next()).ToList();
        }

        private static Personaje CrearPersonajeMonokuma()
        {
            var m = new Personaje("Monokuma");
            m.AgregarExpresion("neutral", Properties.Resources.kuma_neutral);
            m.AgregarExpresion("riendo", Properties.Resources.kuma_riendo);
            m.AgregarExpresion("feliz", Properties.Resources.kuma_feliz);
            m.AgregarExpresion("serio", Properties.Resources.kuma_serio);
            m.AgregarExpresion("curioso", Properties.Resources.kuma_curioso);
            m.AgregarExpresion("despreocupado", Properties.Resources.kuma_despreocupado);
            return m;
        }

        public static Zona CrearZonaMonokumaFinal()
        {
            var monokuma = CrearPersonajeMonokuma();
            var dialogos = ConstruirDialogos("monokuma_final", monokuma);
            var acertijo = ConstruirAcertijoCodigo("monokuma_final");

            return new Zona("monokuma_final", "Puerta de Salida",
                Properties.Resources.zona_junko,
                Properties.Resources.kuma_serio,
                monokuma, dialogos, acertijo, null );
        }

        // Diálogos de pista para cada personaje
        // Se llaman desde ZonaUC cuando PuedeIrAJunko == true

        public static List<Dialogo> ObtenerDialogosPistaHiyoko()
        {
            var personaje = new Personaje("Hiyoko Saionji");
            personaje.AgregarExpresion("burlona", Properties.Resources.hiyoko_burlona);
            personaje.AgregarExpresion("seria", Properties.Resources.hiyoko_despreocupada);
            personaje.AgregarExpresion("curiosa", Properties.Resources.hiyoko_curiosa);
            return ConstruirDialogos("hiyoko_pista", personaje);
        }

        public static List<Dialogo> ObtenerDialogosPistaGundham()
        {
            var personaje = new Personaje("Gundham Tanaka");
            personaje.AgregarExpresion("serio", Properties.Resources.gundham_serio);
            personaje.AgregarExpresion("dramatico", Properties.Resources.gundham_dramatico);
            personaje.AgregarExpresion("relajado", Properties.Resources.gundham_relajado);
            return ConstruirDialogos("gundham_pista", personaje);
        }

        public static List<Dialogo> ObtenerDialogosPistaChiaki()
        {
            var personaje = new Personaje("Chiaki Nanami");
            personaje.AgregarExpresion("tranquila", Properties.Resources.chiaki_tranquila);
            personaje.AgregarExpresion("curiosa", Properties.Resources.chiaki_curiosa);
            personaje.AgregarExpresion("pensando", Properties.Resources.chiaki_pensando);
            return ConstruirDialogos("chiaki_pista", personaje);
        }

        public static List<Dialogo> ObtenerDialogosPistaNagito()
        {
            var personaje = new Personaje("Nagito Komaeda");
            personaje.AgregarExpresion("sonriente", Properties.Resources.nagito_feliz);
            personaje.AgregarExpresion("pensativo", Properties.Resources.nagito_pensando);
            personaje.AgregarExpresion("intenso", Properties.Resources.nagito_intenso);
            return ConstruirDialogos("nagito_pista", personaje);
        }

        // Helper para construir AcertijoCodigo desde JSON
        private static AcertijoCodigo ConstruirAcertijoCodigo(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            string codigo = nodo?["codigo"]?.GetValue<string>() ?? "";
            string pregunta = nodo?["pregunta"]?.GetValue<string>() ?? "";
            string pista = nodo?["pista"]?.GetValue<string>() ?? "";
            return new AcertijoCodigo(pregunta, codigo, pista);
        }
    }
}
