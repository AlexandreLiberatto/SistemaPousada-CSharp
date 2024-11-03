namespace SistemaHotel.Relatorios
{
    partial class FrmRelComprovante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hotelDataSet = new SistemaHotel.hotelDataSet();
            this.vendaPorIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendaPorIdTableAdapter = new SistemaHotel.hotelDataSetTableAdapters.vendaPorIdTableAdapter();
            this.detalhesvendaIdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.detalhes_venda_IdTableAdapter = new SistemaHotel.hotelDataSetTableAdapters.detalhes_venda_IdTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaPorIdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesvendaIdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSVendas";
            reportDataSource1.Value = this.vendaPorIdBindingSource;
            reportDataSource2.Name = "DSDetalhesVendas";
            reportDataSource2.Value = this.detalhesvendaIdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaHotel.Relatorios.RelComprovante.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(665, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendaPorIdBindingSource
            // 
            this.vendaPorIdBindingSource.DataMember = "vendaPorId";
            this.vendaPorIdBindingSource.DataSource = this.hotelDataSet;
            // 
            // vendaPorIdTableAdapter
            // 
            this.vendaPorIdTableAdapter.ClearBeforeFill = true;
            // 
            // detalhesvendaIdBindingSource
            // 
            this.detalhesvendaIdBindingSource.DataMember = "detalhes_venda_Id";
            this.detalhesvendaIdBindingSource.DataSource = this.hotelDataSet;
            // 
            // detalhes_venda_IdTableAdapter
            // 
            this.detalhes_venda_IdTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelComprovante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelComprovante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprovante Venda";
            this.Load += new System.EventHandler(this.FrmRelComprovante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendaPorIdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalhesvendaIdBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource vendaPorIdBindingSource;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource detalhesvendaIdBindingSource;
        private hotelDataSetTableAdapters.vendaPorIdTableAdapter vendaPorIdTableAdapter;
        private hotelDataSetTableAdapters.detalhes_venda_IdTableAdapter detalhes_venda_IdTableAdapter;
    }
}