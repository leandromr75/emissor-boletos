using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novo_zenite
{
    class DAL
    {
        public static DataTable Deleta_Nome_Mes_Atual(string nome)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Deleta_Nome_Mes_Atual";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", nome);
            //cmd.Parameters.AddWithValue("@Parcela", Parcela);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
       
        public static DataTable Lista_Nome()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Nomes";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Atraso()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Atraso";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Leitura2()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Leitura2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Rateio()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Rateio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Config()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Config";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Rateio_Parcelado(int Rateio)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Rateio_Parcelado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Rateio", Rateio);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Baixar_Rateio(int Id)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Baixar_Rateio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Baixar_Rateio_Parcelado(int Rateio, string Parcela)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Baixar_Rateio_Parcelado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Rateio", Rateio);
            cmd.Parameters.AddWithValue("@Parcela", Parcela);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Rateio_Parcelado2(int Rateio)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Rateio_Parcelado2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Rateio", Rateio);
            //cmd.Parameters.AddWithValue("@Parcela", Parcela);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Leitura()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Leitura";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Mes_Atual()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Mes_Atual";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Inativo()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Inativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Ativo()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Ativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Relatorio_Indice()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Relatorio_Indice";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Relatorio(string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Relatorio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Mes", Mes);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Relatorio2(string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Relatorio2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Mes", Mes);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Relatorio3(string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Relatorio3";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Mes", Mes);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Medição(string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Medição";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Mes", Mes);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Medição2()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Medição2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@Mes", Mes);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static void Insere_Nome(string Nome, string Anterior, string Atual, string Atraso, string Observação, string TX)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Nome";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Anterior", Anterior);
            cmd.Parameters.AddWithValue("@Atual", Atual);
            cmd.Parameters.AddWithValue("@Atraso", Atraso);
            cmd.Parameters.AddWithValue("@Observação", Observação);
            cmd.Parameters.AddWithValue("@TX",TX);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Insere_Config(string Valor_Base, string Dez_Trinta, string Trinta_Noventa, string Noventa, string Multa, string TX_Comercial)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Config";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Valor_Base", Valor_Base);
            cmd.Parameters.AddWithValue("@Dez_Trinta", Dez_Trinta);
            cmd.Parameters.AddWithValue("@Trinta_Noventa", Trinta_Noventa);
            cmd.Parameters.AddWithValue("@Noventa", Noventa);
            cmd.Parameters.AddWithValue("@Multa", Multa);
            cmd.Parameters.AddWithValue("@TX_Comercial", TX_Comercial);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Deleta_Relatorio()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Deleta_Relatorio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Insere_Rateio(string Descrição, string Valor, string Parcelado, string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Rateio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Descrição", Descrição);
            cmd.Parameters.AddWithValue("@Valor", Valor);
            cmd.Parameters.AddWithValue("@Parcelado", Parcelado);
            cmd.Parameters.AddWithValue("@Mes", Mes);            

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Altera_Relatorio(string Nome, string Pagamento)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Altera_Relatorio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Pagamento", Pagamento);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Deleta_Config()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Deleta_Config";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Atualiza_Consumo(Int32 id, string anterior, string atual)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Atualiza_Consumo2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Anterior", anterior);
            cmd.Parameters.AddWithValue("@Atual", atual);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Insere_Rateio_Parcelado(int Rateio, string Descrição, string Parcela, string valor)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Rateio_Parcelado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Rateio", Rateio);
            cmd.Parameters.AddWithValue("@Descrição", Descrição);
            cmd.Parameters.AddWithValue("@Parcela", Parcela);
            cmd.Parameters.AddWithValue("@Valor", valor);
            

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Insere_Relatorio_Indice(string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Relatorio_Indice";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Mes", Mes);
           


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Cria_Relatorio(string Nome, string Anterior, string Atual, string Consumo, string Valor, string Rateio,
            string TX, string Total, string Total_c_Multa, string Atraso, string Pagamento, string Observação_, string Mes)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Cria_Relatorio";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Anterior", Anterior);
            cmd.Parameters.AddWithValue("@Atual", Atual);
            cmd.Parameters.AddWithValue("@Consumo", Consumo);
            cmd.Parameters.AddWithValue("@Valor", Valor);
            cmd.Parameters.AddWithValue("@Rateio", Rateio);
            cmd.Parameters.AddWithValue("@TX", TX);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Total_c_Multa", Total_c_Multa);
            cmd.Parameters.AddWithValue("@Atraso", Atraso);
            cmd.Parameters.AddWithValue("@Pagamento", Pagamento);
            cmd.Parameters.AddWithValue("@Observação", Observação_);
            cmd.Parameters.AddWithValue("@Mes", Mes);


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Insere_Vencimento(int Id, string Vencimento)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Vencimento";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Vencimento", Vencimento);
            

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Pagou_Id(int Id, string Pagou)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Pagou_Id";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Pagou", Pagou);


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Atualiza_Atraso(int Id, string Atraso)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Atualiza_Atraso";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Atraso", Atraso);


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Deleta_Pagou()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Deleta_Pagou";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static DataTable Lista_Vencimento()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Vencimento";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;




            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Lista_Nomes_Re(string Nome)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Lista_Nomes_Re";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", Nome);



            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static DataTable Pagou_Id_Lista(int Id)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Pagou_Id_Lista";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
           


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return clientes;
        }
        public static void Insere_Leitura(int Id, string Atual)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Insere_Leitura";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Atual", Atual);


            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Cria_Mes_Atual(string Atual, string Ano, string Mes, string Dia, string Vencimento,
            string Nome, string Pagamento)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Cria_Mes_Atual";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Atual", Atual);
            cmd.Parameters.AddWithValue("@Ano", Ano);
            cmd.Parameters.AddWithValue("@Mes", Mes);
            cmd.Parameters.AddWithValue("@Dia", Dia);
            cmd.Parameters.AddWithValue("@Vencimento", Vencimento);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Pagamento", Pagamento);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Deleta_Mes_Atual()
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Deleta_Mes_Atual";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        
        public static void Torna_Inativo(int Id)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Torna_Inativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
        public static void Altera_Nome(int Id, string Nome, string Anterior, string Atual, string Atraso, string Observação, string TX)
        {
            string strConnection = "";
            if (Global.Config.BancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "local2")
            {
                strConnection = "Data Source=TI;Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Config.BancoDados == "rede")
            {
                string ip = Global.Config.BancoDados_IP;
                string porta = Global.Config.BancoDados_Porta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=AMBRA;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Altera_Nome";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Anterior", Anterior);
            cmd.Parameters.AddWithValue("@Atual", Atual);
            cmd.Parameters.AddWithValue("@Atraso", Atraso);
            cmd.Parameters.AddWithValue("@Observação", Observação);
            cmd.Parameters.AddWithValue("@TX", TX);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            // return clientes;
        }
    }
}
