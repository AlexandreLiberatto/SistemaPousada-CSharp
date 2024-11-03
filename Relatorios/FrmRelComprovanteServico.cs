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
    public partial class FrmRelComprovanteServico : Form
    {
        public FrmRelComprovanteServico()
        {
            InitializeComponent();
        }

        private void FrmRelComprovanteServico_Load(object sender, EventArgs e)
        {
            this.comprovanteServicoTableAdapter.Fill(this.hotelDataSet.comprovanteServico, Convert.ToInt32(Program.idNovoServico));
            this.reportViewer1.RefreshReport();
        }
    }
}
