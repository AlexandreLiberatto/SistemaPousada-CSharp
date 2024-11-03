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
    public partial class FrmCheckOut : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;
        

        public FrmCheckOut()
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
            grid.Columns[11].Visible = false;
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
            sql = "SELECT * FROM reservas where saida = @data and status = @status and checkout = @checkout and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarFinalReserva.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkout", "Não");
            cmd.Parameters.AddWithValue("@checkin", "Sim");

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
            sql = "SELECT * FROM reservas where nome LIKE @nome and saida = @data and status = @status and checkout = @checkout and checkin = @checkin order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscarFinalReserva.Text));
            cmd.Parameters.AddWithValue("@status", "Confirmada");
            cmd.Parameters.AddWithValue("@checkout", "Não");
            cmd.Parameters.AddWithValue("@checkin", "Sim");
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        private void FrmCheckOut_Load(object sender, EventArgs e)
        {
            dtBuscarFinalReserva.Value = DateTime.Today;
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
           
                con.AbrirCon();
                sql = "UPDATE reservas SET checkout = @checkout where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@checkout", "Sim");
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();
                ListarData();
                btnConfirmar.Enabled = false;
            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirmar.Enabled = true;
            id = grid.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
