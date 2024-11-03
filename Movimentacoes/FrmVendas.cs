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
    public partial class FrmVendas : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string idVenda;
        string idDetVenda;
        string idProduto;
        string totalVenda;
        string ultimoIdVenda;
        string exclusaoVenda;

        public FrmVendas()
        {
            InitializeComponent();
        }


        private void FormatarDGVendas()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Valor Total";
            grid.Columns[2].HeaderText = "Funcionário";
            grid.Columns[3].HeaderText = "Status";
            grid.Columns[4].HeaderText = "Data";
            

            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[1].DefaultCellStyle.Format = "C2";
           

            grid.Columns[0].Visible = false;

           
        }

        private void ListarVendas()
        {

            con.AbrirCon();
            sql = "SELECT * from vendas order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDGVendas();
            gridDetalhes.Visible = false;
        }




        private void FormatarDGDetalhesVendas()
        {
            gridDetalhes.Columns[0].HeaderText = "ID";
            gridDetalhes.Columns[1].HeaderText = "Código Venda";
            gridDetalhes.Columns[2].HeaderText = "Produto";
            gridDetalhes.Columns[3].HeaderText = "Quantidade";
            gridDetalhes.Columns[4].HeaderText = "Valor Unitário";
            gridDetalhes.Columns[5].HeaderText = "Valor Total";
            gridDetalhes.Columns[6].HeaderText = "Funcionário";
            gridDetalhes.Columns[7].HeaderText = "Id Produto";

            //FORMATAR COLUNA PARA MOEDA
            gridDetalhes.Columns[4].DefaultCellStyle.Format = "C2";
            gridDetalhes.Columns[5].DefaultCellStyle.Format = "C2";

            gridDetalhes.Columns[0].Visible = false;
            gridDetalhes.Columns[1].Visible = false;
            gridDetalhes.Columns[7].Visible = false;

        }

        private void ListarDetalhesVendas()
        {

            con.AbrirCon();
            sql = "SELECT * from detalhes_venda where id_venda = @id_venda and funcionario = @funcionario";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridDetalhes.DataSource = dt;
            con.FecharCon();

            FormatarDGDetalhesVendas();
            gridDetalhes.Visible = true;
        }




        private void habilitarCampos()
        {
            //txtProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            //txtEstoque.Enabled = true;
            //txtValor.Enabled = true;
            btnProduto.Enabled = true;
            txtQuantidade.Focus();
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;

        }


        private void desabilitarCampos()
        {
            txtProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtEstoque.Enabled = false;
            txtValor.Enabled = false;
            btnProduto.Enabled = false;
            btnProduto.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }


        private void limparCampos()
        {
            txtProduto.Text = "";
            txtQuantidade.Text = "";
            txtValor.Text = "";
            txtEstoque.Text = "";
            lblTotal.Text = "0";
            
        }


        private void BuscarData()
        {
            con.AbrirCon();
            sql = "SELECT * FROM vendas where data = @data order by data desc";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@data", Convert.ToDateTime(dtBuscar.Text));
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.FecharCon();

            FormatarDGVendas();
        }



        private void FrmVendas_Load(object sender, EventArgs e)
        {
            
            ListarVendas();
            desabilitarCampos();
            totalVenda = "0";
            dtBuscar.Value = DateTime.Today;
            
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            
            habilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            
            btnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text == "0")
            {
                
                MessageBox.Show("É preciso inserir produtos para venda", "Venda Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }


            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO vendas (valor_total, funcionario, status, data) VALUES (@valor_total, @funcionario, @status, curDate())";
            cmd = new MySqlCommand(sql, con.con);
            
            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(totalVenda));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@status", "Efetuada");
           

            cmd.ExecuteNonQuery();
            con.FecharCon();


            



            //RECUPERAR O ULTIMA ID DA VENDA
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT id FROM vendas order by id desc LIMIT 1", con.con);
           
            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA DO LOGIN
                while (reader.Read())
                {
                    ultimoIdVenda = Convert.ToString(reader["id"]);
                   



                }
            }



            //SALVAR VENDA NA TABELA DE MOVIMENTAÇÕES
            con.AbrirCon();
            sql = "INSERT INTO movimentacoes (tipo, movimento, valor, funcionario, data, id_movimento) VALUES (@tipo, @movimento, @valor, @funcionario, curDate(), @id_movimento)";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@tipo", "Entrada");
            cmd.Parameters.AddWithValue("@movimento", "Venda");
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(totalVenda));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_movimento", ultimoIdVenda);


            cmd.ExecuteNonQuery();
            con.FecharCon();




            //RELACIONAR OS ITENS COM A VENDA
            con.AbrirCon();
            sql = "UPDATE detalhes_venda SET id_venda = @id_venda where id_venda = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", "0");
            cmd.Parameters.AddWithValue("@id_venda", ultimoIdVenda);


            cmd.ExecuteNonQuery();
            con.FecharCon();


            MessageBox.Show("Venda Salva com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            limparCampos();
            desabilitarCampos();
            ListarVendas();
            totalVenda = "0";
            btnFechar.Visible = false;

        }

        private void BtnProduto_Click(object sender, EventArgs e)
        {
            
            
            Program.chamadaProdutos = "estoque";
            Produtos.FrmProdutos form = new Produtos.FrmProdutos();
            form.Show();
        }

        private void FrmVendas_Activated(object sender, EventArgs e)
        {
            txtEstoque.Text = Program.estoqueProduto;
            txtProduto.Text = Program.nomeProduto;
            txtValor.Text = Program.valorProduto;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.ToString().Trim() == "")
            {
                
                MessageBox.Show("Preencha a Quantidade", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
                return;
            }


            if (Convert.ToInt32(txtEstoque.Text) < Convert.ToInt32(txtQuantidade.Text))
            {

                MessageBox.Show("Não possui produtos suficiente em estoque", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantidade.Focus();
                return;
            }

            //CÓDIGO DO BOTÃO PARA SALVAR
            con.AbrirCon();
            sql = "INSERT INTO detalhes_venda (id_venda, produto, quantidade, valor_unitario, valor_total, funcionario, id_produto) VALUES (@id_venda, @produto, @quantidade, @valor_unitario, @valor_total, @funcionario, @id_produto)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", "0");
            cmd.Parameters.AddWithValue("@produto", txtProduto.Text);
            cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
            cmd.Parameters.AddWithValue("@valor_unitario", Convert.ToDouble(txtValor.Text));
            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_produto", Program.idProduto);

            cmd.ExecuteNonQuery();
            con.FecharCon();

            //ABATER QUANTIDADE DO ESTOQUE
            con.AbrirCon();
            sql = "UPDATE produtos SET estoque = @estoque where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", Program.idProduto);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) - Convert.ToInt32(txtQuantidade.Text));
            

            cmd.ExecuteNonQuery();
            con.FecharCon();

            //MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //TOTALIZAR A VENDA
            double total;
            total = Convert.ToDouble(totalVenda) + Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text);
            totalVenda = total.ToString();
            lblTotal.Text = string.Format("{0:c2}", total);

            txtQuantidade.Text = "";
            txtProduto.Text = "";
            txtEstoque.Text = "0";
            txtValor.Text = "";
            idDetVenda = "";
            ListarDetalhesVendas();
        }

        private void GridDetalhes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idDetVenda = gridDetalhes.CurrentRow.Cells[0].Value.ToString();
            txtProduto.Text = gridDetalhes.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = gridDetalhes.CurrentRow.Cells[3].Value.ToString();
            txtValor.Text = gridDetalhes.CurrentRow.Cells[4].Value.ToString();
            idProduto = gridDetalhes.CurrentRow.Cells[7].Value.ToString();

            //RECUPERAR O TOTAL DO ESTOQUE DO PRODUTO
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;

            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM produtos where id = @id", con.con);
            cmdVerificar.Parameters.AddWithValue("@id", idProduto);

            reader = cmdVerificar.ExecuteReader();

            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA
                while (reader.Read())
                {
                    txtEstoque.Text = Convert.ToString(reader["estoque"]);

                }
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (idDetVenda == "")
            {

                MessageBox.Show("Selecione um Produto para Remover", "Removendo Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }

            //CÓDIGO DO BOTÃO PARA DELETAR ITEM DA VENDA
            con.AbrirCon();
            sql = "DELETE FROM detalhes_venda WHERE id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", idDetVenda);
            

            cmd.ExecuteNonQuery();
            con.FecharCon();

            //DEVOLVER QUANTIDADE AO ESTOQUE
            con.AbrirCon();
            sql = "UPDATE produtos SET estoque = @estoque where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", idProduto);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtQuantidade.Text));


            cmd.ExecuteNonQuery();
            con.FecharCon();

            //MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //TOTALIZAR A VENDA
            double total;
            total = Convert.ToDouble(totalVenda) - Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text);
            totalVenda = total.ToString();
            lblTotal.Text = string.Format("{0:c2}", total);

            txtQuantidade.Text = "";
            txtProduto.Text = "";
            txtEstoque.Text = "0";
            txtValor.Text = "";
            idDetVenda = "";

            if (exclusaoVenda == "1")
            {
                BuscarDetalhesVenda();
            }
            else
            {
                ListarDetalhesVendas();
            }
            

            

            
        }

        private void FrmVendas_FormClosed(object sender, FormClosedEventArgs e)
        {

            
            
        }

        private void FrmVendas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (totalVenda != "0")
            {
                MessageBox.Show("A venda possui itens, favor remover antes de sair!");
                e.Cancel = true;
            }
            
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idVenda = grid.CurrentRow.Cells[0].Value.ToString();
            Program.idVenda = grid.CurrentRow.Cells[0].Value.ToString();
            totalVenda = grid.CurrentRow.Cells[1].Value.ToString();
            lblTotal.Text = string.Format("{0:c2}", totalVenda);
            BuscarDetalhesVenda();
            btnFechar.Visible = true;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            btnExcluir.Enabled = true;
            exclusaoVenda = "1";
            BtnRel.Enabled = true;

        }

        private void BuscarDetalhesVenda()
        {
            con.AbrirCon();
            sql = "SELECT * from detalhes_venda where id_venda = @id_venda";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_venda", idVenda);
            
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridDetalhes.DataSource = dt;
            con.FecharCon();

            FormatarDGDetalhesVendas();
            gridDetalhes.Visible = true;
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            gridDetalhes.Visible = false;
            btnFechar.Visible = false;
            totalVenda = "0";
            lblTotal.Text = "0";
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (totalVenda == "0")
            {
                var resultado = MessageBox.Show("Deseja Realmente Cancelar a Venda?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    //CÓDIGO DO BOTÃO PARA EXCLUIR
                    con.AbrirCon();
                    sql = "UPDATE vendas set status = @status where id = @id";
                    cmd = new MySqlCommand(sql, con.con);
                    cmd.Parameters.AddWithValue("@status", "Cancelada");
                    cmd.Parameters.AddWithValue("@id", idVenda);
                    cmd.ExecuteNonQuery();
                    con.FecharCon();

                    MessageBox.Show("Venda Cancelada com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNovo.Enabled = true;

                    btnExcluir.Enabled = false;
                    limparCampos();
                    desabilitarCampos();

                    ListarVendas();
                    totalVenda = "0";
                    exclusaoVenda = "";
                    btnFechar.Visible = false;


                    //EXCLUSAO DO MOVIMENTO DA VENDA
                    con.AbrirCon();
                    sql = "DELETE FROM movimentacoes where id_movimento = @id and movimento = @movimento";
                    cmd = new MySqlCommand(sql, con.con);
                    
                    cmd.Parameters.AddWithValue("@id", idVenda);
                    cmd.Parameters.AddWithValue("@movimento", "Venda");
                    cmd.ExecuteNonQuery();
                    con.FecharCon();
                }
            }
            else
            {
                MessageBox.Show("Você precisa excluir todos os itens da venda!!");
            }

           
        }

        private void DtBuscar_ValueChanged(object sender, EventArgs e)
        {
            BuscarData();
        }

        private void BtnRel_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelComprovante form = new Relatorios.FrmRelComprovante();
            form.Show();
        }
    }
}
