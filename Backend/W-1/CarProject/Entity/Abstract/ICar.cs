using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICar
    {
        public string Brand { get; }
        public string Doors { get; }
        public string Engine { get; }
        public string Wheel { get; }

        string GetBrand()
        {
            return this.Brand;
        }
    }
}
