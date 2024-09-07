using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ca_siscar_parte1_menuinterativo
{
    internal class Program
    {

        // -------------------------------------------------------------------------
        
        static void SalvarMarcasEmCsv(List<MARCAS> banco, string caminho) 
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,observacoes");

                    foreach (var item in banco)
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
        
        static List<MARCAS> CarregarMarcasDoCsv(string caminho)
        {
            var MARCA = new List<MARCAS>();

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
                                MARCA.Add(new MARCAS
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
                Console.WriteLine("Ocorreu um erro: " + ex.Message);                throw;
            }
            return MARCA;
        }

        // -------------------------------------------------------------------------

        static void SalvarModelosEmCsv(List<MODELOS> banco, string caminho)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,observacoes");

                    foreach (var item in banco)
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

        static List<MODELOS> CarregarModelosDoCsv(string caminho)
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

        // -------------------------------------------------------------------------

        static void SalvarVeiculosEmCsv(List<VEICULOS> banco, string caminho)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("codigo,nome,anoFabricacao,anoModelo,observacoes");

                    foreach (var item in banco)
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

        static List<VEICULOS> CarregarVeiculosDoCsv(string caminho)
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

        // -------------------------------------------------------------------------


        static void Main(string[] args)
        {
            int opc = 0;
            int opcsub = 0;

            /* variaveis para controle de Marcas*/
            List<MARCAS> bancoMarcas = new List<MARCAS>();
            MARCAS item;

            List<MODELOS> bancoModelos = new List<MODELOS>();
            MODELOS modelos;

            List<VEICULOS> bancoVeiculos = new List<VEICULOS>();
            VEICULOS veiculos;
            
            bancoMarcas = CarregarMarcasDoCsv("MARCA.csv");
            bancoModelos = CarregarModelosDoCsv("MODELOS.csv");
            bancoVeiculos = CarregarVeiculosDoCsv("VEICULOS.csv");

            while (opc != 9)
            {
                Console.WriteLine("\n");
                Console.WriteLine("SISCAR");
                Console.WriteLine("1. Marcas");
                Console.WriteLine("2. Veiculos");
                Console.WriteLine("3. Modelos");
                Console.WriteLine("9. Sair");
                Console.Write("Digite a opcao: ");
                opc = int.Parse(Console.ReadLine());

                if (opc == 1)
                {
                    opcsub = 0;

                    while (opcsub != 19)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("MARCAS");
                        Console.WriteLine("10. Inserir");
                        Console.WriteLine("11. Alterar");
                        Console.WriteLine("12. Excluir");
                        Console.WriteLine("13. Pesquisar");
                        Console.WriteLine("14. Exibir");
                        Console.WriteLine("19. SAIR");
                        Console.Write("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                        switch (opcsub)
                        {
                            case 10:
                                item = new MARCAS();

                                Console.Write("Codigo: ");
                                item.codigo = int.Parse(Console.ReadLine());

                                Console.Write("Nome: ");
                                item.nome = Console.ReadLine();

                                Console.Write("Observacoes: ");
                                item.observacoes = Console.ReadLine();

                                bancoMarcas.Add(item);

                                break;

                            case 11:
                                Console.Write("Digite o código da Marca que deseja alterar: ");
                                int veiID2 = int.Parse(Console.ReadLine());

                                foreach (var item1 in bancoMarcas)
                                {
                                    if (item1.codigo == veiID2)
                                    {
                                        Console.WriteLine("Marca Localizada");

                                        Console.Write("Informe o novo Nome: ");
                                        item1.nome = Console.ReadLine();

                                        Console.Write("Informe as novas Observacoes: ");
                                        item1.observacoes = Console.ReadLine();

                                        break;
                                    }
                                }
                                break;

                            case 12:
                                Console.Write("Remover por Codigo: ");
                                int veiID = int.Parse(Console.ReadLine());

                                foreach (var item1 in bancoMarcas)
                                {
                                    if (item1.codigo == veiID)
                                    {
                                        bancoMarcas.Remove(item1);
                                        Console.WriteLine("Marca removida");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Marca não encontrada.");
                                    }
                                }
                                break;

                            case 13:
                                Console.Write("Pesquisar por Codigo: ");
                                int varID = int.Parse(Console.ReadLine());

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
                                break;

                            case 14:
                                foreach (var valor in bancoMarcas)
                                {
                                    Console.WriteLine("------------------------------");
                                    Console.WriteLine("Codigo: " + valor.codigo);
                                    Console.WriteLine("Nome: " + valor.nome);
                                    Console.WriteLine("Observacoes: " + valor.observacoes);
                                    
                                }
                                break;
                        }
                    }
                }
                else if (opc == 2)
                {
                    opcsub = 0;

                    while (opcsub != 29)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("VEICULOS");
                        Console.WriteLine("20. Inserir");
                        Console.WriteLine("21. Alterar");
                        Console.WriteLine("22. Excluir");
                        Console.WriteLine("23. Pesquisar");
                        Console.WriteLine("24. Exibir");
                        Console.WriteLine("29. SAIR");
                        Console.Write("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                        switch (opcsub)
                        {
                            case 20:
                                VEICULOS novoVeiculo = new VEICULOS();

                                Console.Write("Codigo: ");
                                novoVeiculo.veiid = int.Parse(Console.ReadLine());

                                Console.Write("Nome: ");
                                novoVeiculo.veinome = Console.ReadLine();

                                Console.Write("Ano de Fabricacao: ");
                                novoVeiculo.veianofabricacao = int.Parse(Console.ReadLine());

                                Console.Write("Ano do Modelo: ");
                                novoVeiculo.veianomodelo = int.Parse(Console.ReadLine());

                                Console.Write("Observacoes: ");
                                novoVeiculo.veiobservacoes = Console.ReadLine();

                                bancoVeiculos.Add(novoVeiculo);
                                break;

                            case 21:
                                Console.Write("Nome para Alterar: ");
                                string nomeParaAlterar = Console.ReadLine().Trim();

                                foreach (var veiculo in bancoVeiculos)
                                {
                                    if (veiculo.veinome == nomeParaAlterar)
                                    {
                                        Console.WriteLine("Veiculo Localizado");

                                        Console.Write("Informe o novo Nome: ");
                                        veiculo.veinome = Console.ReadLine();

                                        Console.Write("Informe o novo ano de Fabricacao: ");
                                        veiculo.veianofabricacao = int.Parse(Console.ReadLine());

                                        Console.Write("Informe o novo ano do Modelo: ");
                                        veiculo.veianomodelo = int.Parse(Console.ReadLine());

                                        Console.Write("Informe as novas Observacoes: ");
                                        veiculo.veiobservacoes = Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Veiculo não Localizado");
                                        break;
                                    }
                                }
                                break;

                            case 22:
                                Console.Write("Remover por Codigo: ");
                                int veiID = int.Parse(Console.ReadLine());

                                foreach (var veiculo in bancoVeiculos)
                                {
                                    if (veiculo.veiid == veiID)
                                    {
                                        bancoVeiculos.Remove(veiculo);
                                        Console.WriteLine("Veiculo removido");
                                        break;
                                    }
                                }
                                break;

                            case 23:
                                Console.Write("Pesquisar por codigo: ");
                                int varID = int.Parse(Console.ReadLine());

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
                                break;

                            case 24:
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
                                break;
                        }
                    }
                }
                else if (opc == 3)
                {
                    opcsub = 0;

                    while (opcsub != 39)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("MODELOS");
                        Console.WriteLine("30. Inserir");
                        Console.WriteLine("31. Alterar");
                        Console.WriteLine("32. Excluir");
                        Console.WriteLine("33. Pesquisar");
                        Console.WriteLine("34. Exibir");
                        Console.WriteLine("39. SAIR");
                        Console.WriteLine("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                        switch (opcsub)
                        {
                            case 30:
                                Console.Write("Inserir Modelos ");
                                MODELOS novoModelo = new MODELOS();

                                Console.Write("Codigo: ");
                                novoModelo.modid = int.Parse(Console.ReadLine());

                                Console.Write("Nome: ");
                                novoModelo.modnome = Console.ReadLine();

                                Console.Write("Observacoes: ");
                                novoModelo.modobservacoes = Console.ReadLine();

                                bancoModelos.Add(novoModelo);
                                break;

                            case 31:
                                Console.Write("Alterar por Codigo: ");
                                int codigoAlterar = int.Parse(Console.ReadLine());

                                foreach (var modelo in bancoModelos)
                                {
                                    if (modelo.modid == codigoAlterar)
                                    {
                                        Console.WriteLine("Modelo Localizado");

                                        Console.Write("Informe o novo Codigo: ");
                                        modelo.modid = int.Parse(Console.ReadLine());

                                        Console.Write("Informe o novo Nome: ");
                                        modelo.modnome = Console.ReadLine();

                                        Console.Write("Informe a nova Observacao: ");
                                        modelo.modobservacoes = Console.ReadLine();
                                    }
                                }
                                break;

                            case 32:
                                Console.Write("Excluir por Codigo: ");
                                int codigoExcluir = int.Parse(Console.ReadLine());

                                foreach (var modelo in bancoModelos)
                                {
                                    if (modelo.modid == codigoExcluir)
                                    {
                                        bancoModelos.Remove(modelo);
                                        Console.WriteLine("Modelo excluido");
                                        break;
                                    }
                                }
                                break;

                            case 33:
                                Console.Write("Pesquisar por Codigo: ");
                                int codigoPesquisar = int.Parse(Console.ReadLine());

                                foreach (var modelo in bancoModelos)
                                {
                                    if (modelo.modid == codigoPesquisar)
                                    {
                                        Console.WriteLine("Codigo: " + modelo.modid);
                                        Console.WriteLine("Nome: " + modelo.modnome);
                                        Console.WriteLine("Observacoes: " + modelo.modobservacoes);
                                    }
                                }
                                break;

                            case 34:
                                foreach (var modelo in bancoModelos)
                                {
                                    Console.WriteLine("------------------------------");
                                    Console.WriteLine("Codigo: " + modelo.modid);
                                    Console.WriteLine("Nome: " + modelo.modnome);
                                    Console.WriteLine("Observacoes: " + modelo.modobservacoes);
                                }
                                break;
                        }
                    }
                }
            }
            
            SalvarMarcasEmCsv(bancoMarcas, "MARCA.csv");
            SalvarModelosEmCsv(bancoModelos, "MODELOS.csv");
            SalvarVeiculosEmCsv(bancoVeiculos, "VEICULOS.csv");

        }
        
    }

}
