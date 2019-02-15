using System;
using Xamarin.Forms;

namespace JogoDaMemoria.Views {
    public partial class Home : ContentPage {

        void NovoJogo_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new TipoDeJogo());
        }

        void Ranking_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new Ranking());
        }
    }
}
