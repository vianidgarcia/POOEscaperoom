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
        private static readonly string CarpetaZonas = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "Zonas");
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;

        public static List<Zona> ObtenerTodasLasZonas()
        {
            string[] archivos = Directory.GetFiles(CarpetaZonas, "*.json");
            var zonas = new List<Zona>();
            foreach (var archivo in archivos)
                zonas.Add(ConstruirZonaDesdeJson(archivo));
            return zonas;
        }

        private static Zona ConstruirZonaDesdeJson(string rutaArchivo)
        {
            string json = File.ReadAllText(rutaArchivo);
            var nodo = JsonNode.Parse(json)!;

            string id = nodo["id"]!.GetValue<string>();
            string rutaFondo = nodo["imagenFondo"]!.GetValue<string>();
            string rutaFullbody = nodo["spritePersonaje"]!.GetValue<string>();
            bool daFragmento = nodo["daFragmento"]?.GetValue<bool>() ?? false;

            if (!File.Exists(rutaFondo))
                throw new FileNotFoundException($"La imagen de fondo con la ruta '{rutaFondo}' no existe.");
            if (!File.Exists(rutaFullbody))
                throw new FileNotFoundException($"La imagen de fullbody con la ruta '{rutaFullbody}' no existe.");

            var personaje = ConstruirPersonaje(nodo["personaje"]!);
            var dialogos = ConstruirDialogos(id, personaje);
            var dialogosPista = ConstruirDialogos($"{id}_pista", personaje);
            string? tipoAcertijo = nodo["tipoAcertijo"]?.GetValue<string>();
           

            var acertijo = ConstruirAcertijo(tipoAcertijo, id);

            return new Zona(id, Image.FromFile(rutaFondo), Image.FromFile(rutaFullbody), personaje, dialogos, acertijo, daFragmento, dialogosPista);
        }

        private static Acertijo? ConstruirAcertijo(string? tipoAcertijo, string zonaId)
        { 
            switch (tipoAcertijo)
            {
                case "secuencia":
                    return ConstruirAcertijoSecuencia(zonaId);
                case "memorama":
                    return ConstruirAcertijoMemorama(zonaId);
                case "cuestionario":
                    return ConstruirAcertijoCuestionario(zonaId);
                case "codigo":
                    return ConstruirAcertijoCodigo(zonaId);
                default:
                    return null;
            }
        }

        private static Personaje ConstruirPersonaje(JsonNode nodo)
        {
            string nombre = nodo["nombre"]!.GetValue<string>();
            var personaje = new Personaje(nombre);

            foreach (var par in nodo["expresiones"]!.AsObject())
            {
                string clave = par.Key;
                string ruta = par.Value!.GetValue<string>();

                if (!File.Exists(ruta))
                    throw new FileNotFoundException(
                        $"La imagen con la ruta '{ruta}' perteneciente a la expresión '{clave}' no existe.");

                personaje.AgregarExpresion(clave, Image.FromFile(ruta));
            }

            return personaje;
        }

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

            return new Zona("intro",
                Properties.Resources.zona_intro,
                Properties.Resources.kuma_neutral,
                monokuma, dialogos);
        }

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

        private static AcertijoCuestionario ConstruirAcertijoCuestionario(string zonaId)
        {
            var preguntas = ConstruirPreguntasOpcionMultiple(zonaId);
            return new AcertijoCuestionario(preguntas);
        }

        private static AcertijoSecuencia ConstruirAcertijoSecuencia(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            int rondas = nodo?["rondasParaGanar"]?.GetValue<int>() ?? 3;
            return new AcertijoSecuencia(rondas);
        }

        private static AcertijoMemorama ConstruirAcertijoMemorama(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            int rondas = nodo?["rondasParaGanar"]?.GetValue<int>() ?? 3;
            return new AcertijoMemorama(rondas);
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

                resultado.Add(new AcertijoOpcionMultiple(pregunta, opciones, correcto, imagenes));
            }

            return resultado;
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

        private static AcertijoCodigo ConstruirAcertijoCodigo(string zonaId)
        {
            var nodo = L.ObtenerAcertijo(zonaId);
            string codigo = nodo?["codigo"]?.GetValue<string>() ?? "";
            return new AcertijoCodigo(codigo);
        }
    }
}
