using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Interfaces
{
    public interface IEscenaGrafica
    {
        void CambiarExpresion(Image imagen);

        void CambiarTextoDialogo(string texto);

        void ReproducirSonido(string rutaRelativa);

        void ReproducirMusica(string rutaRelativa);

        void IrAPantalla(Control pantalla);

        void CerrarDialogo();

        Control ControlRaiz { get; }

        void MostrarInputTalento(Action<string> onTalentoIngresado) { }
    }
}

