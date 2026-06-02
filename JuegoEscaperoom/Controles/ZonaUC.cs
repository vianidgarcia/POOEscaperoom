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
        }

        protected override void OnLoad(EventArgs e)
        {
            btnVolver.Text= L.Obtener("ui.volver");
            base.OnLoad(e);
            CargarVisual();
        }

        private void CargarVisual()
        {
            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pbxSprite.Image = _zona.SpritePersonaje;
            pbxSprite.SizeMode = PictureBoxSizeMode.Zoom;
            pbxSprite.Location = DarUbicacionAleatoria();
            pbxSprite.Cursor = Cursors.Hand;

        }

        private Point DarUbicacionAleatoria()
        {
            Random rnd = new Random();
            int x = rnd.Next(449, 975);
            return new Point(x, 72);
        }

        private void AbrirDialogo()
        {
            var ucDialogo = new DialogoUC(_form, _zona);

            ucDialogo.DialogosTerminados += OnDialogosTerminados;

            ucDialogo.UltimoDialogoMostrado += (zona) =>
            {
                var btnJugar = new BotonJuego
                {
                    Text = L.Obtener("ui.opcionesJugar.jugar"),
                    Size = new Size(200, 60),
                    Location = new Point((this.Width - 420) / 2, this.Height - 250)
                };

                var btnRegresar = new BotonJuego
                {
                    Text = L.Obtener("ui.opcionesJugar.regresar"),
                    Size = new Size(200, 60),
                    Location = new Point((this.Width + 20) / 2, this.Height - 250)
                };

                this.Controls.Add(btnJugar);
                this.Controls.Add(btnRegresar);
                btnJugar.BringToFront();
                btnRegresar.BringToFront();

                btnJugar.Click += (s, e) =>
                {
                    OnDialogosTerminados(zona);
                };
                btnRegresar.Click += (s, e) =>
                {
                    _form.MostrarControl(new ZonaUC(_form, _zona));
                };
            };

            this.Controls.Add(ucDialogo);
            ucDialogo.BringToFront();
            ucDialogo.Focus();
        }

        private void MostrarDialogoPista()
        {
            var personaje = _zona.Personaje;
            var dialogoPista = new List<Dialogo> { };
            dialogoPista = _zona.DialogosPista!.ToList();

            var zonaTemp = new Zona(
                _zona.Id, _zona.ImagenFondo,
                _zona.SpritePersonaje, personaje, dialogoPista,
                _zona.Acertijo, false, null);
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

            var zonaTemp = new Zona(
                _zona.Id, _zona.ImagenFondo,
                _zona.SpritePersonaje, personaje, dialogoRevisita,
                _zona.Acertijo, false, null);

            var ucDialogo = new DialogoUC(_form, zonaTemp);


            this.Controls.Add(ucDialogo);
            ucDialogo.BringToFront();
            ucDialogo.Focus();
        }

        private void OnDialogosTerminados(Zona zona)
        {
            UserControl minijuego = zona.Id switch
            {
                "hiyoko" => new MinijuegoSecuenciaUC(_form, zona),
                "gundham" => new MinijuegoPreguntasUC(_form, zona),
                "chiaki" => new MinijuegoMemoramaUC(_form, zona),
                "nagito" => new MinijuegoPreguntasUC(_form, zona),
                "monokuma" => new MinijuegoCodigoUC(_form, zona),
                _ => throw new InvalidOperationException($"Zona desconocida: {zona.Id}")
            };
            _form.MostrarControl(minijuego);
        }

        private void pbxSprite_Click(object sender, EventArgs e)
        {

            if (this.Controls.OfType<DialogoUC>().Any()) return;

            if (_zona.Completada)
            {
                if (_zona.DialogosPista != null && _form.Controlador.Estado.PuedeIrAZonaFinal)
                    MostrarDialogoPista();
                else
                    MostrarDialogoRevisita();
                return;
            }

            AbrirDialogo();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            _form.MostrarControl(new MapaUC(_form));
        }
    }
}
