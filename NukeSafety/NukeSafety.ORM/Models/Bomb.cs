namespace NukeSafety.ORM.Models
{
    public class Bomb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BlastYield { get; set; }
        public string ImagePath { get; set; }
        public virtual List<Country> OnArms { get; set; } = new();
        public virtual ChemicalElement Filling { get; set; }
    }
}
