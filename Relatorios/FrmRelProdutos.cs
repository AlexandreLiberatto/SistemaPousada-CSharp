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
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.produtosFornecedores'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosFornecedoresTableAdapter.Fill(this.hotelDataSet.produtosFornecedores);
            // TODO: esta linha de código carrega dados na tabela 'hotelDataSet.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.hotelDataSet.produtos);

            this.reportViewer1.RefreshReport();
        }
    }
}
