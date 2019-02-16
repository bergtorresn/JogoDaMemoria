using SQLite;

namespace JogoDaMemoria.Model
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tempo { get; set; }
        public int Segundos { get; set; }
        public int Minutos { get; set; }
        public int Milissegundos { get; set; }

    }
}
