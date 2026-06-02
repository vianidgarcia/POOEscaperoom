using JuegoEscaperoom.Clases;
using JuegoEscaperoom.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom.Controles
{
    public partial class DialogoUC : UserControl, IEscenaGrafica
    {

        private string _nombreActual = "";
        private readonly FormPrincipal _form;
        private readonly ServicioAudio _audio;
        private readonly List<Dialogo> _dialogos;
        private readonly Zona _zona;
        private ServicioDialogo _servicioDialogo;
        private int _indiceActual = 0;
        private bool _esperandoInput = false;

        public event Action<Zona>? UltimoDialogoMostrado;
        public event Action<Zona>? DialogosTerminados;
        public event Action<Action<string>>? InputTalentoSolicitado;

        public DialogoUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _audio = form.Audio;
            _zona = zona;
            _dialogos = zona.Dialogos.ToList();
            _servicioDialogo = new ServicioDialogo(texto => lblDialogo.Text = texto);
            this.BackColor = Color.Transparent;

            this.MouseClick += (s, e) => SiguienteDialogo();
            pnlDialogo.MouseClick += (s, e) => SiguienteDialogo();
            lblDialogo.Click += (s, e) => SiguienteDialogo();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Z || e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                    SiguienteDialogo();
            };

            pbxHudBarra.Paint += (s, e) =>
            {
                e.Graphics.TranslateTransform(25, 600);
                e.Graphics.RotateTransform(-90);
                e.Graphics.DrawString(
                    _nombreActual,
                    new Font("FOT-Rodin Pro B", 25, FontStyle.Bold),
                    Brushes.Black,
                    0, 0);
                e.Graphics.ResetTransform();
            };

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pbxHudBarra.Parent = pbxSprite;
            pbxHudDatos.Parent = pbxSprite;
            this.Focus();
            SiguienteDialogo();
        }


        private void SiguienteDialogo()
        {
            if (_esperandoInput) return;
            if (_servicioDialogo.EstaEscribiendo)
            {
                _servicioDialogo.Completar();
                return;
            }
            if (_indiceActual == _dialogos.Count - 1)
                UltimoDialogoMostrado?.Invoke(_zona);
            if (_indiceActual >= _dialogos.Count)
            {
                _audio.DetenerVoz();
                DialogosTerminados?.Invoke(_zona);
                this.Parent?.Controls.Remove(this);
                this.Dispose();
                return;
            }

            var dialogo = _dialogos[_indiceActual];
            _indiceActual++;

            _nombreActual = dialogo.Hablante.Nombre;
            var expresion = dialogo.Hablante.ObtenerExpresion(dialogo.ExpresionAUsar);
            if (expresion != null) CambiarExpresion(expresion);

            _servicioDialogo.Animar(dialogo.Texto);
            
            _audio.ReproducirEfecto("Audios/efecto_pasardialogo.wav");
            dialogo.EfectoEspecial?.Invoke(this);
        }

        public void CambiarExpresion(Image imagen)
        {
            pbxSprite.Image = imagen;
        }

        public void CambiarTextoDialogo(string texto)
        {
            _servicioDialogo.Completar();
            _servicioDialogo.Animar(texto);
        }
        
        public void MostrarInputTalento(Action<string> callback)
        {
            _esperandoInput = true;
            InputTalentoSolicitado?.Invoke(talento =>
            {
                _esperandoInput = false;
                callback(talento);
                SiguienteDialogo();
            });
        }

    }
}