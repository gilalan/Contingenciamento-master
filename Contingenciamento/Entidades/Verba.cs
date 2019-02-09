namespace Contingenciamento.Entidades
{
    public class Verba
    {
        public Verba() { }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Primaria { get; set; }

        public Verba(int id, int codigo, string nome, bool primaria)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Primaria = primaria;
        }

        
    }
}
