using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Insect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bee bee = new Bee("Beetly");

            int counter = 1;
            while (bee.Alive || counter <= 30) //проблема
            {
                Console.WriteLine($"Day: {counter}\n");

                Check(bee);

                bee.CheckAlive();

                counter++;
            }

            Console.WriteLine($"{bee.Name} died... ☠\n");
            bee.ShowInfo();
        }

        public static string Action(Bee bee)
        {
            Console.WriteLine($"1. Feed {bee.Name}\n" +
                    $"2. Find food\n" +
                    $"3. Find honey\n" +
                    $"4. Find out status {bee.Name}\n");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void Check(Bee bee)
        {
            switch (Action(bee))
            {
                case "1":
                    bee.Eat();
                    break;
                case "2":
                    bee.SearchFood();
                    break;
                case "3":
                    bee.SearchHoney();
                    break;
                case "4":
                    bee.ShowInfo();
                    break;
                default:
                    Console.WriteLine("Введите цифру!");
                    Action(bee);
                    break;
            }
        }
    }

    public class Insect
    {
        protected string _name;
        protected int _satiety;

        private int _provisions;
        private bool _alive;

        public string Name => _name;
        public bool Alive => _alive;

        public Insect(string name)
        {
            _name = name;
            _provisions = 10;
            _satiety = 10;
            _alive = true;
        }

        public void CheckAlive()
        {
            if (_provisions <= 0 || _satiety <= 0)
            {
                _alive = false;
            }
        }
       
        public void Eat()
        {
            Console.WriteLine($"\nYour {_name} eated\n" +
                $"Provisions: {_provisions - 1} units of food\n" +
                $"Satiety: {_satiety + 1} units of satiety\n");

            _provisions--;
            _satiety++;
        }

        public void SearchFood()
        {
            Console.WriteLine($"\nYour {_name} found food\n" +
                $"Provisions:{_provisions + 1} units of food\n" +
                $"Satiety: {_satiety - 1} units of satiety\n");

            _provisions++;
            _satiety--;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nСостояние {_name}:\n" +
                $"Provisions: {_provisions} units of food\n" +
                $"Satiety: {_satiety} units of satiety\n");
        }
    }

    public class Bee : Insect
    {
        private int _honey;

        public Bee(string name, int honey = 0) : base(name)
        {
            _honey = honey;
        }

        public void SearchHoney()
        {
            Console.WriteLine($"\nYour {_name} found honey\n" +
                $"Honey: {_honey + 1} units of honey\n" +
                $"Satiety: {_satiety - 1} units of satiety\n");

            _honey++;
            _satiety--;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Honey: {_honey} units of honey");
        }
    }
}
