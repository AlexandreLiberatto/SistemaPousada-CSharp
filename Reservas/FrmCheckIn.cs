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

namespace SistemaHotel.Reservas
{
    public partial class FrmCheckIn : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;
        string pago;

        public FrmCheckIn()
        {
            InitializeComponent();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Quarto";
            grid.Columns[2].HeaderText = "Data Entrada";
            grid.Columns[3].HeaderText = "Data Saída";
            grid.Columns[4].HeaderText = "Dias";
            grid.Columns[5].HeaderText = "Valor";
            grid.Columns[6].HeaderText = "Nome";
            grid.Columns[7].HeaderText = "Telefone";
            grid.Columns[8].HeaderText = "Data";
            grid.Columns[9].HeaderText = "Funcionario";
            grid.Columns[10].HeaderText = "Status";
            grid.Columns[11].HeaderText = "Check-In";

            grid.Columns[12].HeaderText = "Check-Out";
            grid.Columns[13].HeaderText = "Pago";

            grid.Columns[0].Visible = false;
            
            grid.Columns[4].Visible = false;
            grid.Columns[5].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;
            grid.Columns[10].Visible = false;
            grid.Columns[12].Visible = false;
            grid.Columns[13].Visible = false;

            grid.Columns[1].Width = 60;
            grid.Columns[4].Width = 60;
            grid.Columns[11].Width = 60;
            grid.Columns[12].Width = 60;
            grid.Columns[13].Width = 60;
        }

        private void ListarData()
        {

            con.AbrirCon();
            sql = "SELECT * FROM reservas where entrada = @data and status = @status and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarInicioReserva.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkin", "Não");

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }

        private void ListarNome()
        {

            con.AbrirCon();
            sql = "SELECT * FROM reservas where nome LIKE @nome and entrada = @data and status = @status and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarInicioReserva.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkin", "Não");
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        private void FrmCheckIn_Load(object sender, EventArgs e)
        {
            dtBuscarInicioReserva.Value = DateTime.Today;
            ListarData();
            btnConfirmar.Enabled = false;
        }

        private void DtBuscarInicioReserva_ValueChanged(object sender, EventArgs e)
        {
            ListarData();
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            ListarNome();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (pago == "Sim")
            {
                con.AbrirCon();
                sql = "UPDATE reservas SET checkin = @checkin where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@checkin", "Sim");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();
                ListarData();
                btnConfirmar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Você precisa antes confirmar o pagamento!");
                 btnConfirmar.Enabled = false;
            }
        }

        private void Grid_Click(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = true;
            id = grid.CurrentRow.Cells[0].Value.ToString();
            pago = grid.CurrentRow.Cells[13].Value.ToString();
        }
    }
}
