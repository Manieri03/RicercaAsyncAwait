using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RicercaAsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] listanumeri = new int[100];
            RiempiArray(ref listanumeri);

            Console.WriteLine("Inserisci qui un numero da cercare:");
            int numero1 = int.Parse(Console.ReadLine());
            Console.WriteLine(RicercaNumeroAsync(numero1, listanumeri).Result);

            Console.WriteLine("Inserisci qui un numero da cercare:");
            int numero2 = int.Parse(Console.ReadLine());
            Console.WriteLine(RicercaNumeroAsync(numero2, listanumeri).Result);

            Console.ReadLine();
        }

        private static async Task<bool> RicercaNumeroAsync(int n, int[] array)
        {
            bool trovato = false;
            await Task.Run(() =>
            {
                for (int c = 0; c < 100; c++)
                {
                    if (n == array[c])
                    {
                        trovato = true;
                    }
                }
            });
            return trovato;
        }

        private static void RiempiArray(ref int[] numeri)
        {
            Random r = new Random();
            for (int c = 0; c < 100; c++)
            {
                numeri[c] = r.Next(0, 100);
            }
        }
    }
    }
}
