using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transformers_V2.Models
{
    public class Manufacture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Transformer> transformers { get; set; }
        public Manufacture()
        {
            transformers = new List<Transformer>();        }
    }
}
