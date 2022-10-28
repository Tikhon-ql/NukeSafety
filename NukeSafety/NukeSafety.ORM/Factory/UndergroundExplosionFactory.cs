using NukeSafety.ORM.Models;
using NukeSafety.ORM.Models.Explosions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Factory
{
    public class UndergroundExplosionFactory : IExplosionFactory
    {
        public Explosion CreateExplosion(Bomb bomb, double areaOfDamage)
        {
            return new UndergroundExplosion { Bomb = bomb, AreaOfDamage = areaOfDamage };
        }
    }
}
