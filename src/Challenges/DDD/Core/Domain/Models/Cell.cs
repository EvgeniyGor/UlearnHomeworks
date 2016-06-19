namespace DDD.Core.Domain.Models
{
    public class Cell
    {
        public Cell()
        {
            Digit = 0;
            Revealed = false;
            HasMine = false;
        }

        public int Digit { get; set; }
        public bool Revealed { get; private set; }
        public bool HasMine { get; private set; }

        public bool Empty => Digit == 0 && !HasMine;

        public void SetMine()
        {
            HasMine = true;
        }

        public void Reveal()
        {
            Revealed = true;
        }
    }
}