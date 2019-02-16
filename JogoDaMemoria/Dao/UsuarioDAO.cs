using System;
using System.Collections.Generic;
using JogoDaMemoria.Model;
using SQLite;

namespace JogoDaMemoria.Dao
{
    public class UsuarioDAO
    {
        readonly SQLiteConnection conexao;

        public UsuarioDAO(SQLiteConnection connection)
        {
            conexao = connection;
            conexao.CreateTable<Usuario>(); // Table criada apenas se não exisite (default)
        }

        public void SalvarUsuario(Usuario user)
        {
            conexao.Insert(user);
        }

        public List<Usuario> ListarUsuarios()
        {
            return conexao.Table<Usuario>().ToList();
        }
    }
}
