using JuegoEscaperoom.Clases;
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
    public partial class IntroUC : UserControl
    {
        private readonly FormPrincipal _form;

        public IntroUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
            this.Dock = DockStyle.Fill;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BackgroundImage = Properties.Resources.zona_intro;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            var zonaIntro = BancoZonas.CrearZonaIntro( talento =>
            {
                _form.Controlador.Estado.TalentoJugador = talento;
            },
            obtenerTalento: () => _form.Controlador.Estado.TalentoJugador,
            onRegistrar: () => PersistenciaPartida.GuardarPartida(_form.Controlador.Estado)
            );
            AbrirDialogo(zonaIntro);
        }

        private void AbrirDialogo(Zona zona)
        {
            var dialogo = new DialogoUC(_form, zona);
            dialogo.Dock = DockStyle.Fill;
            dialogo.InputTalentoSolicitado += Dialogo_InputTalentoSolicitado;
            dialogo.DialogosTerminados += OnIntroTerminada;

            this.Controls.Add(dialogo);
            dialogo.BringToFront();
            dialogo.Focus();
        }

        private void Dialogo_InputTalentoSolicitado(Action<string> obj)
        {
            TextBox textBox = new TextBox
            {
                Font = new Font("FOT-Rodin Pro B", 20, FontStyle.Bold),
                Location = new Point(300, 500),
                Size = new Size(400, 50)
            };

            this.Controls.Add(textBox);
            textBox.BringToFront();
            textBox.Focus();

            textBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string talento = textBox.Text.Trim();
                    if (!string.IsNullOrEmpty(talento))
                    {
                        obj(talento);
                        this.Controls.Remove(textBox);
                    }
                }
            };
        }

        private void OnIntroTerminada(Zona _)
        {
            _form.Audio.DetenerMusica();
            _form.MostrarControl(new MapaUC(_form));
        }
    }
}