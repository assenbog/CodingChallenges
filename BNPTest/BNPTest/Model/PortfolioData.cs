namespace BNPTest.Model
{
    public class PortfolioData
    {
        public Tenor Duration { get; set; }

        public int PortfolioId { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return $"{Duration},{PortfolioId.ToString()},{Value.ToString()}";
        }
    }
}
