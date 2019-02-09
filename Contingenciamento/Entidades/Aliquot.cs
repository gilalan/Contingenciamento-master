using System;

namespace Contingenciamento.Entidades
{
    public class Aliquot
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime StartValidity { get; set; }
        public DateTime EndValidity { get; set; }

        public Aliquot(int id, double value, DateTime startValidity, DateTime endValidity)
        {
            Id = id;
            Value = value;
            StartValidity = startValidity;
            EndValidity = endValidity;
        }
    }
}