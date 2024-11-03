using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Relatorios
{
    public partial class FrmRelDetReservas : Form
    {
        public FrmRelDetReservas()
        {
            InitializeComponent();
        }

        private void FrmRelDetReservas_Load(object sender, EventArgs e)
        {
            this.detalhesReservaTableAdapter.Fill(this.hotelDataSet.detalhesReserva, Convert.ToInt32(Program.idReserva));
            this.reportViewer1.RefreshReport();
        }
    }
}
