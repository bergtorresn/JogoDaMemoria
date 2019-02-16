using System;

using Xamarin.Forms;

namespace JogoDaMemoria.Views
{
    public partial class TipoDeJogo : ContentPage
    {

        bool IsTradicional { get; set; }
        bool IsDesenho { get; set; }
        bool TipoSeleconado { get; set; }
        bool TemaSelecionado { get; set; }

        public TipoDeJogo()
        {
            InitializeComponent();
        }

        void Iniciar_Clicked(object sender, EventArgs e)
        {
            if (TipoSeleconado && TemaSelecionado)
            {
                if (IsTradicional)
                {
                    Navigation.PushAsync(new JogoNormal(IsDesenho));
                }
                else
                {
                    //   Navigation.PushAsync(new JogoTimeAttack(isDesenho));
                }
            }
            else
            {
                DisplayAlert("Atenção", "Selecione o tipo de jogo e o tema", "Ok");
            }

        }

        void Tradicional_Clicked(object sender, EventArgs e)
        {
            IsTradicional = true;
            TipoSeleconado = true;
            BtnTradicional.BackgroundColor = Color.Black;
            BtnTimeAttack.BackgroundColor = Color.Teal;
        }
        void TimeAttack_Clicked(object sender, EventArgs e)
        {
            IsTradicional = false;
            TipoSeleconado = true;
            BtnTradicional.BackgroundColor = Color.Teal;
            BtnTimeAttack.BackgroundColor = Color.Black;
        }
        void Desenhos_Clicked(object sender, EventArgs e)
        {
            IsDesenho = true;
            TemaSelecionado = true;
            BtnDesenhos.BackgroundColor = Color.Black;
            BtnGames.BackgroundColor = Color.Teal;
        }
        void Games_Clicked(object sender, EventArgs e)
        {
            IsDesenho = false;
            TemaSelecionado = true;
            BtnDesenhos.BackgroundColor = Color.Teal;
            BtnGames.BackgroundColor = Color.Black;
        }
    }
}
