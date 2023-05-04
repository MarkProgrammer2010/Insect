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
            Bee _bee = new Bee("Beetly");

            int counter = 1;
            while (_bee.Alive || counter <= 30)
            {
                Console.WriteLine($"Day:{counter}\n");

                Check(_bee);

                _bee.CheckAlive();
            }

            Console.WriteLine($"{_bee.Name} died... ☠\n");
            _bee.ShowInfo();
        }

        public static string Action(Bee _bee)
        {
            Console.WriteLine($"1. Feed {_bee.Name}\n" +
                    $"2. Find food\n" +
                    $"3. Find honey\n" +
                    $"4. Find out status {_bee.Name}\n");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void Check(Bee _bee)
        {
            switch (Action(_bee))
            {
                case "1":
                    _bee.Eat();
                    break;
                case "2":
                    _bee.SearchFood();
                    break;
                case "3":
                    _bee.SearchHoney();
                    break;
                case "4":
                    _bee.ShowInfo();
                    break;
                default:
                    Console.WriteLine("Введите цифру!");
                    Action(_bee);
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

        public Insect(string name, int provisions = 10, int satiety = 10)
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
            Console.WriteLine($"Your {_name} eated\n" +
                $"Provisions {_provisions - 1} units еды\n" +
                $"Satiety:  {_satiety + 1}  units of satiety\n");

            _provisions--;
            _satiety++;
        }

        public void SearchFood()
        {
            Console.WriteLine($"Your {_name} found food\n" +
                $"Provisions:{_provisions + 1} units of food\n" +
                $"Satiety: {_satiety - 1} units of satiety\n");

            _provisions++;
            _satiety--;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Состояние {_name}:\n" +
                $"Provisions: {_provisions} units of food\n" +
                $"Satiety: {_satiety} units of satiety\n");
        }
    }

    public class Bee : Insect
    {
        private int _honey;

        public Bee(string name, int provisions = 10, int satiety = 10, int honey = 0) : base(name, provisions, satiety)
        {
            _honey = honey;
        }

        public void SearchHoney()
        {
            Console.WriteLine($"Your {_name} found honey\n" +
                $"Honey:{_honey + 1} units of honey\n" +
                $"Satiety:  {_satiety - 1}  units of satiety\n");

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
