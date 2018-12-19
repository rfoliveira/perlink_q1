using System;
using System.Linq;
using static System.Console;
using NumerosFelizesESortudos.Lib;

namespace NumerosFelizesESortudos.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            WriteLine("------------------------------------------");
            WriteLine("Verifica se um número é sortudo e/ou feliz");
            WriteLine("------------------------------------------");
            
            while (!sair)
            {
                WriteLine("Escolha uma opção:");    
                WriteLine("1 - Jogar");
                WriteLine("2 - Sair");

                if ((!int.TryParse(ReadLine(), out int opcao)) && (!new[] {1,2}.Contains(opcao)))
                {
                    Write("Opção inválida.");
                    ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Jogar();
                        ReadKey();
                        
                        break;
                    case 2:
                        sair = true;
                        break;
                }                
            }
        }

        private static void Jogar()
        {
            Write("Informe um número: ");

            if (!int.TryParse(ReadLine(), out int num))
                WriteLine("Nûmero inválido");
            else {
                var feliz = NumeroFelizSortudo.Instance.EhFeliz(num);
                var sortudo = NumeroFelizSortudo.Instance.EhSortudo(num);

                WriteLine($"{num} - Número {(sortudo ? string.Empty : "Não-")}Sortudo e {(feliz ? string.Empty : "Não-")}Feliz.");
            }
        }
    }
}
