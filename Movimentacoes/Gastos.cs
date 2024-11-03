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
    public partial class FrmGastos : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;
        string ultimoIdGasto;

        public FrmGastos()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Descrição";
            grid.Columns[2].HeaderText = "Valor";
            grid.Columns[3].HeaderText = "Funcionário";
            grid.Columns[4].HeaderText = "Data";

            grid.Columns[2].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;

            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 75;
            grid.Columns[4].Width = 75;

            Totalizar();
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM gastos order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
            
        }


        private void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;

            txtDescricao.Focus();

        }


        private void desabilitarCampos()
        {
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
        }


        private void limparCampos()
        {
            txtDescricao.Text = "";
            txtValor.Text = "";

        }



        private void BuscarData()
        {
            con.AbrirCon();
            sql = "SELECT * FROM gastos where data = @data order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscar.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }



        private void FrmGastos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            limparCampos();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }

            if (txtValor.Text.ToString().Trim() == "")
            {
                txtValor.Text = "";
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }




            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO gastos (descricao, valor, funcionario, data) VALUES (@descricao, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);



            cmd.ExecuteNonQuery();
            con.FecharCon();



            //RECUPERAR O ULTIMO ID DO GASTO
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT id FROM gastos order by id desc LIMIT 1", con.con);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdGasto = Convert.ToString(reader["id"]);




                }
            }




            //LANÇAR O GASTO NAS MOVIMENTAÇÕES
            con.AbrirCon();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Saída");
            cmd.Parameters.AddWithValue("@movimento", "Gasto");
            cmd.Parameters.AddWithValue("@valor",txtValor.Text);
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdGasto);


            cmd.ExecuteNonQuery();
            con.FecharCon();


            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.ToString().Trim() == "")
            {
                txtDescricao.Text = "";
                MessageBox.Show("Preencha a Descrição", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Focus();
                return;
            }




            //CÓDIGO DO BOTÃO PARA EDITAR
            con.AbrirCon();
            sql = "UPDATE gastos SET descricao = @descricao, valor = @valor, funcionario = @funcionario, data = curDate() where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
            con.FecharCon();



            //ATUALIZAR O VALOR NA MOVIMENTAÇÃO
            con.AbrirCon();
            sql = "UPDATE movimentacoes SET valor = @valor, funcionario = @funcionario, data = curDate() where id_movimento = @id and movimento = @movimento";
            cmd = new MySqlCommand(sql, con.con);
            
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@movimento", "Gasto");


            cmd.ExecuteNonQuery();
            con.FecharCon();



            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();



        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO PARA EXCLUIR
                con.AbrirCon();
                sql = "DELETE FROM gastos where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.FecharCon();

                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                limparCampos();
                desabilitarCampos();
                Listar();


                //EXCLUSAO DO MOVIMENTO DO GASTO
                con.AbrirCon();
                sql = "DELETE FROM movimentacoes where id_movimento = @id and movimento = @movimento";
                cmd = new MySqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@movimento", "Gasto");
                cmd.ExecuteNonQuery();
                con.FecharCon();
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            habilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[2].Value.ToString();

        }

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }


        private void Totalizar()
        {
            double total = 0;
            foreach (DataGridViewRow linha in grid.Rows)
            {
                total += Convert.ToDouble(linha.Cells["valor"].Value);
            }

            lblTotal.Text = Convert.ToDouble(total).ToString("C2");
        }
    }
}
