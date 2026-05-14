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

        public event Action<Zona>? DialogosTerminados;

        public DialogoUC()
        {
            InitializeComponent();
        }

        public DialogoUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _audio = form.Audio;
            _zona = zona;
            _dialogos = zona.Dialogos.ToList();
            _servicioDialogo = new ServicioDialogo(lblDialogo);

            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;

            // Clic en cualquier parte del HUD avanza el diálogo
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

            pbxHudDatos.Image = Properties.Resources.HUDdatos;
            pbxHudDatos.SizeMode = PictureBoxSizeMode.StretchImage;

            pbxSprite.SendToBack();
            pbxHudBarra.BringToFront();
            pbxHudDatos.BringToFront();
            pnlDialogo.BringToFront();

            this.Focus();
            SiguienteDialogo();
        }

        
        private void SiguienteDialogo()
        {
            if (_servicioDialogo.EstaEscribiendo)
            {
                _servicioDialogo.Completar();
                return;
            }
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

            if (!string.IsNullOrEmpty(dialogo.Hablante.RutaVoz))
                _audio.ReproducirVoz(dialogo.Hablante.RutaVoz);

            _servicioDialogo.Animar(dialogo.Texto);
            //dialogo.EfectoEspecial?.Invoke(this);
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

        public void ReproducirSonido(string rutaRelativa) =>
            _audio.ReproducirEfecto(rutaRelativa);

        public void ReproducirMusica(string rutaRelativa) =>
            _audio.ReproducirMusica(rutaRelativa);

        public void CerrarDialogo()
        {
            _servicioDialogo.Liberar();
            _audio.DetenerVoz();
            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }

        public void IrAPantalla(Control pantalla) =>
            _form.MostrarControl((UserControl)pantalla);

        public Control ControlRaiz => this;

        

    }
}