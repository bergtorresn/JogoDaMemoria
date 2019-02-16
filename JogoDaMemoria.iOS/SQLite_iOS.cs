using System;
using System.IO;
using JogoDaMemoria.Helpers;
using JogoDaMemoria.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace JogoDaMemoria.iOS
{
    public class SQLite_iOS : ISQLite
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
