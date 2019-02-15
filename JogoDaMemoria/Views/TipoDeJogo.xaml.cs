using System;

using Xamarin.Forms;

namespace JogoDaMemoria.Views {
    public partial class TipoDeJogo : ContentPage {

        bool isTradicional { get; set; }

        public TipoDeJogo() {
            InitializeComponent();
        }

        void Iniciar_Clicked(object sender, EventArgs e) {
            if (isTradicional) {
                Navigation.PushAsync(new JogoNormal());
            } else {
                Navigation.PushAsync(new JogoTimeAttack());
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
    }
}
