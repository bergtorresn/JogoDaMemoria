using System;
using SQLite;

namespace JogoDaMemoria.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
