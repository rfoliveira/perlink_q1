using System;
using static System.Console;
using System.Linq;

namespace Perlink_Teste
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
                var feliz = EhFeliz(num);
                var sortudo = EhSortudo(num);

                WriteLine($"{num} - Número {(sortudo ? string.Empty : "Não-")}Sortudo e {(feliz ? string.Empty : "Não-")}Feliz.");
            }
        }

        private static bool EhFeliz(int num)
        {
            int limite = 100;
            bool r = false;
            
            while ((!r) && (limite > 0))
            {
                var soma = SomaDigitosAoQuadrado(num);
                r = (soma == 1);
                
                num = soma;
                limite--;
            }
            
            return r;
        }

        private static int SomaDigitosAoQuadrado(int num)
        {
            int total = 0;
            
            while (num > 0)
            {
                total += (int)Math.Pow(num % 10, 2);
                num /= 10;
            }
            
            return total;
        }

        private static bool EhSortudo(int num) 
        {
            var numeros = Enumerable.Range(1,num).ToList();
            bool r = false;
            
            while (!r) {
                r = (numeros.RemoveAll(x => x % (numeros.FirstOrDefault() + 1) == 0) == 0);
            }
                
            return numeros.IndexOf(num) > 0;
        }
    }
}
