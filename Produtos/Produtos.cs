using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel.Produtos
{
    public partial class FrmProdutos : Form
    {

        string foto;
        string alterou;

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;

        public FrmProdutos()
        {
            InitializeComponent();
        }


        private void CarregarCombobox()
        {
            con.AbrirCon();
            sql = "SELECT * FROM fornecedores order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbFornecedor.DataSource = dt;
            cbFornecedor.ValueMember = "id";
            cbFornecedor.DisplayMember = "nome";

            con.FecharCon();
        }


        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "Descrição";
            grid.Columns[3].HeaderText = "Estoque";
            grid.Columns[4].HeaderText = "Fornecedor";
            grid.Columns[5].HeaderText = "Valor Venda";
            grid.Columns[6].HeaderText = "Valor Compra";
            grid.Columns[7].HeaderText = "Data";
            grid.Columns[8].HeaderText = "Imagem";
            grid.Columns[9].HeaderText = "Id Fornecedor";

            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[5].DefaultCellStyle.Format = "C2";
            grid.Columns[6].DefaultCellStyle.Format = "C2";

            grid.Columns[0].Visible = false;
            
            grid.Columns[8].Visible = false;
            grid.Columns[9].Visible = false;

            grid.Columns[3].Width = 60;
            grid.Columns[5].Width = 90;
            grid.Columns[6].Width = 95;
            grid.Columns[7].Width = 90;
        }

        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDG();
        }


        private void BuscarNome()
        {
            con.AbrirCon();
            sql = "SELECT pro.id, pro.nome, pro.descricao, pro.estoque, forn.nome, pro.valor_venda, pro.valor_compra, pro.data, pro.imagem, pro.fornecedor FROM produtos as pro INNER JOIN fornecedores as forn ON pro.fornecedor = forn.id where pro.nome LIKE @nome order by pro.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");
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
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtValor.Enabled = true;
            cbFornecedor.Enabled = true;
            //txtEstoque.Enabled = true;
            btnImg.Enabled = true;
            txtNome.Focus();

        }


        private void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
            cbFornecedor.Enabled = false;
            txtEstoque.Enabled = false;
            btnImg.Enabled = false;
        }


        private void limparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            txtEstoque.Text = "";
            LimparFoto();
        }



        private void LimparFoto()
        {
            img.Image = Properties.Resources.sem_foto;
            foto = "img/sem-foto.jpg";
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparFoto();
            CarregarCombobox();
            Listar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {


            if (cbFornecedor.Text == "")
            {
                MessageBox.Show("Cadastre Antes um Fornecedor!");
                Close();
            }

            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            if (txtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO produtos (nome, descricao, fornecedor, valor_venda, data, imagem) VALUES (@nome, @descricao,  @fornecedor, @valor_venda, curDate(), @imagem)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            //cmd.Parameters.AddWithValue("@estoque", txtEstoque.Text);
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
            cmd.Parameters.AddWithValue("@valor_venda", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@imagem", Img());

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
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            if (txtValor.Text == "")
            {
                MessageBox.Show("Preencha o Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA EDITAR
            con.AbrirCon();

            if (alterou == "1")
            {
                
                sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, fornecedor = @fornecedor, valor_venda = @valor, imagem = @imagem where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@imagem", Img());

            }
            else
            {
                sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, fornecedor = @fornecedor, valor_venda = @valor where id = @id";
                cmd = new MySqlCommand(sql, con.con);
            }

           
            
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@fornecedor", cbFornecedor.SelectedValue);
            
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.FecharCon();

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            limparCampos();
            desabilitarCampos();
            Listar();
            alterou = "";
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o Registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //CÓDIGO DO BOTÃO PARA EXCLUIR
                con.AbrirCon();
                sql = "DELETE FROM produtos where id = @id";
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
            }
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens(*.jpg;*.png)|*.jpg;*.png|Todos os Arquivos(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                img.ImageLocation = foto;
                alterou = "1";
            }
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            habilitarCampos();

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtEstoque.Text = grid.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = grid.CurrentRow.Cells[4].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[5].Value.ToString();

            if (grid.CurrentRow.Cells[8].Value != DBNull.Value)
            {
                byte[] imagem = (byte[])grid.CurrentRow.Cells[8].Value;
                MemoryStream ms = new MemoryStream(imagem);
                img.Image = System.Drawing.Image.FromStream(ms);
            }
            else
            {
                img.Image = Properties.Resources.sem_foto;
            }
           
        }

        private void TxtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaProdutos == "estoque")
            {
                Program.nomeProduto = grid.CurrentRow.Cells[1].Value.ToString();
                Program.estoqueProduto = grid.CurrentRow.Cells[3].Value.ToString();
                Program.valorProduto = grid.CurrentRow.Cells[5].Value.ToString();
                Program.idProduto = grid.CurrentRow.Cells[0].Value.ToString();
                Close();
            }
        }



        private byte[] Img()
        {
            byte[] imagem_byte = null;
            if (foto == "")
            {
                return null;
            }

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagem_byte = br.ReadBytes((int)fs.Length);
            return imagem_byte;
        }


    }
}
