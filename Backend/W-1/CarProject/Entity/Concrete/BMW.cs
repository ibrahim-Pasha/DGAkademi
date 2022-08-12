using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BMW : ICar
    {
        public string Brand { get { return "BMW"; } }
        public string Doors { get { return "2"; } }
        public string Engine { get { return "2"; } }
        public string Wheel { get { return "6"; } }

      public string GetBmwDetiles()
        {
            return "Brand: "+ Brand+ " , number of doors: "+Doors+ " , number of Engine: "+Engine+ " , number of Wheel: "+ Wheel;
        }
    }
}
