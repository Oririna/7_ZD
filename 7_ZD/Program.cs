using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_ZD
{
    class Program
    {
        // Проверка, есть ли еще возможные комбинации
        static public bool other_options(ushort[] Comb, ushort MaxValue)
        {
            bool ok = true; // Логический флаг
            int n = 0; // Вспомогательная переменная для прохода по массиву
            while (ok && n < Comb.Length)
                if (Comb[n] == MaxValue - Comb.Length + ++n)
                    ok = true;
                else
                    ok = false;

            return !ok;
        }

        // Генерация следующей комбинации
        static public void MakeNextCombination(ushort[] comb, ushort Max)
        {          
            int i = comb.Length - 1; // Вспомогательная переменная для прохода по массиву
            while (comb[i] == Max - comb.Length + 1 + i)
                i--;
            comb[i]++;
            for (i = i + 1; i < comb.Length; i++)
                comb[i] = (ushort)(comb[i - 1] + 1);
        }

        // Печать найденной комбинации
        static public void print_comb(ushort[] Comb)
        {
            for (ushort i = 0; i < Comb.Length; i++)
                Console.Write("{0} ", Comb[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ushort N;// Количество элементов
            
            ushort K; // Длина сочетаний
            
            bool ok;// Флаг правильности ввода

            // Ввод количества элементов
            do
            {
                Console.WriteLine("Введите количество элементов для сочетаний:");
                ok = UInt16.TryParse(Console.ReadLine(), out N) && N > 0;
                if (!ok)
                    Console.WriteLine("Требуется ввести натуральное число.");
            } while (!ok);

            // Ввод длины сочетаний
            do
            {
                Console.WriteLine("Введите длину сочетаний - от 1 до {0}:", N);
                ok = UInt16.TryParse(Console.ReadLine(), out K) && K > 0 && K <= N;
                if (!ok)
                    Console.WriteLine("Требуется ввести натуральное число от 1 до {0}.", N);
            } while (!ok);

            
            ushort Max = (ushort)(N-1); // Максимальный возможный элемент           
            ushort[] Combination = new ushort[K]; // Массив для представления сочетания
            for (ushort i = 0; i < K; i++)
                Combination[i] = i;
            Console.WriteLine("Возможные сочетания без повторений:");
            print_comb(Combination);
            while (other_options(Combination, Max))
            {
                MakeNextCombination(Combination, Max);
                print_comb(Combination);
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}