﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            NavigationPage.SetHasBackButton(this, false);

            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                UsuarioDAO dao = new UsuarioDAO(conexao);
                usuarios = dao.ListarUsuarios();
            }

            var sorted = from usr in usuarios
                         orderby usr.Minutos ascending, usr.Segundos ascending, usr.Milissegundos descending
                         select usr;

            LView.ItemsSource = sorted;
        }

        void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
