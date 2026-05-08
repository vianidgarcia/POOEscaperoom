using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public class EstadoJuego
    {
        public int Puntaje { get; private set; } = 0;
        public Habitacion HabitacionActual { get; private set; } = Habitacion.Cuarto;
        public bool IntroVista { get; set; } = false;
        public DateTime FechaGuardado { get; set; } = DateTime.Now;
        public List<string> Inventario { get; private set; } = new();
        public List<string> ObjetosResueltos { get; private set; } = new();

        public EstadoJuego() { } // partida nueva

        [JsonConstructor]
        public EstadoJuego(int puntaje, Habitacion habitacionActual, bool introVista,
                           DateTime fechaGuardado, List<string> inventario, List<string> objetosResueltos)
        {
            Puntaje = puntaje;
            HabitacionActual = habitacionActual;
            IntroVista = introVista;
            FechaGuardado = fechaGuardado;
            Inventario = inventario ?? new();
            ObjetosResueltos = objetosResueltos ?? new();
        }
        public void SumarPuntos(int puntos)
        {
            if (puntos > 0) Puntaje += puntos;
        }

        public void RegistrarObjetoResuelto(string nombreObjeto)
        {
            if (!ObjetosResueltos.Contains(nombreObjeto))
                ObjetosResueltos.Add(nombreObjeto);
        }
        public bool PuedeResolver(Acertijo acertijo)
        {
            if (string.IsNullOrEmpty(acertijo.ItemRequerido)) return true;
            return Inventario.Contains(acertijo.ItemRequerido);
        }
        public void AgregarAlInventario(string item)
        {
            if (!string.IsNullOrEmpty(item) && !Inventario.Contains(item))
                Inventario.Add(item);
        }
        public void CambiarHabitacion(Habitacion nuevaHabitacion)
        {
            HabitacionActual = nuevaHabitacion;
        }
      
    }
}
