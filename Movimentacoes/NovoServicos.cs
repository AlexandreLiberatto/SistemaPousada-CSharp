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
    public partial class FrmNovoServics : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
                
        string ultimoIdServico;

        string id;

        string valorServico;
        
        public FrmNovoServics()
        {
            InitializeComponent();
        }


        private void CarregarComboboxServicos()
        {
            con.AbrirCon();
            sql = "SELECT * FROM servicos order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbServico.DataSource = dt;
            
            cbServico.DisplayMember = "nome";

            con.FecharCon();
        }


        private void CarregarComboboxQuartos()
        {
            con.AbrirCon();
            sql = "SELECT * FROM quartos order by quarto asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbQuartos.DataSource = dt;

            cbQuartos.DisplayMember = "quarto";

            con.FecharCon();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Hóspede";
            grid.Columns[2].HeaderText = "Serviço";
            grid.Columns[3].HeaderText = "Quarto";
            
            grid.Columns[4].HeaderText = "Valor";
            grid.Columns[5].HeaderText = "Funcionário";
            grid.Columns[6].HeaderText = "Data";


            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[5].DefaultCellStyle.Format = "C2";


            grid.Columns[0].Visible = false;


        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * from novo_servico order by data asc";
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
            
            txtQuantidade.Enabled = true;
            txtNome.Enabled = true;
            txtValor.Enabled = true;
            cbServico.Enabled = true;
            cbQuartos.Enabled = true;
            btnHospede.Enabled = true;
            txtQuantidade.Focus();
           

        }


        private void desabilitarCampos()
        {
            txtQuantidade.Enabled = false;
            txtNome.Enabled = false;
            txtValor.Enabled = false;
            cbServico.Enabled = false;
            cbQuartos.Enabled = false;
            btnHospede.Enabled = false;
            txtQuantidade.Focus();
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
           

        }


        private void BuscarData()
        {
            con.AbrirCon();
            sql = "SELECT * FROM novo_servico where data = @data order by data desc";
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





        private void FrmServicos_Load(object sender, EventArgs e)
        {
            desabilitarCampos();
            Listar();
            dtBuscar.Value = DateTime.Today;
            CarregarComboboxQuartos();
            CarregarComboboxServicos();

        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {

            if (cbServico.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Serviço!");
                Close();
            }


            if (cbQuartos.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Quarto!");
                Close();
            }

            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            
            btnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text == "")
            {

                MessageBox.Show("É preciso inserir uma quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO novo_servico (hospede, servico, quarto, valor, funcionario, data) VALUES (@hospede, @servico, @quarto, @valor, @funcionario, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@hospede", txtNome.Text);
            cmd.Parameters.AddWithValue("@servico", cbServico.Text);
            cmd.Parameters.AddWithValue("@quarto", cbQuartos.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
           


            cmd.ExecuteNonQuery();
            con.FecharCon();






            //RECUPERAR O ULTIMA ID DO SERVIÇO
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT id FROM novo_servico order by id desc LIMIT 1", con.con);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdServico = Convert.ToString(reader["id"]);




                }
            }



            //SALVAR VENDA NA TABELA DE MOVIMENTAÇÕES
            con.AbrirCon();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Serviço");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtValor.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdServico);


            cmd.ExecuteNonQuery();
            con.FecharCon();



            MessageBox.Show("Serviço Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
           
        }

        private void BtnHospede_Click(object sender, EventArgs e)
        {
            Program.chamadaHospedes = "hospedes";
            Cadastros.FrmHospedes form = new Cadastros.FrmHospedes();
            form.Show();
        }

        private void FrmNovoServics_Activated(object sender, EventArgs e)
        {
            txtNome.Text = Program.nomeHospede;
        }

        private void CbServico_SelectedValueChanged(object sender, EventArgs e)
        {
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM servicos where nome = @nome", con.con);
            cmdVerificar.Parameters.AddWithValue("@nome", cbServico.Text);
            
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    valorServico = Convert.ToString(reader["valor"]);
                   
                }

                txtValor.Text = valorServico;
            }
           

            con.FecharCon();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (Program.cargoUsuario == "Gerente")
            {
                var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA EXCLUIR
                    con.AbrirCon();
                    sql = "DELETE FROM novo_servico where id = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.FecharCon();

                    MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //EXCLUSAO DO MOVIMENTO DO SERVIÇO
                    con.AbrirCon();
                    sql = "DELETE FROM movimentacoes where id_movimento = @id and movimento = @movimento";
                    cmd = new MySqlCommand(sql, con.con);

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@movimento", "Serviço");
                    cmd.ExecuteNonQuery();
                    con.FecharCon();


                    btnNovo.Enabled = true;
                    
                    btnExcluir.Enabled = false;
                    limparCampos();
                    desabilitarCampos();

                    Listar();
                }
            }
            else
            {
                MessageBox.Show("Somente um Gerente pode excluir um serviço", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            BtnRel.Enabled = true;
            habilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            Program.idNovoServico = id;
           
        }

        private void BtnRel_Click(object sender, EventArgs e)
        {
            BtnRel.Enabled = false;
            Relatorios.FrmRelComprovanteServico form = new Relatorios.FrmRelComprovanteServico();
            form.Show();
            
        }
    }
}
