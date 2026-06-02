using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class ServicioDialogo
    {
        private string _textoCompleto = "";
        private int _charActual = 0;
        private bool _estaEscribiendo = false;
        private readonly System.Windows.Forms.Timer _timer;
        private Action<string> _actualizarTexto;

        public bool EstaEscribiendo => _estaEscribiendo;

        public event Action? TextoTerminado;

        public ServicioDialogo(Action<string> actualizarTexto)
        {
            _actualizarTexto = actualizarTexto;
            _timer = new System.Windows.Forms.Timer { Interval = 30 };
            _timer.Tick += Tick;
        }

        public void Animar(string texto)
        {
            _textoCompleto = texto;
            _charActual = 0;
            _actualizarTexto("");
            _estaEscribiendo = true;
            _timer.Start();
        }

        public void Completar()
        {
            _timer.Stop();
            _actualizarTexto(_textoCompleto);
            _estaEscribiendo = false;
            TextoTerminado?.Invoke();
        }
        public void Liberar()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void Tick(object? sender, EventArgs e)
        {
            if (_charActual < _textoCompleto.Length)
            {
                _actualizarTexto(_textoCompleto.Substring(0, _charActual + 1));
                _charActual++;
            }
            else
            {
                Completar();
            }
        }
    }
}