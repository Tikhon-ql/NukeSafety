using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeSafety.ORM.Models.Explosions
{
    public abstract class Explosion
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual Bomb Bomb { get; set; }
        //[Required]
        //public double AreaOfDamage { get; set; }
        public abstract double GetRadius();
    }
}
