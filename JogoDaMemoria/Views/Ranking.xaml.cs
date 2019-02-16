using System;
using System.Collections.Generic;
using JogoDaMemoria.Dao;
using JogoDaMemoria.Helpers;
using JogoDaMemoria.Model;
using Xamarin.Forms;

namespace JogoDaMemoria.Views
{
    public partial class Ranking : ContentPage
    {

        List<Usuario> usuarios;

        public Ranking()
        {
            InitializeComponent();


            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                UsuarioDAO dao = new UsuarioDAO(conexao);
                dao.SalvarUsuario(new Usuario { Nome = "Teste1", Tempo = 1000 });
                dao.SalvarUsuario(new Usuario { Nome = "Teste2", Tempo = 1030 });

                usuarios = dao.ListarUsuarios();
            }
        }
    }
}
