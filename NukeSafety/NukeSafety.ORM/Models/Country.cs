using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Bomb> Bombs { get; set; } = new();
    }
}
