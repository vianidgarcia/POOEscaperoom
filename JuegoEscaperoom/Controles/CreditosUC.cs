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
    public partial class CreditosUC : UserControl
    {
        private FormPrincipal _form;
        public CreditosUC(FormPrincipal form)
        {
            InitializeComponent();
            _form = form;
        }
    }
}
