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
    public class modelo
    {

        private List<MODELOS> bancoModelos = new List<MODELOS>();
        private MODELOS modelos;

        private string caminhoBanco;
        private string nomeBancosModelos;
        private string caminho;


        public modelo()
        {
            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancosModelos = ConfigurationManager.AppSettings["nomeBancosModelos"];
            caminho = caminhoBanco + nomeBancosModelos;

            bancoModelos = CarregarModelosDoCsv();
        }

        public void inserir(MODELOS novoModelo)
        {
            bancoModelos.Add(novoModelo);
            Console.WriteLine("Estado inserido com sucesso!");
        }

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
