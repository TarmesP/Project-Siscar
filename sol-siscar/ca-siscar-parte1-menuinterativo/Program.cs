using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ca_siscar_parte1_menuinterativo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int opc = 0;
            int opcsub = 0;

            while (opc !=9)
            {
                Console.WriteLine("\n");
                Console.WriteLine("SISCAR");
                Console.WriteLine("1. Marcas");
                Console.WriteLine("2. Veiculos");
                Console.WriteLine("3. Modelos");
                Console.WriteLine("9. Sair");
                Console.WriteLine("Digite a opcao: ");
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
                        Console.WriteLine("19. SAIR");
                        Console.WriteLine("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                    }

                }
                else if (opc == 2)
                {
                    opcsub = 0;

                    while (opcsub != 19)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("VEICULOS\n");
                        Console.WriteLine("20. Inserir");
                        Console.WriteLine("21. Alterar");
                        Console.WriteLine("22. Excluir");
                        Console.WriteLine("23. Pesquisar");
                        Console.WriteLine("29. SAIR");
                        Console.WriteLine("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                    }

                }
                else if (opc == 3)
                {
                    opcsub = 0;

                    while (opcsub != 19)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("MODELOS");
                        Console.WriteLine("30. Inserir");
                        Console.WriteLine("31. Alterar");
                        Console.WriteLine("32. Excluir");
                        Console.WriteLine("33. Pesquisar");
                        Console.WriteLine("39. SAIR");
                        Console.WriteLine("Digite a opcao: ");
                        opcsub = int.Parse(Console.ReadLine());

                    }

                }
                
            }

        }
    }
}
