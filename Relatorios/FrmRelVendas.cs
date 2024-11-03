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
    public partial class FrmRelVendas : Form
    {
        public FrmRelVendas()
        {
            InitializeComponent();
        }

        private void FrmRelVendas_Load(object sender, EventArgs e)
        {
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            cbStatus.SelectedIndex = 0;
            BuscarData();


        }


        private void BuscarData()
        {
            this.vendasPorDataTableAdapter.Fill(this.hotelDataSet.vendasPorData, Convert.ToDateTime(dtInicial.Text), Convert.ToDateTime(dtFinal.Text), cbStatus.Text);

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataInicial", dtInicial.Text));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dataFinal", dtFinal.Text));
            this.reportViewer1.RefreshReport();
        }

        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void CbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarData();
        }
    }
}
