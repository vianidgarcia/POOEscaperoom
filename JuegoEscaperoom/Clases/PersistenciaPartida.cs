using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public static class PersistenciaPartida
    {
        private static readonly string RutaCarpetaPartidas = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Partidas");

        private static readonly JsonSerializerOptions Opciones =
            new() { WriteIndented = true };

        public static bool TalentoYaExiste(string talento)
        {
            return ListarPartidasGuardadas()
                .Any(p => p.TalentoJugador.Equals(talento, StringComparison.OrdinalIgnoreCase));
        }
        public static void GuardarPartida(EstadoJuego estado)
        {
            if (!Directory.Exists(RutaCarpetaPartidas))
                Directory.CreateDirectory(RutaCarpetaPartidas);
            string json = JsonSerializer.Serialize(estado, Opciones);
            string nombreArchivo = $"{estado.SlotId}.json";
            string rutaArchivo = Path.Combine(RutaCarpetaPartidas, nombreArchivo);
            File.WriteAllText(rutaArchivo, json);
        }

        public static List<EstadoJuego> ListarPartidasGuardadas()
        {
            if (!Directory.Exists(RutaCarpetaPartidas))
                return new List<EstadoJuego>();

            var archivos = Directory.GetFiles(RutaCarpetaPartidas, "*.json");
            var partidas = new List<EstadoJuego>();

            foreach (var archivo in archivos)
            {
                string json = File.ReadAllText(archivo);
                var estado = JsonSerializer.Deserialize<EstadoJuego>(json);
                if (estado != null)
                    partidas.Add(estado);
            }

            return partidas;
        }

        public static EstadoJuego CargarPartida(string slotId)
        {
            string rutaArchivo = Path.Combine(RutaCarpetaPartidas, $"{slotId}.json");
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException(
                    $"No se encontró una partida para el talento '{slotId}'.", RutaCarpetaPartidas);

            EstadoJuego estado = JsonSerializer.Deserialize<EstadoJuego>(File.ReadAllText(rutaArchivo))
               ?? throw new FormatException( $"La partida para el talento '{slotId}' no se pudo deserializar.");
            return estado;
        }

        public static void EliminarPartida(string slotId)
        {
            string rutaArchivo = Path.Combine(RutaCarpetaPartidas, $"{slotId}.json");
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);
        }
    }
}