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

    class ContingencyPastComparer : IEqualityComparer<ContingencyPast>
    {
        public bool Equals(ContingencyPast x, ContingencyPast y)
        {
            if (x == null || y == null || x.GetType() != y.GetType() || x.EmployeeHistory == null || y.EmployeeHistory == null)
                return false;

            return x.EmployeeHistory.Id == y.EmployeeHistory.Id;
        }

        public int GetHashCode(ContingencyPast obj)
        {
            // Don't compute hash code on null object.
            if (obj == null || obj.EmployeeHistory == null)
            {
                return 0;
            }
            else
            {
                return obj.EmployeeHistory.Id.GetHashCode();
            }
        }
    }
}
