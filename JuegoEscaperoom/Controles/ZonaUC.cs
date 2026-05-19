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
    public partial class ZonaUC : UserControl
    {
        private readonly FormPrincipal _form;
        private readonly Zona _zona;

        public ZonaUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;

            this.Dock = DockStyle.Fill;
            this.DoubleBuffered = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarVisual();
        }

        private void CargarVisual()
        {
            // Fondo de la zona
            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Sprite del personaje
            pbxSprite.Image = _zona.SpritePersonaje;
            pbxSprite.SizeMode = PictureBoxSizeMode.Zoom;
            pbxSprite.Cursor = Cursors.Hand; 

            pbxSprite.MouseClick += OnSpriteClick;

            // Música de la zona si el personaje tiene
            if (!string.IsNullOrEmpty(_zona.Personaje.RutaVoz))
                _form.Audio.ReproducirMusica($"Audio/{_zona.Personaje.RutaVoz}");
        }

        private void OnSpriteClick(object? sender, MouseEventArgs e)
        {
            if (this.Controls.OfType<DialogoUC>().Any()) return;

            if (_zona.Completada)
            {
                MostrarDialogoRevisita();
                return;
            }

            AbrirDialogo();
        }

        private void AbrirDialogo()
        {
            var ucDialogo = new DialogoUC(_form, _zona);

            // Posicionar en la parte inferior, centrado


            ucDialogo.DialogosTerminados += OnDialogosTerminados;

            this.Controls.Add(ucDialogo);
            ucDialogo.BringToFront();
            ucDialogo.Focus();
        }

        private void MostrarDialogoRevisita()
        {
            var personaje = _zona.Personaje;
            var dialogoRevisita = new List<Dialogo>
            {
                new()
                {
                    Hablante       = personaje,
                    Texto          = "Ya resolviste mi desafío. No tengo nada más para ti.",
                    ExpresionAUsar = personaje.Expresiones.Keys.FirstOrDefault() ?? ""
                }
            };

            // Zona temporal solo para el diálogo de revisita
            var zonaTemp = new Zona(
                _zona.Id, _zona.NombreVisible, _zona.ImagenFondo,
                _zona.SpritePersonaje, personaje, dialogoRevisita,
                _zona.Acertijo, null);

            var ucDialogo = new DialogoUC(_form, zonaTemp);


            this.Controls.Add(ucDialogo);
            ucDialogo.BringToFront();
            ucDialogo.Focus();
        }

        private void OnDialogosTerminados(Zona zona)
        {
            // Navega al minijuego correspondiente según el id de la zona
            UserControl minijuego = zona.Id switch
            {
                "hiyoko" => new MinijuegoSecuenciaUC(_form, zona),
                "gundham" => new MinijuegoPreguntasUC(_form, zona, BancoZonas.ObtenerPreguntasGundham()),
                "chiaki" => new MinijuegoMemoramaUC(_form, zona),
                "nagito" => new MinijuegoPreguntasUC(_form, zona, BancoZonas.ObtenerPreguntasNagito()),
                _ => throw new InvalidOperationException($"Zona desconocida: {zona.Id}")
            };

            _form.MostrarControl(minijuego);
        }

        private void pbxSprite_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
                _form.MostrarControl(new MapaUC(_form));
        }
    }
}
