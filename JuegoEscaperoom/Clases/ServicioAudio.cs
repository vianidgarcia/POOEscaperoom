using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom.Clases
{
    public class ServicioAudio : IDisposable
    {
        private IWavePlayer? _playerMusica;
        private AudioFileReader? _musicaReader;

        private IWavePlayer? _playerVoz;
        private AudioFileReader? _vozReader;

        private IWavePlayer? _playerEfecto;
        private AudioFileReader? _efectoReader;

        private static readonly string BaseDir =
            AppDomain.CurrentDomain.BaseDirectory;

        // ── Música de fondo 
        public void ReproducirMusica(string rutaRelativa)
        {
            DetenerMusica();
            string ruta = Path.Combine(BaseDir, rutaRelativa);
            if (!File.Exists(ruta)) return;

            try
            {
                _musicaReader = new AudioFileReader(ruta);
                _playerMusica = new WaveOutEvent();
                var loop = new LoopStream(_musicaReader);
                _playerMusica.Init(loop);
                _playerMusica.Play();
            }
            catch {}
        }

        public void DetenerMusica()
        {
            _playerMusica?.Stop();
            _playerMusica?.Dispose();
            _musicaReader?.Dispose();
            _playerMusica = null;
            _musicaReader = null;
        }

        // ── Voz del personaje 
        public void ReproducirVoz(string rutaRelativa)
        {
            DetenerVoz();
            string ruta = Path.Combine(BaseDir, "Audio", rutaRelativa);
            if (!File.Exists(ruta)) return;

            try
            {
                _vozReader = new AudioFileReader(ruta);
                _playerVoz = new WaveOutEvent();
                _playerVoz.Init(_vozReader);
                _playerVoz.Play();
            }
            catch { }
        }

        public void DetenerVoz()
        {
            _playerVoz?.Stop();
            _playerVoz?.Dispose();
            _vozReader?.Dispose();
            _playerVoz = null;
            _vozReader = null;
        }

        // ── Efectos de sonido 
        public void ReproducirEfecto(string rutaRelativa)
        {
            _playerEfecto?.Stop();
            _playerEfecto?.Dispose();
            _efectoReader?.Dispose();

            string ruta = Path.Combine(BaseDir, rutaRelativa);
            if (!File.Exists(ruta)) return;

            try
            {
                _efectoReader = new AudioFileReader(ruta);
                _playerEfecto = new WaveOutEvent();
                _playerEfecto.Init(_efectoReader);
                _playerEfecto.Play();
            }
            catch { }
        }

        // ── Control global 
        public void DetenerTodo()
        {
            DetenerMusica();
            DetenerVoz();
            _playerEfecto?.Stop();
            _playerEfecto?.Dispose();
            _efectoReader?.Dispose();
            _playerEfecto = null;
            _efectoReader = null;
        }

        public void Dispose() => DetenerTodo();
    }

    // ── Helper: loop infinito para NAudio 
    internal class LoopStream : WaveStream
    {
        private readonly WaveStream _source;
        public LoopStream(WaveStream source) => _source = source;
        public override WaveFormat WaveFormat => _source.WaveFormat;
        public override long Length => _source.Length;
        public override long Position
        {
            get => _source.Position;
            set => _source.Position = value;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalRead = 0;
            while (totalRead < count)
            {
                int read = _source.Read(buffer, offset + totalRead, count - totalRead);
                if (read == 0) _source.Position = 0; // reinicia el loop
                else totalRead += read;
            }
            return totalRead;
        }
    }
}
