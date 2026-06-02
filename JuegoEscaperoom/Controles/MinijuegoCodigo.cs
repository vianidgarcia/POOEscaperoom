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
    public partial class MinijuegoCodigoUC : UserControl
    {
        private readonly FormPrincipal _form;
        private readonly Zona _zona;
        private readonly AcertijoCodigo _acertijo;
        private readonly ServicioAudio _audio;
        private static ServicioLocalizacion L => ServicioLocalizacion.Instancia;

        private string _codigoIngresado = "";
        private const int MaxDigitos = 4;

        public event Action<Zona>? MinijuegoCompletado;

        public MinijuegoCodigoUC(FormPrincipal form, Zona zona)
        {
            InitializeComponent();
            _form = form;
            _zona = zona;
            _acertijo = zona.Acertijo as AcertijoCodigo ?? throw new ArgumentException("La zona no tiene un acertijo de tipo código.");
            _audio = form.Audio;

            _form.Controlador.JuegoTerminado += () =>
            {
                _form.MostrarControl(new CreditosUC(_form));
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.BackgroundImage = _zona.ImagenFondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;


            lblCodigo.Text = "_ _ _ _";
            lblEstado.Text = L.Obtener("ui.codigo.estadoInicial");
            btnBorrar.Text = L.Obtener("ui.codigo.borrar");
            btnRegresar.Text = L.Obtener("ui.codigo.regresar");

            btnBorrar.Click += (s, ev) => Borrar();
            btnRegresar.Click += (s, ev) => Regresar();
            ConfigurarBotones();


        }

        private void ConfigurarBotones()
        {
            List<BotonJuego> botones = new() { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnBorrar, btnRegresar};
            foreach (var btn in botones)
            {
                btn.R = 67; btn.G = 20; btn.B = 40;
            }
            btn0.Click += (s, ev) => IngresarDigito("0");
            btn1.Click += (s, ev) => IngresarDigito("1");
            btn2.Click += (s, ev) => IngresarDigito("2");
            btn3.Click += (s, ev) => IngresarDigito("3");
            btn4.Click += (s, ev) => IngresarDigito("4");
            btn5.Click += (s, ev) => IngresarDigito("5");
            btn6.Click += (s, ev) => IngresarDigito("6");
            btn7.Click += (s, ev) => IngresarDigito("7");
            btn8.Click += (s, ev) => IngresarDigito("8");
            btn9.Click += (s, ev) => IngresarDigito("9");
        }

        private void IngresarDigito(string digito)
        {
            if (_codigoIngresado.Length >= MaxDigitos) return;

            _codigoIngresado += digito;
            ActualizarDisplay();

            if (_codigoIngresado.Length == MaxDigitos)
                ValidarCodigo();
        }

        private void Borrar()
        {
            if (_codigoIngresado.Length == 0) return;
            _codigoIngresado = _codigoIngresado[..^1];
            ActualizarDisplay();
        }

        private void ActualizarDisplay()
        {
            string display = "";
            for (int i = 0; i < MaxDigitos; i++)
                display += i < _codigoIngresado.Length
                    ? _codigoIngresado[i] + " "
                    : "_ ";
            lblCodigo.Text = display.Trim();
        }

        private void ValidarCodigo()
        {
            if (_acertijo.Resolver(_codigoIngresado))
            {
                _audio.ReproducirEfecto("Audios/efecto_revelaacertijo.wav");
                lblEstado.Text = L.Obtener("ui.codigo.correcto");
                MinijuegoCompletado?.Invoke(_zona);
                _form.Controlador.ProcesarVictoriaZona(_zona, _acertijo.CalcularPuntos());
                _form.Controlador.ProcesarVictoriaFinal();

            }
            else
            {
                _audio.ReproducirEfecto("Audios/efecto_triste.wav");
                lblEstado.Text = L.Obtener("ui.codigo.incorrecto");
                _codigoIngresado = "";
                ActualizarDisplay();
            }
        }

        private void Regresar()
        {
            _form.MostrarControl(new ZonaUC(_form, _zona));
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Color.FromArgb(67, 20, 40); // normal
            this.ForeColor = Color.White;
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = Color.FromArgb(67, 20, 40); // normal
            this.ForeColor = Color.White;
        }
    }
}