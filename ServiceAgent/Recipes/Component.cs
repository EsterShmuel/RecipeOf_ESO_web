using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAgent.Recipes
{
    public class ListComponent
    {
        public List<Component> ingredients { get; set; }
    }

    public class Component
    {
        public string Name { get; set; }
        public Amount Amount { get; set; }
    }


    public class Amount
    {
        public Metric Metric { get; set; }
    }

    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }



}
