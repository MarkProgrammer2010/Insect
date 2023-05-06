using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeProj
{
    public class Bee : Insect
    {
        private int _honey;

        public Bee(string name, int hungry, int food) : base(name, hungry, food)
        {
            _honey = 10;

            // Actions collectHoney = CollectHoney;
            // ActionMap.Add(ActionMap.Keys.Count + 1, collectHoney);

            ActionMap.Add(ActionMap.Keys.Count + 1, CollectHoney);
        }

        private void CollectHoney()
        {
            _honey++;
            Hungry--;

            Console.WriteLine($"{Name} отправился собирать мёд");
        }

        protected override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Количество меда: {_honey}");
        }
    }
}
