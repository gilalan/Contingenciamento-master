namespace Contingenciamento.Entidades
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Department(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}