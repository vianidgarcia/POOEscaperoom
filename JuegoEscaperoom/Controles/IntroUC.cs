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


            var zonaIntro = BancoZonas.CrearZonaIntro();
            AbrirDialogo(zonaIntro);
        }

        private void AbrirDialogo(Zona zona)
        {
            var dialogo = new DialogoUC(_form, zona);
            dialogo.Dock = DockStyle.Fill;
            dialogo.DialogosTerminados += OnIntroTerminada;

            this.Controls.Add(dialogo);
            dialogo.BringToFront();
            dialogo.Focus();
        }

        private void OnIntroTerminada(Zona _)
        {
            _form.Audio.DetenerMusica();
            _form.MostrarControl(new MapaUC(_form));
        }
    }
}