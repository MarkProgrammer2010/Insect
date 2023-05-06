using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeProj
{
    internal class Ant : Insect
    {
        private int _brunches;

        public Ant(string name, int hungry, int food) : base(name, hungry, food)
        {
            _brunches = 10;

            // Actions collectBrunches = CollectBrunches;
            // ActionMap.Add(ActionMap.Keys.Count + 1, collectBrunches);

            ActionMap.Add(ActionMap.Keys.Count + 1, CollectBrunches);
        }

        private void CollectBrunches()
        {
            _brunches++;
            Hungry--;
            Console.WriteLine($"{Name} отправился собирать веточки");
        }

        protected override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Количество веток: {_brunches}");
        }
    }
}
