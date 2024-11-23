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
    public class veiculo1
    {
        private List<VEICULOS> bancoVeiculos = new List<VEICULOS>();
        private VEICULOS veiculos;

        private string caminhoBanco;
        private string nomeBancosVeiculos;
        private string caminho;

        //passo 2
        // string de conexão, mostra qual o servido sql que quer se comunicar e o database
        string connectionString = "Server=DESKTOP-P0TGKNJ;Database=SISCARDB;Integrated Security=True;";
        // string connectionString = "Server=localhost;Database=SeuBancoDeDados;Integrated Security=True;";

        public veiculo1()
        {
            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancosVeiculos = ConfigurationManager.AppSettings["nomeBancosVeiculos"];
            caminho = caminhoBanco + nomeBancosVeiculos;

            bancoVeiculos = CarregarVeiculosDoCsv();


        }

        public void Inserir(VEICULOS novoVeiculo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TBLVEICULOS (VEIID, VEIANOFABRICACAO, VEIANOMODELO, VEINOME, VEIOBSERVACOES) " +
                               "VALUES (@VEIID, @VEIANOFABRICACAO, @VEIANOMODELO, @VEINOME, @VEIOBSERVACOES)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@VEIID", novoVeiculo.veiid);
                cmd.Parameters.AddWithValue("@VEIANOFABRICACAO", novoVeiculo.veianofabricacao);
                cmd.Parameters.AddWithValue("@VEIANOMODELO", novoVeiculo.veianomodelo);
                cmd.Parameters.AddWithValue("@VEINOME", novoVeiculo.veinome);
                cmd.Parameters.AddWithValue("@VEIOBSERVACOES", novoVeiculo.veiobservacoes);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Veículo inserido com sucesso.");
            }
        }

        /*
         public void inserir(VEICULOS novoVeiculo)
        {
            bancoVeiculos.Add(novoVeiculo);
            Console.WriteLine("Veiculo inserido com sucesso!");
        }
         */

        public void Alterar(string nomeParaAlterar, VEICULOS veiculo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE TBLVEICULOS SET VEIANOFABRICACAO = @VEIANOFABRICACAO, VEIANOMODELO = @VEIANOMODELO, " +
                               "VEINOME = @VEINOME, VEIOBSERVACOES = @VEIOBSERVACOES WHERE VEINOME = @NOMEANTIGO";
                SqlCommand cmd = new SqlCommand(query, conn);

                //cmd.Parameters.AddWithValue("@VEIID", veiculo.veiid);
                cmd.Parameters.AddWithValue("@VEIANOFABRICACAO", veiculo.veianofabricacao);
                cmd.Parameters.AddWithValue("@VEIANOMODELO", veiculo.veianomodelo);
                cmd.Parameters.AddWithValue("@VEINOME", veiculo.veinome);
                cmd.Parameters.AddWithValue("@VEIOBSERVACOES", veiculo.veiobservacoes);
                cmd.Parameters.AddWithValue("@NOMEANTIGO", nomeParaAlterar); // Nome a ser pesquisado

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Veículo alterado com sucesso.");
            }
        }

        /*
         public void alterar(string nomeParaAlterar, VEICULOS veiculo)
        {
            foreach (var pesquisa_veiculo in bancoVeiculos)
            {
                if (pesquisa_veiculo.veinome == nomeParaAlterar)
                {

                    pesquisa_veiculo.veinome = veiculo.veinome;
                    pesquisa_veiculo.veianofabricacao = veiculo.veianofabricacao;
                    pesquisa_veiculo.veianomodelo = veiculo.veianomodelo;
                    pesquisa_veiculo.veiobservacoes = veiculo.veiobservacoes;

                    Console.WriteLine("Veiculo alterado com sucesso!");

                    break;
                }

            }
        }
         */

        public void excluir(int veiID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TBLVEICULOS WHERE VEIID = @VEIID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@VEIID", veiID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Veículo excluído com sucesso.");
            }

        }

        /*
         public void excluir(int veiID)
        {
            foreach (var veiculo in bancoVeiculos)
            {
                if (veiculo.veiid == veiID)
                {
                    bancoVeiculos.Remove(veiculo);
                    Console.WriteLine("Veiculo removido");
                    break;
                }
            }

        }
         */

        public VEICULOS Pesquisar(int veiID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT VEIID, VEIANOFABRICACAO, VEIANOMODELO, VEINOME, VEIOBSERVACOES " +
                               "FROM TBLVEICULOS WHERE VEIID = @VEIID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@VEIID", veiID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new VEICULOS
                    {
                        veiid = (int)reader["VEIID"],
                        veianofabricacao = (int)reader["VEIANOFABRICACAO"],
                        veianomodelo = (int)reader["VEIANOMODELO"],
                        veinome = reader["VEINOME"].ToString(),
                        veiobservacoes = reader["VEIOBSERVACOES"].ToString()
                    };
                }

                conn.Close();
            }

            return null; // Retorna null se nenhum registro for encontrado.

        }

        /*
         public void pesquisar(int varID)
        {
            foreach (var veiculo in bancoVeiculos)
            {
                if (veiculo.veiid == varID)
                {
                    Console.WriteLine("Codigo: " + veiculo.veiid);
                    Console.WriteLine("Nome: " + veiculo.veinome);
                    Console.WriteLine("Ano Fabricacao: " + veiculo.veianofabricacao);
                    Console.WriteLine("Ano Modelo: " + veiculo.veianomodelo);
                    Console.WriteLine("Observacoes: " + veiculo.veiobservacoes);
                    Console.WriteLine();
                }
            }
        }
         */

        public List<VEICULOS> ExibirTodos()
        {
            List<VEICULOS> veiculos = new List<VEICULOS>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT VEIID, VEIANOFABRICACAO, VEIANOMODELO, VEINOME, VEIOBSERVACOES FROM TBLVEICULOS";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    veiculos.Add(new VEICULOS
                    {
                        veiid = (int)reader["VEIID"],
                        veianofabricacao = (int)reader["VEIANOFABRICACAO"],
                        veianomodelo = (int)reader["VEIANOMODELO"],
                        veinome = reader["VEINOME"].ToString(),
                        veiobservacoes = reader["VEIOBSERVACOES"].ToString()
                    });
                }

                conn.Close();
            }

            return veiculos;
        }

        /*
         public void exibirTodos()
        {
            foreach (var valor in bancoVeiculos)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Codigo: " + valor.veiid);
                Console.WriteLine("Nome: " + valor.veinome);
                Console.WriteLine("Ano Fabricacao: " + valor.veianofabricacao);
                Console.WriteLine("Ano Modelo: " + valor.veianomodelo);
                Console.WriteLine("Observacoes: " + valor.veiobservacoes);
                Console.WriteLine();
            }
        }
         */

        public void SalvarVeiculosEmCsv()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,anoFabricacao,anoModelo,observacoes");

                    foreach (var item in bancoVeiculos)
                    {
                        writer.WriteLine(
                            $"{item.veiid},{item.veinome},{item.veianofabricacao},{item.veianomodelo},{item.veiobservacoes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        public List<VEICULOS> CarregarVeiculosDoCsv()
        {
            var veiculos = new List<VEICULOS>();

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
                            if (partes.Length == 5)
                            {
                                int codigo = int.Parse(partes[0]);
                                string nome = partes[1];
                                int anoFabricacao = int.Parse(partes[2]);
                                int anoModelo = int.Parse(partes[3]);
                                string observacoes = partes[4];
                                veiculos.Add(new VEICULOS
                                {
                                    veiid = codigo,
                                    veinome = nome,
                                    veianofabricacao = anoFabricacao,
                                    veianomodelo = anoModelo,
                                    veiobservacoes = observacoes
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
            return veiculos;
        }

        internal void inserir(string nomeParaAlterar)
        {
            throw new NotImplementedException();
        }


    }
}
