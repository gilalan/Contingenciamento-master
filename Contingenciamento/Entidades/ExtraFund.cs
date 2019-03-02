namespace Contingenciamento.Entidades
{
    public class ExtraFund
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MonetaryFund MonetaryFund { get; set; }

        public ExtraFund(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public ExtraFund(string name)
        {
            Name = name;
        }

        public ExtraFund()
        {
        }
    }
}