using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class EstadoJuego
    {
        public int Puntaje { get; private set; } = 0;
        public string TalentoJugador { get; set; } = "";
        public List<string> ZonasCompletadas { get; private set; } = new();
        public int FragmentosObtenidos { get; private set; } = 0;

        public DateTime FechaGuardado { get; set; } = DateTime.Now;

        public string SlotId => $"{TalentoJugador}_{FechaGuardado:yyyyMMddHHmmss}";

        public EstadoJuego() { }

        [JsonConstructor]
        public EstadoJuego(int puntaje, string talentoJugador,
                           List<string> zonasCompletadas,
                           int fragmentosObtenidos,
                           DateTime fechaGuardado)
        {
            Puntaje = puntaje;
            TalentoJugador = talentoJugador;
            ZonasCompletadas = zonasCompletadas ?? new();
            FragmentosObtenidos = fragmentosObtenidos;
            FechaGuardado = fechaGuardado;
        }

        public void SumarPuntos(int puntos)
        {
            if (puntos > 0) Puntaje += puntos;
        }

        public void RegistrarZonaCompletada(string idZona)
        {
            if (!ZonasCompletadas.Contains(idZona))
                ZonasCompletadas.Add(idZona);
        }

        public bool ZonaCompletada(string idZona) =>
            ZonasCompletadas.Contains(idZona);

        public void AgregarFragmento() => FragmentosObtenidos++;

        public bool PuedeIrAZonaFinal => FragmentosObtenidos >= 4;
    }
}

