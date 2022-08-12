
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Audi : ICar
    {

        public string Brand { get { return "Audi"; } }
        public string Doors { get { return "5"; } }
        public string Engine { get { return "1"; } }
        public string Wheel { get { return "4"; } }

        public string GetAudiDetiles()
        {
            return "Brand: " + Brand + " , number of doors: " + Doors + " , number of Engine: " + Engine + " , number of Wheel: " + Wheel;
        }
    }
}
