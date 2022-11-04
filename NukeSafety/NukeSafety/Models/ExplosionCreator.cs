using NukeSafety.ORM.Factory;
using NukeSafety.ORM.Models;
using NukeSafety.ORM.Models.Explosions;

namespace NukeSafety.Models
{
    public class ExplosionCreator
    {
        private IExplosionFactory _factory;
        public ExplosionCreator()
        {
        }

        public void SetState(IExplosionFactory factory)
        {
            _factory = factory;
        }

        public Explosion CreateExplosion(double blastYield)
        {
            return _factory.CreateExplosion(new ORM.Models.Bomb { BlastYield = blastYield });
        }
        public Explosion CreateExplosion(Bomb bomb)
        {
            return _factory.CreateExplosion(bomb);
        }
    }
}
