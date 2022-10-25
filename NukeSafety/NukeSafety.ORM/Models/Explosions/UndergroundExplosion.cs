using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Models.Explosions
{
    public class UndergroundExplosion : Explosion
    {
        public override double GetRadius()
        {
            throw new NotImplementedException();
        }
    }
}
