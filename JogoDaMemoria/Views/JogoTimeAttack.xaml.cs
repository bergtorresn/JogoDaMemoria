using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JogoDaMemoria.Helpers;
using Xamarin.Forms;

namespace JogoDaMemoria.Views {
    public partial class JogoTimeAttack : ContentPage {

        // Properties

        List<Button> BtnsAtras;
        List<Button> BtnsFrente;
        List<int> NumeroDeOpcoes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<Color> BackgroundColors = new List<Color> { Color.Red, Color.Blue, Color.Brown, Color.Fuchsia, Color.Yellow };
        Dictionary<string, List<Button>> Jogadas = new Dictionary<string, List<Button>>();
        public int ContadorDeJogadas = 1;

        // Lifecycle

        protected override void OnAppearing() {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "IncrementarContadorDeJogadas", (incrementar) => {
                ContadorDeJogadas += 1;
            });
            MessagingCenter.Subscribe<string>(this, "UsuarioEncontrouTodas", (fim) => {
                ContadorDeJogadas += 1;
            });
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "IncrementarContadorDeJogadas");
            MessagingCenter.Unsubscribe<string>(this, "UsuarioEncontrouTodas");
        }

        public JogoTimeAttack() {
            InitializeComponent();
            PreparandoJogo();
        }

        // Methods

        void PreparandoJogo() {
            BtnsAtras = new List<Button> { Btn1Atras, Btn2Atras, Btn3Atras, Btn4Atras, Btn5Atras, Btn6Atras, Btn7Atras, Btn8Atras, Btn9Atras, Btn10Atras };
            BtnsFrente = new List<Button> { Btn1Frente, Btn2Frente, Btn3Frente, Btn4Frente, Btn5Frente, Btn6Frente, Btn7Frente, Btn8Frente, Btn9Frente, Btn10Frente };

            foreach (Color Cor in BackgroundColors) {
                randomPrimeiroFundo(Cor);
                randomSegundoFundo(Cor);
            }
        }

        void randomPrimeiroFundo(Color Cor) {

            Random random = new Random();
            int numeroRandom = random.Next(0, NumeroDeOpcoes.Count);
            int opcao = NumeroDeOpcoes[numeroRandom];

            Button Btn = BtnsAtras[opcao];
            Btn.BackgroundColor = Cor;

            NumeroDeOpcoes.Remove(opcao);
        }

        void randomSegundoFundo(Color Cor) {

            Random random = new Random();
            int numeroRandom = random.Next(0, NumeroDeOpcoes.Count);
            int opcao = NumeroDeOpcoes[numeroRandom];

            Button Btn = BtnsAtras[opcao];
            Btn.BackgroundColor = Cor;

            NumeroDeOpcoes.Remove(opcao);
        }

        async Task JogadaDoUsuario(Button BtnFrente, Button BtnAtras) {
            LogicaDoJogo Jogo = new LogicaDoJogo();

            if (!BtnAtras.IsVisible) {
                await Jogo.Logica(BtnFrente, BtnAtras, ContadorDeJogadas, Jogadas);
            }
        }

        // Button Actions

        async void Button1_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn1Frente, Btn1Atras);
        }
        async void Button2_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn2Frente, Btn2Atras);
        }
        async void Button3_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn3Frente, Btn3Atras);
        }
        async void Button4_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn4Frente, Btn4Atras);
        }
        async void Button5_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn5Frente, Btn5Atras);
        }
        async void Button6_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn6Frente, Btn6Atras);
        }
        async void Button7_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn7Frente, Btn7Atras);
        }
        async void Button8_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn8Frente, Btn8Atras);
        }
        async void Button9_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn9Frente, Btn9Atras);
        }
        async void Button10_Clicked(object sender, EventArgs e) {
            await JogadaDoUsuario(Btn10Frente, Btn10Atras);
        }

        void Cancelar_Clicked(object sender, EventArgs e) {
            Navigation.PopToRootAsync();
        }
    }
}
