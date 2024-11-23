using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using siscarmodel;

// passo 1 
using System.Data;
using System.Data.SqlClient;

namespace siscarcontroller
{
    public class modelo
    {

        private List<MODELOS> bancoModelos = new List<MODELOS>();
        private MODELOS modelos;

        private string caminhoBanco;
        private string nomeBancosModelos;
        private string caminho;

        //passo 2
        // string de conexão, mostra qual o servido sql que quer se comunicar e o database
        string connectionString = "Server=DESKTOP-P0TGKNJ;Database=SISCARDB;Integrated Security=True;";
        // string connectionString = "Server=localhost;Database=SeuBancoDeDados;Integrated Security=True;";


        public modelo()
        {
            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancosModelos = ConfigurationManager.AppSettings["nomeBancosModelos"];
            caminho = caminhoBanco + nomeBancosModelos;

            bancoModelos = CarregarModelosDoCsv();
        }

        public void inserir(MODELOS novoModelo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TBLMODELOS (MODID, MODNOME, MODOBSERVACOES) VALUES (@MODID, @MODNOME, @MODOBSERVACOES)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MODID", novoModelo.modid);
                cmd.Parameters.AddWithValue("@MODNOME", novoModelo.modnome);
                cmd.Parameters.AddWithValue("@MODOBSERVACOES", novoModelo.modobservacoes);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Modelo inserido com sucesso.");
            }
        }

        /*
         public void inserir(MODELOS novoModelo)
        {
            bancoModelos.Add(novoModelo);
            Console.WriteLine("Estado inserido com sucesso!");
        }
         */

        public void alterar(int codigoAlterar, MODELOS veiculo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tblmodelos SET MODNOME = @MODNOME, MODOBSERVACOES = @MODOBSERVACOES WHERE MODID = @MODID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MODID", codigoAlterar);
                cmd.Parameters.AddWithValue("@MODNOME", veiculo.modnome);
                cmd.Parameters.AddWithValue("@MODOBSERVACOES", veiculo.modobservacoes);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Modelo alterado com sucesso.");
            }
        }

        /*
         public void alterar(int codigoAlterar, MODELOS veiculo)
        {
            foreach (var modelo in bancoModelos)
            {
                if (modelo.modid == codigoAlterar)
                {
 
                    modelo.modid = veiculo.modid;
                    modelo.modnome = veiculo.modnome;
                    modelo.modobservacoes = modelo.modobservacoes;

                    Console.WriteLine("Estado alterado com sucesso!");

                    break;
                }
            }
        }
         */

        public void excluir(int codigoExcluir)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM tblmodelos WHERE MODID = @MODID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MODID", codigoExcluir);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Modelo excluído com sucesso.");
            }
        }

        /*
         public void excluir(int codigoExcluir)
        {
            foreach (var modelo in bancoModelos)
            {
                if (modelo.modid == codigoExcluir)
                {
                    bancoModelos.Remove(modelo);
                    Console.WriteLine("Modelo excluido");
                    break;
                }
            }
        }
         */

        public MODELOS Pesquisar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MODID, MODNOME, MODOBSERVACOES FROM tblmodelos WHERE MODID = @MODID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MODID", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new MODELOS
                    {
                        modid = (int)reader["MODID"],
                        modnome = reader["MODNOME"].ToString(),
                        modobservacoes = reader["MODOBSERVACOES"].ToString()
                    };
                }

                conn.Close();
            }

            return null; // Retorna null se nenhum registro foi encontrado.
        }

        /*
         public void pesquisar(int codigoPesquisar)
        {
            foreach (var modelo in bancoModelos)
            {
                if (modelo.modid == codigoPesquisar)
                {
                    Console.WriteLine("Codigo: " + modelo.modid);
                    Console.WriteLine("Nome: " + modelo.modnome);
                    Console.WriteLine("Observacoes: " + modelo.modobservacoes);

                    break;
                }
            }

        }
         */

        public List<MODELOS> ExibirTodos()
        {
            List<MODELOS> modelos = new List<MODELOS>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MODID, MODNOME, MODOBSERVACOES FROM tblmodelos";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    modelos.Add(new MODELOS
                    {
                        modid = (int)reader["MODID"],
                        modnome = reader["MODNOME"].ToString(),
                        modobservacoes = reader["MODOBSERVACOES"].ToString()
                    });
                }

                conn.Close();
            }

            return modelos;

        }

            /*
             public void exibirTodos()
            {
                foreach (var modelo in bancoModelos)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Codigo: " + modelo.modid);
                    Console.WriteLine("Nome: " + modelo.modnome);
                    Console.WriteLine("Observacoes: " + modelo.modobservacoes);
                }
            }
             */

            public void SalvarModelosEmCsv()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,observacoes");

                    foreach (var item in bancoModelos)
                    {
                        writer.WriteLine(
                            $"{item.modid},{item.modnome},{item.modobservacoes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        public List<MODELOS> CarregarModelosDoCsv()
        {
            var modelos = new List<MODELOS>();

            try
            {
                if (File.Exists(caminho))
                {
                    using (StreamReader reader = new StreamReader(caminho))
                    {
                        string linha = reader.ReadLine();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            var partes = linha.Split(',');
                            if (partes.Length == 3)
                            {
                                int codigo = int.Parse(partes[0]);
                                string nome = partes[1];
                                string observacoes = partes[2];
                                modelos.Add(new MODELOS
                                {
                                    modid = codigo,
                                    modnome = nome,
                                    modobservacoes = observacoes
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                throw;
            }
            return modelos;
        }

        internal void alterar(MODELOS modelo, int codigoAlterar)
        {
            throw new NotImplementedException();
        }
    }
}
