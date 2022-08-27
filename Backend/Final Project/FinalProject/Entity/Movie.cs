using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Duration { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public bool Popular { get; set; }
    }
}
