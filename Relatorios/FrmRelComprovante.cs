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
    public partial class FrmRelComprovante : Form
    {
        public FrmRelComprovante()
        {
            InitializeComponent();
        }

        private void FrmRelComprovante_Load(object sender, EventArgs e)
        {

            this.vendaPorIdTableAdapter.Fill(this.hotelDataSet.vendaPorId, Convert.ToInt32(Program.idVenda));
            this.detalhes_venda_IdTableAdapter.Fill(this.hotelDataSet.detalhes_venda_Id, Convert.ToInt32(Program.idVenda));

            this.reportViewer1.RefreshReport();
        }
    }
}
