using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Models
{
    public class ChemicalElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string HalfLive { get; set; }
    }
}
