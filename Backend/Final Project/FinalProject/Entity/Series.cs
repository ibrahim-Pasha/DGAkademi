using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Series : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public int Pisodes { get; set; }
        public bool Popular { get; set; }
    }
}
