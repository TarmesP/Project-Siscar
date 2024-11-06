using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using siscarmodel;

namespace siscarcontroller
{
    public class veiculo1
    {
        private List<VEICULOS> bancoVeiculos = new List<VEICULOS>();
        private VEICULOS veiculos;

        private string caminhoBanco;
        private string nomeBancosVeiculos;
        private string caminho;

        public veiculo1()
        {
            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancosVeiculos = ConfigurationManager.AppSettings["nomeBancosVeiculos"];
            caminho = caminhoBanco + nomeBancosVeiculos;

            bancoVeiculos = CarregarVeiculosDoCsv();


        }

        public void inserir(VEICULOS novoVeiculo)
        {
            bancoVeiculos.Add(novoVeiculo);
            Console.WriteLine("Veiculo inserido com sucesso!");
        }

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
