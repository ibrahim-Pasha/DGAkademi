using Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
