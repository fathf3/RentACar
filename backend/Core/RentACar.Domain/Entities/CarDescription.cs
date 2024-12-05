using RentACar.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities
{
    public class CarDescription : BaseEntity
    {
        public string Details { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
