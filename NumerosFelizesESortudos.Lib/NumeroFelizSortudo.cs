using System;
using System.Linq;

namespace NumerosFelizesESortudos.Lib
{
    public class NumeroFelizSortudo
    {
        private static Lazy<NumeroFelizSortudo> instance = 
            new Lazy<NumeroFelizSortudo>(() => new NumeroFelizSortudo());

        public static NumeroFelizSortudo Instance => instance.Value;

        private NumeroFelizSortudo() {}

        public bool EhFeliz(int num)
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

        private int SomaDigitosAoQuadrado(int num)
        {
            int total = 0;
            
            while (num > 0)
            {
                total += (int)Math.Pow(num % 10, 2);
                num /= 10;
            }
            
            return total;
        }

        public bool EhSortudo(int num)
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