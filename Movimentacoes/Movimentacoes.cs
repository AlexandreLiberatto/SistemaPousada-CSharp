using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Movimentacoes
{
    public partial class FrmMovimentacoes : Form
    {

        double totalEntradas, totalSaidas;
        

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        public FrmMovimentacoes()
        {
            InitializeComponent();
        }

        private void FrmMovimentacoes_Load(object sender, EventArgs e)
        {
            cbBuscar.SelectedIndex = 0;
            dtInicial.Value = DateTime.Today;
            dtFinal.Value = DateTime.Today;
            
            BuscarData();
        }


        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * from movimentacoes order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
            
        }



        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Tipo";
            grid.Columns[2].HeaderText = "Movimento";
            grid.Columns[3].HeaderText = "Valor";
            grid.Columns[4].HeaderText = "Funcionario";
            grid.Columns[5].HeaderText = "Data";
            grid.Columns[6].HeaderText = "Id Movimento";


            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[3].DefaultCellStyle.Format = "C2";


            grid.Columns[0].Visible = false;
            grid.Columns[6].Visible = false;


            TotalizarSaidas();
            TotalizarEntradas();
            Totalizar();

        }


        private void BuscarData()
        {
            con.AbrirCon();

            if (cbBuscar.SelectedIndex == 0)
            {
                sql = "SELECT * FROM movimentacoes where data >= @dataInicial and data <= @dataFinal order by data desc";
                cmd = new MySqlCommand(sql, con.con);

            }
            else
            {
                sql = "SELECT * FROM movimentacoes where data >= @dataInicial and data <= @dataFinal and tipo = @tipo order by data desc";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@tipo", cbBuscar.Text);
            }

           
            cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dtInicial.Text));
            cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dtFinal.Text));
           

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
           
        }




        private void DtInicial_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void DtFinal_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }


        /*
        private void BuscarTipo()
        {
            con.AbrirCon();
            sql = "SELECT * FROM movimentacoes where tipo = @tipo order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@tipo", cbBuscar.Text);
            
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }

    */

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BuscarTipo();
            BuscarData();
        }


        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in grid.Rows)
            {
                total = totalEntradas - totalSaidas;
            }

            lblTotal.Text = Convert.ToDouble(total).ToString("C2");

            if (total >= 0)
            {
                lblTotal.ForeColor = Color.Green;
            }
            else
            {
                lblTotal.ForeColor = Color.Red;
            }
        }


        private void TotalizarEntradas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in grid.Rows)
            {
                if (linha.Cells["tipo"].Value.ToString() == "Entrada")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
                
            }
            totalEntradas = total;
            lblEntradas.Text = Convert.ToDouble(total).ToString("C2");
        }


        private void TotalizarSaidas()
        {
            double total = 0;
            foreach (DataGridViewRow linha in grid.Rows)
            {
                if (linha.Cells["tipo"].Value.ToString() == "Saída")
                {
                    total += Convert.ToDouble(linha.Cells["valor"].Value);
                }
            }
            totalSaidas = total;
            lblSaidas.Text = Convert.ToDouble(total).ToString("C2");
        }


    }
}
