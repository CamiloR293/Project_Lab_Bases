using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Streaming
{
    public partial class ViendoPelicula : Form
    {
        public ViendoPelicula()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
