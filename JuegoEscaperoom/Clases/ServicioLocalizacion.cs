using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public sealed class ServicioLocalizacion
    {
        private string RutaJson(string codigo) =>
            Path.GetFullPath(Path.Combine(CarpetaIdiomas, $"{codigo}.json"));
        private ServicioLocalizacion() => CargarIdioma("es");
        private static ServicioLocalizacion? _instancia;
        public static ServicioLocalizacion Instancia => _instancia ??= new ServicioLocalizacion();
        private JsonNode _datos = JsonNode.Parse("{}")!;

        private static readonly string CarpetaIdiomas = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data", "Idiomas");

        public JsonNode? ObtenerAcertijo(string zonaId) => _datos["acertijos"]?[zonaId];

        public string IdiomaActual { get; private set; } = "es";

        public void CargarIdioma(string codigoIdioma)
        {
            string ruta = RutaJson(codigoIdioma);

            if (!File.Exists(ruta))
            {
                ruta = RutaJson("es");
                codigoIdioma = "es";
            }

            _datos = JsonNode.Parse(File.ReadAllText(ruta))!;
            IdiomaActual = codigoIdioma;
        }

        public string Obtener(string ruta)
        {
            JsonNode? nodo = _datos;
            foreach (string segmento in ruta.Split('.'))
            {
                nodo = nodo?[segmento];
                if (nodo == null) return $"[{ruta}]";
            }
            return nodo?.GetValue<string>() ?? $"[{ruta}]";
        }

        public string Formato(string ruta, params object[] args)
        {
            string plantilla = Obtener(ruta);
            try { return string.Format(plantilla, args); }
            catch { return plantilla; }
        }

        public JsonArray ObtenerDialogos(string zonaId) =>
            _datos["dialogos"]?[zonaId]?.AsArray() ?? new JsonArray();

        public string ObtenerReaccionTalento(string talento, bool duplicado)
        {
            string clave = duplicado
                ? "dialogos.monokuma_talento_duplicado"
                : "dialogos.monokuma_talento_nuevo";
            return Formato(clave, talento);
        }
    }
}
