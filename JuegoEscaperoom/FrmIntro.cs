using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom
{
    public partial class FrmIntro : Form
    {
        public FrmIntro()
        {
            InitializeComponent();
        }

        private readonly List<string> dialogos = new()
        {
            "...",
            "¿Dónde... estoy?",
            "Recuerdo haber entrado a esa casa abandonada con mis amigos...",
            "Había una lluvia fuerte y buscamos refugio.",
            "Pero entonces escuché un golpe... y todo se volvió oscuro.",
            "Ahora estoy aquí. Solo.",
            "Las puertas están bloqueadas. Alguien — o algo — las cerró.",
            "Tendré que resolver los acertijos que me dejaron si quiero salir.",
            "Mi nombre es Tilin. Y voy a escapar de esta casa."
        };

        private int dialogoActual = 0;
        private int charActual = 0;
        private string textoCompleto = "";


        private void FrmIntro_Load(object sender, EventArgs e)
        {
            MostrarDialogo(dialogoActual);
            CargarImagenPersonaje();
        }
        private void CargarImagenPersonaje()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "personaje.png");
            if (File.Exists(ruta))
            {
                pbxPersonaje.Image = Image.FromFile(ruta);
                pbxPersonaje.BackColor = Color.Transparent;
                pbxPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (tmrTexto.Enabled)
            {
                tmrTexto.Stop();
                lblDialogo.Text = textoCompleto;
            }
            else
            {
                dialogoActual++;
                MostrarDialogo(dialogoActual);
            }
        }
        private void tmrTexto_Tick(object sender, EventArgs e)
        {
            if (charActual < textoCompleto.Length)
            {
                lblDialogo.Text += textoCompleto[charActual];
                charActual++;
            }
            else
            {
                tmrTexto.Stop();
            }
        }

        private void MostrarDialogo(int indice)
        {
            if (indice >= dialogos.Count)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            textoCompleto = dialogos[indice];
            lblDialogo.Text = "";
            charActual = 0;
            tmrTexto.Start();

        }

    }
}
