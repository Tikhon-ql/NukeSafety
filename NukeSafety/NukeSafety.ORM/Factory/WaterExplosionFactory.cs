using NukeSafety.ORM.Models;
using NukeSafety.ORM.Models.Explosions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Factory
{
    public class WaterExplosionFactory : IExplosionFactory
    {
        public Explosion CreateExplosion(Bomb bomb)
        {
            return new WaterExplosion { Bomb = bomb };
        }
    }
}
