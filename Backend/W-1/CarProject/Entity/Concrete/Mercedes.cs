using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Mercedes : ICar
    {
        public string Brand { get { return "Mercedes"; } }
        public string Doors { get { return "2"; } }
        public string Engine { get { return "2"; } }
        public string Wheel { get { return "8"; } }

        public string GetMercedesDetiles()
        {
            return "Brand: " + Brand + " , number of doors: " + Doors + " , number of Engine: " + Engine + "number of Wheel: " + Wheel;
        }
    }
}
