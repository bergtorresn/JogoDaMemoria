using SQLite;

namespace JogoDaMemoria.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Tempo { get; set; }
    }
}
