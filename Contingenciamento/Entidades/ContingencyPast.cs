using System.Collections.Generic;

namespace Contingenciamento.Entidades
{
    public class ContingencyPast
    {
        public long Id { get; set; }
        public EmployeeHistory EmployeeHistory { get; set; }
        public string MonetaryFundName { get; set; }
        public List<ContingencyAliquot> ContingencyAliquots { get; set; }

        public ContingencyPast(long id, EmployeeHistory employeeHistory, string monetaryFundName, List<ContingencyAliquot> contingencyAliquots)
        {
            Id = id;
            EmployeeHistory = employeeHistory;
            MonetaryFundName = monetaryFundName;
            ContingencyAliquots = contingencyAliquots;
        }

        public ContingencyPast()
        {
            ContingencyAliquots = new List<ContingencyAliquot>();
        }
    }
}
