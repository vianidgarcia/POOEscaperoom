using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;

namespace JuegoEscaperoom
{
    public class ControladorJuego
    {
        private EstadoJuego _estado;
        public EstadoJuego Estado => _estado;

        public bool CambiosSinGuardar { get; private set; } = false;

        // Eventos hacia el Form 
        public event Action<EscenaHabitacion> EscenaCargada;
        public event Action<string> DialogoSolicitado;
        public event Action UIActualizada;
        public event Action JuegoTerminado;

        
        public void IniciarPartidaNueva()
        {
            _estado = new EstadoJuego();
            CambiosSinGuardar = false;
            CargarHabitacion(Habitacion.Cuarto);
            DialogoSolicitado?.Invoke("¿Donde estoy? Todo parece una pesadilla... debo salir de aquí.");
        }

        public void IniciarPartidaGuardada()
        {
            // PersistenciaPartida ya no atrapa excepciones; las dejamos subir.
            var guardado = PersistenciaPartida.CargarPartida();
            _estado = guardado;
            CargarHabitacion(_estado.HabitacionActual);
            UIActualizada?.Invoke();
            DialogoSolicitado?.Invoke("Retomando donde lo dejé...\nAquí están mis notas.");
        }

        public void GuardarPartida()
        {
            // Puede lanzar excepción; el Form decide cómo mostrarla.
            PersistenciaPartida.GuardarPartida(_estado);
            CambiosSinGuardar = false;
        }

       
        public AcertijoResultado EvaluarClic(Acertijo acertijo)
        {
            if (acertijo.Resuelto)
                return AcertijoResultado.YaResuelto;

            if (!_estado.PuedeResolver(acertijo))
                return AcertijoResultado.Bloqueado;

            return AcertijoResultado.Disponible;
        }

        public void ProcesarVictoria(Acertijo acertijo)
        {
            bool cambioHabitacion = _estado.ProcesarVictoria(acertijo);
            CambiosSinGuardar = true;

            if (!string.IsNullOrEmpty(acertijo.ItemRecompensa))
                DialogoSolicitado?.Invoke($"¡He encontrado: {acertijo.ItemRecompensa}!");

            if (cambioHabitacion)
            {
                DialogoSolicitado?.Invoke(
                    $"¡Progreso! Se ha desbloqueado el acceso a: {acertijo.HabitacionDestino}");
                CargarHabitacion(_estado.HabitacionActual);
            }

            if (acertijo.NombreObjeto == "Puerta Final")
            {
                JuegoTerminado?.Invoke();
                return; // El Form maneja el reinicio; no seguimos actualizando.
            }

            UIActualizada?.Invoke();
        }

        // Helpers 
        private void CargarHabitacion(Habitacion hab)
        {
            Image fondo = CargarImagenFondo(hab);
            if (fondo == null)
                throw new InvalidOperationException(
                    $"No se encontró la imagen de fondo para: {hab}");

            var acertijos = BancoPreguntas.ObtenerAcertijosPorHabitacion(hab);
            var escena = new EscenaHabitacion(fondo);

            foreach (var acertijo in acertijos)
            {
                if (_estado.ObjetosResueltos.Contains(acertijo.NombreObjeto))
                    acertijo.MarcarComoResuelto();

                escena.RegistrarObjeto(acertijo, acertijo.Area);
            }

            _estado.CambiarHabitacion(hab);
            EscenaCargada?.Invoke(escena);
        }

        private static Image CargarImagenFondo(Habitacion hab) =>
            (Image)Properties.Resources.ResourceManager.GetObject(hab.ToString());
    }

    public enum AcertijoResultado { Disponible, YaResuelto, Bloqueado }
}
