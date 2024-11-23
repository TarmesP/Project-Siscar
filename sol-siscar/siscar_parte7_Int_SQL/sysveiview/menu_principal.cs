using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using siscarmodel;
using siscarcontroller;



namespace siscarview
{

    public class menu_principal
    {

        private Marcas marcas = new Marcas();
        private Marca item;

        private veiculo1 Veiculos = new veiculo1();
        private VEICULOS Veiculo;

        private modelo Modelos = new modelo();
        private MODELOS Modelo;
        

        public menu_principal()
        {

            int opc = 0;

            

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
                    exibir_submenu_marcas();
                }
                else if (opc == 2)
                {
                    exibir_submenu_veiculos();
                }
                else if (opc == 3)
                {
                    exibir_submenu_modelos();
                }
            }
        }

        private void exibir_submenu_marcas()
        {
            int opcsub = 0;
            Marcas marcaRepo = new Marcas();


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
                                item = new Marca();

                                Console.Write("Codigo: ");
                                item.codigo = int.Parse(Console.ReadLine());

                                Console.Write("Nome: ");
                                item.nome = Console.ReadLine();

                                Console.Write("Observacoes: ");
                                item.observacoes = Console.ReadLine();

                                marcas.inserir(item);

                                break;

                            case 11:
                                Console.Write("Digite o código da Marca que deseja alterar: ");
                                int veiID2 = int.Parse(Console.ReadLine());
                                item = new Marca();


                                Console.WriteLine("Marca Localizada");

                                Console.Write("Informe o novo Nome: ");
                                item.nome = Console.ReadLine();

                                Console.Write("Informe as novas Observacoes: ");
                                item.observacoes = Console.ReadLine();

                                marcas.alterar(veiID2, item);



                                break;

                            case 12:
                                Console.Write("Remover por Codigo: ");
                                int veiID = int.Parse(Console.ReadLine());

                                marcas.excluir(veiID);

                                break;

                            case 13:


                        Console.Write("Pesquisar por Código: ");
                        int varID = int.Parse(Console.ReadLine()); // Lê o ID digitado pelo usuário.

                        Marca marcaPesquisada = marcaRepo.pesquisar(varID); // Armazena o retorno do método pesquisar.

                        if (marcaPesquisada != null) // Verifica se um registro foi encontrado.
                        {
                            Console.WriteLine($"Marca encontrada: {marcaPesquisada.nome}, {marcaPesquisada.observacoes}");
                        }
                        else
                        {
                            Console.WriteLine("Marca não encontrada.");
                        }



                        /*
                          Console.Write("Pesquisar por Codigo: ");
                            int varID = int.Parse(Console.ReadLine());
                            marcas.pesquisar(varID);


                            Marcas marcaRepo = new Marcas();

                            Marca marcaPesquisada = marcaRepo.pesquisar(1);
                            if (marcaPesquisada != null)
                            {
                                Console.WriteLine($"Marca encontrada: {marcaPesquisada.nome}, {marcaPesquisada.observacoes}");
                            }

                            else
                            {
                                Console.WriteLine("Marca não encontrada.");
                            }

                            break;
                         */

                        break;

                    case 14:

                        /* marcas.exibirTodos(); */


                        List<Marca> todasMarcas = marcaRepo.ExibirTodos();
                        Console.WriteLine("Exibindo todas as marcas:");
                        foreach (var marca in todasMarcas)
                        {
                            Console.WriteLine($"Código: {marca.codigo}, Nome: {marca.nome}, Observações: {marca.observacoes}");
                        }

                        break;

                        }
                }
        }

        private void exibir_submenu_veiculos()
        {
            int opcsub = 0;

            veiculo1 repo = new veiculo1();

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

                        Veiculos.Inserir(novoVeiculo);


                        break;

                    case 21:
                        Console.Write("Nome para Alterar: ");
                        string nomeParaAlterar = Console.ReadLine().Trim();
                        var veiculo = new VEICULOS();


                        Console.WriteLine("Veiculo Localizado");

                        
                        /* Não faz sentido, não se altera o codigo no banco de dados
                         
                        Console.Write("Informe o novo Codigo: ");
                        veiculo.veiid = int.Parse(Console.ReadLine());

                        */

                        Console.Write("Informe o novo Nome: ");
                        veiculo.veinome = Console.ReadLine();

                        Console.Write("Informe o novo ano de Fabricacao: ");
                        veiculo.veianofabricacao = int.Parse(Console.ReadLine());

                        Console.Write("Informe o novo ano do Modelo: ");
                        veiculo.veianomodelo = int.Parse(Console.ReadLine());

                        Console.Write("Informe as novas Observacoes: ");
                        veiculo.veiobservacoes = Console.ReadLine();


                        Veiculos.Alterar(nomeParaAlterar, veiculo);




                        break;

                    case 22:
                        Console.Write("Remover por Codigo: ");
                        int veiID = int.Parse(Console.ReadLine());

                        Veiculos.excluir(veiID);

                        break;

                    case 23:
                        Console.Write("Pesquisar por codigo: ");
                        int varID = int.Parse(Console.ReadLine());

                        // Veiculos.pesquisar(varID);


                        VEICULOS veiculoPesquisado = repo.Pesquisar(varID);
                        if (veiculoPesquisado != null)
                        {
                            Console.WriteLine($"ID: {veiculoPesquisado.veiid}, Nome: {veiculoPesquisado.veinome}");
                        }
                        else
                        {
                            Console.WriteLine("Veículo não encontrado.");
                        }




                        break;

                    case 24:
                        // Veiculos.exibirTodos();

                        List<VEICULOS> todosVeiculos = repo.ExibirTodos();
                        foreach (var veiculo1 in todosVeiculos)
                        {
                            Console.WriteLine($"ID: {veiculo1.veiid}, Nome: {veiculo1.veinome}, Ano de Fabricação: {veiculo1.veianofabricacao}");
                        }


                        break;
                }
            }
        }

        private void exibir_submenu_modelos()
        {
            int opcsub = 0;

            modelo repo = new modelo();

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

                        Modelos.inserir(novoModelo);


                        break;

                    case 31:
                        Console.Write("Alterar por Codigo: ");
                        int codigoAlterar = int.Parse(Console.ReadLine());
                        var modelo = new MODELOS();


                        Console.WriteLine("Modelo Localizado");

                        Console.Write("Informe o novo Codigo: ");
                        modelo.modid = int.Parse(Console.ReadLine());

                        Console.Write("Informe o novo Nome: ");
                        modelo.modnome = Console.ReadLine();

                        Console.Write("Informe a nova Observacao: ");
                        modelo.modobservacoes = Console.ReadLine();

                        Modelos.alterar(codigoAlterar, modelo);

                        break;

                    case 32:
                        Console.Write("Excluir por Codigo: ");
                        int codigoExcluir = int.Parse(Console.ReadLine());
                        Veiculos.excluir(codigoExcluir);

                        break;

                    case 33:

                        /*
                        Console.Write("Pesquisar por Codigo: ");
                        int codigoPesquisar = int.Parse(Console.ReadLine());

                        Veiculos.excluir(codigoPesquisar);

                        break; 
                        */

                       

                        Console.WriteLine("Digite o código do modelo que deseja pesquisar:");
                        int modID = int.Parse(Console.ReadLine()); // Lê o ID informado pelo usuário

                        
                        MODELOS modeloPesquisado = repo.Pesquisar(modID); // Chama o método Pesquisar

                        if (modeloPesquisado != null)
                        {
                            // Exibe os dados encontrados
                            Console.WriteLine("Modelo encontrado:");
                            Console.WriteLine($"ID: {modeloPesquisado.modid}");
                            Console.WriteLine($"Nome: {modeloPesquisado.modnome}");
                            Console.WriteLine($"Observações: {modeloPesquisado.modobservacoes}");
                        }
                        else
                        {
                            // Caso nenhum modelo seja encontrado
                            Console.WriteLine("Nenhum modelo encontrado com o código informado.");
                        }


                        break;

                    case 34:
                        /*
                        Veiculos.exibirTodos();
                        */

                        

                        Console.WriteLine("Exibir todos os modelos:");
                        List<MODELOS> todosModelos = repo.ExibirTodos();
                        foreach (var modelos in todosModelos)
                        {
                            Console.WriteLine($"ID: {modelos.modid}, Nome: {modelos.modnome}, Observações: {modelos.modobservacoes}");
                        }


                        break;
                }
            }
        }
        
    }
}
