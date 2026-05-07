using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoEscaperoom
{
    public static class InterfazHelper
    {
        public static void ActualizarInventario(FlowLayoutPanel flp, List<string> items)
        {
            flp.Controls.Clear();

            ToolTip tip = new ToolTip();

            foreach (string nombreItem in items)
            {
                PictureBox icono = new PictureBox
                {
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(5),
                    Cursor = Cursors.Help,
                    BackColor = flp.BackColor
                };

                var img = (Image)Properties.Resources.ResourceManager.GetObject(nombreItem);
                if (img != null) icono.Image = img;

                tip.SetToolTip(icono, nombreItem);

                flp.Controls.Add(icono);
            }
        }
    }
}