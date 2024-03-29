﻿using System;
using JogoDaMemoria.Dao;
using JogoDaMemoria.Helpers;
using JogoDaMemoria.Model;
using Xamarin.Forms;

namespace JogoDaMemoria.Views
{
    public partial class Formulario : ContentPage
    {
        Cronometro cronometro;
        string tempoFormatado;

        public Formulario(Cronometro c)
        {
            InitializeComponent();

            EntryNome.TextChanged += (sender, e) =>
            {
                string _text = EntryNome.Text;
                if (_text.Length > 6)
                {
                    _text = _text.Remove(_text.Length - 1);
                    EntryNome.Text = _text;
                }
            };

            cronometro = c;
            tempoFormatado = string.Format("{0}:{1:00}:{2:000}", c.mins, c.segs, c.milesegs);
            LabelTempo.Text = tempoFormatado;
        }

        void SalvarDadosNoBanco()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                UsuarioDAO dao = new UsuarioDAO(conexao);
                dao.SalvarUsuario(new Usuario
                {
                    Nome = EntryNome.Text,
                    Minutos = cronometro.mins,
                    Segundos = cronometro.segs,
                    Milissegundos = cronometro.milesegs,
                    Tempo = tempoFormatado,
                });
            }
        }

        void ButtonEnviar_Clicked(object sender, EventArgs e)
        {
            if ((EntryNome != null) && (EntryNome.Text != ""))
            {
                SalvarDadosNoBanco();
                Navigation.PushAsync(new Ranking());
            }
            else
            {
                DisplayAlert("Atenção", "Informe o seu nome", "Ok");
            }
        }

        void ButtonTentarNovamente_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
