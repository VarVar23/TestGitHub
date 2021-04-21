using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transformers_V2.Models
{
    public class Transformer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
    }
}
