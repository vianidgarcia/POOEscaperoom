using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class ControladorJuego
    {
        private readonly EstadoJuego _estado;
        private readonly List<Zona> _zonas;

        public EstadoJuego Estado => _estado;
        public IReadOnlyList<Zona> Zonas => _zonas;

        // Eventos hacia la UI
        public event Action<Zona>? ZonaCompletada;
        public event Action? ZonaFinalDesbloqueada;
        public event Action? JuegoTerminado;

        public bool CambiosSinGuardar { get; private set; } = false;

        public ControladorJuego(EstadoJuego estado, List<Zona> zonas)
        {
            _estado = estado;
            _zonas = zonas;

            // Restaurar zonas si es partida cargada
            foreach (var zona in _zonas)
                if (_estado.ZonaCompletada(zona.Id))
                    zona.MarcarComoCompletada();
        }

        // Acciones del jugador
        public void ProcesarVictoriaZona(Zona zona, int puntos)
        {
            if (zona.Completada) return;

            zona.MarcarComoCompletada();
            _estado.RegistrarZonaCompletada(zona.Id);
            _estado.SumarPuntos(puntos);

            if (zona.DaFragmento)
                _estado.AgregarFragmento();

            CambiosSinGuardar = true;
            ZonaCompletada?.Invoke(zona);

            if (_estado.PuedeIrAZonaFinal)
                ZonaFinalDesbloqueada?.Invoke();
        }

        public void ProcesarVictoriaFinal()
        {
            CambiosSinGuardar = false;
            JuegoTerminado?.Invoke();
        }

        // Persistencia
        public void GuardarPartida() => PersistenciaPartida.GuardarPartida(_estado);
    }
}