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
                usuarios = dao.ListarUsuarios();
            }

            LView.ItemsSource = usuarios;
        }
    }
}
