using System;

using Xamarin.Forms;

namespace JogoDaMemoria.Views {
    public partial class TipoDeJogo : ContentPage {

        bool isTradicional { get; set; }
        bool isDesenho { get; set; }

        public TipoDeJogo() {
            InitializeComponent();
        }

        void Iniciar_Clicked(object sender, EventArgs e) {
            if (isTradicional) {
                Navigation.PushAsync(new JogoNormal(isDesenho));
            } else {
                Navigation.PushAsync(new JogoTimeAttack(isDesenho));
            }
        }

        void Tradicional_Clicked(object sender, EventArgs e) {
            isTradicional = true;
            BtnTradicional.BackgroundColor = Color.Black;
            BtnTimeAttack.BackgroundColor = Color.Teal;
        }
        void TimeAttack_Clicked(object sender, EventArgs e) {
            isTradicional = false;
            BtnTradicional.BackgroundColor = Color.Teal;
            BtnTimeAttack.BackgroundColor = Color.Black;
        }
        void Desenhos_Clicked(object sender, EventArgs e)
        {
            isDesenho = true;
            BtnDesenhos.BackgroundColor = Color.Black;
            BtnGames.BackgroundColor = Color.Teal;
        }
        void Games_Clicked(object sender, EventArgs e)
        {
            isDesenho = false;
            BtnDesenhos.BackgroundColor = Color.Teal;
            BtnGames.BackgroundColor = Color.Black;
        }
    }
}
