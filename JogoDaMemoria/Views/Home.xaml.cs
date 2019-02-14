using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoDaMemoria.Views {
    public partial class Home : ContentPage {

        List<Button> BtnsAtras;
        List<int> NumeroDeOpcoes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<Color> BackgtoundColors = new List<Color> { Color.Red, Color.Blue, Color.Brown, Color.Fuchsia, Color.Yellow };

        Dictionary<string, List<Button>> Jogadas = new Dictionary<string, List<Button>>();
        int ContadorDeAcertos = 1;

        public Home() {
            InitializeComponent();

            BtnsAtras = new List<Button>() { Btn1Atras, Btn2Atras, Btn3Atras, Btn4Atras, Btn5Atras, Btn6Atras, Btn7Atras, Btn8Atras, Btn9Atras, Btn10Atras };

            foreach (Color Cor in BackgtoundColors) {

                randomPrimeiroFundo(Cor);
                randomSegundoFundo(Cor);

            }
        }

        // Methods

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

        async Task RotateButton(Button Frente, Button Atras) {
            uint timeout = 500;

            var BtnFrente = Frente;
            var BtnAtras = Atras;

            if (!BtnAtras.IsVisible) {

                //Rotação do Botão

                BtnAtras.RotationY = -270;
                await BtnFrente.RotateYTo(-90, timeout, Easing.SpringIn);

                BtnFrente.IsVisible = false;
                BtnAtras.IsVisible = true;

                await BtnAtras.RotateYTo(-360, timeout, Easing.SpringOut);
                BtnAtras.RotationY = 0;

                // Lógica

                await Logica(timeout, BtnFrente, BtnAtras);
            }

            /* if (BtnAtras.IsVisible) {

                 BtnFrente.RotationY = -270;
                 await BtnAtras.RotateYTo(-90, timeout, Easing.SpringIn);

                 BtnAtras.IsVisible = false;
                 BtnFrente.IsVisible = true;

                 await BtnFrente.RotateYTo(-360, timeout, Easing.SpringOut);
                 BtnFrente.RotationY = 0;

             } else {

                 BtnAtras.RotationY = -270;
                 await BtnFrente.RotateYTo(-90, timeout, Easing.SpringIn);

                 BtnFrente.IsVisible = false;
                 BtnAtras.IsVisible = true;

                 await BtnAtras.RotateYTo(-360, timeout, Easing.SpringOut);
                 BtnAtras.RotationY = 0;
             }*/
        }

        async Task Logica(uint timeout, Button BtnFrente, Button BtnAtras) {

            if (!Jogadas.ContainsKey("jogada" + ContadorDeAcertos)) {
                List<Button> Buttons = new List<Button> { BtnFrente, BtnAtras };
                Jogadas.Add("jogada" + ContadorDeAcertos, Buttons);
            } else {

                var UltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeAcertos];
                var CorDaUltimaJogada = UltimaJogadaDoUsuario[1].BackgroundColor;

                if (CorDaUltimaJogada.Equals(BtnAtras.BackgroundColor)) {
                    UltimaJogadaDoUsuario.Add(BtnFrente);
                    UltimaJogadaDoUsuario.Add(BtnAtras);
                    ContadorDeAcertos += 1;
                } else {
                    BtnFrente.RotationY = -270;
                    await BtnAtras.RotateYTo(-90, timeout, Easing.SpringIn);

                    BtnAtras.IsVisible = false;
                    BtnFrente.IsVisible = true;

                    await BtnFrente.RotateYTo(-360, timeout, Easing.SpringOut);
                    BtnFrente.RotationY = 0;
                    //
                    UltimaJogadaDoUsuario[0].RotationY = -270;
                    await UltimaJogadaDoUsuario[1].RotateYTo(-90, timeout, Easing.SpringIn);

                    UltimaJogadaDoUsuario[1].IsVisible = false;
                    UltimaJogadaDoUsuario[0].IsVisible = true;

                    await UltimaJogadaDoUsuario[0].RotateYTo(-360, timeout, Easing.SpringOut);
                    UltimaJogadaDoUsuario[0].RotationY = 0;

                    Jogadas.Remove("jogada" + ContadorDeAcertos);
                }
            }
        }

        // Button Actions

        async void Button1_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn1Frente, Btn1Atras);
        }
        async void Button2_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn2Frente, Btn2Atras);
        }
        async void Button3_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn3Frente, Btn3Atras);
        }
        async void Button4_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn4Frente, Btn4Atras);
        }
        async void Button5_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn5Frente, Btn5Atras);
        }
        async void Button6_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn6Frente, Btn6Atras);
        }
        async void Button7_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn7Frente, Btn7Atras);
        }
        async void Button8_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn8Frente, Btn8Atras);
        }
        async void Button9_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn9Frente, Btn9Atras);
        }
        async void Button10_Clicked(object sender, EventArgs e) {
            await RotateButton(Btn10Frente, Btn10Atras);
        }
    }
}
