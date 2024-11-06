﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using siscarmodel;

namespace siscarcontroller
{
    public class Marcas
    {
        private List<Marca> bancoMarcas = new List<Marca>();
        private Marca item;

        private string caminhoBanco;
        private string nomeBancosMarcas;
        private string caminho;

        public Marcas()
        {
            caminhoBanco = ConfigurationManager.AppSettings["caminhoBanco"];
            nomeBancosMarcas = ConfigurationManager.AppSettings["nomeBancosMarcas"];
            caminho = caminhoBanco + nomeBancosMarcas;

            bancoMarcas = CarregarMarcasDoCsv();
        }

        public void inserir(Marca item)
        {
            bancoMarcas.Add(item);
            Console.WriteLine("Marca inserida com sucesso!");
        }

        public void alterar(int veiID2, Marca item)
        {
            foreach (var item1 in bancoMarcas)
            {
                if (item1.codigo == veiID2)
                {

                    item1.nome = item.nome;
                    item1.observacoes = item.observacoes;

                    Console.WriteLine("Marca alterado com sucesso");

                    break;
                }
            }

        }

        public void excluir(int veiID)
        {
            foreach (var item1 in bancoMarcas)
            {
                if (item1.codigo == veiID)
                {
                    bancoMarcas.Remove(item1);
                    Console.WriteLine("Estado removido com sucesso!");

                    break;
                }
            }
        }

        public void pesquisar(int varID)
        {
            foreach (var item1 in bancoMarcas)
            {
                if (item1.codigo == varID)
                {
                    Console.Write("Codigo: " + item1.codigo);
                    Console.Write("Nome: " + item1.nome);
                    Console.Write("Observacoes: " + item1.observacoes);
                    Console.WriteLine();
                }
            }
        }

        public void exibirTodos()
        {
            foreach (var valor in bancoMarcas)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Codigo: " + valor.codigo);
                Console.WriteLine("Nome: " + valor.nome);
                Console.WriteLine("Observacoes: " + valor.observacoes);

            }
        }


        public void SalvarMarcasEmCsv()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,observacoes");

                    foreach (var item in bancoMarcas)
                    {
                        writer.WriteLine(
                            $"{item.codigo},{item.nome},{item.observacoes}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }

        public List<Marca> CarregarMarcasDoCsv()
        {
            var MARCA = new List<Marca>();

            try
            {
                if (File.Exists(caminho) == true)
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
                                MARCA.Add(new Marca
                                {
                                    codigo = codigo,
                                    nome = nome,
                                    observacoes = observacoes
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
            }
            return MARCA;
        }


    }
}