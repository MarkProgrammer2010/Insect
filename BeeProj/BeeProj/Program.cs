using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeProj
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bee bee = new Bee("Пчёлка", 10, 10);
            Ant ant = new Ant("Муравей", 10, 10);

            // LifeImitation(30, bee);
            // LifeImitation(7, ant);
        }

        public static void LifeImitation(int daysCount, Insect insect)
        {
            for (int i = 1; i <= daysCount; i++)
            {
                Console.WriteLine($"Начало {i}-го дня\n");

                insect.ChooseRandomAction();

                if (insect.IsAlive == false)
                {
                    Console.WriteLine($"{insect.Name} помер с голоду");
                    break;
                }
            }

            Console.WriteLine("Имитация жизненного цикла закончилась");
        }

        public static void Continue()
        {
            Console.WriteLine("Нажмите Enter для продолжения");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
