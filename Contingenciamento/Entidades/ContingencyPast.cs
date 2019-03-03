
namespace Contingenciamento.Entidades
{
    public class ContingencyPast
    {
        public long Id { get; set; }
        public long EmployeeHistoryId { get; set; }
        public string MonetaryFundName { get; set; }
        public string ContingencyFundName { get; set; }
        public double Aliquot { get; set; }
        public double CalculatedValue { get; set; }

        public ContingencyPast(long id, long employeeHistoryId, string monetaryFundName, string contingencyFundName, double aliquot, double calculatedValue)
        {
            Id = id;
            EmployeeHistoryId = employeeHistoryId;
            MonetaryFundName = monetaryFundName;
            ContingencyFundName = contingencyFundName;
            Aliquot = aliquot;
            CalculatedValue = calculatedValue;
        }

        public ContingencyPast()
        {

        }
    }
}
