using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace JuegoEscaperoom.Clases
{
    public static class PersistenciaPartida
    {
        private static readonly string RutaGuardado = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "guardado.json");

        private static readonly JsonSerializerOptions Opciones =
            new() { WriteIndented = true };

        public static void GuardarPartida(EstadoJuego estado)
        {
            string json = JsonSerializer.Serialize(estado, Opciones);
            File.WriteAllText(RutaGuardado, json);
        }

        public static EstadoJuego CargarPartida()
        {
            if (!File.Exists(RutaGuardado))
                throw new FileNotFoundException(
                    "No se encontró el archivo de guardado.", RutaGuardado);

            string json = File.ReadAllText(RutaGuardado);
            return JsonSerializer.Deserialize<EstadoJuego>(json)
                ?? throw new InvalidDataException("El archivo de guardado está vacío o corrupto.");
        }

        public static bool ExistePartida() => File.Exists(RutaGuardado);

        public static void BorrarPartida()
        {
            if (ExistePartida())
                File.Delete(RutaGuardado);
        }
    }
}