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
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;
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

        }

        private void OnSpriteClick(object? sender, MouseEventArgs e)
          {
            if (this.Controls.OfType<DialogoUC>().Any()) return;

            if (_zona.Completada)
            {
                if (_zona.DialogosPista != null && _form.Controlador.Estado.PuedeIrAZonaFinal)
                {
                    MostrarDialogoPista();
                }
                else
                    MostrarDialogoRevisita();
                return;
            }

            AbrirDialogo();
        }

        private void AbrirDialogo()
        {
            var ucDialogo = new DialogoUC(_form, _zona);

            ucDialogo.DialogosTerminados += OnDialogosTerminados;

            this.Controls.Add(ucDialogo);
            ucDialogo.BringToFront();
            ucDialogo.Focus();
        }

        private void MostrarDialogoPista()
        {
            var personaje = _zona.Personaje;
            var dialogoPista = new List<Dialogo> { };
            dialogoPista = _zona.DialogosPista!.ToList();

            // Zona temporal solo para el diálogo de pista
            var zonaTemp = new Zona(
                _zona.Id, _zona.NombreVisible, _zona.ImagenFondo,
                _zona.SpritePersonaje, personaje, dialogoPista,
                _zona.Acertijo, null);
            var ucDialogo = new DialogoUC(_form, zonaTemp);
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
                    Texto          = L.Obtener("ui.zonaRevisita"),
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
                "monokuma_final" => new MinijuegoCodigoUC(_form, zona), 
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
