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
        public List<string> FragmentosEsperanza { get; private set; } = new();
        public DateTime FechaGuardado { get; set; } = DateTime.Now;

        public string SlotId => $"{TalentoJugador}_{FechaGuardado:yyyyMMddHHmmss}";

        public EstadoJuego() { }

        [JsonConstructor]
        public EstadoJuego(int puntaje, string talentoJugador,
                           List<string> zonasCompletadas,
                           List<string> fragmentosEsperanza,
                           DateTime fechaGuardado)
        {
            Puntaje = puntaje;
            TalentoJugador = talentoJugador;
            ZonasCompletadas = zonasCompletadas ?? new();
            FragmentosEsperanza = fragmentosEsperanza ?? new();
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

        public void AgregarFragmento(string fragmento)
        {
            if (!string.IsNullOrEmpty(fragmento) &&
                !FragmentosEsperanza.Contains(fragmento))
                FragmentosEsperanza.Add(fragmento);
        }

        public bool ZonaCompletada(string idZona) =>
            ZonasCompletadas.Contains(idZona);

        public bool PuedeIrAJunko => FragmentosEsperanza.Count >= 4;
    }
}

