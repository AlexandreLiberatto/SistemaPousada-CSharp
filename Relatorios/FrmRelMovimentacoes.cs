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
    public partial class FrmRelMovimentacoes : Form
    {
        public FrmRelMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmRelMovimentacoes_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            cbTipo.SelectedIndex = 0;
            BuscarData();
           
        }


        private void BuscarData()
        {
            this.movimentacoesPorDataTableAdapter.Fill(this.hotelDataSet.movimentacoesPorData, Convert.ToDateTime(dtInicial.Text), Convert.ToDateTime(dtFinal.Text), cbTipo.Text);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("tipo", cbTipo.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void CbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
