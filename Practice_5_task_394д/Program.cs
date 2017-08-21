using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5_task_394д
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Поиск строк-полиндромов");
            Console.WriteLine();
            do
            {
                int n;//размерность матрицы
                bool ok;// переменная для проверки
                do//ввод n с проверкой
                {
                    Console.Write("Введите целое положительное число n, размерность матрицы: ");
                    ok = int.TryParse(Console.ReadLine(), out n);
                    if ((!ok) || (n <= 0)) Console.WriteLine("Неверный ввод!");
                    if ((ok) && (n <= 0)) ok = false;
                } while (!ok);// конец ввода n с проверкой

                int[,] mas = new int[n, n];//исходная матрица

                Console.WriteLine("Введите " + n + " строк по " + n + " целочисленных элементов в каждой, разделенных пробелами:");
                for (int i=0; i<n; i++)//ввод матрицы с проверкой
                {
                    Console.WriteLine("Введите " + (i+1) + " строку:");
                    do//ввод строки с проверкой
                    {
                        string[] s = Console.ReadLine().Split();//считываем строку в массив из строк
                        if (s.Length < n)//если в введеной строке элементов меньше, чем n
                        {
                            Console.WriteLine("Вы ввели слишком мало элементов, их должно быть " + n + "! Введите строку заново:");
                            ok = false;
                        }
                        else
                        {
                            for (int j = 0; j < n; j++)
                            {
                                ok = int.TryParse(s[j], out mas[i, j]);
                                if (!ok)//если в строке есть не целые числа или строки
                                {
                                    Console.WriteLine("Неверный ввод! Введите строку заново:");
                                    break;
                                }
                            }
                        }
                    } while (!ok);//конец ввода строки с проверкой
                }//конец ввода матрицы с проверкой

                Console.WriteLine();
                Console.WriteLine("МАТРИЦА:");
                for (int i = 0; i < n; i++)//вывод матрицы на экран
                {
                    for (int j = 0; j < n; j++)
                        Console.Write(mas[i, j] + " ");
                    Console.WriteLine();
                }

                Console.Write("ОТВЕТ: ");
                bool okey=false;//переменная для проверки, существует ли строка-полиндром в данной матрице. Предполагаем, что ее нет
                for (int i=0; i<n; i++)//Перебираем строки, ищем полиндромы
                {
                    ok = true;//предполагаем, что данная строка - полиндром
                    for (int j=0; j<n/2; j++)
                    {
                        if (mas[i, j] != mas[i, n - j - 1]) ok = false;//если хоть один элемент не совпал, то строка не полиндром
                    }
                    if (ok)//если строка полиндром
                    {
                        Console.Write((i + 1) + " ");//выводим ее номер
                        okey = true;//полиндромы есть
                    }
                }
                if (!okey) Console.WriteLine("В данной матрице нет строк-полиндромов");
                Console.WriteLine();
                Console.ReadLine();
            } while (true);
        }
    }
}
