using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeProj
{
    public class Insect
    {
        private string _name;
        private int _food;

        protected Dictionary<int, Actions> ActionMap = new Dictionary<int, Actions>();
        protected int Hungry;

        protected delegate void Actions();

        public bool IsAlive => Hungry > 0;
        public string Name => _name;

        public Insect(string name, int hungry, int food)
        {
            _name = name;
            Hungry = hungry;
            _food = food;

            // Actions findFood = FindFood;
            // Actions tryEat = TryEat;
            // ActionMap.Add(ActionMap.Keys.Count + 1, findFood);
            // ActionMap.Add(ActionMap.Keys.Count + 1, tryEat);

            ActionMap.Add(ActionMap.Keys.Count + 1, FindFood);
            ActionMap.Add(ActionMap.Keys.Count + 1, TryEat);
        }

        private void TryEat()
        {
            if (_food <= 0)
            {
                Console.WriteLine("Нет еды.");
                return;
            }

            Hungry++;
            _food--;
            Console.WriteLine($"{_name} поел");

            return;
        }

        private void FindFood()
        {
            Hungry--;
            _food++;

            Console.WriteLine($"{_name} отправился на поиск еды");
        }

        public void ChooseRandomAction()
        {
            Random random = new Random();
            int actionNumber = random.Next(1, ActionMap.Keys.Count + 1);

            ActionMap[actionNumber]();
            ShowInfo();

            Program.Continue();
        }

        protected virtual void ShowInfo()
        {
            Console.WriteLine($"Насекомое: {_name}\nЧувство сытости: {Hungry}\nКоличество еды: {_food}");
        }
    }
}
