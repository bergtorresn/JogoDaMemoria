using System;
using System.IO;
using JogoDaMemoria.Droid;
using JogoDaMemoria.Helpers;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace JogoDaMemoria.Droid
{
    public class SQLite_Android : ISQLite
    {
        const string nomeDoAquivoDB = "Memodex.db3";

        public SQLiteConnection PegarConexao()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, nomeDoAquivoDB);
            return new SQLiteConnection(path);
        }
    }
}
